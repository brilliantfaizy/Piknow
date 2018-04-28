using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portal.repo;

namespace Portal
{
    public partial class CanceledTrips : System.Web.UI.Page
    {
        protected usersRepo usersRepos;

        public CanceledTrips()
        {
            
            usersRepos = new usersRepo();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userType"] != "admin")
            {
                Response.Redirect("login.aspx");
            }
           var data = usersRepos.getCanceledRides();
           User_ListView.DataSource = data;
           User_ListView.DataBind();
        }
    }
}