using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kärnan
{
    public partial class MasterMasterPage : System.Web.UI.MasterPage
    {

        SQL sql = new SQL();
        List<SQL> listSql = new List<SQL>();
        Employee emp = new Employee();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoggin_Click1(object sender, EventArgs e)
        {
            //if (txbUser.Text == null || txbPassword.Text == null)
            //{
            //    lblMessage.Text = "Du måste fylla i användarnamn och lösenord";
            //    sql.conn.Close();
            //}

            bool admin = emp.controllEmployee();

            sql.conn.Open();
            sql.cmd = new NpgsqlCommand("SELECT employeeid, pass FROM userpass WHERE employeeid = '" + txbUser.Text + "' AND pass = '" + txbPassword.Text + "'", sql.conn);
            sql.cmd.Connection = sql.conn;
            int output = Convert.ToInt32(sql.cmd.ExecuteScalar());


            if (output > 0)
            {
                Session["employeeid"] = txbUser.Text;
                sql.conn.Close();
                Response.Redirect("inloggad.aspx");
                
                if (txbUser.Text == Convert.ToString(admin))
                {
                    Response.Redirect("adminPage.aspx");
                }
            }
            else
            {
                lblMessage.Text = "Felaktigt användarnamn eller lösenord";
                sql.conn.Close();
            }

            if (output != 0)
            {
                emp.controllEmployee();
                Response.Redirect("adminPage.aspx");
            }
        }
    }
}
