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
            //try
            //{
            //sql.conn.Open();
            //NpgsqlCommand cmd = new NpgsqlCommand("SELECT employeeid, pass FROM userpass WHERE employeeid = @employeeid", sql.conn);
            //cmd.Parameters.AddWithValue("@employeeid", Convert.ToInt32(txbUser.Text));
            //DataTable dt = new DataTable();
            //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            //da.Fill(dt);
            //string userid = txbUser.Text;
            //string password = txbPassword.Text;
            //bool flag = Crypt.VerifyHash(txbPassword.Text, "SHA512", password);

            //if (userid == txbUser.Text && flag == true)
            //{
            //    Session["employeeid"] = txbUser.Text;
            //    sql.conn.Close();
            //    Response.Redirect("inloggad.aspx");
            //}
            //else
            //{
            //    lblMessage.Text = "Fel användarnamn eller lösenord";
            //}
            //}

            //catch (NpgsqlException ex)
            //{
            //    sql.ex = ex.Message;
            //}
            //sql.conn.Close();     
            

            sql.conn.Open();
            sql.cmd = new NpgsqlCommand("SELECT userpass.employeeid, pass, admin FROM userpass, employee WHERE userpass.employeeid = '" + txbUser.Text + "' AND pass = '" + txbPassword.Text + "'", sql.conn);
            sql.cmd.Connection = sql.conn;
            int output = Convert.ToInt32(sql.cmd.ExecuteScalar());
            //bool admin = emp.controllEmployee();       
            int username = Convert.ToInt32(txbUser.Text);
            emp.controllEmployee(username);

            if (username == 1 || username == 6)
            {
                Response.Redirect("adminPage.aspx");
                Session["employeeid"] = txbUser.Text;
                sql.conn.Close();
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

            //if (output != 0)
            //{
            //    emp.controllEmployee();
            //    Response.Redirect("adminPage.aspx");
            //}
        }
    }
}
