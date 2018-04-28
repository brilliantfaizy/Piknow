using Portal.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class cityPriceDetails : System.Web.UI.Page
    {
        protected CitiesRepo CitiesRepo;
        public cityPriceDetails()
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
        protected void save_Click(object sender, EventArgs e)
        {
            string chargesID = Request.QueryString["chargesID"];
            if ((!string.IsNullOrEmpty(chargesID.Trim())) && (!chargesID.Trim().Equals("0")))
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

                string result = CitiesRepo.updateCityPrice(new tbl_autoCharges
                {
                    charges = charges,
                    chargesID = int.Parse(chargesID),
                    updatedAt = DateTime.Now,
                    from_city = int.Parse(fromCity_dropDown.SelectedValue),
                    to_city = int.Parse(toCity_dropDown.SelectedValue),
                    VehicleTypeIsNormal = VehicleTypeIsNormal,
                    type = type
                });

                if (result.Equals("true"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated Successfully.');", true);
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
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Something went wrong.');", true);
            }
        }
        protected void reset_Click(object sender, EventArgs e)
        {
            cityDetail();
        }

        public void cityDetail()
        {
            try
            {
                string chargesID = Request.QueryString["chargesID"];
                if ((!string.IsNullOrEmpty(chargesID.Trim())) && (!chargesID.Trim().Equals("0")))
                {
                    var cities = CitiesRepo.getCities();
                    var data = CitiesRepo.getCityPrice(int.Parse(chargesID));
                    
                    fromCity_dropDown.DataSource = cities;
                    fromCity_dropDown.DataTextField = "cityName";
                    fromCity_dropDown.DataValueField = "cityID";
                    fromCity_dropDown.SelectedValue = data.tbl_cities.cityID.ToString();
                    fromCity_dropDown.DataBind();
                    
                    toCity_dropDown.DataSource = cities;
                    toCity_dropDown.DataTextField = "cityName";
                    toCity_dropDown.DataValueField = "cityID";
                    toCity_dropDown.SelectedValue = data.tbl_cities1.cityID.ToString();
                    toCity_dropDown.DataBind();
                    txt_charges.Value = data.charges;

                    if (data.type.ToLower().Trim().Equals("sedan"))
                    {
                        VehicleTypeBus.Checked = false;
                        VehicleTypeSedan.Checked = true;
                        VehicleTypeVan.Checked = false;
                    }
                    else if (data.type.ToLower().Trim().Equals("van"))
                    {
                        VehicleTypeBus.Checked = false;
                        VehicleTypeSedan.Checked = false;
                        VehicleTypeVan.Checked = true;
                    }
                    else if (data.type.ToLower().Trim().Equals("bus"))
                    {
                        VehicleTypeBus.Checked = true;
                        VehicleTypeSedan.Checked = false;
                        VehicleTypeVan.Checked = false;
                    }

                    if (data.VehicleTypeIsNormal == true)
                    {
                        VehicleTypeEconomy.Checked = true;
                        VehicleTypeLuxury.Checked = false;
                    }
                    else if (data.VehicleTypeIsNormal == false)
                    {
                        VehicleTypeEconomy.Checked = false;
                        VehicleTypeLuxury.Checked = true;
                    }

                }
                else
                {
                    Response.Redirect("CitiesPricing.aspx");
                }
            }
            catch (Exception)
            {

                Response.Redirect("CitiesPricing.aspx");
            }
        }
    }
}
