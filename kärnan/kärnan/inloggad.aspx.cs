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
        Employee employee = new Employee();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Håller koll på vem det är som är inloggad    
            if (Session["employeeid"] != null)
            {
                if (employee.controllEmployee() == true)
                {
                    //btnHantera.Enabled = false;
                }


                //-------SKRIVER UT ID PÅ DEN INLOGGADE---------
                //lblonline.Text = Session["employeeid"].ToString();
            }

        }

        protected void btnSkriv_Click(object sender, EventArgs e)
        {
            if (Session["employeeid"] != null)
            {
                Response.Redirect("writeJournal.aspx");
            }
        }

        protected void btnLäs_Click(object sender, EventArgs e)
        {
            if (Session["employeeid"] != null)
            {
                Response.Redirect("readJournal.aspx");
            }            
        }

        protected void btnHantera_Click(object sender, EventArgs e)
        {
            if (Session["employeeid"] != null)
            {
               Response.Redirect("adminPage.aspx");
            }            
        }
      }
    }