using Portal.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class _default : System.Web.UI.Page
    {
        protected OtherRepo OtherRepos;

        public _default()
        {
            OtherRepos = new OtherRepo();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("users.aspx");
            if (Session["userType"] != "admin")
            {
                Response.Redirect("login.aspx");
            }

            lbl_canceledTrips.Text = OtherRepos.canceledTrips().ToString();
            lbl_companyUsers.Text = OtherRepos.companyUsers().ToString();
            lbl_pendingTrips.Text = OtherRepos.pendingTrips().ToString();
            lbl_successfulTrips.Text = OtherRepos.completedTrips().ToString();
            lbl_totalUsers.Text = OtherRepos.totalUsers().ToString();
            lbl_governmentUsers.Text = OtherRepos.governmentUsers().ToString();
        }
    }
}