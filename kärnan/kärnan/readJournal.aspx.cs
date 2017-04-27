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
    public partial class readJournal : System.Web.UI.Page
    {
        SQL sql = new SQL();
        Unit ut = new Unit();
        Family family = new Family();
        Journal journal = new Journal();

        List<Journal> aktuellJournal = new List<Journal>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Visa namnen på enhet i dropdownlist1
                sql.conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT name, unitid FROM unit", sql.conn);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                drpUnit.DataSource = dt;
                drpUnit.DataBind();

                //Håller koll på vem det är som är inloggad  
                if (Session["employeeid"] != null)
                {
                    //lblInitials.Text = Session["employeeid"].ToString();
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
                               "FROM family_unit " +
                               "JOIN unit ON family_unit.unitid = unit.unitid " +
                               "JOIN family ON family_unit.familyid = family.familyid " +
                               "WHERE unit.unitid =" + drpUnit.SelectedItem.Value, sql.conn);

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
        }

        //Måste ha denna för att namn ska visas i drpClient
        protected void drpClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Lägg till klientnamn i label
            lblclient.Text = drpClient.SelectedItem.ToString();
        }

        //Visa ALLA datum + anteckningar i listbox
        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            //Deklarera information från dropdowns
            ut.name = drpUnit.SelectedItem.Value;
            int unitid = Convert.ToInt32(ut.name);
            family.name = drpClient.SelectedItem.Value;
            int familyid = Convert.ToInt32(family.name);

            //Visa information (DATUM + RUBRIK) i listbox
            Journal jc = new Journal();
            List<Journal> journal = jc.showIncident(unitid, familyid);

            lsbList.DataSource = journal;
            //lsbList.SelectedIndex = 0;
            lsbList.DataTextField = "date" + "incident";
            lsbList.DataValueField = "journalid";
            lsbList.Items.Add("dateIncident");
            lsbList.DataBind();
        }


         protected void lsbList_SelectedIndexChanged(object sender, EventArgs e)
        {
     try
            {
            sql.conn.Open();
            string query = "SELECT DISTINCT journal.date, journalnote, incident, initials " +
                           "FROM journal, employee " +
                           "WHERE journalid = @journalid " +
                           "AND journal.employeeid = employee.employeeid";

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
    }
}