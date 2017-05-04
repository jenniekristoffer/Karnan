using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kärnan
{
    public partial class adminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Håller koll på vem det är som är inloggad    
            if (Session["employeeid"] != null)
            {

            }
        }

        protected void btnUnit_Click(object sender, EventArgs e)
        {
            if (Session["employeeid"] != null)
            {
                Response.Redirect("adminUnit.aspx");
            }
        }

        protected void btnFamily_Click(object sender, EventArgs e)
        {
            if (Session["employeeid"] != null)
            {
                Response.Redirect("adminFamily.aspx");
            }
        }

        protected void btnEmployee_Click(object sender, EventArgs e)
        {
            if (Session["employeeid"] != null)
            {
                Response.Redirect("adminEmployee.aspx");
            }
        }
    }
}