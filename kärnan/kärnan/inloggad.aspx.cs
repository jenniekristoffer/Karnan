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
        //Employee loggedInAs;

        Employee employee = new Employee();

        protected void Page_Load(object sender, EventArgs e)
        {





            //            if (User.Identity.IsAuthenticated)
            //           {
            //           lblonline.Text = User.Identity.Name;
            //   }

            //           else
            //             {
            //lblInitials.Text = "No user identity available."; 
            //           }

            //Håller koll på vem det är som är inloggad    
            if (Session["anv"] != null)
            {
                //Employee employee = (Employee)Session["anv"];

                //employee.logginInfo(Session["anv"].ToString());
                //lblInitials.Text = employee.initials;
                //lblonline.Text = employee.anv;
            }





            //Student student = (Student)Session["UserAuthentication"];
            //lbStudentNum.Text = student.StudentNumber;
            //City.Text = student.City;
            //Postcode.Text = student.Postcode;




            //Employee em = new Employee();
            //var username = User.Identity.GetUserName();

            //Employee verifiedMember = em.logginInfo(username);
            //Session["verifiedMember"] = verifiedMember;

            //if (Session["verifiedMember"] != null)
            //{
            //    loggedInAs = (Employee)Session["verifiedMember"];
            //    Response.Write("<script>alert('Du är inloggas som ');</script>" + username);
            //}
        }

        protected void btnSkriv_Click(object sender, EventArgs e)
        {

            if (Session["anv"] != null)
            {
                //Employee employee = (Employee)Session["anv"];
                Response.Redirect("writeJournal.aspx");
                //employee.logginInfo(Session["anv"].ToString());
                //lblInitials.Text = employee.initials;
                //lblonline.Text = employee.anv;
            }
         

        }

        protected void btnLäs_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }

        protected void btnHantera_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }


        public void checkEmployee (string anv, string pass)
        {



//            SELECT initials, name, surname FROM employee, userpass
//WHERE employee.employeeid = userpass.employeeid
//AND anv = 'user5'
        }
    }
}