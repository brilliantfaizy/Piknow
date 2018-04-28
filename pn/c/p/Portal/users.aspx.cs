using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portal.repo;

namespace Portal
{
    public partial class users : System.Web.UI.Page
    {
        protected usersRepo usersRepos;

        public users()
        {
            usersRepos = new usersRepo();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userType"] == "government")
            {
                Response.Redirect("login.aspx");
            }

            if (Session["userEmail"] != null && Session["userType"] == "company")
            {
                string userEmail = Session["userEmail"].ToString();
                var data = usersRepos.getCompanyUsers(userEmail);
                User_ListView.DataSource = data;
                User_ListView.DataBind();
            }
            else
            {
                var data = usersRepos.getUsers();
                User_ListView.DataSource = data;
                User_ListView.DataBind();
            }
        }

        public string getApproved(string approved)
        {
            if (approved.Equals("True"))
            {
                return "Approved";
            }
            else
            {
                return "Not Approved";
            }
        }

        /* protected void Unnamed_Click(object sender, EventArgs e)
         {
             LinkButton data = (LinkButton)sender;
             string abc = data.CommandName;
         }*/
    }
}