using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Webservice.Repo;
using System.Web.Script.Services;
using Webservice.helper;
using Webservice.Models;
using System.Globalization;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;


namespace Webservice
{
    [WebService(Namespace = "http://service.piknow.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class services : System.Web.Services.WebService
    {
        public services()
        {
        }

        #region Pick Now
        [WebMethod(Description = "This method(type=post), use for create a new user by (country = required,birthday = required, gender = required, email = required, full_name = required, password = required, number = required, deviceToken = required , profile_pic = required, cnic_front = required, cnic_back = required).")]
      [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
      public void register()
        {
            try
            {
                HttpRequest Request = HttpContext.Current.Request;
                //string service = string.IsNullOrEmpty(Request.Form["service"]) ? "" : Request.Form["service"].Trim();
                string number = string.IsNullOrEmpty(Request.Form["number"]) ? "" : Request.Form["number"].Trim();
                string email = string.IsNullOrEmpty(Request.Form["email"]) ? "" : Request.Form["email"].Trim();
                string country = string.IsNullOrEmpty(Request.Form["country"]) ? "" : Request.Form["country"].Trim();
                string full_name = string.IsNullOrEmpty(Request.Form["full_name"]) ? "" : Request.Form["full_name"].Trim();
                string password = string.IsNullOrEmpty(Request.Form["password"]) ? "" : Request.Form["password"].Trim();
                string deviceToken = string.IsNullOrEmpty(Request.Form["deviceToken"]) ? "" : Request.Form["deviceToken"].Trim();
                string birthday = string.IsNullOrEmpty(Request.Form["birthday"]) ? "" : Request.Form["birthday"].Trim();
                string gender = string.IsNullOrEmpty(Request.Form["gender"]) ? "" : Request.Form["gender"].Trim();
                HttpPostedFile profile_pic = Request.Files["profile_pic"];
                HttpPostedFile cnic_frant = Request.Files["cnic_front"];
                HttpPostedFile cnic_back = Request.Files["cnic_back"];

                if (string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(birthday) || string.IsNullOrWhiteSpace(number) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(full_name) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(deviceToken) || profile_pic == null || cnic_frant == null || cnic_back == null)
                {
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(new ErrorMessage { error = "all fields required." }));
                }
                else
                {

                if (!number.Contains("+"))
                {
                    number = "+" + number;
                }
                UserRepo userRepo = new UserRepo();

               /* if (service.Equals("set"))
                {*/

                    tbl_profile data = new tbl_profile
                    {
                        email = email,
                        full_name = full_name,
                        number = number,
                        password = password,
                        status = "1",
                        approved = false,
                        type = "1",
                        deviceToken = deviceToken,
                        createdAt = DateTime.Now,
                        country = country,
                        birthday = birthday.Trim(),
                        gender = gender.Trim()
                        //fastTrackIsAuto = true,
                        //receive_email = "1"
                    };

                    var result = userRepo.Registration(data, profile_pic,cnic_frant,cnic_back);
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(result));
                }

                /*}
                else if (service.Equals("get"))
                {
                    var result = userRepo.checkUserExist(ema);
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write( js.Serialize(result) );
                }*/
            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = "" + ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=post), use for edit user details by (country = required,birthday = required, gender = required, full_name = required, password = required,user_id = required,number = required,profile_pic = required, cnic_front = required, cnic_back = required).")] //, accountHolder = optional,accountNumber = optional,bankName = optional,shabaNumber = optional
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void editProfile()
        {
            try
            {
                HttpRequest Request = HttpContext.Current.Request;
                
                //string email = string.IsNullOrEmpty(Request.Form["email"]) ? "" : Request.Form["email"].Trim();
                string full_name = string.IsNullOrEmpty(Request.Form["full_name"]) ? "" : Request.Form["full_name"].Trim();
                string country = string.IsNullOrEmpty(Request.Form["country"]) ? "" : Request.Form["country"].Trim();
                string birthday = string.IsNullOrEmpty(Request.Form["birthday"]) ? "" : Request.Form["birthday"].Trim();
                string gender = string.IsNullOrEmpty(Request.Form["gender"]) ? "" : Request.Form["gender"].Trim();
                string password = string.IsNullOrEmpty(Request.Form["password"]) ? "" : Request.Form["password"].Trim();
                //string receive_email = string.IsNullOrEmpty(Request.Form["receive_email"]) ? "" : Request.Form["receive_email"].Trim();
                string number = string.IsNullOrEmpty(Request.Form["number"]) ? "" : Request.Form["number"].Trim();
                int user_id = string.IsNullOrEmpty(Request.Form["user_id"]) ? 0 : Convert.ToInt32(Request.Form["user_id"].Trim());
                HttpPostedFile profile_pic = Request.Files["profile_pic"];
                HttpPostedFile cnic_frant = Request.Files["cnic_front"];
                HttpPostedFile cnic_back = Request.Files["cnic_back"];

                if (string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(birthday) || string.IsNullOrWhiteSpace(number) || string.IsNullOrWhiteSpace(country) || string.IsNullOrWhiteSpace(full_name) || string.IsNullOrWhiteSpace(password))
                {
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(new ErrorMessage { error = "all fields required." }));
                }
                else
                {

                    UserRepo userRepo = new UserRepo();
                    tbl_profile data = new tbl_profile
                    {
                        birthday = birthday.Trim(),
                        //email = email.Trim(),
                        country = country.Trim(),
                        full_name = full_name.Trim(),
                        gender = gender.Trim(),
                        password = password.Trim(),
                        //receive_email = receive_email.Trim(),
                        number = number.Trim(),
                        user_id = user_id
                    };

                    /* string accountHolder = string.IsNullOrEmpty(Request.Form["accountHolder"]) ? "" : Request.Form["accountHolder"].Trim();
                     string accountNumber = string.IsNullOrEmpty(Request.Form["accountNumber"]) ? "" : Request.Form["accountNumber"].Trim();
                     string bankName = string.IsNullOrEmpty(Request.Form["bankName"]) ? "" : Request.Form["bankName"].Trim();
                     string shabaNumber = string.IsNullOrEmpty(Request.Form["shabaNumber"]) ? "" : Request.Form["shabaNumber"].Trim();

                     tbl_accountDetail accountData = new tbl_accountDetail
                     {
                         accountHolder = accountHolder,
                         accountNumber = accountNumber,
                         bankName = bankName,
                         shabaNumber = shabaNumber,
                         user_id = user_id
                     };*/

                    var result = userRepo.editProfile(data, profile_pic, cnic_frant, cnic_back);
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(result));
                }

                //HttpPostedFile id_card_back = Request.Files["id_card_back"];
                //HttpPostedFile id_card_front = Request.Files["id_card_front"];
                
            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = "" + ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=post), use for update user latLong. Parameters (user_id = required,latLong = required")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void userLocation()
        {
            try
            {
                HttpRequest Request = HttpContext.Current.Request;
                string latLong = string.IsNullOrEmpty(Request.Form["latLong"]) ? "" : Request.Form["latLong"].Trim();
                string user_id = string.IsNullOrEmpty(Request.Form["user_id"]) ? "" : Request.Form["user_id"].Trim();

                if (string.IsNullOrWhiteSpace(user_id) || string.IsNullOrWhiteSpace(latLong))
                {
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(new ErrorMessage { error = "all fields required." }));
                }
                else
                {
                    UserRepo userRepo = new UserRepo();
                    var result = userRepo.updateLocation(user_id, latLong);
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(result));
                }

            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = "" + ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(CacheDuration = 30, Description = "This method(type=post), use for authenticate user by (email = required, password = required, deviceToken = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void login()
        {
            try
            {
                HttpRequest Request = HttpContext.Current.Request;
                string email = string.IsNullOrEmpty(Request.Form["email"]) ? "" : Request.Form["email"].Trim();
                string password = string.IsNullOrEmpty(Request.Form["password"]) ? "" : Request.Form["password"].Trim();
                string deviceToken = string.IsNullOrEmpty(Request.Form["deviceToken"]) ? "" : Request.Form["deviceToken"].Trim();
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(deviceToken))
                {
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(new ErrorMessage { error = "all fields required." }));
                }
                else
                {
                    /*if (!number.Contains("+"))
               {
                   number = "+" + number;
               }*/

                    UserRepo userRepo = new UserRepo();
                    var result = userRepo.Authentication(email, password, deviceToken);
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(result));
                }
               
            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = "" + ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(CacheDuration = 30, Description = "This method(type=get), use for logout user by (email = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void logout(string email)
        {
            try
            {
                /*if (!number.Contains("+"))
                {
                    number = "+" + number;
                }*/

                 if (string.IsNullOrWhiteSpace(email))
                {
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(new ErrorMessage { error = "all field required." }));
                }
                else
                {

                    UserRepo userRepo = new UserRepo();
                    var result = userRepo.logout(email);
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write( js.Serialize(result) );
                 }
            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = "" + ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(CacheDuration = 30, Description = "This method(type=get), use for get user details by (user_id = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getProfile(int user_id)
        {
            try
            {
                if (user_id == null)
                {
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(new ErrorMessage { error = "all field required." }));
                }
                else
                {
                    UserRepo userRepo = new UserRepo();
                    var result = userRepo.getProfile(Convert.ToInt32(user_id));
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                    Context.Response.Write(js.Serialize(result));
                }
            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = "" + ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(CacheDuration = 30, Description = "This method(type=get), use for check exist user by (email = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void checkUserExist(string email)
        {
            try
            {
                UserRepo userRepo = new UserRepo();
                /* if (!number.Contains("+"))
                 {
                     number = "+" + number;
                 }*/
                //var result = userRepo.UserExist(email);

                if (string.IsNullOrWhiteSpace(email))
                {
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(new ErrorMessage { error = "all field required." }));
                }
                else
                {

                    var result = userRepo.checkUserExist(email);
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(result));
                }
            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = "" + ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(CacheDuration = 30, Description = "This method(type=get), use for send password to user from sms by (email = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void forgetPassword(string email)
        {
            try
            {
                UserRepo userRepo = new UserRepo();
                /*if (!number.Contains("+"))
                {
                    number = "+" + number.Trim();
                }*/

                if (string.IsNullOrWhiteSpace(email))
                {
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(new ErrorMessage { error = "all field required." }));
                }
                else
                {
                    var result = userRepo.forgetPassword(email);
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(result));
                }
            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = "" + ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(CacheDuration = 30, Description = "This method(type=get), use for get list of vehicle by (user_id = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getVehicle(int user_id)
        {
            try
            {

                if (user_id == null)
                {
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(new ErrorMessage { error = "all field required." }));
                }
                else
                {

                    VehicleRepo VehicleRepoCls = new VehicleRepo();
                    var result = VehicleRepoCls.getVehicle(Convert.ToInt32(user_id));
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                    Context.Response.Write(js.Serialize(result));
                }

                
            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = "" + ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=post), use for added a new vehicle by (user_id = required, type = required, brand = required,color = required,model = required,plateNumber = required, carPhoto = required, carLicense = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void addVehicle()
        {
            try
            {
                HttpRequest Request = HttpContext.Current.Request;
                string user_id = string.IsNullOrEmpty(Request.Form["user_id"]) ? "" : Request.Form["user_id"].Trim();
                string brand = string.IsNullOrEmpty(Request.Form["brand"]) ? "" : Request.Form["brand"].Trim();
                string color = string.IsNullOrEmpty(Request.Form["color"]) ? "" : Request.Form["color"].Trim();
                string model = string.IsNullOrEmpty(Request.Form["model"]) ? "" : Request.Form["model"].Trim();
                string plateNumber = string.IsNullOrEmpty(Request.Form["plateNumber"]) ? "" : Request.Form["plateNumber"].Trim();
                string type = string.IsNullOrEmpty(Request.Form["type"]) ? "" : Request.Form["type"].Trim();

                HttpPostedFile carPhoto = Request.Files["carPhoto"];
                HttpPostedFile carLicense = Request.Files["carLicense"];

                if (string.IsNullOrWhiteSpace(user_id) ||
                    string.IsNullOrWhiteSpace(brand) ||
                    string.IsNullOrWhiteSpace(color) ||
                    string.IsNullOrWhiteSpace(model) ||
                    string.IsNullOrWhiteSpace(type) ||
                    string.IsNullOrWhiteSpace(plateNumber) ||
                    carPhoto == null || carLicense == null)
                {
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(new ErrorMessage { error = "all fields required." }));
                }
                else
                {
                    VehicleRepo VehicleRepoCls = new VehicleRepo();
                    tbl_vehicle data = new tbl_vehicle
                    {
                        brand = brand,
                        color = color,
                        model = model,
                        plateNumber = plateNumber,
                        user_id = int.Parse(user_id),
                        createdAt = DateTime.Now,
                        approved = false,
                        type = type,
                    };

                    var result = VehicleRepoCls.addVehicle(data, carPhoto, carLicense);
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(result));
                }
            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = "" + ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=post), use for edit vehicle by (vehicle_id = required, type = required, brand = required, color = required, model = required, plateNumber = required, carPhoto = optional, carLicense = optional).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void editVehicle()
        {
            try
            {
                HttpRequest Request = HttpContext.Current.Request;
                string vehicle_id = string.IsNullOrEmpty(Request.Form["vehicle_id"]) ? "" : Request.Form["vehicle_id"].Trim();
                string brand = string.IsNullOrEmpty(Request.Form["brand"]) ? "" : Request.Form["brand"].Trim();
                string color = string.IsNullOrEmpty(Request.Form["color"]) ? "" : Request.Form["color"].Trim();
                string model = string.IsNullOrEmpty(Request.Form["model"]) ? "" : Request.Form["model"].Trim();
                string plateNumber = string.IsNullOrEmpty(Request.Form["plateNumber"]) ? "" : Request.Form["plateNumber"].Trim();
                string type = string.IsNullOrEmpty(Request.Form["type"]) ? "" : Request.Form["type"].Trim();

                if (string.IsNullOrWhiteSpace(vehicle_id) ||
                    string.IsNullOrWhiteSpace(brand) ||
                    string.IsNullOrWhiteSpace(color) ||
                    string.IsNullOrWhiteSpace(model) ||
                    string.IsNullOrWhiteSpace(type) ||
                    string.IsNullOrWhiteSpace(plateNumber))
                {
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(new ErrorMessage { error = "all input fields required." }));
                }
                else
                {
                    HttpPostedFile carPhoto = Request.Files["carPhoto"];
                    HttpPostedFile carLicense = Request.Files["carLicense"];

                    VehicleRepo VehicleRepoCls = new VehicleRepo();
                    tbl_vehicle data = new tbl_vehicle
                    {
                        brand = brand,
                        color = color,
                        model = model,
                        plateNumber = plateNumber,
                        vehicle_id = int.Parse(vehicle_id),
                        type = type,
                        updatedAt = DateTime.Now
                    };

                    var result = VehicleRepoCls.editVehicle(data, carPhoto, carLicense);
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(result));
                }

            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = "" + ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(CacheDuration = 30, Description = "This method(type=get), use for check vehicle Approved or Not Approved by (user_id = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void isVehicleApproved(int user_id)
        {
            try
            {

                if (user_id == null)
                {
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(new ErrorMessage { error = "all field required." }));
                }
                else
                {

                    VehicleRepo VehicleRepos = new VehicleRepo();
                    var result = VehicleRepos.isVehicleApproved(Convert.ToInt32(user_id));
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(result));
                }
                    
            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = "" + ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(CacheDuration = 30, Description = "This method(type=get), use for get list of vehicle brands.")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getBrands()
        {
            try
            {

                VehicleRepo VehicleRepoCls = new VehicleRepo();
                var result = VehicleRepoCls.getVehicleBrands();
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = "" + ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(CacheDuration = 30, Description = "This method(type=get), use for get list of vehicle Colors.")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getColors()
        {
            try
            {

                VehicleRepo VehicleRepoCls = new VehicleRepo();
                var result = VehicleRepoCls.getVehicleColors();
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = "" + ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(CacheDuration = 30, Description = "This method(type=get), use for get list of vehicle types.")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getVehicleTypes()
        {
            try
            {

                VehicleRepo VehicleRepoCls = new VehicleRepo();
                var result = VehicleRepoCls.getVehicleTypes();
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = "" + ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=get), use for delete vehicle by (vehicle_id = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void deleteVehicle(int vehicle_id)
        {
            try
            {
                if (vehicle_id == null)
                {
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(new ErrorMessage { error = "all field required." }));
                }
                else
                {

                    VehicleRepo VehicleRepoCls = new VehicleRepo();
                    var result = VehicleRepoCls.deleteVehicle(Convert.ToInt32(vehicle_id));
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(result));
                }
            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = "" + ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=get) is use for delete ride by (Ride_ID = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void deleteRide(int Ride_ID)
        {
            try
            {
                offerRideRepo offerRideRepoCls = new offerRideRepo();
                var result = offerRideRepoCls.deleteOfferRide(Ride_ID);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=post) is use for create a ride by (middleSeat = (true/false)required, from_place = (string)required, from_latLong = (string)required, no_seats = (number)required, price = (number)required, ride_comment = (string)optional, to_place = (string)required, to_latlong = (string)required, user_id = (number)required, vehicle_id = (number)required, vehicle_type = (string)required, datetime = (string)required), isAllowFemale = (true/false) required,")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void addRide()
        {
            try
            {
                HttpRequest Request = HttpContext.Current.Request;
                //bool charter = string.IsNullOrEmpty(Request.Form["charter"]) ? false : true;
                string middleSeat = Request.Form["middleSeat"];
                string isAllowFemale = Request.Form["isAllowFemale"];
                string from_place = Request.Form["from_place"];
                string from_latlong = Request.Form["from_latlong"];
                string to_place = Request.Form["to_place"];
                string to_latlong = Request.Form["to_latlong"];
                
                //string from_place_persian = string.IsNullOrEmpty(Request.Form["from_place_persian"]) ? "" : Request.Form["from_place_persian"].Trim();
                string no_seats = Request.Form["no_seats"];
                string price = Request.Form["price"];
                string ride_comment = string.IsNullOrEmpty(Request.Form["ride_comment"]) ? "" : Request.Form["ride_comment"].Trim();
                //string to_place_persian = string.IsNullOrEmpty(Request.Form["to_place_persian"]) ? "" : Request.Form["to_place_persian"].Trim();
                string user_id = Request.Form["user_id"];
                string vehicle_id = Request.Form["vehicle_id"];
                string vehicle_type = Request.Form["vehicle_type"];
                string datetime = Request.Form["datetime"];

                //bool Music = Request.Form["Music"].Equals("0") ? false : true;
                //bool Cigarette = Request.Form["Cigarette"].Equals("0") ? false : true;
                //bool AC = Request.Form["AC"].Equals("0") ? false : true;

                if (string.IsNullOrWhiteSpace(middleSeat)
                    || string.IsNullOrWhiteSpace(from_place)
                    || string.IsNullOrWhiteSpace(to_place)
                    || string.IsNullOrWhiteSpace(from_latlong)
                    || string.IsNullOrWhiteSpace(to_latlong)
                    || string.IsNullOrWhiteSpace(no_seats)
                    || string.IsNullOrWhiteSpace(price)
                    || string.IsNullOrWhiteSpace(user_id)
                    || string.IsNullOrWhiteSpace(vehicle_id)
                    || string.IsNullOrWhiteSpace(vehicle_type)
                    || string.IsNullOrWhiteSpace(datetime)
                    || string.IsNullOrWhiteSpace(isAllowFemale)
                    )
                {
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(new ErrorMessage { error = "all fields required." }));
                }
                else
                    { 
                        offerRideRepo offerRideCls = new offerRideRepo();
                        tbl_offerRide data = new tbl_offerRide
                        {
                            //charter = charter,
                            datetime = DateTime.Parse(datetime.Trim()),
                            from_place = from_place.Trim(),
                            from_latlong = from_latlong.Trim(),
                            to_latlong = to_latlong.Trim(),
                            //from_place_persian = from_place_persian,
                            no_seats = int.Parse(no_seats.Trim()),
                            price = price.Trim(),
                            ride_comment = ride_comment,
                            status = true,
                            to_place = to_place.Trim(),
                            //to_place_persian = to_place_persian,
                            user_id = int.Parse(user_id.Trim()),
                            vehicle_type = vehicle_type.Trim(),
                            statusType = "pending",
                            vehicle_id = int.Parse(vehicle_id.Trim()),
                            //Music = Music,
                            //Cigarette = Cigarette,
                           // AC = AC,
                            complaint = false,
                            middleSeat = Convert.ToBoolean(middleSeat.Trim()) == true ? true:false,
                            isAllowFemale = Convert.ToBoolean(isAllowFemale.Trim()) == true ? true : false,
                            createdAt = DateTime.Now
                        };

                        var result = offerRideCls.addofferRide(data);
                        var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                        Context.Response.Write(js.Serialize(result));
                }
            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = ""+ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(CacheDuration = 30, Description = "This method(type=get) is use for Get all list of rides Current and History by (user_id = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getRides(int user_id)
        {
            try
            {
                offerRideRepo offerRideRepoCls = new offerRideRepo();
                var result = offerRideRepoCls.getofferRide(user_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                //Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(new ErrorMessage { error = "" + ex.Message }));
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        //"This method(type=post) is use for search ride list by (charter = 0/1 (optional), from_place = string (required), no_seats = integer (required), to_place = string (required), vehicle_type = string (required), datetime = string (required), user_id = int (required) )")]
        [WebMethod(Description = "This method(type=post) is use for search ride list by (from_place = string (required), no_seats = string (optional), to_place = string (required), datetime = string (optional), user_id = string (required))")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void searchRide()
        {
            try
            {
                HttpRequest Request = HttpContext.Current.Request;
                //bool charter = string.IsNullOrEmpty(Request.Form["charter"]) ? false : true;
                string from_place = string.IsNullOrEmpty(Request.Form["from_place"]) ? "" : Request.Form["from_place"].Trim();
                //string from_place_persian = string.IsNullOrEmpty(Request.Form["from_place_persian"]) ? "" : Request.Form["from_place_persian"].Trim();
                string no_seats = string.IsNullOrEmpty(Request.Form["no_seats"]) ? "" : Request.Form["no_seats"].Trim();
                string user_id = string.IsNullOrEmpty(Request.Form["user_id"]) ? "" : Request.Form["user_id"].Trim();
                string to_place = string.IsNullOrEmpty(Request.Form["to_place"]) ? "" : Request.Form["to_place"].Trim();
                string datetime = string.IsNullOrEmpty(Request.Form["datetime"]) ? "" : Request.Form["datetime"].Trim();
                //string to_place_persian = string.IsNullOrEmpty(Request.Form["to_place_persian"]) ? "" : Request.Form["to_place_persian"].Trim();
                //string vehicle_type = string.IsNullOrEmpty(Request.Form["vehicle_type"]) ? "" : Request.Form["vehicle_type"].Trim();

                if (string.IsNullOrWhiteSpace(from_place)
                   || string.IsNullOrWhiteSpace(to_place)
                   || string.IsNullOrWhiteSpace(user_id)
                   )
                {
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(new ErrorMessage { error = "Required fields cannot be empty and must be filled out." }));
                }
                else
                {
                    offerRideRepo offerRideCls = new offerRideRepo();
                    DateTime midnight = DateTime.UtcNow.Date;
                    var result = offerRideCls.searchOffers(/*charter,*/ datetime, from_place, to_place/*, from_place_persian*/, /*to_place_persian,*/ no_seats, /*vehicle_type,*/ user_id, midnight);
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                    Context.Response.Write(js.Serialize(result));
                }
                
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=post) is use for recharge wallet by (user_id = required, debit = [amount] required, RechargedBy = [type] required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void walletRecharge()
        {
            try
            {
                HttpRequest Request = HttpContext.Current.Request;
                string user_id = string.IsNullOrEmpty(Request.Form["user_id"]) ? "0" : Request.Form["user_id"].Trim();
                string Debit = string.IsNullOrEmpty(Request.Form["debit"]) ? "0" : Request.Form["debit"].Trim();
                string RechargedBy = string.IsNullOrEmpty(Request.Form["rechargedBy"]) ? "" : Request.Form["rechargedBy"].Trim();

                tbl_WalletTransaction WalletTransaction = new tbl_WalletTransaction
                {
                    user_id = int.Parse(user_id),
                    Debit = Debit,
                    transaction_Title = "Recharge",
                    transaction_datetime = DateTime.Now,
                    rechargedBy = RechargedBy,
                    Credit = ""
                };

                TransactionRepo TransactionRepos = new TransactionRepo();
                var result = TransactionRepos.walletRecharge(WalletTransaction);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=post) is use for request ride, parameters (from_place = string (required),from_latLong = string (required), no_seats = string (optional), to_place = string (required), to_latLong = string (required), datetime = string (optional), user_id = string (required))")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void pickMe()
        {
            try
            {
                HttpRequest Request = HttpContext.Current.Request;
                string from_place = string.IsNullOrEmpty(Request.Form["from_place"]) ? "" : Request.Form["from_place"].Trim();
                string from_latLong = string.IsNullOrEmpty(Request.Form["from_latLong"]) ? "" : Request.Form["from_latLong"].Trim();
                string no_seats = string.IsNullOrEmpty(Request.Form["no_seats"]) ? "" : Request.Form["no_seats"].Trim();
                string user_id = string.IsNullOrEmpty(Request.Form["user_id"]) ? "" : Request.Form["user_id"].Trim();
                string to_place = string.IsNullOrEmpty(Request.Form["to_place"]) ? "" : Request.Form["to_place"].Trim();
                string to_latLong = string.IsNullOrEmpty(Request.Form["to_latLong"]) ? "" : Request.Form["to_latLong"].Trim();
                string datetime = string.IsNullOrEmpty(Request.Form["datetime"]) ? "" : Request.Form["datetime"].Trim();
                //string current_latlong = string.IsNullOrEmpty(Request.Form["current_latlong"]) ? "" : Request.Form["current_latlong"].Trim();
                if (string.IsNullOrWhiteSpace(from_place)
                   || string.IsNullOrWhiteSpace(to_place)
                   || string.IsNullOrWhiteSpace(user_id)
                   //|| string.IsNullOrWhiteSpace(current_latlong)
                   )
                {
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(new ErrorMessage { error = "Required fields cannot be empty and must be filled out." }));
                }
                else
                {
                    offerRideRepo offerRideCls = new offerRideRepo();
                    DateTime midnight = DateTime.UtcNow.Date;
                    var result = offerRideCls.pickMe(datetime, from_place, to_place, no_seats, user_id);
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                    Context.Response.Write(js.Serialize(result));
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=get) is use for send request to driver, parameters (offerRide_ID = required, user_id = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void sendRequest(int offerRide_ID, int user_id)
        {
            try
            {
                offerRideRepo offerRideCls = new offerRideRepo();
                var result = offerRideCls.sendRequest(offerRide_ID, user_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=get) is use for create chat board, parameters (offerRide_ID = required, user_id = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void createChat(int offerRide_ID, int user_id)
        {
            try
            {
                offerRideRepo offerRideCls = new offerRideRepo();
                var result = offerRideCls.createChat(offerRide_ID, user_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=post) is use for sent messages, parameters (chat_ID = required, user_id = required, message = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void sendMessage()
        {
            try
            {
                HttpRequest Request = HttpContext.Current.Request;
                string user_id = string.IsNullOrEmpty(Request.Form["user_id"]) ? "" : Request.Form["user_id"].Trim();
                string chat_ID = string.IsNullOrEmpty(Request.Form["chat_ID"]) ? "" : Request.Form["chat_ID"].Trim();
                string message = string.IsNullOrEmpty(Request.Form["message"]) ? "" : Request.Form["message"].Trim();
                if (string.IsNullOrWhiteSpace(user_id)
                   || string.IsNullOrWhiteSpace(chat_ID)
                   || string.IsNullOrWhiteSpace(message)
                   )
                {
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(new ErrorMessage { error = "Required fields cannot be empty and must be filled out." }));
                }
                else
                {

                    offerRideRepo offerRideCls = new offerRideRepo();
                    var result = offerRideCls.sendMessage(int.Parse(user_id), int.Parse(chat_ID), message);
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(result));
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=get) is use for get messages, parameters (chat_ID = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getMessages(int chat_ID)
        {
            try
            {
                offerRideRepo offerRideCls = new offerRideRepo();
                var result = offerRideCls.getMessages(chat_ID);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }


        [WebMethod(Description = "This method(type=get) is use for Approve passenger ride, parameters (book_id = required, user_id = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void approvedRide(int book_id, int user_id)
        {
            try
            {
                BookRepo BookRepoCls = new BookRepo();
                var result = BookRepoCls.approvedRide(book_id, user_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=get) is use for Start ride, parameter (book_id = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void startRide(int book_id)
        {
            try
            {
                BookRepo BookRepoCls = new BookRepo();
                var result = BookRepoCls.startRide(book_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=get) is use for Complete ride, parameter (book_id = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void completeRide(int book_id)
        {
            try
            {
                BookRepo BookRepoCls = new BookRepo();
                var result = BookRepoCls.completeRide(book_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=get) is use for i am arrived, parameter (book_id = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void iAmArrived(int book_id)
        {
            try
            {
                BookRepo BookRepoCls = new BookRepo();
                var result = BookRepoCls.iAmArrived(book_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=get) is use for i am arrived, parameter (book_id = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void iAmComing(int book_id)
        {
            try
            {
                BookRepo BookRepoCls = new BookRepo();
                var result = BookRepoCls.iAmComing(book_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=get) is use for Get Driver and Passenger Locations, parameter (book_id = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getLocations(int book_id)
        {
            try
            {
                BookRepo BookRepoCls = new BookRepo();
                var result = BookRepoCls.getLocations(book_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=get) is use for cancel passenger ride, parameters (book_id = required, user_id = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void cancelRide(int book_id, int user_id)
        {
            try
            {
                BookRepo BookRepoCls = new BookRepo();
                var result = BookRepoCls.canceledRide(book_id, user_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(CacheDuration = 30, Description = "This method(type=get) is use for get passenger ride details, parameters (book_id = (required) ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getPassengerAcceptInfo(int book_id)
        {
            try
            {
                OtherRepo OtherRepoCls = new OtherRepo();
                var result = OtherRepoCls.getPassengerAcceptInfo(book_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(CacheDuration = 30, Description = "This method(type=get) is use for get driver ride details, parameters (book_id = (required) ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getDriverAcceptInfo(int book_id)
        {
            try
            {
                OtherRepo OtherRepoCls = new OtherRepo();
                var result = OtherRepoCls.getDriverAcceptInfo(book_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=get) is use for get list of users notifications by (user_id = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getUsersNotification(int user_id)
        {
            try
            {
                OtherRepo OtherRepoCls = new OtherRepo();
                var result = OtherRepoCls.getUsersNotification(user_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=get) is use for delete notfication by (ID = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void deleteNotification(int ID)
        {
            try
            {
                OtherRepo OtherRepoCls = new OtherRepo();
                var result = OtherRepoCls.deleteNotfication(ID);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=get) is use for get list of users rating by (user_id = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getUsersRating(int user_id)
        {
            try
            {
                OtherRepo OtherRepoCls = new OtherRepo();
                var result = OtherRepoCls.getUsersRating(user_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(CacheDuration = 30, Description = "This method(type=get) is use for get list of user transactions with detail by (user_id=(required) ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getTransactions(int user_id)
        {
            try
            {
                TransactionRepo TransactionRepos = new TransactionRepo();
                var result = TransactionRepos.getTransactions(user_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        [WebMethod(Description = "This method(type=get) is use for set user rating by (user_id = required, rateCount = required, rate_user_id = required, book_id = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void rateUser(int user_id, int rateCount, int rate_user_id, int book_id)
        {
            try
            {
                OtherRepo OtherRepoCls = new OtherRepo();
                tbl_userRating data = new tbl_userRating
                {
                    rate_user_id = rate_user_id,
                    ratingCount = rateCount,
                    user_id = user_id,
                    rateDatetime = DateTime.Now,
                    offerRide_ID = book_id
                };
                var result = OtherRepoCls.userRating(data);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        #endregion


        /* //[WebMethod(CacheDuration = 30, Description = "This method(type=get) is use for check exist user by (email = required).")]
         [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
         public void UserExist(string email)
         {
             try
             {
                 UserRepo userRepo = new UserRepo();
                 //if (!number.Contains("+"))
                 //{
                 //    number = "+" + number;
                 //}
                 var result = userRepo.UserExist(email);
                 //var result = userRepo.checkUserExist(email);
                 var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                 Context.Response.Write( js.Serialize(result) );
             }
             catch (Exception ex)
             {
                 HandleAndLogException.LogErrorToText(ex);
             }
         }*/

        //[WebMethod(CacheDuration = 30, Description = "This method(type=get) is use for check user isApproved by (user_id = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void isUserApproved(int user_id)
        {
            try
            {
                UserRepo userRepo = new UserRepo();
                var result = userRepo.isApproved(Convert.ToInt32(user_id));
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }


        //[WebMethod(CacheDuration = 30, Description = "This method(type=get) is use for Get ride details with DRIVER Or PASSENGER type by user_id and Ride_ID .")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getRideDetails(int user_id, int Ride_ID)
        {
            try
            {
                
                offerRideRepo offerRideRepoCls = new offerRideRepo();
                var result = offerRideRepoCls.getofferRideDetails(user_id, Ride_ID);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

       
        
        //[WebMethod(CacheDuration = 30, Description = "This method(type=get) is use for get list of company by language = English/Persian (required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getCompany()
        {
            try
            {
                
                OtherRepo OtherRepoCls = new OtherRepo();
                var result = OtherRepoCls.getCompany();
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        //[WebMethod(Description = "This method(type=post) is use for Book ride by (Ride_ID = required, user_id = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void bookRide()
        {
            try
            {
                HttpRequest Request = HttpContext.Current.Request;
                string user_id = string.IsNullOrEmpty(Request.Form["user_id"]) ? "0" : Request.Form["user_id"].Trim();
                string Ride_ID = string.IsNullOrEmpty(Request.Form["Ride_ID"]) ? "0" : Request.Form["Ride_ID"].Trim();
                 

                BookRepo BookRepoCls = new BookRepo();
                tbl_book data = new tbl_book
                {
                    user_id = int.Parse(user_id),
                    offerRide_ID = int.Parse(Ride_ID),
                    status = "pending",
                    datetime = DateTime.Now
                };

                var result = BookRepoCls.bookRide(data);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        //[WebMethod(CacheDuration = 30, Description = "This method(type=get) is use for Get list of book pending rides by (user_id = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getBookRides(int user_id)
        {
            try
            {
                
                BookRepo BookRepoCls = new BookRepo();
                var result = BookRepoCls.getBookRides(user_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        //[WebMethod(Description = "This method(type=get) is use for cancel book ride by (book_id = required, user_id = required ).")]
        /*[ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void cancelRide(int book_id, int user_id)
        {
            try
            {
                
                BookRepo BookRepoCls = new BookRepo();
                var result = BookRepoCls.cancelRide(book_id, user_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }*/

        //[WebMethod(Description = "This method(type=get) is use for cancelride by (Ride_ID = required, user_id = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void cancelRRide(int Ride_ID, int user_id)
        {
            try
            {
                
                offerRideRepo offerRideRepoCls = new offerRideRepo();
                var result = offerRideRepoCls.cancelOfferRide(Ride_ID, user_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        //[WebMethod(Description = "This method(type=get) is use for completed ride by (Ride_ID = required, user_id = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void doneRide(int Ride_ID, int user_id)
        {
            try
            {
                
                offerRideRepo offerRideRepoCls = new offerRideRepo();
                var result = offerRideRepoCls.doneOfferRide(Ride_ID, user_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }


        //[WebMethod(CacheDuration = 30, Description = "This method(type=get) is use for Get General data by language = English/Persian (required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getGeneraldata()
        {
            try
            {
                
                OtherRepo OtherRepoCls = new OtherRepo();
                var result = OtherRepoCls.getGeneraldata();
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        //[WebMethod(Description = "This method(type=get) is use for send test notification to device by (user_id = required, msg =  required ).")]
        public void notificationTest(int user_id, string msg)
        {
            try
            {
                
                OtherRepo otherRepos = new OtherRepo();
                var result = otherRepos.sendTestPush(user_id, msg);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }


        [WebMethod(Description = "test")]
        public void locationTestMethod(double myLat, double myLong)
        {
            try
            {
                string urlParameters = "?origin=24.877703,%2067.159687&destination=24.821457,%2067.071804&key=AIzaSyB7-paBiC5ahLqrG93ywHcPdirUUFYX3LM";

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/directions/json");

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsStringAsync().Result;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    RootObject Data = serializer.Deserialize<RootObject>(dataObjects);
                    List<cGeogatePoint> aList = new List<cGeogatePoint>();
                    foreach (Step d in Data.routes[0].legs[0].steps)
                    {
                        aList.Add(new cGeogatePoint(d.end_location.lat, d.end_location.lng));
                    }

                    cGeoGate a = new cGeoGate(aList);
                    var ab = a.Contains(myLat, myLong);
                    var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                    Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                    Context.Response.Write(js.Serialize(ab));
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }
        

        [WebMethod(Description = "This method(type=get) is use for send test notification to device by (user_id = required, msg =  required ).")]
        public void emailTest(string msg)
        {
            try
            {

                helper.notificationCls a = new helper.notificationCls();
                a.SendCrash_Report("msg"); 
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                Context.Response.Write("sent");
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        //[WebMethod(Description = "This method(type=get) is use for get list of users rating by (user_id = required, rate_user_id = required, Ride_ID = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void getUserRating(int user_id, int rate_user_id, int Ride_ID)
        {
            try
            {
                OtherRepo OtherRepoCls = new OtherRepo();
                var result = OtherRepoCls.getUserRating(user_id, rate_user_id, Ride_ID);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        //[WebMethod(Description = "This method(type=post) is use for create a new complaint by (user_id = required, Ride_ID = required, message = required, ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void complaint()
        {
            try
            {
                HttpRequest Request = HttpContext.Current.Request;
                OtherRepo otherRepos = new OtherRepo();
                string user_id = string.IsNullOrEmpty(Request.Form["user_id"]) ? "0" : Request.Form["user_id"].Trim();
                string Ride_ID = string.IsNullOrEmpty(Request.Form["Ride_ID"]) ? "0" : Request.Form["Ride_ID"].Trim();
                string message = string.IsNullOrEmpty(Request.Form["message"]) ? "" : Request.Form["message"].Trim();
                 

                tbl_complaint data = new tbl_complaint
                {
                    message = message,//language.Trim().Equals("Persian") ? TranslateCls.Translate(message, "Persian", "English") : message,
                    offerRide_ID = int.Parse(Ride_ID),
                    user_id = int.Parse(user_id),
                    datetime = DateTime.Now
                };

                var result = otherRepos.complaint(data);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        //[WebMethod(Description = "This method(type=post) is use for set user comes from(Individual Or Company) by (user_id = user id (required), individual = 1 (required)/company_id = company id (required)).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void userComesFrom()
        {
            try
            {
                HttpRequest Request = HttpContext.Current.Request;
                string user_id = string.IsNullOrEmpty(Request.Form["user_id"]) ? "0" : Request.Form["user_id"].Trim();
                string individual = string.IsNullOrEmpty(Request.Form["individual"]) ? "" : Request.Form["individual"].Trim();
                string company_id = string.IsNullOrEmpty(Request.Form["company_id"]) ? "0" : Request.Form["company_id"].Trim();
                tbl_userComesFrom userComesFrom = new tbl_userComesFrom
                {
                    company_id = int.Parse(company_id),
                    individual = string.IsNullOrWhiteSpace(individual) ? false : true,
                    user_id = int.Parse(user_id)
                };

                UserRepo userRepo = new UserRepo();
                var result = userRepo.userComes(userComesFrom);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        

        

        //[WebMethod(Description = "This method(type=get) is use for verify passenger code and completed passenger ride by (user_id = required,Ride_ID = required, code = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void verifyPassengerCode(int user_id, int Ride_ID, string code)
        {
            try
            {
                
                offerRideRepo offerRideRepoCls = new offerRideRepo();
                var result = offerRideRepoCls.verifyPassengerCode(user_id, Ride_ID, code);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        #region Fast Track

        //Fast track endpoints
        /*//[WebMethod(Description = "This method(type=get) is use for check in on fast track mode by (user_id = required, userType = Driver/Passenger (required), LatLong = user current location (required)), vehicle_id = required and cityName = required.")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void fastTrackIn(int user_id, string userType, string LatLong, int vehicle_id)
        {
            try
            {
                string cityName = HttpContext.Current.Request.QueryString["cityName"] == null ? "" : HttpContext.Current.Request.QueryString["cityName"];
                FastTrackRepo FastTrackRepos = new FastTrackRepo();
                var result = FastTrackRepos.fastTrackIn(user_id, userType.ToLower().Trim(), LatLong, vehicle_id, cityName);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }
        */
        /*//[WebMethod(Description = "This method(type=get) is use for update LatLong on fast track mode by (user_id = required, LatLong = user current location (required))")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void updateTrackIn(int user_id, string LatLong)
        {
            try
            {
                FastTrackRepo FastTrackRepos = new FastTrackRepo();
                var result = FastTrackRepos.updateTrackIn(user_id, LatLong);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        //[WebMethod(CacheDuration = 30, Description = "This method(type=get) is use for check out on fast track mode by (user_id = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void fastTrackOut(int user_id)
        {
            try
            {
                FastTrackRepo FastTrackRepos = new FastTrackRepo();
                var result = FastTrackRepos.fastTrackOut(user_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }
        */
        /*//[WebMethod(CacheDuration = 30, Description = "This method(type=get) is use for get passenger ride details by (fastRide_ID = (required) ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getPassengerInfo(int fastRide_ID)
        {
            try
            {
                
                FastTrackRepo FastTrackRepos = new FastTrackRepo();
                var result = FastTrackRepos.getPassengerInfo(fastRide_ID);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }*/
        
        /*
        //[WebMethod(CacheDuration = 30, Description = "This method(type=get) is use for get list of drivers details by (cityName = (required), (cityName_persian = (required) ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getDriversList()
        {
            try
            {
                
                var cityName = HttpContext.Current.Request.QueryString["cityName"] == null ? "" : HttpContext.Current.Request.QueryString["cityName"];
                var cityName_persian = HttpContext.Current.Request.QueryString["cityName_persian"] == null ? "" : HttpContext.Current.Request.QueryString["cityName_persian"];
                FastTrackRepo FastTrackRepos = new FastTrackRepo();
                var result = FastTrackRepos.getDriversInfo(cityName,cityName_persian);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.AddHeader("Content-Type", "application/json; charset=UTF-8");
                Context.Response.Write(js.Serialize(result));
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }*/
        /*
        //[WebMethod(CacheDuration = 30, Description = "This method(type=get) is use for get driver details by (fastRide_ID = (required) ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getDriverInfo(int fastRide_ID)
        {
            try
            {
                
                FastTrackRepo FastTrackRepos = new FastTrackRepo();
                var result = FastTrackRepos.getDriverInfo(fastRide_ID);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }*/

       /* //[WebMethod(Description = "This method(type=post) is use for create fast ride by (user_id = required,from_place = required,to_place = required,from_place_persian = required,to_place_persian = required,LatLong = required,from_LatLong = required, to_LatLong = required, vehicleType = required, isNormal = 1/0 ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void CreateFastRide()
        {
            try
            {
                HttpRequest Request = HttpContext.Current.Request;
                string user_id = string.IsNullOrEmpty(Request.Form["user_id"]) ? "0" : Request.Form["user_id"].Trim();
                string from_place = string.IsNullOrEmpty(Request.Form["from_place"]) ? "" : Request.Form["from_place"].Trim();
                string from_place_persian = string.IsNullOrEmpty(Request.Form["from_place_persian"]) ? "" : Request.Form["from_place_persian"].Trim();
                string to_place = string.IsNullOrEmpty(Request.Form["to_place"]) ? "" : Request.Form["to_place"].Trim();
                string to_place_persian = string.IsNullOrEmpty(Request.Form["to_place_persian"]) ? "" : Request.Form["to_place_persian"].Trim();
                string from_LatLong = string.IsNullOrEmpty(Request.Form["from_LatLong"]) ? "" : Request.Form["from_LatLong"].Trim();
                string to_LatLong = string.IsNullOrEmpty(Request.Form["to_LatLong"]) ? "" : Request.Form["to_LatLong"].Trim();
                string LatLong = string.IsNullOrEmpty(Request.Form["LatLong"]) ? "" : Request.Form["LatLong"].Trim();
                string vehicleType = string.IsNullOrEmpty(Request.Form["vehicleType"]) ? "" : Request.Form["vehicleType"].Trim();
                string isNormal = string.IsNullOrEmpty(Request.Form["isNormal"]) ? "" : Request.Form["isNormal"].Trim();
                 

                tbl_fastRide fastRideData = new tbl_fastRide {
                    
                    createdAt = DateTime.Now,
                    from_place = from_place,//language.Trim().Equals("Persian") ? TranslateCls.Translate(from_place, "Persian", "English") : from_place,
                    from_place_persian = from_place_persian,
                    LatLong = LatLong,
                    statusType = "pending",
                    to_place = to_place,//language.Trim().Equals("Persian") ? TranslateCls.Translate(to_place, "Persian", "English") : to_place,
                    to_place_persian = to_place_persian,
                    user_id = int.Parse(user_id),
                    vehicleType = vehicleType.ToLower().Trim(),
                    VehicleTypeIsNormal = isNormal.Equals("1")?true:false,
                    from_LatLong = from_LatLong,
                    to_LatLong = to_LatLong
                };

                FastTrackRepo FastTrackRepos = new FastTrackRepo();
                var result = FastTrackRepos.CreateFastRide(fastRideData);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }

        //[WebMethod(Description = "This method(type=get) is use for Approved fast ride by (fastRide_ID = required, driver_id = required, price = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void approvedFastRide(int fastRide_ID, int driver_id, string price)
        {
            try
            {
                
                FastTrackRepo FastTrackRepos = new FastTrackRepo();
                var result = FastTrackRepos.approvedFastRide(fastRide_ID, driver_id, price);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }
        */
        /*//[WebMethod(Description = "This method(type=get) is use for Canceled fast ride by (fastRide_ID = required, driver_id = required).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void canceledFastRide(int fastRide_ID, int driver_id)
        {
            try
            {
                FastTrackRepo FastTrackRepos = new FastTrackRepo();
                var result = FastTrackRepos.canceledFastRide(fastRide_ID, driver_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }
        */
        /*//[WebMethod(Description = "This method(type=get) is use for Passenger canceled fast ride by (fastRide_ID = required, passenger_id = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void PassengerCanceledRide(int fastRide_ID, int passenger_id)
        {
            try
            {
                
                FastTrackRepo FastTrackRepos = new FastTrackRepo();
                var result = FastTrackRepos.PassengerCanceledRide(fastRide_ID, passenger_id);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }*/

       /* //[WebMethod(Description = "This method(type=get) is use for Start fast ride by (fastRide_ID = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void startFastRide(int fastRide_ID)
        {
            try
            {
                
                FastTrackRepo FastTrackRepos = new FastTrackRepo();
                var result = FastTrackRepos.startFastRide(fastRide_ID);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }
        */
       /* //[WebMethod(Description = "This method(type=get) is use for Finish fast ride by (fastRide_ID = required ).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void finishFastRide(int fastRide_ID)
        {
            try
            {
                
                FastTrackRepo FastTrackRepos = new FastTrackRepo();
                var result = FastTrackRepos.finishFastRide(fastRide_ID);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }
        */
        /*//[WebMethod(Description = "This method(type=get) is use for set user rating by (user_id = required, rateCount = required, rate_user_id = required, fastRide_ID = required, userType = driver/passenger (required), PayBy = cash/online(required)).")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void fastTrackRateUser(int user_id, int rateCount, int rate_user_id, int fastRide_ID, string userType, string PayBy)
        {
            try
            {
                FastTrackRepo FastTrackRepos = new FastTrackRepo();
                tbl_fastUserRating data = new tbl_fastUserRating
                {
                    rate_user_id = rate_user_id,
                    ratingCount = rateCount,
                    user_id = user_id,
                    rateDatetime = DateTime.Now,
                    fastRide_ID = fastRide_ID
                };
                var result = FastTrackRepos.fastUserRating(data, userType, PayBy);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }
        */

       /* //[WebMethod(Description = "This method(type=get) is use for convert language by msg=xyz and language=Persian/English.")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void convertLanguage()
        {
            try
            {
                
                var msg = HttpContext.Current.Request.QueryString["msg"] == null ? "" : HttpContext.Current.Request.QueryString["msg"];
                OtherRepo OtherRepoCls = new OtherRepo();
                var result = OtherRepoCls.convertLanguage(msg,language);
                var js = new System.Web.Script.Serialization.JavaScriptSerializer();
                Context.Response.AddHeader("Content-Type", "application/json;charset=UTF-8");
                Context.Response.Write( js.Serialize(result) );
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }*/

        /*[WebMethod]
         public void testMethod()
         {
            string a = DateTime.Now.AddDays(-60).ToString("MM/dd/yyyy") + " 00:00:00' AND '" + DateTime.Now.ToString("MM/dd/yyyy") + " 23:59:59";

             //ExampleCall a = new ExampleCall();
             //string p = @"C:\Users\Colworx-Z\Documents\signup.png";
             //a.UploadImageToServer(p,"signup.png","1","westgate","09252017","28.88","true","submitted","19193193","161","eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIzNjVwbHVzIiwianRpIjoiODcxN2IxNDMtZTFjOS00ZDlmLWI3NGYtYWMyMmFlYjFmMDg0IiwiaWF0IjoxNTA2NjY5NTE0LCJOYW1lSWQiOiIxOTE5MzE5MyIsIk1lbWJlcklkIjoiSVAzODM3OVRWQyIsIlBhcnRuZXJJZCI6IjE2MSIsIk1lbWJlckNsYXNzSWQiOiIxMDAzIiwibmJmIjoxNTA2NjY5NTE0LCJleHAiOjE1MDY2Njk4MTQsImlzcyI6IklDRSIsImF1ZCI6IldlYiJ9.BWvFevS7IWnuPvMmsdC0AcZt5Y9dxE59RgPOjqc-oik");
         }
        */

        #endregion
        public class ErrorMessage
        {
            public string error { get; set; }
        }


        public class GeocodedWaypoint
        {
            public string geocoder_status { get; set; }
            public string place_id { get; set; }
            public List<string> types { get; set; }
        }

        public class Northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Bounds
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Distance
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class Duration
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class EndLocation
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class StartLocation
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Distance2
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class Duration2
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class EndLocation2
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Polyline
        {
            public string points { get; set; }
        }

        public class StartLocation2
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Step
        {
            public Distance2 distance { get; set; }
            public Duration2 duration { get; set; }
            public EndLocation2 end_location { get; set; }
            public string html_instructions { get; set; }
            public Polyline polyline { get; set; }
            public StartLocation2 start_location { get; set; }
            public string travel_mode { get; set; }
            public string maneuver { get; set; }
        }

        public class Leg
        {
            public Distance distance { get; set; }
            public Duration duration { get; set; }
            public string end_address { get; set; }
            public EndLocation end_location { get; set; }
            public string start_address { get; set; }
            public StartLocation start_location { get; set; }
            public List<Step> steps { get; set; }
            public List<object> traffic_speed_entry { get; set; }
            public List<object> via_waypoint { get; set; }
        }

        public class OverviewPolyline
        {
        }

        public class Route
        {
            public Bounds bounds { get; set; }
            public string copyrights { get; set; }
            public List<Leg> legs { get; set; }
            public OverviewPolyline overview_polyline { get; set; }
            public string summary { get; set; }
            public List<object> warnings { get; set; }
            public List<object> waypoint_order { get; set; }
        }

        public class RootObject
        {
            public List<GeocodedWaypoint> geocoded_waypoints { get; set; }
            public List<Route> routes { get; set; }
            public string status { get; set; }
        }
    }
}
