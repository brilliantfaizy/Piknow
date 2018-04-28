using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portal.repo;

namespace Portal
{
    public partial class vehicleDetail : System.Web.UI.Page
    {
        protected VehicleRepo VehicleRepos;
        public vehicleDetail()
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
                getVehicleDetail();
            }

        }

        public void getVehicleDetail()
        {
            try
            {
                string vehicle_id = Request.QueryString["vehicle_id"];
                if ((!string.IsNullOrEmpty(vehicle_id.Trim())) && (!vehicle_id.Trim().Equals("0")))
                {
                    var data = VehicleRepos.getVehicle(int.Parse(vehicle_id));
                    //txt_brand.Value = data.brand;
                    //txt_color.Value = data.color;
                    //txt_insurance.Value = data.insuranceNumber;
                    //txt_model.Value = data.model;
                    //txt_plate.Value = data.plateNumber;

                    //if (data.type.ToLower().Trim().Equals("sedan"))
                    //{
                    //    VehicleTypeBus.Checked = false;
                    //    VehicleTypeSedan.Checked = true;
                    //    VehicleTypeVan.Checked = false;
                    //}
                    //else if (data.type.ToLower().Trim().Equals("van"))
                    //{
                    //    VehicleTypeBus.Checked = false;
                    //    VehicleTypeSedan.Checked = false;
                    //    VehicleTypeVan.Checked = true;
                    //}
                    //else if (data.type.ToLower().Trim().Equals("bus"))
                    //{
                    //    VehicleTypeBus.Checked = true;
                    //    VehicleTypeSedan.Checked = false;
                    //    VehicleTypeVan.Checked = false;
                    //}

                    if (data.approved == true)
                    {
                        vehicleApproved.Checked = true;
                        vehicleNotApproved.Checked = false;
                    }
                    else if (data.approved == false)
                    {
                        vehicleApproved.Checked = false;
                        vehicleNotApproved.Checked = true;
                    }

                    //if (data.VehicleTypeIsNormal == true)
                    //{
                    //    VehicleTypeEconomy.Checked = true;
                    //    VehicleTypeLuxury.Checked = false;
                    //}
                    //else if (data.VehicleTypeIsNormal == false)
                    //{
                    //    VehicleTypeEconomy.Checked = false;
                    //    VehicleTypeLuxury.Checked = true;
                    //}
                }
                else
                {
                    Response.Redirect("vehicles.aspx");
                }
            }
            catch (Exception)
            {

                Response.Redirect("vehicles.aspx");
            }
        }

        protected void resetVehicle_Data(object sender, EventArgs e)
        {
            getVehicleDetail();
        }

        protected void saveVehicle_Data(object sender, EventArgs e)
        {
            string vehicle_id = Request.QueryString["vehicle_id"];
            if ((!string.IsNullOrEmpty(vehicle_id.Trim())) && (!vehicle_id.Trim().Equals("0")))
            {
                //string type = "";

                //if (VehicleTypeSedan.Checked)
                //{
                //    type = "Sedan";
                //}
                //else if (VehicleTypeVan.Checked)
                //{
                //    type = "Van";
                //}
                //else if (VehicleTypeBus.Checked)
                //{
                //    type = "Bus";
                //}

               // bool VehicleTypeIsNormal = (VehicleTypeEconomy.Checked) ? true : false;

                //if (type.ToLower().Trim().Equals("van") && (!VehicleTypeIsNormal))
                //{
                //    VehicleTypeEconomy.Checked = true;
                //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Luxury type not set for Van.');", true);
                //    return;
                //}

                //if (type.ToLower().Trim().Equals("bus") && (!VehicleTypeIsNormal))
                //{
                //    VehicleTypeEconomy.Checked = true;
                //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Luxury type not set for Bus.');", true);
                //    return;
                //}

               // string brand = txt_brand.Value;
                //string model = txt_model.Value;
                //string color = txt_color.Value;
               // string insuranceNumber = txt_insurance.Value;
                //string plateNumber = txt_plate.Value;
                bool approved = (vehicleApproved.Checked) ? true : false;

                //if ((string.IsNullOrWhiteSpace(type)) ||
                //    (string.IsNullOrWhiteSpace(brand)) ||
                //    (string.IsNullOrWhiteSpace(model)) ||
                //    (string.IsNullOrWhiteSpace(color)) ||
                //    (string.IsNullOrWhiteSpace(insuranceNumber)) ||
                //    (string.IsNullOrWhiteSpace(plateNumber)))
                //{

                //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('All fields required.');", true);
                //    return;
                //}

                if (VehicleRepos.updateVehicleInfo(new tbl_vehicle
                {
                    vehicle_id = int.Parse(vehicle_id),
                    approved = approved,
                    //brand = brand,
                   // color = color,
                    //insuranceNumber = insuranceNumber,
                   // model = model,
                   // plateNumber = plateNumber,
                  //  type = type,
                    //VehicleTypeIsNormal = VehicleTypeIsNormal
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
    }
}