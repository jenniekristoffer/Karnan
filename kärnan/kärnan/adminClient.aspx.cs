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

                ////Visa och dölj knappar beroende på alternativ i listboxen
                alternativ();

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

        //Lägg till client till enhet 
        protected void btnAddFamily_Click(object sender, EventArgs e)
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

        //Uppdatera client 
        protected void btnUpdateFamily_Click(object sender, EventArgs e)
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

        //Radera client
        protected void btnRemove_Click(object sender, EventArgs e)
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

        //Metod som fyller dropboxen med alternativ 
        public void choice()
        {
            //List<ListItem> items = new List<ListItem>();
            //items.Add(new ListItem("Lägg till", "Value 2"));
            //items.Add(new ListItem("Radera", "Value 1"));
            //items.Add(new ListItem("Redigera", "Value 3"));
            //items.Sort(delegate (ListItem item1, ListItem item2) { return item1.Text.CompareTo(item2.Text); });
            //drpChoice.Items.AddRange(items.ToArray());

            //drpChoice.Items.Add("--- Välj alternativ ---");
            //drpChoice.Items.Add("Lägg till ny klient");
            //drpChoice.Items.Add("Radera befintlig klient");
            //drpChoice.Items.Add("Redigera befintlig klient");
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
            lsbClient.Items.Add("nameSurnameBirthUnitname");
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

        //Metod för att avgöra vilket alternativ användaren väljer i droplist 
        public void alternativ()
        {

            if (drpChoice.SelectedItem.Value == "-1")
            {
                btnAddFamily.Enabled = false;
                btnUpdateFamily.Enabled = false;
                btnRemove.Enabled = false;
            }

           else if (drpChoice.SelectedItem.Value == "1")
            {
                btnAddFamily.Enabled = true;
                btnUpdateFamily.Enabled = false;
                btnRemove.Enabled = false;
            }

            else if (drpChoice.SelectedItem.Value == "2")
            {
                btnAddFamily.Enabled = false;
                btnUpdateFamily.Enabled = true;
                btnRemove.Enabled = false;
            }

           else if (drpChoice.SelectedItem.Value == "3")
            {
                btnAddFamily.Enabled = false;
                btnUpdateFamily.Enabled = false;
                btnRemove.Enabled = true;
            }
        }

        //Metod Radera textboxrar
        public void clearTextbox()
        {
            txbName.Text = string.Empty;
            txbSurname.Text = string.Empty;
            txbBirth.Text = string.Empty;
            drpUnit.SelectedItem.Text = "-- Välj enhet --";
        }

    }
}