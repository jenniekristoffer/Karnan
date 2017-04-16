using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kärnan
{
    public partial class journal : System.Web.UI.Page
    {
         Unit unit = new Unit();
         Family family = new Family();
         SQL sql = new SQL();

        List<Unit> aktuellUnit = new List<Unit>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Visa enhetsnamn i DROPDOWNLIST 
                List<Unit> ut = unit.showUnit();
                drpEnhet.DataSource = ut;
                drpEnhet.DataTextField = "unitName";
                drpEnhet.DataValueField = "unitID";
                drpEnhet.DataBind();
                //drpEnhet.Items.Insert(0, "Val");


               //(Convert.ToInt32(unit.unitID)
               // List<Family> fy = family.showFamily(Convert.ToInt32(unit.unitID));

                //aktuelltbarn = (barn)cmb_vem.SelectedItem;
                // //cmb_vem.SelectedIndex = -1;

                // if (aktuelltbarn != null)
                // {
                //     //visa något
                // }
                //    aktuellUnit = (Unit)drpEnhet.SelectedItem;

                //if (unit.unitID == family.familyID)
                //{
                //List<Family> fy = family.showFamily(unit.unitID);
                //drpKlient.DataSource = fy;
                //drpKlient.DataTextField = family.showName;
                //drpKlient.DataValueField = "showName";
                //drpKlient.DataBind();
            }

            //}
        }

        //välj enhetdropdown
        protected void drpEnhet_SelectedIndexChanged(object sender, EventArgs e)
        {
            //aktuellgrupp = (grupper)listBox5.SelectedItem;

            //listBox6.DataSource = null;
            //listBox6.Items.Clear();
            //if (aktuellgrupp != null)
            //{
            //    listBox6.DataSource = (db.visaMedlemmariGrupp(aktuellgrupp.gruppid));
            //}

            //aktuellUnit = drpEnhet.SelectedItem;

            //aktuellUnit = drpEnhet.SelectedItem;

            if (drpEnhet.SelectedValue == "Blå")
            {
                //List<Family> fy = family.showFamily(unit.unitID);
                List<Family> fy = family.showFamily(Convert.ToInt32(unit.unitID));
                drpKlient.DataSource = fy;
                drpKlient.DataTextField = "showName";
                drpKlient.DataValueField = "familyID";
                drpKlient.DataBind();
                drpKlient.Items.Insert(0, "Valj");
            }

          //  List<Contest> list = c.getTimeToString(Convert.ToInt64(onlyId));


            //string a, b;
            //a = drpEnhet.SelectedValue.ToString();
            //b = drpEnhet.SelectedItem.Text;

            //if (a != "0")
            //{

            //    List<Family> fy = family.showFamily(unit.unitID);
            //    drpKlient.DataSource = fy;
            //    drpKlient.DataTextField = family.showName;
            //    drpKlient.DataValueField = "showName";
            //    drpKlient.DataBind();

            //}

        }

        //välj klientdropdown
        protected void drpKlient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }