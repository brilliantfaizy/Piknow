using Portal.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class cityPriceAdd : System.Web.UI.Page
    {
        protected CitiesRepo CitiesRepo;
        public cityPriceAdd()
        {
            
            CitiesRepo = new CitiesRepo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userType"] != "admin")
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                cityDetail();
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

            string result = CitiesRepo.addCityPrice(new tbl_autoCharges
            {
                charges = charges,
                createdAt = DateTime.Now,
                from_city = int.Parse(fromCity_dropDown.SelectedValue),
                to_city = int.Parse(toCity_dropDown.SelectedValue),
                type = type,
                VehicleTypeIsNormal = VehicleTypeIsNormal
            });

            if (result.Equals("true"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added successfully.');", true);
                cityDetail();
            }
            else if (result.Equals("already"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('This city name is already exist.');", true);
            }
            else if (result.Equals("same"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Same city names not allowed.');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Something went wrong.');", true);
            }
        }

        public void cityDetail()
        {
            try
            {
                var cities = CitiesRepo.getCities();
                fromCity_dropDown.DataSource = cities;
                fromCity_dropDown.DataTextField = "cityName";
                fromCity_dropDown.DataValueField = "cityID";
                fromCity_dropDown.DataBind();

                toCity_dropDown.DataSource = cities;
                toCity_dropDown.DataTextField = "cityName";
                toCity_dropDown.DataValueField = "cityID";
                toCity_dropDown.DataBind();
                txt_charges.Value = "";
                VehicleTypeSedan.Checked = true;
                VehicleTypeEconomy.Checked = true;
            }
            catch (Exception)
            {

                Response.Redirect("CitiesPricing.aspx");
            }
        }
    }
}
