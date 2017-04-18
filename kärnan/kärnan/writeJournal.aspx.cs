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
    public partial class writeJournal : System.Web.UI.Page
    {
        SQL sql = new SQL();
        journalClass jc = new journalClass();
        Family family = new Family();

        List<journalClass> newjc = new List<journalClass>();
        List<Family> newfam = new List<Family>();

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
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();           
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
                //lblPnr.Text = DropDownList1.SelectedItem.ToString();

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
            Family f = new Family();
            string född = f.birth;

         
            List<Family> familj = f.showBirth(född);
            



            //Contest c = new Contest();
            //List<Contest> nyCon = c.Competitions();
            //generateContestComp();
            //DropDownList1.DataSource = nyCon;
            //DropDownList1.DataTextField = "nameAndDate";
            //DropDownList1.DataValueField = "contestId";
            //DropDownList1.DataBind();





            //aktuellanhörig = (anhörig)lsb_anhöriga.SelectedItem;

            //if (aktuellanhörig != null)
            //{
            //    txb_namnanhörig.Text = aktuellanhörig.namn;
            //    txb_rollanhörig.Text = aktuellanhörig.roll;
            //    txb_telefonanhörig.Text = aktuellanhörig.telefon;
            //    txb_epostanhörig.Text = aktuellanhörig.epost;

            //}








            //try
            //{
            //    sql.conn.Open();
            //    NpgsqlCommand cmd = new NpgsqlCommand("SELECT birth FROM family WHERE familyid =" + DropDownList2.DataValueField, sql.conn);

            //    //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            //    NpgsqlDataReader rd = cmd.ExecuteReader();
            //    //DataTable dt = new DataTable();
            //    //da.Fill(dt);
            //    //DropDownList2.DataSource = dt;
            //    //DropDownList2.DataBind();

            //    //Lägg till enhetsnamn i label
            //    //lblPnr.Text = family.birth;
            //    lblPnr.Text = rd["birth"].ToString();
            //}
            //catch (NpgsqlException ex)
            //{
            //    this.sql.ex = ex.Message;
            //    return;
            //}
            //finally
            //{
            //    sql.conn.Close();
            //}


            //if (DropDownList2.DataValueField.ToString() == lblKlient.Text)
            //{
            //    //family.showBirth(family.birth);


            //}
        }

        //Spara journal
        protected void btnSpara_Click(object sender, EventArgs e)
        {
            string incident = txbincident.InnerText;
            string journal = txbJournal.InnerText;

            jc.saveJournal(journal, incident, jc.date /*jc.journalID*/);
        }

        //Avbryt skrivande journal
        protected void btnAvbry_Click(object sender, EventArgs e)
        {
            //string namn = txb_förnamnbarn.Text;
            //string övriginfo = txb_övriginfobarn.Text;
            //string foto = fotas;
            //string kontaktinfobarn = kontaktinfo;
            //int avdelning = Convert.ToInt32(cmb_avdelning.Text);

            //db.dbLäggtillBarn(namn, övriginfo, foto, kontaktinfobarn, avdelning);
        }
    }
}