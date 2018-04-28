using Portal.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class vehicleBrandAdd : System.Web.UI.Page
    {
        protected VehicleRepo VehicleRepo;
        public vehicleBrandAdd()
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
                vehiclebrandDetail();
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            string brand = txt_brand.Value;
            string model = txt_model.Value;
            if (string.IsNullOrWhiteSpace(brand) || string.IsNullOrWhiteSpace(model))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('All fields required.');", true);
                return;
            }

            string result = VehicleRepo.addVehicleBrand(new tbl_vehicleBrands
            {
                createdAt = DateTime.Now,
                brand = brand.Trim(),
                model = model.Trim()
            });

            if (result.Equals("true"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added successfully.');", true);
                vehiclebrandDetail();
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

        public void vehiclebrandDetail()
        {
            try
            {
                txt_brand.Value = "";
                txt_model.Value = "";
            }
            catch (Exception)
            {
                Response.Redirect("vehicleBrands.aspx");
            }
        }
    }
}
