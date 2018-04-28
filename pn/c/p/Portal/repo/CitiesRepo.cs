using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.repo
{
    public class CitiesRepo
    {
        protected PN_Entities DBContext;
        public CitiesRepo()
        {
            DBContext = new PN_Entities();
        }

        #region Cities functions

        public object getCities()
        {
            try
            {
                return DBContext.tbl_cities.ToList().OrderByDescending(e => e.createdAt);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public tbl_cities getCity(int cityID)
        {
            try
            {
                return DBContext.tbl_cities.SingleOrDefault(e => e.cityID == cityID);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string addCity(tbl_cities data)
        {
            try
            {
                var details = DBContext.tbl_cities.SingleOrDefault(e => e.cityName.ToLower() == data.cityName.ToLower());
                if (details != null)
                {
                    return "already";
                }
                else
                {
                    DBContext.tbl_cities.Add(data);
                    DBContext.SaveChanges();
                    return "true";
                }

            }
            catch (Exception)
            {
                return "false";
            }
        }

        public bool deleteCity(int cityID)
        {
            try
            {
                int city = DBContext.tbl_cities.SingleOrDefault(e => e.cityID == cityID).tbl_autoCharges.Count;
                int city1 = DBContext.tbl_cities.SingleOrDefault(e => e.cityID == cityID).tbl_autoCharges1.Count;

                if (city != 0 || city1 != 0)
                {
                    return false;
                }

                var data = DBContext.tbl_cities.SingleOrDefault(e => e.cityID == cityID);
                DBContext.tbl_cities.Remove(data);
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updateCity(tbl_cities data)
        {
            try
            {
                var result = DBContext.tbl_cities.SingleOrDefault(e => e.cityID == data.cityID);
                result.cityName = data.cityName;
                result.updatedAt = data.updatedAt;
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Cities Pricing functions
        public object getCitiesPricing()
        {
            try
            {
                var data = DBContext.tbl_autoCharges.ToList().OrderByDescending(e => e.createdAt);
                List<autoChargesCls> autoChargesLst = new List<autoChargesCls>();
                foreach (var item in data)
                {
                    autoChargesLst.Add(new autoChargesCls
                    {
                        charges = item.charges,
                        chargesID = item.chargesID,
                        createdAt = item.createdAt,
                        from_city = item.tbl_cities.cityName,
                        to_city = item.tbl_cities1.cityName,
                        updatedAt = item.updatedAt,
                        type = item.type,
                        VehicleTypeIsNormal = item.VehicleTypeIsNormal == true ? "Economy" : "Luxury"
                    });
                }
                return autoChargesLst;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public tbl_autoCharges getCityPrice(int chargesID)
        {
            try
            {
                return DBContext.tbl_autoCharges.SingleOrDefault(e => e.chargesID == chargesID);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string addCityPrice(tbl_autoCharges data)
        {
            try
            {
                if (data.from_city == data.to_city)
                {
                    return "same";
                }

                if (DBContext.tbl_autoCharges.SingleOrDefault(e => e.from_city == data.from_city && e.to_city == data.to_city && e.type.Equals(data.type) && e.VehicleTypeIsNormal == data.VehicleTypeIsNormal) != null)
                {
                    return "already";
                }

                var result = DBContext.tbl_autoCharges.Add(new tbl_autoCharges
                {
                    charges = data.charges,
                    createdAt = DateTime.Now,
                    from_city = data.from_city,
                    to_city = data.to_city,
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

        public bool deleteCityPrice(int chargesID)
        {
            try
            {
                var data = DBContext.tbl_autoCharges.SingleOrDefault(e => e.chargesID == chargesID);
                DBContext.tbl_autoCharges.Remove(data);
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string updateCityPrice(tbl_autoCharges data)
        {
            try
            {
                if (data.from_city == data.to_city)
                {
                    return "same";
                }

                if (DBContext.tbl_autoCharges.SingleOrDefault(e => e.from_city == data.from_city && e.to_city == data.to_city && e.chargesID != data.chargesID && e.type.Equals(data.type) && e.VehicleTypeIsNormal == data.VehicleTypeIsNormal) != null)
                {
                    return "already";
                }

                var result = DBContext.tbl_autoCharges.SingleOrDefault(e => e.chargesID == data.chargesID);
                result.charges = data.charges;
                result.from_city = data.from_city;
                result.to_city = data.to_city;
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

        public class autoChargesCls
        {
            public int chargesID { get; set; }
            public string from_city { get; set; }
            public string to_city { get; set; }
            public string charges { get; set; }
            public string type { get; set; }
            public string VehicleTypeIsNormal { get; set; }
            public DateTime createdAt { get; set; }
            public Nullable<System.DateTime> updatedAt { get; set; }
        }

        #endregion

    }
}