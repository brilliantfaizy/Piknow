using Portal.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class vehiclePriceAdd : System.Web.UI.Page
    {
        protected VehicleRepo VehicleRepo;
        public vehiclePriceAdd()
        {

            VehicleRepo = new VehicleRepo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userType"] != "admin")
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                vehicleDetail();
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            string charges = txt_charges.Value;
            if (string.IsNullOrWhiteSpace(charges))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('All fields required.');", true);
                return;
            }

            string type = "";

            if (VehicleTypeSedan.Checked)
            {
                type = "Sedan";
            }
            else if (VehicleTypeVan.Checked)
            {
                type = "Van";
            }
            else if (VehicleTypeBus.Checked)
            {
                type = "Bus";
            }

            bool VehicleTypeIsNormal = (VehicleTypeEconomy.Checked) ? true : false;

            if (type.ToLower().Trim().Equals("van") && (!VehicleTypeIsNormal))
            {
                VehicleTypeEconomy.Checked = true;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Luxury type not set for Van.');", true);
                return;
            }

            if (type.ToLower().Trim().Equals("bus") && (!VehicleTypeIsNormal))
            {
                VehicleTypeEconomy.Checked = true;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Luxury type not set for Bus.');", true);
                return;
            }

            string result = VehicleRepo.addVehiclePrice(new tbl_kmCharges
            {
                charges = charges,
                createdAt = DateTime.Now,
                type = type,
                VehicleTypeIsNormal = VehicleTypeIsNormal
            });

            if (result.Equals("true"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added successfully.');", true);
                vehicleDetail();
            }
            else if (result.Equals("already"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('This is already exist.');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Something went wrong.');", true);
            }
        }

        public void vehicleDetail()
        {
            try
            {
                VehicleTypeSedan.Checked = true;
                VehicleTypeEconomy.Checked = true;
            }
            catch (Exception)
            {

                Response.Redirect("vehiclePricing.aspx");
            }
        }
    }
}
