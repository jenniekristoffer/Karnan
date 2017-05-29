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
    public partial class adminReadJournal : System.Web.UI.Page
    {
        SQL sql = new SQL();
        Unit ut = new Unit();
        Client client = new Client();
        Journal journal = new Journal();

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
                drpUnit.DataSource = dt;
                drpUnit.DataBind();

                //Håller koll på vem det är som är inloggad  
                if (Session["employeeid"] != null)
                {
                }
            }
        }

        //Visa namnen på familjer i drpClient när enhet valt i drpUnit
        protected void drpUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpClient.Items.Clear();
            drpClient.Items.Add("-- Välj namn --");

            try
            {
                sql.conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT family.name, family.familyid " +
                                                      "FROM family, unit " +
                                                      "WHERE family.unitid = unit.unitid " +
                                                      "AND unit.unitid = " + drpUnit.SelectedItem.Value, sql.conn);

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                drpClient.DataSource = dt;
                drpClient.DataBind();

                //Lägg till enhetsnamn i label
                lblunit.Text = drpUnit.SelectedItem.ToString();

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

            clean();
        }

        //Måste ha denna för att namn ska visas i drpClient
        protected void drpClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Lägg till klientnamn i label
            lblclient.Text = drpClient.SelectedItem.ToString();
            showAllJournal();
            cleanJournal();
        }

        //Visa journaler mellan vald datum 
        protected void btnShowSpecifik_Click(object sender, EventArgs e)
        {
            //if (Request.Form["date1"] == string.Empty || Request.Form["date2"] == string.Empty)
            //{
            //    lblFelmeddelande.Text = "Du måste välja mellan vilka datum du vill läsa";
            //}
            if (lblclient.Text == string.Empty && lblunit.Text == string.Empty)
            {
                lblFelmeddelande.Text = "Du måste först välja enhet och klient";
            }

            else
            {

                lblFelmeddelande.Text = string.Empty;
                journal.date = Convert.ToDateTime(Request.Form["date1"]);
                DateTime date = journal.date;
                journal.date2 = Convert.ToDateTime(Request.Form["date2"]);
                DateTime date2 = journal.date2;

                ut.unitname = drpUnit.SelectedItem.Value;
                int unitid = Convert.ToInt32(ut.unitname);
                client.name = drpClient.SelectedItem.Value;
                int familyid = Convert.ToInt32(client.name);

                //Visa specifik information (DATUM + RUBRIK) i listbox
                List<Journal> j = journal.dateJournal(familyid, unitid, date, date2);

                lsbList.DataSource = j;
                lsbList.DataTextField = "date" + "incident";
                lsbList.DataValueField = "journalid";
                lsbList.Items.Add("dateIncident");
                lsbList.DataBind();
                cleanJournal();
            }
        }

        //Visa ALLA datum + anteckningar i listbox
        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            showAllJournal();
            cleanJournal();
        }

        //Visa info i textboxrar om journal när namnet markeras i listboxen
        protected void lsbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sql.conn.Open();

                string query = "SELECT DISTINCT journalnote, incident, initials, date " +
                               "FROM journal, employee " +
                               "WHERE journal.employeeid = employee.employeeid " +
                               "AND journal.journalid = " + lsbList.SelectedItem.Value;

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Parameters.AddWithValue("journalid", lsbList.SelectedItem.Value);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Connection = sql.conn;

                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txbRubrik.InnerText = dr["incident"].ToString();
                    txbJournal.InnerText = dr["journalnote"].ToString();
                    lblInitialer.Text = dr["initials"].ToString();
                    txbDate.InnerText = Convert.ToDateTime(dr["date"]).ToShortDateString();
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

        //Metod: radera information 
        public void clean()
        {
            txbDate.InnerText = string.Empty;
            txbJournal.InnerText = string.Empty;
            txbRubrik.InnerText = string.Empty;
            lblInitialer.Text = string.Empty;
            lblclient.Text = string.Empty;
            lsbList.Items.Clear();    
        }
        
        public void cleanJournal()
        {
            txbDate.InnerText = string.Empty;
            txbJournal.InnerText = string.Empty;
            txbRubrik.InnerText = string.Empty;
            lblInitialer.Text = string.Empty;
        }


        //Metod: Visa alla journaler 
        public void showAllJournal()
        {
            if (lblclient.Text == string.Empty && lblunit.Text == string.Empty)
            {
                lblFelmeddelande.Text = "Du måste först välja enhet och klient";
            }
            else
            {
                //Deklarera information från dropdowns
                ut.unitname = drpUnit.SelectedItem.Value;
                int unitid = Convert.ToInt32(ut.unitname);
                client.name = drpClient.SelectedItem.Value;
                int familyid = Convert.ToInt32(client.name);

                Journal jc = new Journal();
                List<Journal> journal = jc.showIncident(unitid, familyid);

                lsbList.DataSource = journal;
                lsbList.DataTextField = "date" + "incident";
                lsbList.DataValueField = "journalid";
                lsbList.Items.Add("dateIncident");
                lsbList.DataBind();
            }
        }
    }
}