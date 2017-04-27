using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kärnan
{
    public partial class Master2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Logga ut 
        protected void btnLoggaUt_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("startPage.aspx");
        }
    }
}