using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kärnan
{
    public partial class mainMaster : System.Web.UI.MasterPage
    {
        SQL sql = new SQL();
        List<SQL> listSql = new List<SQL>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Logga in 
        protected void btnLoggin_Click(object sender, EventArgs e)
        {
            sql.conn.Open();
            sql.cmd = new NpgsqlCommand("SELECT employeeid, pass FROM userpass WHERE employeeid = '" + txbUser.Text + "' AND pass = '" + txbPassword.Text + "'", sql.conn);
            sql.cmd.Connection = sql.conn;

            string output = sql.cmd.ExecuteScalar().ToString();

            if (output != null)
            {
                Session["employeeid"] = txbUser.Text;
                sql.conn.Close();
                Response.Redirect("inloggad.aspx");
            }
            else
            {
                lblMessage.Text = "Skriv in rätt användarnamn och lösenord";
                sql.conn.Close();
            }
        }
    }
}