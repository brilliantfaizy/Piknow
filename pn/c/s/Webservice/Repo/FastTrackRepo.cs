using Webservice.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webservice.Models;

namespace Webservice.Repo
{
    public class FastTrackRepo
    {
        protected Service_DBEntities DBContext;
        protected notificationCls Notification;
        

        public FastTrackRepo()
        {
            DBContext = new Service_DBEntities();
            Notification = new notificationCls();
            
        }

        public object fastTrackIn(int user_id, string userType, string LatLong, int vehicle_id, string cityName)
        {

            try
            {
                var result = DBContext.tbl_profile.Where(e => e.user_id == user_id && e.approved == true && e.status.Equals("1")).ToList();
                if (result.Count == 0)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    if (userType.ToLower().Trim().Equals("driver"))
                    {
                        string userAmount = new OtherRepo().getAmount(user_id);
                        string fastTrackAmount = DBContext.tbl_commissionFee.FirstOrDefault().minFastInBalance;

                        if (!(double.Parse(fastTrackAmount) <= double.Parse(userAmount)))
                        {
                            return new ErrorMessage { error = "your wallet balance is low" };
                        }

                    }

                    List<tbl_fastTrack> users = DBContext.tbl_fastTrack.Where(e => e.user_id == user_id).ToList();
                    foreach (var item in users)
                    {
                        DBContext.tbl_fastTrack.Remove(item);
                    }

                    if (!string.IsNullOrWhiteSpace(cityName))
                    {
                        string city = cityName;

                        DBContext.tbl_fastTrack.Add(new tbl_fastTrack
                        {
                            InDatetime = DateTime.Now,
                            status = "online",
                            user_id = user_id,
                            userType = userType.ToLower().Trim(),
                            LatLong = LatLong,
                            vehicle_id = vehicle_id,
                            cityName = cityName,
                        });
                        
                    }
                    else
                    {
                        return new ErrorMessage { error = "cityName required" };
                    }
                    
                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Check in successfully" };
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }

        }

