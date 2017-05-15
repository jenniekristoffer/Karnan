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
    public partial class mainMaster : System.Web.UI.MasterPage
    {
        SQL sql = new SQL();
        List<SQL> listSql = new List<SQL>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True;User Instance=True"))
            //{
            //    using (SqlCommand cmd = new SqlCommand("Select UserId,Password from tblLogin where UserId=@UserId", con))
            //    {
            //        cmd.Parameters.AddWithValue("@UserId", txtUserName.Text);

            //        DataTable dt = new DataTable();
            //        SqlDataAdapter da = new SqlDataAdapter(cmd);
            //        da.Fill(dt);
            //        string userid = dt.Rows[0]["UserId"].ToString();
            //        string password = dt.Rows[0]["Password"].ToString();
            //        bool flag = Helper.VerifyHash(txtPassword.Text, "SHA512", password);

            //        if (userid == txtUserName.Text && flag == true)
            //        {
            //            Response.Redirect("Welcome.aspx");
            //        }
            //        else
            //        {
            //            lblmsg.Text = "Invalid UserId or password";
            //        }
            //        txtPassword.Text = string.Empty;
            //        txtUserName.Text = string.Empty;
            //    }
            //}
        }

        //Logga in 
        protected void btnLoggin_Click(object sender, EventArgs e)
        {

            sql.conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT employeeid, pass FROM userpass WHERE employeeid = @employeeid", sql.conn);
            cmd.Parameters.AddWithValue("@employeeid", txbUser.Text);
            DataTable dt = new DataTable();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            da.Fill(dt);
            string userid = dt.Rows[0]["employeeid"].ToString();
            string password = dt.Rows[0]["password"].ToString();
            bool flag = Crypt.VerifyHash(txbPassword.Text, "SHA512", password);

            if (userid == txbUser.Text && flag == true)
            {
                Session["employeeid"] = txbUser.Text;
                sql.conn.Close();
                Response.Redirect("inloggad.aspx");               
            }
            else
            {
                lblMessage.Text = "Fel användarnamn eller lösenord";
            }




            //sql.cmd = new NpgsqlCommand("SELECT employeeid, pass FROM userpass WHERE employeeid = '" + txbUser.Text + "' AND pass = '" + txbPassword.Text + "'", sql.conn);
            // sql.cmd.Connection = sql.conn;

            // int output = Convert.ToInt32(sql.cmd.ExecuteScalar());
            // if (output > 0)
            // {               
            //     Session["employeeid"] = txbUser.Text;
            //     sql.conn.Close();
            //     Response.Redirect("inloggad.aspx");               
            // }
            //else 
            // {
            //     lblMessage.Text = "Felaktigt användarnamn eller lösenord";
            //     sql.conn.Close();
            // }
        }
    }
}