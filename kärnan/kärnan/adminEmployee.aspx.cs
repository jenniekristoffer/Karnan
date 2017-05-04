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

        protected void Page_Load(object sender, EventArgs e)
        {
            fillEmployeeList();
        }

        //Lägg till ny anställd
        protected void btnAddEmployee_Click(object sender, EventArgs e)
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
            DropDownList1.Items.Clear();
            fillEmployeeList();
        }

        //Radera anställd
        protected void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            employ.employeeid = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            int employeeid = Convert.ToInt32(employ.employeeid);

            employ.removeEmployee(employeeid);
            DropDownList1.Items.Clear();
            fillEmployeeList();
        }

        //Ändra information på anställd
        protected void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            //Deklarerar info
            employ.employeeid = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            int employteeid = Convert.ToInt32(employ.employeeid);
            employ.name = txbUpdateName.Text;
            string name = employ.name.ToString();
            employ.surname = txbUpdateSurname.Text;
            string surname = employ.surname.ToString();
            employ.initials = txbUpdateInitials.Text;
            string initials = employ.initials.ToString();
            employ.admin = cbxUpdateAdmin.Checked;
            bool admin = Convert.ToBoolean(employ.admin);

            employ.updateEmployee(employteeid, name, surname, initials, admin);

            DropDownList2.Items.Clear();
            fillEmployeeList();
            //lblCorrectMessage.Text = "Namnet på enheten är ändrad!";
            //txbChangeUnit.Text = string.Empty;
        }

        //_____________________________________________________TA BORT !!!!!???????
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        //Visa info från dropdown i textbox
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sql.conn.Open();

                string query = "SELECT employeeid, name, surname, initials, admin " +
                               "FROM employee " +
                               "WHERE employeeid = " + DropDownList2.SelectedItem.Value;

                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Parameters.AddWithValue("employeeid", DropDownList2.SelectedItem.Value);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Connection = sql.conn;

                NpgsqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txbUpdateName.Text = dr["name"].ToString();
                    txbUpdateSurname.Text = dr["surname"].ToString();
                    txbUpdateInitials.Text = dr["initials"].ToString();
                    cbxUpdateAdmin.Checked = Convert.ToBoolean(dr["admin"]);
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

        //Fyll dropdownlist:orna 
        public void fillEmployeeList()
        {
            //Visa namn på familj i dropdownlist1
            List<Employee> aktuellEmployee = employ.showEmployee();
            DropDownList1.DataSource = aktuellEmployee;
            DropDownList1.DataTextField = "name" + "surname" + "initials" + "admin";
            DropDownList1.DataValueField = "employeeid";
            DropDownList1.Items.Add("nameSurnameInitialsAdmin");
            DropDownList1.DataBind();

            //Visa namn på familj i dropdownlist2
            List<Employee> aktuellEmployee1 = employ.showEmployee();
            DropDownList2.DataSource = aktuellEmployee1;
            DropDownList2.DataTextField = "name" + "surname" + "initials" + "admin";
            DropDownList2.DataValueField = "employeeid";
            DropDownList2.Items.Add("nameSurnameInitialsAdmin");
            DropDownList2.DataBind();
        }
    }
}