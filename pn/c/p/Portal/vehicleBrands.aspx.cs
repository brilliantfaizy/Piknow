using Portal.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class vehicleBrands : System.Web.UI.Page
    {
        protected VehicleRepo VehicleRepos;

        public vehicleBrands()
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
                vehiclesBrandsList();
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            LinkButton data = (LinkButton)sender;
            string brand_id = data.CommandName;
            if (VehicleRepos.deleteVehicleBrand(int.Parse(brand_id)))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted successfully');", true);
                vehiclesBrandsList();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('you can not delete');", true);
            }
        }
        public void vehiclesBrandsList()
        {
            var data = VehicleRepos.getVehicleBrands();
            Brand_ListView.DataSource = data;
            Brand_ListView.DataBind();
        }
    }
}