        public object updateTrackIn(int user_id, string LatLong)
        {
            try
            {
                var result = DBContext.tbl_profile.Where(e => e.user_id == user_id && e.approved == true && e.status.Equals("1")).ToList();
                if (result.Count == 0)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    var data = DBContext.tbl_fastTrack.SingleOrDefault(e => e.user_id == user_id);
                    data.LatLong = LatLong;
                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Updated successfully" };
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        /*public object CreateFastRide(tbl_fastRide data)
        {
            try
            {
                //Validate user approved and not deleted
                var result = DBContext.tbl_profile.Where(e => e.user_id == data.user_id && e.approved == true && e.status.Equals("1")).ToList();
                if (result.Count == 0)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    var fastRideData = DBContext.tbl_fastRide.Add(data);

                    int defaultKM = 10;
                    bool driverAvailable = false;
                    int driver_id = 0;

                    //Get list of all online drivers
                    var onlineDrivers = DBContext.tbl_fastTrack.Where(e => e.userType.Equals("driver") && e.tbl_profile.approved == true && e.tbl_profile.deviceToken != null && e.tbl_profile.tbl_vehicle.Count != 0 && e.tbl_profile.status.Equals("1")).ToList();

                    if ((bool)data.VehicleTypeIsNormal)
                    {
                        onlineDrivers = onlineDrivers.Where(e => e.tbl_vehicle.type.ToLower() == data.vehicleType.ToLower() && e.tbl_vehicle.VehicleTypeIsNormal == true).ToList();
                    }
                    else
                    {
                        onlineDrivers = onlineDrivers.Where(e => e.tbl_vehicle.type.ToLower() == data.vehicleType.ToLower() && e.tbl_vehicle.VehicleTypeIsNormal == false).ToList();
                    }

                    DBContext.SaveChanges();

                    foreach (var user in onlineDrivers)
                    {
                        var driverDetail = onlineDrivers.Where(e => e.user_id == user.user_id).LastOrDefault();
                        if (driverDetail.status.Equals("online"))
                        {
                            string[] PassengerLatLong = data.LatLong.Split(',');
                            string[] DriverLatLong = user.LatLong.Split(',');
                            double Kilometers = DistanceTo(double.Parse(PassengerLatLong[0]), double.Parse(PassengerLatLong[1]), double.Parse(DriverLatLong[0]), double.Parse(DriverLatLong[1]));

                            //If driver vehicle nearest location, passenger ride notification send to driver
                            if (Kilometers <= defaultKM)
                            {
                                DBContext.tbl_Notification.Add(new tbl_Notification
                                {
                                    message = "Passenger ride request.|fastRide_ID=" + fastRideData.fastRide_ID,
                                    notification_user_id = user.user_id,
                                    notificationDatetime = DateTime.Now,
                                    user_id = data.user_id
                                });

                                Notification.sendPush(user.tbl_profile.deviceToken, "Passenger ride request." + "|fastRide_ID=" + fastRideData.fastRide_ID);
                                driverAvailable = true;
                                driver_id = user.user_id;
                            }
                        }
                    }

                    //If driver available sent notification to passenger
                    if (driverAvailable)
                    {
                        DBContext.tbl_Notification.Add(new tbl_Notification
                        {
                            message = "
         * to driver.",
                            notification_user_id = data.user_id,
                            notificationDatetime = DateTime.Now,
                            user_id = driver_id
                        });

                        Notification.sendPush(fastRideData.tbl_profile.deviceToken, "Ride request sent to driver." + "");
                        DBContext.SaveChanges();
                        return new SuccessMessage { success = "Ride successfully created." };
                    }

                    return new ErrorMessage { error = "No driver available." };
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }
        */
        public object approvedFastRide(int fastRide_ID, int driver_id, string price)
        {
            try
            {
                var passengerResult = DBContext.tbl_fastRide.SingleOrDefault(e => e.fastRide_ID == fastRide_ID && e.statusType.Equals("pending"));
                if (passengerResult == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    int vehicle_id = (int)DBContext.tbl_fastTrack.SingleOrDefault(e => e.user_id == driver_id && e.userType.Equals("driver") && e.status.Equals("online")).vehicle_id;
                    passengerResult.statusType = "approved";
                    passengerResult.tbl_fastRideDetails.Add(new tbl_fastRideDetails
                    {
                        driver_id = driver_id,
                        vehicle_id = vehicle_id,
                        fastRide_ID = fastRide_ID,
                        price = price.Trim()
                    });

                    DBContext.tbl_Notification.Add(new tbl_Notification
                    {
                        message = "Driver approved ride.|fastRide_ID=" + fastRide_ID,
                        notification_user_id = passengerResult.user_id,
                        notificationDatetime = DateTime.Now,
                        user_id = driver_id
                    });
                    Notification.sendPush(passengerResult.tbl_profile.deviceToken, "Driver approved ride." + "|fastRide_ID=" + fastRide_ID);
                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Ride successfully approved" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object canceledFastRide(int fastRide_ID, int driver_id)
        {
            try
            {
                var passengerResult = DBContext.tbl_fastRide.SingleOrDefault(e => e.fastRide_ID == fastRide_ID && e.statusType.Equals("pending"));
                if (passengerResult == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    DBContext.tbl_fastRide_canceled.Add(new tbl_fastRide_canceled
                    {

                        createdAt = DateTime.Now,
                        driver_id = driver_id,
                        fastRide_ID = fastRide_ID

                    });

                    /* DBContext.tbl_Notification.Add(new tbl_Notification
                     {
                         message = "Driver canceled ride.|fastRide_ID=" + fastRide_ID,
                         notification_user_id = passengerResult.user_id,
                         notificationDatetime = DateTime.Now,
                         user_id = driver_id
                     });
                     Notification.sendPush(passengerResult.tbl_profile.deviceToken, "Driver canceled ride.|fastRide_ID=" + fastRide_ID);*/
                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Ride successfully canceled" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object PassengerCanceledRide(int fastRide_ID, int passenger_id)
        {
            try
            {
                var passengerResult = DBContext.tbl_fastRide.SingleOrDefault(e => e.fastRide_ID == fastRide_ID && e.user_id == passenger_id && e.statusType.Equals("approved"));
                if (passengerResult == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    var driver_details = passengerResult.tbl_fastRideDetails.ToList();
                    passengerResult.statusType = "canceled";
                    if (driver_details.Count != 0)
                    {
                        foreach (var driver in driver_details)
                        {
                            DBContext.tbl_fastRide_canceled.Add(new tbl_fastRide_canceled
                            {
                                createdAt = DateTime.Now,
                                driver_id = driver.driver_id,
                                fastRide_ID = fastRide_ID
                            });

                            DBContext.tbl_Notification.Add(new tbl_Notification
                            {
                                message = "Driver canceled ride.|fastRide_ID=" + fastRide_ID,
                                notification_user_id = driver.driver_id,
                                notificationDatetime = DateTime.Now,
                                user_id = passenger_id
                            });
                            Notification.sendPush(driver.tbl_profile.deviceToken, "Passenger canceled ride." + "|fastRide_ID=" + fastRide_ID);
                        }
                    }
                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Ride successfully canceled" };
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object startFastRide(int fastRide_ID)
        {
            try
            {
                var passengerResult = DBContext.tbl_fastRide.SingleOrDefault(e => e.fastRide_ID == fastRide_ID && e.statusType.Equals("approved"));
                if (passengerResult == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    passengerResult.statusType = "started";
                    passengerResult.tbl_fastRideDetails.FirstOrDefault().startAt = DateTime.Now;
                    passengerResult.tbl_fastRideDetails.FirstOrDefault().startLatLong = passengerResult.from_LatLong;

                    DBContext.tbl_Notification.Add(new tbl_Notification
                    {
                        message = "Driver start ride.|fastRide_ID=" + fastRide_ID,
                        notification_user_id = passengerResult.user_id,
                        notificationDatetime = DateTime.Now,
                        user_id = passengerResult.tbl_fastRideDetails.FirstOrDefault().driver_id
                    });
                    Notification.sendPush(passengerResult.tbl_profile.deviceToken, "Driver start ride." + "|fastRide_ID=" + fastRide_ID);
                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Ride successfully started" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object finishFastRide(int fastRide_ID)
        {
            try
            {
                var passengerResult = DBContext.tbl_fastRide.SingleOrDefault(e => e.fastRide_ID == fastRide_ID && e.statusType.Equals("started"));
                if (passengerResult == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    passengerResult.statusType = "finished";
                    passengerResult.tbl_fastRideDetails.FirstOrDefault().endAt = DateTime.Now;
                    passengerResult.tbl_fastRideDetails.FirstOrDefault().endLatLong = passengerResult.to_LatLong;

                    DBContext.tbl_Notification.Add(new tbl_Notification
                    {
                        message = "Driver finish ride.|fastRide_ID=" + fastRide_ID,
                        notification_user_id = passengerResult.user_id,
                        notificationDatetime = DateTime.Now,
                        user_id = passengerResult.tbl_fastRideDetails.FirstOrDefault().driver_id
                    });
                    Notification.sendPush(passengerResult.tbl_profile.deviceToken, "Driver finish ride." + "|fastRide_ID=" + fastRide_ID);
                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Ride successfully finished" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }
        public double DistanceTo(double lat1, double lon1, double lat2, double lon2, char unit = 'K')
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            switch (unit)
            {
                case 'K': //Kilometers -> default
                    return dist * 1.609344;
                case 'N': //Nautical Miles 
                    return dist * 0.8684;
                case 'M': //Miles
                    return dist;
            }

            return dist;
        }

        public object fastTrackOut(int user_id)
        {

            try
            {
                var result = DBContext.tbl_profile.Where(e => e.user_id == user_id && e.approved == true && e.status.Equals("1")).ToList();
                if (result.Count == 0)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    List<tbl_fastTrack> users = DBContext.tbl_fastTrack.Where(e => e.user_id == user_id).ToList();
                    foreach (var item in users)
                    {
                        DBContext.tbl_fastTrack.Remove(item);
                    }

                    DBContext.tbl_fastTrack.Add(new tbl_fastTrack
                    {
                        OutDatetime = DateTime.Now,
                        status = "offline",
                        user_id = user_id
                    });
                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Check out successfully" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }

        }

        public object getPassengerInfo(int fastRide_ID)
        {
            try
            {
                var a = (from b in DBContext.tbl_fastRide
                         where (b.statusType == "pending" || b.statusType == "approved") && b.fastRide_ID == fastRide_ID && b.tbl_profile.status == "1" && b.tbl_profile.approved == true
                         select b).SingleOrDefault();

                if (a == null)
                {
                    return new ErrorMessage { error = "No data found." };
                }

                var searchPrice = DBContext.tbl_autoCharges.ToList();
                string price = "0";
                string[] from_place = a.from_place.Split(',');
                string[] to_place = a.to_place.Split(',');
                string from_city = from_place[from_place.Length - 1].ToLower().Trim();
                string to_city = to_place[to_place.Length - 1].ToLower().Trim();

                if (from_city.Equals(to_city))
                {
                    string vehicleType = a.vehicleType.ToLower().Trim();
                    bool IsNormal = (bool)a.VehicleTypeIsNormal;
                    var KMchargesData = DBContext.tbl_kmCharges.SingleOrDefault(e => e.type.ToLower().Trim().Equals(vehicleType) && e.VehicleTypeIsNormal == IsNormal);
                    if (KMchargesData == null)
                    {
                        return new ErrorMessage { error = "No data found." };
                    }
                    else
                    {
                        double from_lat = double.Parse(a.from_LatLong.Split(',')[0].Trim());
                        double from_long = double.Parse(a.from_LatLong.Split(',')[1].Trim());
                        double to_lat = double.Parse(a.to_LatLong.Split(',')[0].Trim());
                        double to_long = double.Parse(a.to_LatLong.Split(',')[1].Trim());
                        double place_KM = DistanceTo(from_lat, from_long, to_lat, to_long, 'K');
                        double perKM_price = double.Parse(KMchargesData.charges);
                        double Total_Price = perKM_price * place_KM;
                        price = Math.Round(Total_Price, 3).ToString();
                    }
                }
                else
                {
                    foreach (var item in searchPrice)
                    {
                        if ((from_city.Equals(item.tbl_cities.cityName.ToLower()) && to_city.Equals(item.tbl_cities1.cityName.ToLower())) || (from_city.Equals(item.tbl_cities1.cityName.ToLower()) && to_city.Equals(item.tbl_cities.cityName.ToLower())))
                        {
                            price = Math.Round(double.Parse(item.charges), 3).ToString();
                            break;
                        }
                    }
                }

                fastTrackUsersPassenger fastTrackUsers = new fastTrackUsersPassenger
                {
                    from_place = a.from_place,
                    full_name = a.tbl_profile.full_name,
                    LatLong = a.LatLong,
                    profile_pic = a.tbl_profile.profile_pic,
                    to_place = a.to_place,
                    user_id = a.user_id,
                    userRating = "4.5",
                    price = price,
                    from_LatLong = a.from_LatLong,
                    to_LatLong = a.to_LatLong
                };

                if (fastTrackUsers != null)
                {
                    return fastTrackUsers;
                }
                else
                {
                    return new ErrorMessage { error = "No data found." };
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }


        public object getDriversInfo(string cityName, string cityName_persian)
        {
            try
            {
                string cityNamePersian = "";
                string cityNameEnglish = "";

                cityNamePersian = cityName_persian;
                cityNameEnglish = cityName;

                var b = from bc in DBContext.tbl_fastTrack
                        where bc.status == "online" && bc.userType == "driver" && (bc.cityName_persian == cityNamePersian || bc.cityName == cityNameEnglish)
                        select new driversLatLong {
                            LatLong = bc.LatLong
                        };
                
                if (b.Count() == 0)
                {
                    return new ErrorMessage { error = "No data found." };
                }

                return b;
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public class driversLatLong
        {
            public string LatLong { get; set; }
        }

        public object getDriverInfo(int fastRide_ID)
        {
            try
            {
                var fastTrackUsers = (from a in DBContext.tbl_fastRide
                                      where a.statusType == "approved" && a.fastRide_ID == fastRide_ID
                                      select a).SingleOrDefault();

                if (fastTrackUsers == null)
                {
                    return new ErrorMessage { error = "Driver not available." };
                }

                if (fastTrackUsers.tbl_fastRideDetails.FirstOrDefault().tbl_profile.tbl_fastTrack.Where(e => e.status.Equals("online")).ToList().Count == 0)
                {
                    return new ErrorMessage { error = "Driver is offline." };
                }

                fastTrackUsersDriver fastTrackUsersdata = new fastTrackUsersDriver();
               
                {
                    fastTrackUsersdata.color = fastTrackUsers.tbl_fastRideDetails.SingleOrDefault().tbl_profile.tbl_fastTrack.SingleOrDefault().tbl_vehicle.color;
                    fastTrackUsersdata.full_name = fastTrackUsers.tbl_fastRideDetails.SingleOrDefault().tbl_profile.full_name;
                    fastTrackUsersdata.LatLong = fastTrackUsers.tbl_fastRideDetails.SingleOrDefault().tbl_profile.tbl_fastTrack.SingleOrDefault().LatLong;
                    fastTrackUsersdata.model = fastTrackUsers.tbl_fastRideDetails.SingleOrDefault().tbl_profile.tbl_fastTrack.SingleOrDefault().tbl_vehicle.model;
                    fastTrackUsersdata.number = fastTrackUsers.tbl_fastRideDetails.SingleOrDefault().tbl_profile.number;
                    fastTrackUsersdata.plate = fastTrackUsers.tbl_fastRideDetails.SingleOrDefault().tbl_profile.tbl_fastTrack.SingleOrDefault().tbl_vehicle.plateNumber;
                    fastTrackUsersdata.price = fastTrackUsers.tbl_fastRideDetails.SingleOrDefault().price;
                    fastTrackUsersdata.profile_pic = fastTrackUsers.tbl_fastRideDetails.SingleOrDefault().tbl_profile.profile_pic;
                    fastTrackUsersdata.user_id = fastTrackUsers.tbl_fastRideDetails.SingleOrDefault().tbl_profile.user_id;
                    fastTrackUsersdata.userRating = "4.5";
                }
                

                if (fastTrackUsersdata != null)
                {
                    return fastTrackUsersdata;
                }
                else
                {
                    return new ErrorMessage { error = "No data found." };
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object fastUserRating(tbl_fastUserRating data, string userType, string PayBy)
        {
            try
            {
                var passengerResult = DBContext.tbl_fastRide.SingleOrDefault(e => e.fastRide_ID == data.fastRide_ID && e.statusType.Equals("finished"));
                if (passengerResult == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    if (userType.ToLower().Trim().Equals("passenger"))
                    {
                        passengerResult.tbl_fastRideDetails.FirstOrDefault().PayBy = PayBy;
                    }

                    double amount = double.Parse(passengerResult.tbl_fastRideDetails.FirstOrDefault().price);
                    double karenroDetect = double.Parse(DBContext.tbl_commissionFee.FirstOrDefault().persianPassengerFee);
                    double percentAmount = (amount / 100) * karenroDetect;
                    double driverTotal = amount - percentAmount;
                    int driver_id = passengerResult.tbl_fastRideDetails.FirstOrDefault().driver_id;

                    var userDriverTrans = DBContext.tbl_WalletTransaction.Where(e => e.user_id == driver_id).ToList().LastOrDefault();
                    if (userDriverTrans == null)
                    {
                        userDriverTrans.Balance = "0";
                    }

                    string driverBalance = (double.Parse(userDriverTrans.Balance) + driverTotal).ToString();
                    var driverTrans = DBContext.tbl_WalletTransaction.Add(new tbl_WalletTransaction
                    {
                        Balance = driverBalance,
                        Debit = driverTotal.ToString(),
                        transaction_datetime = DateTime.Now,
                        transaction_Title = "Received",
                        user_id = driver_id,
                        rechargedBy = "",
                        Credit = ""
                    });

                    DBContext.SaveChanges();
                    DBContext.tbl_fastTransDetails.Add(new tbl_fastTransDetails
                    {
                        transaction_ID = driverTrans.transaction_ID,
                        KarenroDetect = percentAmount.ToString(),
                        amount = amount.ToString(),
                        total = driverTotal.ToString(),
                        userType = "driver",
                        fastRide_ID = (int)data.fastRide_ID
                    });

                    var adminTransaction = DBContext.tbl_adminTransaction.ToList().LastOrDefault();
                    string adminTransactionBalance = "0";
                    if (adminTransaction == null)
                    {
                        adminTransactionBalance = "0";
                    }
                    else
                    {
                        adminTransactionBalance = adminTransaction.Balance;
                    }

                    //Received driver amount to admin account
                    DBContext.tbl_adminTransaction.Add(new tbl_adminTransaction
                    {

                        Balance = (double.Parse(adminTransactionBalance) + amount).ToString(),
                        Debit = amount.ToString(),
                        transaction_datetime = DateTime.Now,
                        user_id = driver_id,
                        type = "driver",
                        transaction_Title = "Received",
                        Credit = "",
                        receivedCommission = ""

                    });

                    //Paid to driver after detect
                    DBContext.tbl_adminTransaction.Add(new tbl_adminTransaction
                    {
                        Balance = (double.Parse(adminTransactionBalance) + percentAmount).ToString(),
                        Credit = driverTotal.ToString(),
                        transaction_datetime = DateTime.Now,
                        user_id = driver_id,
                        type = "driver",
                        transaction_Title = "Paid",
                        Debit = "",
                        receivedCommission = percentAmount.ToString()
                    });

                    DBContext.tbl_fastUserRating.Add(data);
                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Submitted" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public class fastTrackUsersCls
        {
            public int user_id { get; set; }
            public string full_name { get; set; }
            public string number { get; set; }
            public string email { get; set; }
            public string birthday { get; set; }
            public string profile_pic { get; set; }
            
            public string gender { get; set; }
            public string LatLong { get; set; }
            public string userType { get; set; }
        }

        public class fastTrackUsersPassenger
        {
            public int user_id { get; set; }
            public string full_name { get; set; }
            public string profile_pic { get; set; }
            public string LatLong { get; set; }
            public string from_place { get; set; }
            public string to_place { get; set; }
            public string from_LatLong { get; set; }
            public string to_LatLong { get; set; }
            public string userRating { get; set; }
            public string price { get; set; }
        }

        public class fastTrackUsersDriver
        {
            public int user_id { get; set; }
            public string full_name { get; set; }
            public string profile_pic { get; set; }
            public string LatLong { get; set; }
            public string model { get; set; }
            public string plate { get; set; }
            public string number { get; set; }
            public string userRating { get; set; }
            public string color { get; set; }
            public string price { get; set; }
        }

        public class SuccessMessage
        {
            public string success { get; set; }
        }

        public class ErrorMessage
        {
            public string error { get; set; }
        }

    }
}