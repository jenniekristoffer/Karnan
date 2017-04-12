using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kärnan
{
    public partial class journal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            drpEnhet.Items.Add("Blå");
            drpEnhet.Items.Add("Grön");
            drpEnhet.Items.Add("Gul");

            drpKlient.Items.Add("Mamma");
            drpKlient.Items.Add("Pappa");
            drpKlient.Items.Add("Barn");

            
        }
    }
}