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
    public partial class adminClientt : System.Web.UI.Page
    {
        SQL sql = new SQL();
        Client family = new Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Fyll information i listbox 
                fillList();

                btnAddClient.Visible = false;
                btnRemoveClient.Visible = false;
                btnUpdateClient.Visible = false;

                //Håller koll på vem det är som är inloggad  
                if (Session["employeeid"] != null)
                {
                }
            }
        }

        //Vid vald familj, visa info i textbox/dropdown
        protected void lsbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sql.conn.Open();
                string query = "SELECT familyid, name, surname, birth, unitname " +
                           "FROM family, unit " +
                           "WHERE family.unitid = unit.unitid " +
                           "AND family.familyid = " + lsbClient.SelectedItem.Value;

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Parameters.AddWithValue("familyid", lsbClient.SelectedItem.Value);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Connection = sql.conn;

                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txbName.Text = dr["name"].ToString();
                    txbSurname.Text = dr["surname"].ToString();
                    txbBirth.Text = dr["birth"].ToString();
                    drpUnit.SelectedItem.Text = dr["unitname"].ToString();
                    family.familyid = Convert.ToInt32(dr["familyid"]);
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

        protected void drpUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Radera alla textfält 
        protected void btnClearText_Click(object sender, EventArgs e)
        {
            //tömmer textboxrarna
            txbName.Text = string.Empty;
            txbSurname.Text = string.Empty;
            txbBirth.Text = string.Empty;
            drpUnit.SelectedItem.Text = "-- Välj enhet --";
        }

        //Uppdatera lista 
        public void fillList()
        {   //Visa information om klient
            Client f = new Client();
            List<Client> aktuellfamily = f.showFamily();

            //visa namn på alla klienter i en listbox
            lsbClient.DataSource = aktuellfamily;
            lsbClient.DataTextField = "name" + "surname" + "birth" + "unitname";
            lsbClient.DataValueField = "familyid";
            lsbClient.DataBind();

            //Visa namnen på enhet i dropdownlist
            sql.conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT unitname, unitid FROM unit", sql.conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            drpUnit.DataSource = dt;
            drpUnit.DataBind();

        }

        //Metod Radera textboxrar
        public void clearTextbox()
        {
            txbName.Text = string.Empty;
            txbSurname.Text = string.Empty;
            txbBirth.Text = string.Empty;
            drpUnit.SelectedItem.Text = "-- Välj enhet --";
        }

        //Lägg till klient
        protected void btnAddClient_Click(object sender, EventArgs e)
        {
            if (txbName.Text == string.Empty || txbSurname.Text == string.Empty || txbBirth.Text == string.Empty || drpUnit.SelectedItem.Value == string.Empty)
            {
                lblmeddelande.Text = "Du måste fylla i information i textboxrarna och välja enhet";
            }
            else
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

                family.saveClient(name, surname, birth, unitid);
                lsbClient.Items.Clear();
                drpUnit.Items.Clear();
                fillList();
                clearTextbox();
                lblcorrekt.Text = "Ny klient är tillagd";
            }
        }

        //Uppdatera klient
        protected void btnUpdateClient_Click(object sender, EventArgs e)
        {
            //Deklarerar info
            family.familyid = Convert.ToInt32(lsbClient.SelectedItem.Value);
            int familyid = Convert.ToInt32(family.familyid);
            family.name = txbName.Text;
            string name = family.name;
            family.surname = txbSurname.Text;
            string surname = family.surname;
            family.birth = txbBirth.Text;
            string birth = family.birth;
            family.unitname = drpUnit.SelectedItem.Value;
            string unitname = family.unitname;

            family.updateFamily(familyid, name, surname, birth);
            lsbClient.Items.Clear();
            drpUnit.Items.Clear();
            fillList();
            clearTextbox();
            lblcorrekt.Text = "Information om klient är uppdaterad";
        }

        //Radera klient
        protected void btnRemoveClient_Click(object sender, EventArgs e)
        {
            if (lsbClient.SelectedItem == null)
            {
                lblmeddelande.Text = "Välj klient innan du raderar";
            }
            else
            {
                //deklarera
                family.familyid = Convert.ToInt32(lsbClient.SelectedItem.Value);
                int familyid = Convert.ToInt32(family.familyid);

                family.removeFamily(familyid);
                lsbClient.Items.Clear();
                drpUnit.Items.Clear();
                fillList();
                clearTextbox();
                lblcorrekt.Text = "Klient är borttagen";
            }
        }

        protected void drpChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpChoice.SelectedItem.Value == "-1")
            {
                btnAddClient.Visible = false;
                btnRemoveClient.Visible = false;
                btnUpdateClient.Visible = false;
                lsbClient.Enabled = false;
            }

            else if (drpChoice.SelectedItem.Value == "1")
            {
                btnUpdateClient.Visible = false;
                btnRemoveClient.Visible = false;
                btnAddClient.Visible = true;
                lsbClient.Enabled = false;
            }

            else if (drpChoice.SelectedItem.Value == "2")
            {
                btnAddClient.Visible = false;
                btnUpdateClient.Visible = true;
                btnRemoveClient.Visible = false;
                lsbClient.Enabled = true;
            }

            else if (drpChoice.SelectedItem.Value == "3")
            {
                btnAddClient.Visible = false;
                btnUpdateClient.Visible = false;
                btnRemoveClient.Visible = true;
                lsbClient.Enabled = true;
            }
        }
    }
}