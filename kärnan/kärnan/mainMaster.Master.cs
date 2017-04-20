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
        //SQL sql = new SQL();
        SQL sql = new SQL();
        List<SQL> listSql = new List<SQL>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoggin_Click(object sender, EventArgs e)
        {
            sql.conn.Open();
            sql.cmd = new NpgsqlCommand("SELECT anv, pass FROM userpass WHERE anv = '" + txbUser.Text + "' AND pass = '" + txbPassword.Text + "'", sql.conn);
            sql.cmd.Connection = sql.conn;

            string output = sql.cmd.ExecuteScalar().ToString();

            if (output != null)
            {
                Session["anv"] = txbUser.Text;
                sql.conn.Close();
                Response.Redirect("inloggad.aspx");
            }
            else
            {
                lblMessage.Text = "Skriv in rätt användarnamn och lösenord";
                sql.conn.Close();
            }

            //sql.conn.Open();
            //string query = ("SELECT anv, pass FROM userpass WHERE anv'" + txbUser.Text + "' AND pass'" + txbPassword.Text + "'");

            //NpgsqlCommand cmd = new NpgsqlCommand(query, sql.conn);

            //string output = sql.cmd.ExecuteScalar().ToString();

            //if (output == "1")
            //{
            //    Session["anv"] = txbUser.Text;
            //    sql.conn.Close();
            //    Response.Redirect("inloggad.aspx");
            //}

            //else
            //{
            //    lblMessage.Text = "Skriv in rätt användarnamn och lösenord";
            //    sql.conn.Close();
            //}
        }


        //    Postgress p = new Postgress();
        //p.cmd = new Npgsql.NpgsqlCommand("select count(*) from account where golfid = '" + golf_id.Text + "' AND password = '" + password.Text + "'", p.conn);

        //    p.cmd.Connection = p.conn;
        //    int obj = Convert.ToInt32(p.cmd.ExecuteScalar());           /* vi måste även hantera kontonamn med bokstäver, med tanke på personalkonton om de ej ska listas som vanliga golfidn - Martin N*/
        //    if(obj > 0)
        //    {

        //        Session["golfid"] = golf_id.Text;
        //        p.conn.Close();
        //        Response.Redirect("inloggad.aspx");

        //    }
        //    else
        //    {
        //        p.conn.Close();
        //        Response.Write("<script>alert('Felaktigt användarnamn och lösenord')</script>");

    }

}