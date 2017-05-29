using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kärnan
{
    public partial class inloggad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Håller koll på vem det är som är inloggad    
            if (Session["employeeid"] != null)
            {

            }

        }
      }
    }