using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using Npgsql;

namespace kärnan
{
    public partial class Test : System.Web.UI.Page
    {
        SQL sql = new SQL();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                sql.conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO crypish (username, password) VALUES(@username, @password)", sql.conn);

                string crypt = Crypt.ComputeHash(TextBox2.Text, "SHA512", null);

                cmd.Parameters.AddWithValue("@username", TextBox1.Text);
                cmd.Parameters.AddWithValue("@password", crypt);
                cmd.ExecuteNonQuery();
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

            //using (SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True;User Instance=True"))
            //{
            //    using (SqlCommand cmd = new SqlCommand("Insert into tblLogin(UserId,Password,EmpName,Address,ContactNo) values(@UserId,@Password,@EmpName,@Address,@ContactNo)", con))
            //    {
            //        cmd.Parameters.AddWithValue("@UserId", txtUserId.Text);
            //        //Here i have implemented the code for doing encryption of password
            //        string ePass = Helper.ComputeHash(txtPassword.Text, "SHA512", null);

            //        cmd.Parameters.AddWithValue("@Password", ePass);
            //        cmd.Parameters.AddWithValue("@EmpName", txtEmpName.Text);
            //        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            //        cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text);
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        con.Close();
            //        Cleartextbox();
            //        lblmsg.Text = "Your profile has been created Sucessfully";
            //    }
        }
    }
  }