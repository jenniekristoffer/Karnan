using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kärnan
{
    public partial class adminFamily : System.Web.UI.Page
    {
        SQL sql = new SQL();
        Family family = new Family();
        //List<Family> aktuellFamilj = new List<Family>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Visa namnen på enhet i dropdownlist
                sql.conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT unitname, unitid FROM unit", sql.conn);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                drpUnit.DataSource = dt;
                drpUnit.DataBind();
         
                //Visa information (DATUM + RUBRIK)
                Family f = new Family();
                List<Family> aktuellfamily = f.showFamily();

                //visa namn på familj i listbox
                ListBox1.DataSource = aktuellfamily;
                ListBox1.DataTextField = "name" + "surname"  + "birth" + "unitname";
                ListBox1.DataValueField = "familyid";
                ListBox1.Items.Add("nameSurnameBirthUnitname");
                ListBox1.DataBind();
                //Visa namn på familj i dropdownlist2
                DropDownList2.DataSource = aktuellfamily;
                DropDownList2.DataTextField = "name" + "surname" + "birth" + "unitname";
                DropDownList2.DataValueField = "familyid";
                DropDownList2.Items.Add("nameSurnameBirthUnitname");
                DropDownList2.DataBind();

                //Håller koll på vem det är som är inloggad  
                if (Session["employeeid"] != null)
                {
                }             
            }
        }

        protected void drpUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Lägg till familj till enhet 
        protected void btnAddFamily_Click(object sender, EventArgs e)
        {
            //Deklarerar info från textboxen
            family.name = txbName.Text;
            string name = family.name.ToString();
            family.surname = txbSurname.Text;
            string surname = family.surname.ToString();
            family.birth = txbBirth.Text;
            string birth = family.birth.ToString();

            family.unitname = drpUnit.SelectedItem.Value;
            int unitid = Convert.ToInt32(family.unitname);

            family.saveFamily(name, surname, birth, unitid);
        }

        //Visa info i textboxrar om familj när namnet markeras i listboxen
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sql.conn.Open();
                string query = "SELECT name, surname, birth, unitname " +
                           "FROM family, unit " +
                           "WHERE family.unitid = unit.unitid " +
                           "AND family.familyid = " + ListBox1.SelectedItem.Value;

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Parameters.AddWithValue("familyid", ListBox1.SelectedItem.Value);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Connection = sql.conn;

                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txbUpdateName.Text = dr["name"].ToString();
                    txbUpdateSurname.Text = dr["surname"].ToString();
                    txbUpdateBirth.Text = dr["birth"].ToString();
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

        //Uppdatera information om familj
        protected void btnUpdateFamily_Click(object sender, EventArgs e)
        {
            //Deklarerar info
            family.familyid = Convert.ToInt32(ListBox1.SelectedItem.Value);
            int familyid = Convert.ToInt32(family.familyid);
            family.name = txbUpdateName.Text;
            string name = family.name;
            family.surname = txbUpdateSurname.Text;
            string surname = family.surname;
            family.birth = txbUpdateBirth.Text;
            string birth = family.birth;
            

            family.updateFamily(familyid, name, surname, birth);
            ListBox1.Items.Clear(); 
            //lblCorrectMessage.Text = "Namnet på enheten är ändrad!";         
            //txbChangeUnit.Text = string.Empty;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnRemoveFamily_Click(object sender, EventArgs e)
        {
            //deklarera
            family.familyid = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            int familyid = Convert.ToInt32(family.familyid);

            family.removeFamily(familyid);
        }

        //Uppdatera lista 
        public void fillNewList ()
        {

        }
    }
}