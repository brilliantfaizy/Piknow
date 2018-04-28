using Portal.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class login : System.Web.UI.Page
    {
        protected usersRepo usersRepos;
        public login()
        {
            usersRepos = new usersRepo();
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
                if (usersRepos.Authentication(username, password))
                {
                    FormsAuthentication.RedirectFromLoginPage(username, Persist.Checked);
                    string ReturnUrl = Request.QueryString["ReturnUrl"];
                    Session["userType"] = "admin";
                    if ((!string.IsNullOrWhiteSpace(ReturnUrl)))
                    {
                        Response.Redirect(ReturnUrl.Trim());
                    }
                    else
                    {
                        Response.Redirect("users.aspx");
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