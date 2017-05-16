using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace kärnan
{
    public partial class adminUnit : System.Web.UI.Page
    {
        Unit unit = new Unit();
        SQL sql = new SQL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Visa namnen på enhet i dropdownlist
                sql.conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT unitname, unitid FROM unit ORDER BY unitid", sql.conn);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();
                DropDownList2.DataSource = dt;
                DropDownList2.DataBind();

                //Håller koll på vem det är som är inloggad  
                if (Session["employeeid"] != null)
                {
                }

                showAllUnit();

            }
        }
        //Lägg till enhet
        protected void btnAddUnit_Click(object sender, EventArgs e)
        {
            if (txbAddUnit.Text == string.Empty)
            {
                lblUnitMessage.Text = "Du måste skriva ett namn på enheten";
            }
            else
            {
                //Deklarerar info från textboxen
                unit.unitname = txbAddUnit.Text;
                string name = unit.unitname.ToString();

                unit.saveUnit(name);
                lblUnitMessage.Text = "Ny enhet är sparad";

                DropDownList1.Items.Clear();
                DropDownList2.Items.Clear();
                lsbAllUnit.Items.Clear();
                fillList();
            }
        }

        //Visa info i textboxrar om familj när namnet markeras i listboxen
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sql.conn.Open();

                string query = "SELECT unitid, unitname " +
                               "FROM unit " +
                               "WHERE unitid = " + DropDownList1.SelectedItem.Value;

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Parameters.AddWithValue("unitid", DropDownList1.SelectedItem.Value);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Connection = sql.conn;

                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txbChangeUnit.Text = dr["unitname"].ToString();     
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.conn.Close();
                sql.conn.Dispose();
            }
        }

        //Ändra namn på enhet
        protected void btnChangeUnit_Click(object sender, EventArgs e)
        {
            //Deklarerar info
            unit.unitname = DropDownList1.SelectedItem.Value;
            int unitid = Convert.ToInt32(unit.unitname);
            unit.unitname = txbChangeUnit.Text;
            string name = unit.unitname.ToString();

            unit.updateUnit(unitid, name);
            lblCorrectMessage.Text = "Namnet på enheten är ändrad!";

            DropDownList1.Items.Clear();
            DropDownList2.Items.Clear();
            lsbAllUnit.Items.Clear();
            txbChangeUnit.Text = string.Empty;
            fillList();
        }

        //Radera enhet
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Vill du radera enhet? Raderad enhet går inte att få tillbaka", "Radera enhet", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                 unit.unitname = DropDownList2.SelectedItem.Value;
                 int unitid = Convert.ToInt32(unit.unitname);

                 unit.removeUnit(unitid);
                 DropDownList1.Items.Clear();
                 DropDownList2.Items.Clear();
                lsbAllUnit.Items.Clear();

                lblRemoveUnit.Text = "Enheten är raderad";           
             
               fillList();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
              
        public void showAllUnit()
        {
            //Visa information (Unitname)
            List<Unit> listUnit = unit.showUnit();
            lsbAllUnit.DataSource = listUnit;
            lsbAllUnit.DataTextField = "unitname";
            lsbAllUnit.DataValueField = "unitid";
            lsbAllUnit.Items.Add("unitName");
            lsbAllUnit.DataBind();
        }

        //Metod för att fylla listboxrarna med uppdaterad information 
        public void fillList()
        {
            //Uppdatera namnen på dropdownlist1
            sql.conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT unitname, unitid FROM unit ORDER BY unitid", sql.conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();

            //Uppdatera namn i listbox 
            List<Unit> listUnit = unit.showUnit();
            lsbAllUnit.DataSource = listUnit;
            lsbAllUnit.DataTextField = "unitname";
            lsbAllUnit.DataValueField = "unitid";
            lsbAllUnit.Items.Add("unitName");
            lsbAllUnit.DataBind();

            txbAddUnit.Text = string.Empty;
            txbChangeUnit.Text = string.Empty;
        }

        protected void lsbAllUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}