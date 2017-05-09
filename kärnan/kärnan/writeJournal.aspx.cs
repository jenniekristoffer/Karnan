using Microsoft.AspNet.Identity;
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
    public partial class writeJournal : System.Web.UI.Page
    {
        SQL sql = new SQL();
        Journal jc = new Journal();
        Family family = new Family();
        Employee employee = new Employee();
        Unit ut = new Unit();
        Alltables all = new Alltables();

        List<Alltables> listAll = new List<Alltables>();
        List<Journal> newjc = new List<Journal>();
        List<Family> newfam = new List<Family>();

        protected void Page_Load(object sender, EventArgs e)
        {      
            if (!Page.IsPostBack)
            {
                //Visa namnen på enhet i dropdownlist1
                sql.conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT unitname, unitid FROM unit", sql.conn);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();

                //Håller koll på vem det är som är inloggad  
              if (Session["employeeid"] != null)
              {            
                 //lblInitials.Text = Session["employeeid"].ToString();
              }
            }
        }

        //Visa namnen på familjer i dropdownlist2 när enhet valt i dropdownlist1
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("-- Välj namn --");

            try
            {
                sql.conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT family.name, family.familyid " +
                               "FROM family_unit " +
                               "JOIN unit ON family_unit.unitid = unit.unitid " +
                               "JOIN family ON family_unit.familyid = family.familyid " +
                               "WHERE unit.unitid =" + DropDownList1.SelectedItem.Value, sql.conn);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataBind();

                //Lägg till enhetsnamn i label
                lblEnhet.Text = DropDownList1.SelectedItem.ToString();

            }
            catch (NpgsqlException ex)
            {
                this.sql.ex = ex.Message;
                return;
            }
            finally
            {
                sql.conn.Close();
            }
        }

        //Måste ha denna för att namn ska visas i dropdownlist2 
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Lägg till klientnamn i label
            lblKlient.Text = DropDownList2.SelectedItem.ToString();
        }

        //Spara journal
        protected void btnSpara_Click(object sender, EventArgs e)
        {
            //DialogResult dialogResult = MessageBox.Show("Är du säker på att du vill spara ?", "Spara journal", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            saveJournal();
            //}
            //else if (dialogResult == DialogResult.No)
            //{

            //}
        }

        //Avbryt skrivande journal ----------------------------------------------->>>>>>>>BEHÖVS DENNA ? 
        protected void btnAvbry_Click(object sender, EventArgs e)
        {

        }

        public void saveJournal()
        {
            //FELMEDDELANDE, om något inte är ifyllt så går det inte att spara
           // if (lblEnhet.Text == null && lblKlient.Text == null) // DENNA FUNKAR INTE.. 
           // {
           //     //lblBeskrivning.Text = "*";
           //     //lblJournal.Text = "*";
           //     lblMeddelande.Text = "Vänligen välj 'Enhet' och 'Familj'";
           // }

           //else if (txbJournal.Value != "" || txbincident.Value != "")
           // {
           //     lblBeskrivning.Text = "";
           //     lblJournal.Text = "*";
           //     lblMeddelande.Text = "Du måste fylla i 'Rubrik' och skriva i 'Journalanteckning'";
           // }

           // else if (txbincident.Value == "" || txbJournal.Value != "")
           // {
           //     lblBeskrivning.Text = "*";
           //     lblJournal.Text = "";
           //     lblMeddelande.Text = "Du måste fylla i 'rubrik'";
           // }

           // else /*(txbJournal.Value != "" && txbincident.Value != "")*/
           // {

             

                //Visar tomma felmeddelanden
                lblBeskrivning.Text = "";
                lblJournal.Text = "";

                //Deklarerar info från textboxrarna
                jc.incident = txbincident.InnerText;
                string incident = jc.incident.ToString();
                jc.journalnote = txbJournal.InnerText;
                string journalnote = jc.journalnote.ToString();

                ut.unitname = DropDownList1.SelectedItem.Value;
                int unitid = Convert.ToInt32(ut.unitname);
                family.name = DropDownList2.SelectedItem.Value;
                int familyid = Convert.ToInt32(family.name);

                int jourid = Convert.ToInt32(jc.journalid);

                employee.initials = Session["employeeid"].ToString();
                int employeeid = Convert.ToInt32(employee.initials);

                //Lägger till dagens datum
                DateTime datetoday = Convert.ToDateTime(DateTime.Today.ToShortDateString());

                //metod för att spara journalanteckning i db
                jc.saveJournal(journalnote, incident, datetoday, employeeid, unitid, familyid);

                ////metod för att spara i sammanslagen tabell i db ---------->>>>>>>>>> FUNKAR INTE MED JOURNALID 
                //all.saveAllInfo(familyid, unitid, employeeid, all.getLastJournal());     

                //tömmer textboxrarna
                txbincident.InnerText = string.Empty;
                txbJournal.InnerText = string.Empty;
                lblMeddelande.Text = "Journalen är sparad";

            //}
        }
    }
}