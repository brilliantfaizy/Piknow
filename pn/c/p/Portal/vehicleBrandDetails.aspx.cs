using Portal.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class vehicleBrandDetails : System.Web.UI.Page
    {
        protected VehicleRepo VehicleRepos;
        public vehicleBrandDetails()
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
                vehicleBrandDetail();
            }
        }
        protected void save_Click(object sender, EventArgs e)
        {
            string brand_id = Request.QueryString["brand_id"];
            if ((!string.IsNullOrEmpty(brand_id.Trim())) && (!brand_id.Trim().Equals("0")))
            {
                string brand = txt_brand.Value;
                string model = txt_model.Value;
                if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('All fields required.');", true);
                    return;
                }

                string result = VehicleRepos.updateVehicleBrand(new tbl_vehicleBrands
                {
                    brand_id = int.Parse(brand_id),
                    updatedAt = DateTime.Now,
                    brand = brand.Trim(),
                    model = model.Trim()
                });

                if (result.Equals("true"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated Successfully.');", true);
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
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Something went wrong.');", true);
            }
        }
        protected void reset_Click(object sender, EventArgs e)
        {
            vehicleBrandDetail();
        }

        public void vehicleBrandDetail()
        {
            try
            {
                string brand_id = Request.QueryString["brand_id"];
                if ((!string.IsNullOrEmpty(brand_id.Trim())) && (!brand_id.Trim().Equals("0")))
                {
                    var data = VehicleRepos.getVehicleBrand(int.Parse(brand_id));
                    txt_brand.Value = data.brand;
                    txt_model.Value = data.model;
                }
                else
                {
                    Response.Redirect("vehicleBrand.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("vehicleBrand.aspx");
            }
        }
    }
}
