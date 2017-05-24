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
           
            if (txbUser.Text == string.Empty || txbPassword.Text == string.Empty)
            {
                lblMessage.Text = "Du måste fylla i användarnamn och lösenord";
            }
            else
            {
                sql.conn.Open();
                sql.cmd = new NpgsqlCommand("SELECT employeeid, pass, admin FROM employee WHERE employeeid = '" + txbUser.Text + "' AND pass = '" + txbPassword.Text + "'", sql.conn);
                sql.cmd.Connection = sql.conn;
                int output = Convert.ToInt32(sql.cmd.ExecuteScalar());
                //bool admin = emp.controllEmployee();       
                int username = Convert.ToInt32(txbUser.Text);
                emp.controllEmployee(username);

                if (username == 1 || username == 6)
                {
                    Session["employeeid"] = txbUser.Text;
                    sql.conn.Close();
                    Response.Redirect("adminPage.aspx");
                }

                if (output > 0)
                {
                    Session["employeeid"] = txbUser.Text;
                    sql.conn.Close();
                    Response.Redirect("inloggad.aspx");

                }
                else
                {
                    lblMessage.Text = "Felaktigt användarnamn eller lösenord";
                    sql.conn.Close();
                }
            }
        }
    }
}
