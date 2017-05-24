using Microsoft.AspNet.Identity;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
//
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace kärnan
{
    public partial class writeJournal : System.Web.UI.Page
    {
        SQL sql = new SQL();
        Journal jc = new Journal();
        Client family = new Client();
        Employee employee = new Employee();
        Unit ut = new Unit();

        List<Journal> newjc = new List<Journal>();
        List<Client> newfam = new List<Client>();



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
                                                      "FROM family, unit " +
                                                      "WHERE family.unitid = unit.unitid " +
                                                      "AND unit.unitid = " + DropDownList1.SelectedItem.Value, sql.conn);

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
            DialogResult dialogResult = MessageBox.Show("Är du säker på att du vill spara ?", "Spara journal", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                saveJournal();
        }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        //Spara journal-Metod
        public void saveJournal()
        {

            if (lblKlient.Text == string.Empty && lblEnhet.Text == string.Empty)
            {
                lblClient.Text = "Du måste först välja enhet och klient";
            }

            if (txbincident.InnerText == string.Empty)
            {
                lblBeskrivning.Text = "Du måste skriva en rubrik";
            }

            if(txbJournal.InnerText == string.Empty)
            {
                lblJournal.Text = "Du måste skriva något i journalanteckningen";
            }

            if (lblKlient.Text != string.Empty && lblEnhet.Text != string.Empty && txbincident.InnerText != string.Empty && txbJournal.InnerText != string.Empty)
            {
              //Visar tomma felmeddelanden
                lblBeskrivning.Text = "";
                lblJournal.Text = "";
                lblClient.Text = "";

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

            //Hämta valt datum från datepicker
                jc.date = Convert.ToDateTime(Request.Form["datepicker"]);
                DateTime date = jc.date;

            //Lägger till dagens datum
            DateTime datetoday = Convert.ToDateTime(DateTime.Today.ToShortDateString());

            //metod för att spara journalanteckning i db
            jc.saveJournal(journalnote, incident, date, employeeid, unitid, familyid);

                //tömmer textboxrarna
                txbincident.InnerText = string.Empty;
                txbJournal.InnerText = string.Empty;
                lblMeddelande.Text = "Journalen är sparad";


                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                HtmlGenericControl sparat = new HtmlGenericControl("p");
                sparat.Attributes.Add("id", "saveSeason");
                sparat.InnerHtml = "Ändringar sparade";
                tmp.Controls.Add(sparat);


            }
        }

        //public static string[] GetCustomers(string prefix)
        //{
        //    List<string> customers = new List<string>();
        //    using (SqlConnection conn = new SqlConnection())
        //    {
        //        conn.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.CommandText = "select ContactName, CustomerId from Customers where ContactName like @SearchText + '%'";
        //            cmd.Parameters.AddWithValue("@SearchText", prefix);
        //            cmd.Connection = conn;
        //            conn.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    customers.Add(string.Format("{0}-{1}", sdr["ContactName"], sdr["CustomerId"]));
        //                }
        //            }
        //            conn.Close();
        //        }
        //    }
        //    return customers.ToArray();
        //}

        //protected void Submit(object sender, EventArgs e)
        //{
        //    string customerName = Request.Form[txbincident.UniqueID];
        //    string customerId = Request.Form[hfCustomerId.UniqueID];
        //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + customerName + "\\nID: " + customerId + "');", true);
        //}
    }
}