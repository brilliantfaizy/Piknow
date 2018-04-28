using Portal.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class Government : System.Web.UI.Page
    {
        protected OtherRepo otherRepos;
        public Government()
        {
            otherRepos = new OtherRepo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string username = txt_usernameLogin.Value;
            string password = txt_passwordLogin.Value;

            if ((!string.IsNullOrWhiteSpace(username)) && (!string.IsNullOrWhiteSpace(password)))
            {
                if (otherRepos.Authentication(username, password))
                {
                    FormsAuthentication.RedirectFromLoginPage(username, Persist.Checked);
                    string ReturnUrl = Request.QueryString["ReturnUrl"];
                    Session["userType"] = "government";
                    if ((!string.IsNullOrWhiteSpace(ReturnUrl)))
                    {
                        Response.Redirect(ReturnUrl.Trim());
                    }
                    else
                    {
                        Response.Redirect("Companies.aspx");
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid username or password.');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Username and password are required.');", true);
            }
        }

    }
}