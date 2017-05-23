using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kärnan
{
    public partial class adminEmployeee : System.Web.UI.Page
    {
        Employee employ = new Employee();
        SQL sql = new SQL();
        Client family = new Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Fyll listboxen
                fill();

                btnAdd.Visible = false;
                btnRemove.Visible = false;
                //btnUpdate.Visible = false;
                lsbEmployee.Enabled = false;

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
                string query = "SELECT employee.employeeid, name, surname, initials, admin, pass " +
                           "FROM employee, userpass " +
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
                    txbAnv.Text = Convert.ToString(dr["employeeid"]);
                    txbPass.Text = dr["pass"].ToString();
                    txbPass2.Text = dr["pass"].ToString();
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

        //Töm fälten 
        protected void btnEmptyField_Click(object sender, EventArgs e)
        {
            //tömmer textboxrarna
            txbName.Text = string.Empty;
            txbSurname.Text = string.Empty;
            txbInitials.Text = string.Empty;
            cbxAdmin.Checked = false;
            txbPass.Text = string.Empty;
            txbPass2.Text = string.Empty;
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

            //if (txbPass.Text == txbPass2.Text)
            //{
                employ.anv = txbAnv.Text;
                int employeeid = Convert.ToInt32(employ.employeeid);
                employ.pass = txbPass.Text;
                string pass = employ.pass;

                employ.updatePassword(pass, employeeid);
                lblCorrekt.Text = "Information om anställd är uppdaterad";
            //}

            //else
            //{
            //    lblmeddelande.Text = "Du måste skriva samma lösenord två gånger";
            //}

        }

        //Lägg till ny employee
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txbName.Text == string.Empty || txbSurname.Text == string.Empty || txbInitials.Text == string.Empty)
            {
                lblmeddelande.Text = "Du måste fylla i information i textboxrarna";
            }
            else
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
                lblCorrekt.Text = "Ny användare tillagd";

          }

            if (txbPass.Text == txbPass2.Text)
            {
                employ.anv = txbAnv.Text;
                string anv = employ.anv;

                string crypt = Crypt.ComputeHash(txbPass.Text, "SHA512", null);
                employ.saveInlogg(crypt, anv);
            }

            else if (txbPass.Text != txbPass2.Text || txbPass.Text == string.Empty || txbPass2.Text == string.Empty)
            {
                lblmeddelande.Text = "Du måste skriva samma lösenord två gånger";
            }
        }

        //Radera employee
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            if (lsbEmployee.SelectedItem == null)
            {
                lblmeddelande.Text = "Välj anställd innan du raderar";
            }
            else
            {
                employ.employeeid = Convert.ToInt32(lsbEmployee.SelectedItem.Value);
                int employeeid = Convert.ToInt32(employ.employeeid);

                employ.removeEmployee(employeeid);
                lsbEmployee.Items.Clear();
                clearTextbox();
                fill();
                lblCorrekt.Text = "Anställd är nu raderad";
            }
        }

        //Uppdatera lösenord
        protected void btnUpdateName_Click(object sender, EventArgs e)
        {
            //    if (txbPass.Text == txbPass2.Text)
            //    {
            //        employ.employeeid = Convert.ToInt32(txbAnv.Text);
            //        int employeeid = Convert.ToInt32(employ.employeeid);
            //        employ.pass = txbPass2.Text;
            //        string pass = employ.pass;

            //        employ.updatePassword(pass, employeeid);
            //        lblCorrekt.Text = "Lösenordet är bytt";
            //    }

            //    else
            //    {
            //        lblmeddelande.Text = "Du måste skriva samma lösenord två gånger";
            //    }
        }

        //Metod: Fyll listbox
        public void fill()
        {
            string admin = Convert.ToString(employ.admin);
            string ad = admin = "Admin";
            if (employ.admin == true )
            {
                ad.ToString();
            }

            else
            {
                
            }

            Employee e = new Employee();
            List<Employee> aktuellEmployee = e.showEmployee();

            //Visa namn på familj i listbox         
            lsbEmployee.DataSource = aktuellEmployee;
            lsbEmployee.DataTextField = "name" + "surname" + "initials" + ad.ToString();
            lsbEmployee.DataValueField = "employeeid";
            lsbEmployee.DataBind();
        }

        //Metod: Radera boxarna
        public void clearTextbox()
        {
            txbName.Text = string.Empty;
            txbSurname.Text = string.Empty;
            txbInitials.Text = string.Empty;
            cbxAdmin.Checked = false;
            txbPass.Text = string.Empty;
            txbPass2.Text = string.Empty;
            txbAnv.Text = string.Empty;
            drpChoice.SelectedItem.Text = "-- Välj enhet --";
        }

        protected void drpChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpChoice.SelectedItem.Value == "-1")
            {
                btnAdd.Visible = false;
                btnRemove.Visible = false;
                //btnUpdate.Visible = false;
                lsbEmployee.Enabled = false;
            }

            else if (drpChoice.SelectedItem.Value == "1")
            {
                btnAdd.Visible = true;
                btnRemove.Visible = false;
                //btnUpdate.Visible = false;
                lsbEmployee.Enabled = false;
            }

            else if (drpChoice.SelectedItem.Value == "2")
            {
                btnAdd.Visible = false;
                btnRemove.Visible = false;
                //btnUpdate.Visible = true;
                lsbEmployee.Enabled = true;
            }

            else if (drpChoice.SelectedItem.Value == "3")
            {
                btnAdd.Visible = false;
                btnRemove.Visible = true;
                //btnUpdate.Visible = false;
                lsbEmployee.Enabled = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
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

            if (txbPass.Text == txbPass2.Text)
            {
                employ.anv = txbAnv.Text;
                int employeeid = Convert.ToInt32(employ.employeeid);
                employ.pass = txbPass2.Text;
                string pass = employ.pass;

                employ.updatePassword(pass, employeeid);
                lblCorrekt.Text = "Lösenordet är bytt";
            }

            else
            {
                lblmeddelande.Text = "Du måste skriva samma lösenord två gånger";
            }
        }
    }
}