using Portal.repo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class CompanyForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_click(object sender, EventArgs e)
        {
            string email = txt_email_login.Text;

            if ((!string.IsNullOrWhiteSpace(email)))
            {
                CompanyRepo CompanyRepo = new CompanyRepo();
                string result = CompanyRepo.forgotPassword(email);
                if (result.Equals("true"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Password sent to your email address.');", true);
                    return;
                }
               
                if (result.Equals("wrong")){

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid email.');", true);
                    return;
                }

                if (result.Equals("false"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Something went wrong.');", true);
                    return;
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Email is required.');", true);
                return;
            }
        }

    }
}