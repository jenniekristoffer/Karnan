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
    public partial class adminUnit : System.Web.UI.Page
    {
        Unit unit = new Unit();
        SQL sql = new SQL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Visa namnen på enhet i dropdownlist
                sql.conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT name, unitid FROM unit", sql.conn);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataBind();

                //Håller koll på vem det är som är inloggad  
                if (Session["employeeid"] != null)
                {
                    //lblInitials.Text = Session["employeeid"].ToString();
                }
            }
        }
    //Lägg till enhet
        protected void btnAddUnit_Click(object sender, EventArgs e)
        {
            //Deklarerar info från textboxen
            unit.name = txbAddUnit.Text;
            string name = unit.name.ToString();

            unit.saveUnit(name);
            lblUnitMessage.Text = "Ny enhet är sparad";
            lblUnitMessage.Text = string.Empty;

            //Visa namnen på enhet i dropdownlist
            DropDownList1.Items.Clear();
            sql.conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT name, unitid FROM unit ORDER BY unitid", sql.conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
        }

        //Måste ha denna för att namn ska visas i dropdownlist --ELLER ? 
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        //Ändra namn på enhet
        protected void btnChangeUnit_Click(object sender, EventArgs e)
        {
            //Deklarerar info
            unit.name = DropDownList1.SelectedItem.Value;
            int unitid = Convert.ToInt32(unit.name);
            unit.name = txbChangeUnit.Text;
            string name = unit.name.ToString();

            unit.updateUnit(unitid, name);
            lblCorrectMessage.Text = "Namnet på enheten är ändrad!";

            DropDownList1.Items.Clear();
            txbChangeUnit.Text = string.Empty;

            //Visa namnen på enhet i dropdownlist
            sql.conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT name, unitid FROM unit ORDER BY unitid", sql.conn);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
        }

        //Radera enhet
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            unit.name = DropDownList1.SelectedItem.Value;
            int unitid = Convert.ToInt32(unit.name);

            unit.removeUnit(unitid);
        }
    }
}