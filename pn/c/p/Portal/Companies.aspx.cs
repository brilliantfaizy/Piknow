using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portal.repo;

namespace Portal
{
    public partial class Companies : System.Web.UI.Page
    {
        protected CompanyRepo CompanyRepos;

        public Companies()
        {
            CompanyRepos = new CompanyRepo();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["userType"] != "admin")
            //{
            //    Response.Redirect("login.aspx");
            //}

            if (Session["userType"] == "admin")
            {
                var data = CompanyRepos.getCompanies();
                Companies_ListView.DataSource = data;

            }
            else if (Session["userType"] == "government")
            {
                var data = CompanyRepos.getGovernmentCompanies();
                Companies_ListView.DataSource = data;
            }
            
            Companies_ListView.DataBind();
        }
    }
}