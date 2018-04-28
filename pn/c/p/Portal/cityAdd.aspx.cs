using Portal.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class cityAdd : System.Web.UI.Page
    {
        protected CitiesRepo CitiesRepo;
        public cityAdd()
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
                
            }
        }
        protected void addCity_Click(object sender, EventArgs e)
        {
            string cityName = txt_cityName.Value;
            if (string.IsNullOrWhiteSpace(cityName))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('City name required.');", true);
                return;
            }

            string result = CitiesRepo.addCity(new tbl_cities
            {
                cityName = cityName,
                createdAt = DateTime.Now
            });

            if (result.Equals("true"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added Successfully.');", true);
                txt_cityName.Value = "";

            } else if(result.Equals("already")){

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('This city name is already exist.');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Something went wrong.');", true);
            }
        }
       
    }
}