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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Gör textboxrar oskrivbara
                enabled();

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
                string query = "SELECT employee.employeeid, name, surname, initials, admin, pass " +
                               "FROM employee " +
                               "WHERE employee.employeeid = "+ lsbEmployee.SelectedItem.Value;

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

        //Uppdatera anställd
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
                lblCorrekt.Text = "Användare är uppdaterad";
            }

            else
            {
                lblmeddelande.Text = "Du måste skriva samma lösenord två gånger";
            }
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
                employ.anv = txbAnv.Text;
                string anv = employ.anv.ToString();

                if (txbPass.Text == txbPass2.Text)
              {
                string crypt = Crypt.ComputeHash(txbPass.Text, "SHA512", null);
                employ.saveEmployee(name, surname, initials, admin, crypt);
                lsbEmployee.Items.Clear();
                clearTextbox();
                fill();
                lblCorrekt.Text = "Ny användare tillagd";      
            }

            else if (txbPass.Text != txbPass2.Text || txbPass.Text == string.Empty || txbPass2.Text == string.Empty)
            {
                lblmeddelande.Text = "Du måste skriva samma lösenord två gånger";
            }
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

        //Olika val visas olika alternativ
        protected void drpChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpChoice.SelectedItem.Value == "-1")
            {
                btnAdd.Visible = false;
                btnRemove.Visible = false;
                Button1.Visible = false;
                lsbEmployee.Enabled = false;
                txbName.Enabled = false;
                txbSurname.Enabled = false;
                txbInitials.Enabled = false;
                cbxAdmin.Enabled = false;
                txbAnv.Enabled = false;
                txbPass.Enabled = false;
                txbPass2.Enabled = false;
                clearTextbox();
            }

            else if (drpChoice.SelectedItem.Value == "1")
            {
                btnAdd.Visible = true;
                btnRemove.Visible = false;
                Button1.Visible = false;
                lsbEmployee.Enabled = false;
                txbName.Enabled = true;
                txbSurname.Enabled = true;
                txbInitials.Enabled = true;
                cbxAdmin.Enabled = true;
                txbAnv.Enabled = false;
                txbPass.Enabled = true;
                txbPass2.Enabled = true;
                clearTextbox();
            }

            else if (drpChoice.SelectedItem.Value == "2")
            {
                btnAdd.Visible = false;
                btnRemove.Visible = false;
                Button1.Visible = true;
                lsbEmployee.Enabled = true;
                txbName.Enabled = true;
                txbSurname.Enabled = true;
                txbInitials.Enabled = true;
                cbxAdmin.Enabled = true;
                txbAnv.Enabled = false;
                txbPass.Enabled = true;
                txbPass2.Enabled = true;
                clearTextbox();

            }

            else if (drpChoice.SelectedItem.Value == "3")
            {
                btnAdd.Visible = false;
                btnRemove.Visible = true;
                Button1.Visible = false;
                lsbEmployee.Enabled = true;
                txbName.Enabled = true;
                txbSurname.Enabled = true;
                txbInitials.Enabled = true;
                cbxAdmin.Enabled = true;
                txbAnv.Enabled = false;
                txbPass.Enabled = true;
                txbPass2.Enabled = true;
                txbName.Enabled = false;
                txbSurname.Enabled = false;
                txbInitials.Enabled = false;
                cbxAdmin.Enabled = false;
                txbAnv.Enabled = false;
                txbPass.Enabled = false;
                txbPass2.Enabled = false;
            }
        }

        //Metod: Fyll listbox
        public void fill()
        {
            string admin = Convert.ToString(employ.admin);
            string ad = admin = "Admin";
            if (employ.admin == true)
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
            lsbEmployee.DataTextField = "name" + "surname" + "initials" + ad.ToString() + "employeeid";
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
            txbAnv.Text = "Genereras automatiskt";
            txbPass.Text = string.Empty;
            txbPass2.Text = string.Empty;
            lblCorrekt.Text = string.Empty;
            lblmeddelande.Text = string.Empty;
        }

        //Metod: gör textboxrar ovaldbara
        public void enabled()
        {
            btnAdd.Visible = false;
            btnRemove.Visible = false;
            Button1.Visible = false;
            lsbEmployee.Enabled = false;
            txbName.Enabled = false;
            txbSurname.Enabled = false;
            txbInitials.Enabled = false;
            cbxAdmin.Enabled = false;
            txbAnv.Enabled = false;
            txbPass.Enabled = false;
            txbPass2.Enabled = false;
        }
    }
}