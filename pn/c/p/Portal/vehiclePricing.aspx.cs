using Portal.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class vehiclePricing : System.Web.UI.Page
    {
        protected VehicleRepo VehicleRepos;

        public vehiclePricing()
        {

            VehicleRepos = new VehicleRepo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userType"] != "admin")
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                vehiclesList();
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton data = (LinkButton)sender;
            string chargesID = data.CommandName;
            if (VehicleRepos.deleteVehiclePrice(int.Parse(chargesID)))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted successfully');", true);
                vehiclesList();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('you can not delete');", true);
            }
        }
        public void vehiclesList()
        {
            var data = VehicleRepos.getVehiclesPricing();
            Vehicles_ListView.DataSource = data;
            Vehicles_ListView.DataBind();
        }
    }
}