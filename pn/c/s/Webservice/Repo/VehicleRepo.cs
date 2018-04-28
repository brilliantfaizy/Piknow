using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Webservice.Models;

namespace Webservice.Repo
{
    public class VehicleRepo
    {
        protected Service_DBEntities DBContext;
        
        public VehicleRepo()
        {
            DBContext = new Service_DBEntities();
            
        }

        public object addVehicle(tbl_vehicle data, HttpPostedFile carPhoto, HttpPostedFile carLicense)
        {
            try
            {
                var vehicle = DBContext.tbl_vehicle.SingleOrDefault(e => e.plateNumber.Trim().ToLower().Equals(data.plateNumber.Trim().ToLower()));
                if (vehicle != null)
                {
                    return new ErrorMessage { error = "Somebody else has same plate number in the same state." };
                }

                var result = DBContext.tbl_vehicle.Add(data);
                if (carPhoto != null)
                {
                    string vehicleImage = PutFile(carPhoto);
                    if (vehicleImage != "")
                    {
                        result.carPhoto = vehicleImage;
                    }
                }

                if (carLicense != null)
                {
                    string vehicleLicense = PutFile(carLicense);
                    if (vehicleLicense != "")
                    {
                        result.carLicense = vehicleLicense;
                    }
                }
                DBContext.SaveChanges();
                return new SuccessMessage { success = "Submitted" };
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object editVehicle(tbl_vehicle data, HttpPostedFile carPhoto, HttpPostedFile carLicense)
        {
            try
            {
                if (data.vehicle_id != 0)
                {
                    var result = DBContext.tbl_vehicle.Where(e => e.vehicle_id == data.vehicle_id).FirstOrDefault();
                    result.brand = data.brand;
                    result.color = data.color;
                    result.model = data.model;
                    result.type = data.type;
                    result.updatedAt = data.updatedAt;
                    result.plateNumber = data.plateNumber;
                    if (carPhoto != null)
                    {
                        string vehicleImage = PutFile(carPhoto);
                        if (vehicleImage != "")
                        {
                            deleteFile(result.carPhoto);
                            result.carPhoto = vehicleImage;
                        }
                    }

                    if (carLicense != null)
                    {
                        string vehicleLicense = PutFile(carLicense);
                        if (vehicleLicense != "")
                        {
                            deleteFile(result.carLicense);
                            result.carLicense = vehicleLicense;
                        }
                    }

                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Submitted" };
                }
                else
                {
                    return new ErrorMessage { error = "vehicle not exist." };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object getVehicleBrands()
        {
            try
            {
                var result = DBContext.tbl_vehicleBrands.ToList();
                if (result.Count == 0)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    return from item in DBContext.tbl_vehicleBrands
                           select new tbl_vehicleBrandsCls
                           {
                               brand = item.brand,
                               model = item.model,
                               brand_id = item.brand_id,
                               createdAt = item.createdAt,
                               updatedAt = item.updatedAt
                           };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public class tbl_vehicleBrandsCls
        {
            public int brand_id { get; set; }
            public string brand { get; set; }
            public string model { get; set; }
            public System.DateTime createdAt { get; set; }
            public Nullable<System.DateTime> updatedAt { get; set; }
        }


        public object getVehicleTypes()
        {
            try
            {
                var result = DBContext.tbl_vehicleTypes.ToList();
                if (result.Count == 0)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {

                    return from item in DBContext.tbl_vehicleTypes
                           select new tbl_vehicleTypesCls
                           {
                               type = item.type,
                               type_id = item.type_id,
                               createdAt = item.createdAt,
                               updatedAt = item.updatedAt
                           };

                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public class tbl_vehicleTypesCls
        {
            public int type_id { get; set; }
            public string type { get; set; }
            public System.DateTime createdAt { get; set; }
            public Nullable<System.DateTime> updatedAt { get; set; }
        }
        public object getVehicleColors()
        {
            try
            {
                var result = DBContext.tbl_vehicleColors.ToList();
                if (result.Count == 0)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    return from item in DBContext.tbl_vehicleColors
                           select new tbl_vehicleColorsCls
                           {
                               color = item.color,
                               color_id = item.color_id,
                               createdAt = item.createdAt,
                               updatedAt = item.updatedAt
                           };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public class tbl_vehicleColorsCls
        {
            public int color_id { get; set; }
            public string color { get; set; }
            public System.DateTime createdAt { get; set; }
            public Nullable<System.DateTime> updatedAt { get; set; }
        }

        public object getVehicle(int user_id)
        {
            try
            {
                var result = DBContext.tbl_vehicle.Where(e => e.user_id == user_id).ToList();
                if (result.Count == 0)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    tbl_general generalData = DBContext.tbl_general.FirstOrDefault();
                    return from x in DBContext.tbl_vehicle
                            where x.user_id == user_id
                           select new tbl_vehicleCls
                            {
                                carLicense = x.carPhoto,
                                carPhoto = x.carPhoto,
                                approved = x.approved,
                                brand = x.brand,
                                color = x.color,
                                model = x.model,
                                plateNumber = x.plateNumber,
                                user_id = x.user_id,
                                vehicle_id = x.vehicle_id,
                                type = x.type
                            };
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }

        }

        public class tbl_vehicleCls
        {
            public int vehicle_id { get; set; }
            public int user_id { get; set; }
            public string brand { get; set; }
            public string model { get; set; }
            public string color { get; set; }
            public string plateNumber { get; set; }
            public bool approved { get; set; }
            public string carPhoto { get; set; }
            public string carLicense { get; set; }
            public string type { get; set; }
        }

        /* public object getVehicleApproved(int user_id)
         {

             try
             {

                 var result = DBContext.tbl_vehicle.Where(e => e.user_id == user_id && e.approved == true).ToList();
                 if (result.Count == 0)
                 {
                     return new ErrorMessage { error = "No data found" };
                 }
                 else
                 {
                     tbl_general generalData = DBContext.tbl_general.FirstOrDefault();
                     List<tbl_vehicle> vehicleList = new List<tbl_vehicle>();
                     {
                         foreach (var x in result)
                         {
                             tbl_vehicle vehicleItem = new tbl_vehicle
                             {
                                 picture = generalData.hostAddress.Trim() + "upload/" + x.picture,//"http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"] + "/KarenroService/upload/" + x.picture,
                                 approved = x.approved,
                                 brand = x.brand,
                                 color = x.color,
                                 insuranceNumber = x.insuranceNumber,
                                 model = x.model,
                                 plateNumber = x.plateNumber,
                                 type = x.type,
                                 user_id = x.user_id,
                                 vehicle_id = x.vehicle_id,
                                 VehicleTypeIsNormal = x.VehicleTypeIsNormal
                             };

                             vehicleList.Add(vehicleItem);
                         }
                     }
                    

                     return vehicleList;
                 }

             }
             catch (Exception ex)
             {
                 HandleAndLogException.LogErrorToText(ex);
                 return new ErrorMessage { error = "Something went wrong" };
             }

         }*/
        public object deleteVehicle(int vehicle_id)
        {

            try
            {
                var result = DBContext.tbl_vehicle.SingleOrDefault(e => e.vehicle_id == vehicle_id);
                if (result == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    deleteFile(result.carPhoto);
                    deleteFile(result.carLicense);
                    DBContext.tbl_vehicle.Remove(result);
                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Deleted" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }

        }

        public object isVehicleApproved(int user_id)
        {

            try
            {
                var resultData = DBContext.tbl_vehicle.Where(e => e.user_id == user_id && e.approved == true).FirstOrDefault();
                if (resultData != null)
                {
                    return new vehicleApproved
                    {
                        approved = resultData.approved.ToString()
                    };
                }
                else
                {
                    return new ErrorMessage { error = "No data found" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public class vehicleApproved
        {
            public string approved { get; set; }
        }
        public class SuccessMessage
        {
            public string success { get; set; }
        }

        public class ErrorMessage
        {
            public string error { get; set; }
        }

        public string PutFile(HttpPostedFile file)
        {
            if (file.FileName != "")
            {
                string path = HttpContext.Current.Server.MapPath(".");
                string UUID = System.Guid.NewGuid().ToString();
                string filepath = path + "/upload/" + UUID + ".png";
                file.SaveAs(filepath);
                return UUID + ".png";
            }
            return "";
        }

        public bool deleteFile(string fileName)
        {
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                string path = HttpContext.Current.Server.MapPath(".");
                string filepath = path + "/upload/" + fileName;
                File.Delete(filepath);
                return true;
            }
            return false;
        }
    }
}