using Portal.helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Portal.repo
{
    public class VehicleRepo
    {
        
        protected PN_Entities DBContext;
        public VehicleRepo()
        {
            DBContext = new PN_Entities();
        }

        public tbl_vehicle getVehicle(int vehicle_id)
        {
            try
            {
                var x = DBContext.tbl_vehicle.SingleOrDefault(e => e.vehicle_id == vehicle_id);
                if (x == null)
                {
                    return null;
                }
                else
                {
                    return x;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object getVehicles()
        {
            try
            {
                var result = DBContext.tbl_vehicle.ToList();
                if (result.Count == 0)
                {
                    return null;
                }
                else
                {
                    string imagesServerPath = WebConfigurationManager.AppSettings["imagesServerPath"];
                    List<userVehiclesCls> userVehiclesLst = new List<userVehiclesCls>();
                    foreach (var item in result)
                    {
                        userVehiclesLst.Add(new userVehiclesCls
                        {
                            approved = (item.approved)?"Approved":"Not Approved",
                            brand = item.brand,
                            color = item.color,
                            full_name = item.tbl_profile.full_name,
                            //insurance = item.insuranceNumber,
                            model = item.model,
                            number = item.tbl_profile.number,
                            plate = item.plateNumber,
                            type = item.type,
                            vehicle_id = item.vehicle_id,
                            //VehicleTypeIsNormal = ((bool)item.VehicleTypeIsNormal)?"Economy":"Luxury",
                            createdAt = String.Format("{0:g}", item.createdAt),
                            carLicense = imagesServerPath + item.carLicense,
                            carPhoto = imagesServerPath + item.carPhoto

                        });
                    }

                    return userVehiclesLst.OrderByDescending(e=>e.createdAt);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool updateVehicleInfo(tbl_vehicle data)
        {
            try
            {
                var result = DBContext.tbl_vehicle.SingleOrDefault(e => e.vehicle_id == data.vehicle_id);
                result.approved = data.approved;
                //result.brand = data.brand;
                //result.color = data.color;
                //result.insuranceNumber = data.insuranceNumber;
                //result.model = data.model;
                //result.plateNumber = data.plateNumber;
                //result.type = data.type;
                //result.VehicleTypeIsNormal = data.VehicleTypeIsNormal;
                DBContext.SaveChanges();

                if (!string.IsNullOrWhiteSpace(result.tbl_profile.deviceToken))
                {
                    notificationCls Notification = new notificationCls();
                    Notification.sendPush(result.tbl_profile.deviceToken, "Your vehicle approved by admin.");
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public class userVehiclesCls
        {
            public int vehicle_id { get; set; }
            public string full_name { get; set; }
            public string number { get; set; }
            public string type { get; set; }
            public string brand { get; set; }
            public string model { get; set; }
            public string color { get; set; }
            //public string insurance { get; set; }
            public string plate { get; set; }
            public string approved { get; set; }
            //public string VehicleTypeIsNormal { get; set; }
            public string createdAt { get; set; }
            public string carPhoto { get; set; }
            public string carLicense { get; set; }
        }

        #region Vehicles Pricing functions
        public object getVehiclesPricing()
        {
            try
            {
                var data = DBContext.tbl_kmCharges.ToList().OrderByDescending(e => e.createdAt);
                List<vehicleChargesCls> vehicleChargesLst = new List<vehicleChargesCls>();
                foreach (var item in data)
                {
                    vehicleChargesLst.Add(new vehicleChargesCls
                    {
                        charges = item.charges,
                        chargesID = item.chargesID,
                        createdAt = item.createdAt,
                        updatedAt = item.updatedAt,
                        type = item.type,
                        VehicleTypeIsNormal = item.VehicleTypeIsNormal == true ? "Economy" : "Luxury"
                    });
                }
                return vehicleChargesLst;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public tbl_kmCharges getVehiclePrice(int chargesID)
        {
            try
            {
                return DBContext.tbl_kmCharges.SingleOrDefault(e => e.chargesID == chargesID);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string addVehiclePrice(tbl_kmCharges data)
        {
            try
            {

                if (DBContext.tbl_kmCharges.SingleOrDefault(e => e.type.Equals(data.type) && e.VehicleTypeIsNormal == data.VehicleTypeIsNormal) != null)
                {
                    return "already";
                }

                var result = DBContext.tbl_kmCharges.Add(new tbl_kmCharges
                {
                    charges = data.charges,
                    createdAt = DateTime.Now,
                    type = data.type,
                    VehicleTypeIsNormal = data.VehicleTypeIsNormal
                });
                DBContext.SaveChanges();
                return "true";
            }
            catch (Exception)
            {
                return "false";
            }
        }

        public bool deleteVehiclePrice(int chargesID)
        {
            try
            {
                var data = DBContext.tbl_kmCharges.SingleOrDefault(e => e.chargesID == chargesID);
                DBContext.tbl_kmCharges.Remove(data);
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string updateVehiclePrice(tbl_kmCharges data)
        {
            try
            {

                if (DBContext.tbl_kmCharges.SingleOrDefault(e => e.chargesID != data.chargesID && e.type.Equals(data.type) && e.VehicleTypeIsNormal == data.VehicleTypeIsNormal) != null)
                {
                    return "already";
                }

                var result = DBContext.tbl_kmCharges.SingleOrDefault(e => e.chargesID == data.chargesID);
                result.charges = data.charges;
                result.updatedAt = data.updatedAt;
                result.VehicleTypeIsNormal = data.VehicleTypeIsNormal;
                result.type = data.type;
                DBContext.SaveChanges();
                return "true";
            }
            catch (Exception)
            {
                return "false";
            }
        }

        public class vehicleChargesCls
        {
            public int chargesID { get; set; }
            public string charges { get; set; }
            public string type { get; set; }
            public string VehicleTypeIsNormal { get; set; }
            public DateTime createdAt { get; set; }
            public Nullable<System.DateTime> updatedAt { get; set; }
        }

        #endregion

        #region Vehicles brands functions
        public object getVehicleBrands()
        {
            try
            {
                var data = DBContext.tbl_vehicleBrands.ToList().OrderByDescending(e => e.createdAt);
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public tbl_vehicleBrands getVehicleBrand(int brand_id)
        {
            try
            {
                return DBContext.tbl_vehicleBrands.SingleOrDefault(e => e.brand_id == brand_id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string addVehicleBrand(tbl_vehicleBrands data)
        {
            try
            {
                if (DBContext.tbl_vehicleBrands.SingleOrDefault(e => e.brand.ToLower().Trim().Equals(data.brand.ToLower().Trim()) && e.model.ToLower().Trim().Equals(data.model.ToLower().Trim())) != null)
                {
                    return "already";
                }

                var result = DBContext.tbl_vehicleBrands.Add(new tbl_vehicleBrands
                {
                    createdAt = data.createdAt,
                    brand = data.brand,
                    model = data.model
                });
                DBContext.SaveChanges();
                return "true";
            }
            catch (Exception)
            {
                return "false";
            }
        }

        public bool deleteVehicleBrand(int brand_id)
        {
            try
            {
                var data = DBContext.tbl_vehicleBrands.SingleOrDefault(e => e.brand_id == brand_id);
                DBContext.tbl_vehicleBrands.Remove(data);
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string updateVehicleBrand(tbl_vehicleBrands data)
        {
            try
            {

                if (DBContext.tbl_vehicleBrands.SingleOrDefault(e => e.brand_id != data.brand_id && e.brand.ToLower().Trim().Equals(data.brand.ToLower().Trim()) && e.model.ToLower().Trim().Equals(data.model.ToLower().Trim())) != null)
                {
                    return "already";
                }

                var result = DBContext.tbl_vehicleBrands.SingleOrDefault(e => e.brand_id == data.brand_id);
                result.brand = data.brand;
                result.model = data.model;
                result.updatedAt = data.updatedAt;
                DBContext.SaveChanges();
                return "true";
            }
            catch (Exception)
            {
                return "false";
            }
        }

        #endregion
    }
}