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
        Client client = new Client ();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                enabled();

                //Fyll information i listbox 
                fillList();

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
                    client.familyid = Convert.ToInt32(dr["familyid"]);
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

        //Måste ha 
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
                client.name = txbName.Text;
                string name = client.name.ToString();
                client.surname = txbSurname.Text;
                string surname = client.surname.ToString();
                client.birth = txbBirth.Text;
                string birth = client.birth.ToString();

                client.unitname = drpUnit.SelectedItem.Value;
                int unitid = Convert.ToInt32(client.unitname);

                client.saveClient(name, surname, birth, unitid);
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
            client.familyid = Convert.ToInt32(lsbClient.SelectedItem.Value);
            int familyid = Convert.ToInt32(client.familyid);
            client.name = txbName.Text;
            string name = client.name;
            client.surname = txbSurname.Text;
            string surname = client.surname;
            client.birth = txbBirth.Text;
            string birth = client.birth;
            client.unitname = drpUnit.SelectedItem.Value;
            int unitname = Convert.ToInt32(client.unitname);

            client.updateFamily(familyid, name, surname, birth, unitname);
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
                client.familyid = Convert.ToInt32(lsbClient.SelectedItem.Value);
                int familyid = Convert.ToInt32(client.familyid);

                client.removeFamily(familyid);
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
                btnClearText.Visible = false;
                lsbClient.Enabled = false;
                txbName.Enabled = false;
                txbSurname.Enabled = false;
                txbBirth.Enabled = false;
                drpUnit.Enabled = false;
                txbName.Text = string.Empty;
                txbSurname.Text = string.Empty;
                txbBirth.Text = string.Empty;
                drpUnit.SelectedItem.Text = "-- Välj enhet --";

            }

            else if (drpChoice.SelectedItem.Value == "1")
            {
                btnUpdateClient.Visible = false;
                btnRemoveClient.Visible = false;
                btnAddClient.Visible = true;
                btnClearText.Visible = true;
                lsbClient.Enabled = false;
                txbName.Enabled = true;
                txbSurname.Enabled = true;
                txbBirth.Enabled = true;
                drpUnit.Enabled = true;
                lsbClient.Enabled = false;
            }

            else if (drpChoice.SelectedItem.Value == "2")
            {
                btnAddClient.Visible = false;
                btnUpdateClient.Visible = true;
                btnRemoveClient.Visible = false;
                lsbClient.Enabled = true;
                btnClearText.Visible = true;
                txbName.Enabled = true;
                txbSurname.Enabled = true;
                txbBirth.Enabled = true;
                drpUnit.Enabled = true;
                lsbClient.Enabled = true;
            }

            else if (drpChoice.SelectedItem.Value == "3")
            {
                btnAddClient.Visible = false;
                btnUpdateClient.Visible = false;
                btnRemoveClient.Visible = true;
                lsbClient.Enabled = true;
                btnClearText.Visible = true;
                txbName.Enabled = true;
                txbSurname.Enabled = true;
                txbBirth.Enabled = true;
                drpUnit.Enabled = true;
                txbName.Enabled = false;
                txbSurname.Enabled = false;
                txbBirth.Enabled = false;
                drpUnit.Enabled = false;
            }
        }

        public void enabled()
        {
            btnAddClient.Visible = false;
            btnRemoveClient.Visible = false;
            btnUpdateClient.Visible = false;
            btnClearText.Visible = false;
            txbName.Enabled = false;
            txbSurname.Enabled = false;
            txbBirth.Enabled = false;
            drpUnit.Enabled = false;
            lsbClient.Enabled = false;
        }
    }
}