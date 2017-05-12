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
    public partial class adminEmployee : System.Web.UI.Page
    {
        Employee employ = new Employee();
        SQL sql = new SQL();
        Client family = new Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              //Fyll dropdown 
              choice();

              //Fyll listboxen
              fill();

            //Håller koll på vem det är som är inloggad  
            if (Session["employeeid"] != null)
            {
            }
          }
        }

        //Visa info från listbox i texbox
        protected void lsbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sql.conn.Open();
                string query = "SELECT employeeid, name, surname, initials, admin " +
                           "FROM employee " +
                           "WHERE employee.employeeid = " + lsbEmployee.SelectedItem.Value;

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Parameters.AddWithValue("employeeid", lsbEmployee.SelectedItem.Value);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Connection = sql.conn;

                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txbName.Text = dr["name"].ToString();
                    txbSurname.Text = dr["surname"].ToString();
                    txbInitials.Text = dr["initials"].ToString();
                    cbxAdmin.Checked = Convert.ToBoolean(dr["admin"]);
                    //employ.employeeid = Convert.ToInt32(dr["employeeid"]);
                    txbAnv.Text = Convert.ToString(dr["employeeid"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                sql.conn.Close();
                sql.conn.Dispose();
            }
        } 
        
        //Uppdatera information om employee
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Deklarerar info
            employ.employeeid = Convert.ToInt32(lsbEmployee.SelectedItem.Value);
            int employteeid = Convert.ToInt32(employ.employeeid);
            employ.name = txbName.Text;
            string name = employ.name.ToString();
            employ.surname = txbSurname.Text;
            string surname = employ.surname.ToString();
            employ.initials = txbInitials.Text;
            string initials = employ.initials.ToString();
            employ.admin = cbxAdmin.Checked;
            bool admin = Convert.ToBoolean(employ.admin);

            employ.updateEmployee(employteeid, name, surname, initials, admin);
            lsbEmployee.Items.Clear();
            clearTextbox();
            fill();
        }

        //Lägg till ny employee
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Deklarerar info från textboxen
            employ.name = txbName.Text;
            string name = employ.name.ToString();
            employ.surname = txbSurname.Text;
            string surname = employ.surname.ToString();
            employ.initials = txbInitials.Text;
            string initials = employ.initials.ToString();
            employ.admin = cbxAdmin.Checked;
            bool admin = Convert.ToBoolean(employ.admin);

            employ.saveEmployee(name, surname, initials, admin);
            lsbEmployee.Items.Clear();
            clearTextbox();
            fill();
        }

        //Radera employee
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            employ.employeeid = Convert.ToInt32(lsbEmployee.SelectedItem.Value);
            int employeeid = Convert.ToInt32(employ.employeeid);

            employ.removeEmployee(employeeid);
            lsbEmployee.Items.Clear();          
            clearTextbox();
            fill();
        }

        //Töm fälten 
        protected void btnEmptyField_Click(object sender, EventArgs e)
        {
            //tömmer textboxrarna
            txbName.Text = string.Empty;
            txbSurname.Text = string.Empty;
            txbInitials.Text = string.Empty;
            cbxAdmin.Checked = false;
        }
    
        //Dropdown med alternativ 
        protected void drpAlternativ_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Lägg till ny inloggning för Employee
        protected void btnUsername_Click(object sender, EventArgs e)
        {
            if (txbPass.Text == txbPass2.Text)
            {
                employ.employeeid = Convert.ToInt32(txbAnv.Text);
                int employeeid = Convert.ToInt32(employ.employeeid);
                employ.pass = txbPass2.Text;
                string pass = employ.pass;

                employ.saveInlogg(pass, employeeid);
            }

            else
            {

            }
        }        
        
        //Uppdatera lösenord
        protected void btnUpdateName_Click(object sender, EventArgs e)
        {
            if (txbPass.Text == txbPass2.Text)
            {
                employ.employeeid = Convert.ToInt32(txbAnv.Text);
                int employeeid = Convert.ToInt32(employ.employeeid);
                employ.pass = txbPass2.Text;
                string pass = employ.pass;

                employ.updatePassword(pass, employeeid);
            }

            else
            {

            }
        }

        //Metod: Fyll listbox
        public void fill()
      {
            Employee e = new Employee();
            List<Employee> aktuellEmployee = e.showEmployee();

            //Visa namn på familj i listbox         
            lsbEmployee.DataSource = aktuellEmployee;
            lsbEmployee.DataTextField = "name" + "surname" + "initials" + "admin";
            lsbEmployee.DataValueField = "employeeid";
            lsbEmployee.Items.Add("nameSurnameInitialsAdmin");
            lsbEmployee.DataBind();

            //lsbEmployee.Items.Clear();
            //clearTextbox();
            //fill();
        }

        //Metod som fyller dropboxen med alternativ 
        public void choice()
        {
            drpAlternativ.Items.Add("--- Välj alternativ ---");
            drpAlternativ.Items.Add("Lägg till ny klient");
            drpAlternativ.Items.Add("Radera befintlig klient");
            drpAlternativ.Items.Add("Redigera befintlig klient");
        }

        //Metod: Radera boxarna
        public void clearTextbox()
        {
            txbName.Text = string.Empty;
            txbSurname.Text = string.Empty;
            txbInitials.Text = string.Empty;
            cbxAdmin.Checked = false;
            drpAlternativ.SelectedItem.Text = "-- Välj enhet --";
        }


    }
}