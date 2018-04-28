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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected usersRepo usersRepos;
        public ChangePassword()
        {
            usersRepos = new usersRepo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                txt_userNumber.Value = Request.QueryString["number"];
                txt_userToken.Value = Request.QueryString["token"];
            }
            catch (Exception)
            {
                Response.Redirect("page_404.html");
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            string password = txt_passwordLogin.Value;
            string cpassword = txt_cpasswordLogin.Value;
            string userNumber = txt_userNumber.Value;
            string userToken = txt_userToken.Value;

            if ((!string.IsNullOrWhiteSpace(password)) && (!string.IsNullOrWhiteSpace(cpassword)) && password.Equals(cpassword))
            {
                if ((!string.IsNullOrWhiteSpace(userNumber)) && (!string.IsNullOrWhiteSpace(userToken)))
                {
                    userToken = txt_userToken.Value.Replace(" ","+");
                    if (!userNumber.Contains("+"))
                    {
                        userNumber = "+" + userNumber.Trim();
                    }

                    if (usersRepos.tokenValidate(userNumber, userToken))
                    {
                        if (usersRepos.updateUserPassword(userNumber, password))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Your password successfully changed.');", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Something went wrong.');", true);
                        }

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid number or token.');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid number or token.');", true);
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Password and confirm password are required and must be same.');", true);
            }
        }

    }
}