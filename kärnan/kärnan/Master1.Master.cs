using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kärnan
{
    public partial class Master1 : System.Web.UI.MasterPage
    {
        loggin ln = new loggin();
        List<loggin> listLoggin = new List<loggin>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLoggin_Click(object sender, EventArgs e)
        {

            // deklarerar info från textboxrarna
            ln.user =  txbAnv.Text;

            //jc.incident = txbincident.InnerText;
            //string incident = jc.incident.ToString();
            //jc.journalnote = txbJournal.InnerText;
            //string journalnote = jc.journalnote.ToString();

            if ()
            {


            }
        }
    }
}