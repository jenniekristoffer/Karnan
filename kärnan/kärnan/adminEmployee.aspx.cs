using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kärnan
{
    public partial class adminEmployee : System.Web.UI.Page
    {
        Employee employ = new Employee();

        protected void Page_Load(object sender, EventArgs e)
        {

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
        }
    }
}