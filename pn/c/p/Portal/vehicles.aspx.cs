using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portal.repo;

namespace Portal
{
    public partial class vehicles : System.Web.UI.Page
    {
        protected VehicleRepo vehicleRepos;

        public vehicles()
        {

            vehicleRepos = new VehicleRepo();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userType"] != "admin")
            {
                Response.Redirect("login.aspx");
            }

            var data = vehicleRepos.getVehicles();
            User_ListView.DataSource = data;
            User_ListView.DataBind();
        }
    }
}