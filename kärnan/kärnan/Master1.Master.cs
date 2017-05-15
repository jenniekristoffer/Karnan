using System;
using System.Collections.Generic;
using Npgsql;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace kärnan
{
    public partial class Master1 : System.Web.UI.MasterPage
    {
        Loggain ln = new Loggain();
        List<Loggain> listLoggin = new List<Loggain>();

        SQL sql = new SQL();
        List<SQL> listSql = new List<SQL>();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLoggin_Click(object sender, EventArgs e)
        {
            sql.conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT employeeid, pass FROM userpass WHERE employeeid = @employeeid", sql.conn);
            cmd.Parameters.AddWithValue("@employeeid", txbAnv.Text);
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            da.Fill(dt);
            string userid = dt.Rows[0]["employeeid"].ToString();
            string password = dt.Rows[0]["password"].ToString();
            bool flag = Crypt.VerifyHash(txbLösen.Text, "SHA512", password);

            if (userid == txbAnv.Text && flag == true)
            {
                Session["employeeid"] = txbAnv.Text;
                sql.conn.Close();
                Response.Redirect("inloggad.aspx");
            }
            else
            {
                lblMessage.Text = "Fel användarnamn eller lösenord";
            }




            //sql.conn.Open();
            //string query = "SELECT loggin.user, loggin.password FROM loggin WHERE loggin.user'" + txbAnv + "' AND loggin.password'" + txbLösen + "' ";

            //NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);
            //string output = cmd.ExecuteScalar().ToString();

            //if (output == "1")
            //{
            //    Session["user"] = txbAnv.Text;           
            //    sql.conn.Close();
            //    Response.Redirect("inloggad.aspx");
            //}

            //else
            //{
            //    lblMessage.Text = "Skriv in rätt användarnamn och lösenord";
            //}

        }
    }
}