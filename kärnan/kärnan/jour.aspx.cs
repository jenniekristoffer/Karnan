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
    public partial class jour : System.Web.UI.Page
    {
        SQL newSql = new SQL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                newSql.conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT name, unitid FROM unit", newSql.conn);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("Select State");
          
            try
            {
                newSql.conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT family.name, family.familyid " +
                               "FROM family_unit " +
                               "JOIN unit ON family_unit.unitid = unit.unitid " +
                               "JOIN family ON family_unit.familyid = family.familyid " +
                               "WHERE unit.unitid =" + DropDownList1.SelectedItem.Value, newSql.conn);

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();

            }
            catch (NpgsqlException ex)
            {
                this.newSql.ex = ex.Message;
                return;
            }
            finally
            {
                newSql.conn.Close();
            }

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DropDownList3.Items.Clear();
            //DropDownList3.Items.Add("Select State");

            //SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True");
            //SqlCommand cmd = new SqlCommand("select * from tbl_city where state_id=" + DropDownList2.SelectedItem.Value, con);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);

            //DropDownList3.DataSource = dt;
            //DropDownList3.DataBind();
        }
    }
}