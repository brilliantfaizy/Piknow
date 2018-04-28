
using Portal.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class cityDetails : System.Web.UI.Page
    {
        protected CitiesRepo CitiesRepo;
        public cityDetails()
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
        protected void saveCity_Profile(object sender, EventArgs e)
        {
            string cityID = Request.QueryString["cityID"];
            if ((!string.IsNullOrEmpty(cityID.Trim())) && (!cityID.Trim().Equals("0")))
            {
                string cityName = txt_cityName.Value;
                if (string.IsNullOrWhiteSpace(cityName))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('City name required.');", true);
                    return;
                }

                if (CitiesRepo.updateCity(new tbl_cities
                {
                    cityID = int.Parse(cityID),
                    cityName = cityName,
                    updatedAt = DateTime.Now
                }))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated Successfully.');", true);
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
        protected void resetCity_Profile(object sender, EventArgs e)
        {
            cityDetail();
        }

        public void cityDetail()
        {
            try
            {
                string cityID = Request.QueryString["cityID"];
                if ((!string.IsNullOrEmpty(cityID.Trim())) && (!cityID.Trim().Equals("0")))
                {
                    var data = CitiesRepo.getCity(int.Parse(cityID));
                    txt_cityName.Value = data.cityName;
                }
                else
                {
                    Response.Redirect("Cities.aspx");
                }
            }
            catch (Exception)
            {

                Response.Redirect("Cities.aspx");
            }
        }
    }
}