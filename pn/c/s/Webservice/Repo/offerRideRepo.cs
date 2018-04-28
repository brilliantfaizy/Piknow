using Webservice.helper;
using PersianDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webservice.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;

namespace Webservice.Repo
{
    public class offerRideRepo
    {
        protected Service_DBEntities DBContext;
        protected UserRepo UserRepos;
        protected OtherRepo OtherRepos;
        protected notificationCls Notification;


        public offerRideRepo()
        {
            DBContext = new Service_DBEntities();
            UserRepos = new UserRepo();
            OtherRepos = new OtherRepo();
            Notification = new notificationCls();

        }
        public object addofferRide(tbl_offerRide data)
        {
            try
            {

                if (Math.Round(decimal.Parse(OtherRepos.getAmount(data.user_id)), 2) < decimal.Parse("1000"))
                {
                    return new ErrorMessage { error = "Minimum balance 1000, please recharge your wallet." };
                }

                var user = DBContext.tbl_profile.Where(e => e.user_id == data.user_id).SingleOrDefault();
                var vehicle = DBContext.tbl_vehicle.Where(e => e.vehicle_id == data.vehicle_id).SingleOrDefault();

                if (user != null && vehicle != null)
                {
                    var result = DBContext.tbl_offerRide.Add(data);
                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Submitted" };
                }
                else
                {
                    return new ErrorMessage { error = "user or vehicle not exist." };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong /n" + ex };
            }
        }

        private object searchOfferReturnList(List<tbl_offerRide> searchPlaces)
        {
            try
            {

                if (searchPlaces.Count != 0)
                {
                    List<offerRideCls> offerRideSearchList = new List<offerRideCls>();

                    {
                        foreach (var item in searchPlaces)
                        {
                            var approvedCount = DBContext.tbl_book.Where(e => e.offerRide_ID == item.offerRide_ID && e.status.Equals("approved")).ToList();
                            offerRideCls offerRide = new offerRideCls
                            {
                                //charter = item.charter,
                                middleSeat = item.middleSeat.ToString(),
                                datetime = String.Format("{0:f}", item.datetime),
                                from_place = item.from_place,
                                no_seats = item.no_seats.ToString(),
                                offerRide_ID = item.offerRide_ID,
                                price = item.price.ToString(),
                                ride_comment = item.ride_comment,
                                status = item.status.ToString(),
                                to_place = item.to_place,
                                user_id = item.user_id,
                                vehicle_type = item.vehicle_type,
                                profile_pic = UserRepos.getUserProfile(item.user_id).profile_pic,
                                type = "1",
                                rating = OtherRepos.getUserOwnRating(item.user_id),
                                seatsAvailable = approvedCount.Count.ToString(),
                                statusType = item.statusType,
                                complaint = item.complaint == true ? "1" : "0",
                                from_latlong = item.from_latlong,
                                to_latlong = item.to_latlong
                            };

                            offerRideSearchList.Add(offerRide);
                        }
                    }

                    return offerRideSearchList;
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
        public object searchOffers(/*bool charter, */string datetime, string from_place, string to_place/*, string from_place_persian*/, /*string to_place_persian,*/ string no_seats, /*string vehicle_type,*/ string user_id, DateTime midnight)
        {
            try
            {
                var searchPlaces = DBContext.tbl_offerRide.AsEnumerable().Where(e => e.status == true && e.user_id != int.Parse(user_id) && e.statusType != "completed" /*&& e.datetime >= midnight*/).ToList();
                if (!string.IsNullOrEmpty(no_seats))
                {
                    searchPlaces = searchPlaces.Where(e => e.no_seats >= int.Parse(no_seats)).ToList();
                }

                if (searchPlaces.Count != 0)
                {

                    /*if (!string.IsNullOrWhiteSpace(vehicle_type))
                    {
                        string vehicle_typeVal = vehicle_type.ToLower();
                        if (!vehicle_typeVal.Equals("all"))
                        {
                            string[] types = vehicle_type.Split('|');
                            if (types.Length == 1)
                            {
                                searchPlaces = searchPlaces.Where(e => e.vehicle_type.ToLower().Equals(types[0].ToLower())).ToList();
                            }
                            else if (types.Length == 2)
                            {
                                searchPlaces = searchPlaces.Where(e => e.vehicle_type.ToLower().Equals(types[0].ToLower()) && e.vehicle_type.ToLower().Equals(types[1].ToLower())).ToList();
                            }
                            else if (types.Length == 3)
                            {
                                searchPlaces = searchPlaces.Where(e => e.vehicle_type.ToLower().Equals(types[0].ToLower()) && e.vehicle_type.ToLower().Equals(types[1].ToLower()) && e.vehicle_type.ToLower().Equals(types[2].ToLower())).ToList();
                            }
                        }
                    }*/


                    from_place = from_place.Split(',')[1];//TranslateCls.Translate(from_place, "Persian", "English").Split(',')[0];
                    to_place = to_place.Split(',')[1];// TranslateCls.Translate(to_place, "Persian", "English").Split(',')[0];

                    //from_place_persian = from_place_persian.Split('،')[0];
                    //to_place_persian = to_place_persian.Split('،')[0];

                    if (!string.IsNullOrWhiteSpace(datetime))
                    {
                        DateTime offerDatetime = DateTime.Parse(datetime);

                        /*  if (charter)
                          {
                              //searchPlaces = searchPlaces.Where(e => e.datetime <= offerDatetime ).ToList();
                              searchPlaces = searchPlaces.Where(e => e.from_place.ToLower().Contains(from_place.ToLower()) && e.to_place.ToLower().Contains(to_place.ToLower()) && e.datetime <= offerDatetime && e.charter == charter).ToList();
                          }
                          else
                          {*/
                        searchPlaces = searchPlaces.Where(e => e.from_place.ToLower().Contains(from_place.ToLower()) && e.to_place.ToLower().Contains(to_place.ToLower()) && e.datetime >= offerDatetime).ToList();
                        // }

                        if (searchPlaces.Count != 0)
                        {
                            return searchOfferReturnList(searchPlaces);
                        }
                        else
                        {
                            return new ErrorMessage { error = "No data found" };
                        }
                    }
                    else
                    {
                        /* if (charter)
                         {
                             searchPlaces = searchPlaces.Where(e => e.from_place.ToLower().Contains(from_place.ToLower()) && e.to_place.ToLower().Contains(to_place.ToLower()) && e.charter == charter).ToList();
                         }
                         else
                         {*/
                        searchPlaces = searchPlaces.Where(e => e.from_place.ToLower().Contains(from_place.ToLower()) && e.to_place.ToLower().Contains(to_place.ToLower())).ToList();
                        // }

                        if (searchPlaces.Count != 0)
                        {
                            return searchOfferReturnList(searchPlaces);
                        }
                        else
                        {
                            return new ErrorMessage { error = "No data found" };
                        }
                    }
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
        public object sendRequest(int offerRide_ID, int user_id)
        {
            try
            {
                var offer = DBContext.tbl_offerRide.Where(e => e.offerRide_ID == offerRide_ID).SingleOrDefault();

                if (offer != null)
                {
                    tbl_book data = new tbl_book
                    {
                        user_id = user_id,
                        offerRide_ID = offerRide_ID,
                        status = "pending",
                        datetime = DateTime.Now
                    };

                    var result = DBContext.tbl_book.Add(data);
                    DBContext.SaveChanges();

                    Notification.sendPush(offer.tbl_profile.deviceToken, "1 new request for a ride.|book_id=" + result.book_id);
                    DBContext.tbl_Notification.Add(new tbl_Notification
                    {
                        message = "1 new request for a ride.|book_id=" + result.book_id,
                        notification_user_id = user_id,
                        notificationDatetime = DateTime.Now,
                        user_id = offer.tbl_profile.user_id
                    });

                    DBContext.tbl_Notification.Add(new tbl_Notification
                    {
                        message = "Ride request sent to driver.|book_id=" + result.book_id,
                        notification_user_id = offer.tbl_profile.user_id,
                        notificationDatetime = DateTime.Now,
                        user_id = user_id
                    });

                    //Notification.sendPush(DBContext.tbl_profile.Where(w=>w.user_id == user_id).SingleOrDefault().deviceToken, "Ride request sent to driver." + "");
                    DBContext.SaveChanges();

                    return new SuccessMessage { success = "Ride successfully created." };
                }
                else
                {
                    return new ErrorMessage { error = "No driver available." };
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object createChat(int offerRide_ID, int user_id)
        {
            try
            {
                var chat = DBContext.tbl_chat.Where(e => e.offerRide_ID == offerRide_ID && e.user_id == user_id).SingleOrDefault();
                if (chat != null)
                {
                    return chat;
                }
                else
                {
                    tbl_chat data1 = new tbl_chat
                    {
                        createdAt = DateTime.Now,
                        user_id = user_id,
                        offerRide_ID = offerRide_ID,
                        userType = "Passenger"
                    };

                    var result1 = DBContext.tbl_chat.Add(data1);
                    DBContext.SaveChanges();
                    return result1;
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object sendMessage(int user_id,int chat_ID, string message)
        {
            try
            {
                var chat = DBContext.tbl_chat.Where(e => e.chat_ID == chat_ID).SingleOrDefault();
                if (chat != null)
                {
                    var offer = DBContext.tbl_offerRide.Where(e => e.offerRide_ID == chat.offerRide_ID).SingleOrDefault();
                    tbl_chatDetails data = new tbl_chatDetails
                    {
                        chat_ID = chat_ID,
                        createdAt = DateTime.Now,
                        message = message,
                        user_id = user_id
                    };

                    DBContext.tbl_chatDetails.Add(data);

                    var driver = offer.tbl_profile;
                    var passenger = chat.tbl_profile;
                    string deviceToken = "";
                    int fromUserID;
                    int toUserID;

                    if(driver.user_id == user_id){

                        deviceToken = driver.deviceToken;
                        toUserID = passenger.user_id;
                        fromUserID = driver.user_id;

                    }
                     else
	                {

                        deviceToken = passenger.deviceToken;
                        toUserID = driver.user_id;
                        fromUserID = passenger.user_id;

	                }

                    Notification.sendPush(deviceToken, message+"|chat_ID=" + chat_ID);
                    DBContext.tbl_Notification.Add(new tbl_Notification
                    {
                        message = message + "|chat_ID=" + chat_ID,
                        notification_user_id = fromUserID,
                        notificationDatetime = DateTime.Now,
                        user_id = toUserID
                    });

                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Message sent." };
                }
                else
                {
                    return new ErrorMessage { error = "No chat board found" };
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object getMessages(int chat_ID)
        {
            try
            {

                var chat = DBContext.tbl_chatDetails.Where(e => e.chat_ID == chat_ID).ToList().OrderByDescending(e => e.createdAt);
                if (chat != null)
                {
                    List<chatMessageItem> lst = new List<chatMessageItem>();
                    foreach (var item in chat)
                    {
                        lst.Add(new chatMessageItem { 
                            
                            chat_ID = chat_ID,
                            createdAt = String.Format("{0:f}", item.createdAt),
                            full_name = item.tbl_profile.full_name,
                            message =item.message,
                            profile_pic = item.tbl_profile.profile_pic,
                            user_id = item.user_id

                        });
                    }
                    return lst;
                }
                else
                {
                    return new ErrorMessage { error = "record not found" };
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        private object pickMeDriverList(List<tbl_offerRide> searchPlaces, tbl_profile passengerData)
        {
            try
            {
                if (searchPlaces.Count != 0)
                {
                   // int defaultKM = 10;
                    {
                        bool driverAvailable = false;
                        BookRepo BookRepoCls = new BookRepo();
                        List<DriverAcceptInfo> drivers = new List<DriverAcceptInfo>();
                        foreach (var item in searchPlaces)
                        {
                            string[] PassengerLatLong = passengerData.latLong.Split(',');
                            string[] DriverLatLong = item.tbl_profile.latLong.Split(',');
                            string driverFrom = item.from_latlong;
                            string driverTo = item.to_latlong;
                            //double Kilometers = DistanceTo(double.Parse(PassengerLatLong[0]), double.Parse(PassengerLatLong[1]), double.Parse(DriverLatLong[0]), double.Parse(DriverLatLong[1]));

                            //If driver vehicle nearest location
                            //if (Kilometers <= defaultKM)
                            //{

                            try
                            {
                                string urlParameters = "?origin="+driverFrom+"&destination="+driverTo+"&key=AIzaSyB7-paBiC5ahLqrG93ywHcPdirUUFYX3LM";

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
                                    var ab = a.Contains(double.Parse(PassengerLatLong[0]), double.Parse(PassengerLatLong[1]));

                                    if (ab)
                                    {
                                        drivers.Add(new DriverAcceptInfo
                                        {
                                            full_name = item.tbl_profile.full_name,
                                            offerRide_ID = item.offerRide_ID,
                                            profile_pic = item.tbl_profile.profile_pic,
                                            from = item.from_place,
                                            to = item.to_place,
                                            currentLatLong = item.tbl_profile.latLong,
                                            datetime = String.Format("{0:f}", item.datetime),
                                            perSeatCash = (double.Parse(item.price) / item.no_seats).ToString(),
                                            brand = item.tbl_vehicle.brand,
                                            carPhoto = item.tbl_vehicle.carPhoto,
                                            color = item.tbl_vehicle.color,
                                            model = item.tbl_vehicle.model,
                                            type = item.tbl_vehicle.type,
                                            plateNumber = item.tbl_vehicle.plateNumber
                                        });

                                        driverAvailable = true;
                                    }
                                }
                                else
                                {
                                    
                                }
                            }
                            catch (Exception ex)
                            {
                                HandleAndLogException.LogErrorToText(ex);
                            }
                           // }
                        }

                        //If driver available sent notification to passenger
                        if (driverAvailable)
                        {
                            return drivers;
                        }

                        return new ErrorMessage { error = "No driver available." };
                    }
                }
                else
                {
                    return new ErrorMessage { error = "No driver available." };
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public class chatMessageItem
        {
            public int user_id { get; set; }
            public int chat_ID { get; set; }
            public string profile_pic { get; set; }
            public string full_name { get; set; }
            public string message { get; set; }
            public string createdAt { get; set; }
        }

        public object pickMe(string datetime, string from_place, string to_place, string no_seats, string user_id)
        {
            try
            {
                tbl_profile passengerData = DBContext.tbl_profile.AsEnumerable().Where(e => e.user_id == int.Parse(user_id) && e.latLong != "" && e.latLong != null).SingleOrDefault();
                if (passengerData != null)
                {
                    if (string.IsNullOrWhiteSpace(passengerData.latLong) || string.IsNullOrEmpty(passengerData.latLong))
                    {
                        return new ErrorMessage { error = "No driver available." };
                    }
                }

                var searchPlaces = DBContext.tbl_offerRide.AsEnumerable().Where(e => e.status == true && e.user_id != int.Parse(user_id) && e.statusType != "completed").ToList();
                if (!string.IsNullOrEmpty(no_seats))
                {
                    searchPlaces = searchPlaces.Where(e => e.no_seats >= int.Parse(no_seats)).ToList();
                }

                if (searchPlaces.Count != 0)
                {
                    from_place = from_place.Split(',')[1];
                    to_place = to_place.Split(',')[1];

                    if (!string.IsNullOrWhiteSpace(datetime))
                    {
                        DateTime offerDatetime = DateTime.Parse(datetime);

                       // searchPlaces = searchPlaces.Where(e => e.from_place.ToLower().Contains(from_place.ToLower()) && e.to_place.ToLower().Contains(to_place.ToLower()) && e.datetime >= offerDatetime).ToList();
                        searchPlaces = searchPlaces.Where(e => e.datetime >= offerDatetime).ToList();
                        if (searchPlaces.Count != 0)
                        {
                            return pickMeDriverList(searchPlaces, passengerData);
                        }
                        else
                        {
                            return new ErrorMessage { error = "No driver available." };
                        }
                    }
                    else
                    {
                       // searchPlaces = searchPlaces.Where(e => e.from_place.ToLower().Contains(from_place.ToLower()) && e.to_place.ToLower().Contains(to_place.ToLower())).ToList();

                        if (searchPlaces.Count != 0)
                        {
                            return pickMeDriverList(searchPlaces, passengerData);
                        }
                        else
                        {
                            return new ErrorMessage { error = "No driver available." };
                        }
                    }


                }
                else
                {
                    return new ErrorMessage { error = "No driver available." };
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        /*public bool locationTestMethod(double myLat, double myLong)
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
                    return ab;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
            }
        }*/

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


        public object getofferRide(int user_id)
        {
            try
            {
                var result = DBContext.tbl_offerRide.Where(e => e.status == true && e.statusType != "deleted").ToList();
                if (result != null)
                {
                    var timeUtc = DateTime.UtcNow;
                    TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                    DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);
                    DateTime currentDate = easternTime.Date;
                    offerRideList offerRideListCls = new offerRideList();
                    List<offerRideCls> Current = new List<offerRideCls>();
                    List<offerRideCls> History = new List<offerRideCls>();
                    var userDetail = UserRepos.getUserProfile(user_id);
                    if (userDetail != null)
                    {
                        {
                            foreach (var item in result)
                            {
                                //this condition compare book ride
                                if (DBContext.tbl_book.Where(e => e.offerRide_ID == item.offerRide_ID && e.user_id == user_id).Count() != 0)
                                {
                                    var approvedCount = DBContext.tbl_book.Where(e => e.offerRide_ID == item.offerRide_ID && e.status.Equals("approved")).ToList();

                                    offerRideCls offerRide = new offerRideCls();

                                    //offerRide.charter = item.charter;
                                    offerRide.middleSeat = item.middleSeat.ToString();
                                    offerRide.datetime = String.Format("{0:f}", item.datetime);
                                    offerRide.from_place = item.from_place;
                                    offerRide.no_seats = item.no_seats.ToString();
                                    offerRide.offerRide_ID = item.offerRide_ID;
                                    offerRide.price = item.price.ToString();
                                    offerRide.ride_comment = item.ride_comment;
                                    offerRide.status = item.status.ToString();
                                    offerRide.to_place = item.to_place;
                                    offerRide.user_id = item.user_id;
                                    offerRide.vehicle_type = item.vehicle_type;
                                    offerRide.profile_pic = UserRepos.getUserProfile(item.user_id).profile_pic;
                                    offerRide.type = "0";
                                    offerRide.rating = OtherRepos.getUserOwnRating(item.user_id);
                                    offerRide.seatsAvailable = approvedCount.Count.ToString();
                                    offerRide.statusType = item.statusType;
                                    offerRide.complaint = item.complaint == true ? "1" : "0";
                                    offerRide.from_latlong = item.from_latlong;
                                    offerRide.to_latlong = item.to_latlong;

                                    if (item.datetime >= currentDate)
                                    {
                                        if (offerRide.statusType.Equals("pending"))
                                        {
                                            Current.Add(offerRide);
                                        }
                                        else
                                        {
                                            History.Add(offerRide);
                                        }
                                    }
                                    else
                                    {
                                        History.Add(offerRide);
                                    }

                                }

                                //this condition comapre make own offer
                                if (item.user_id == user_id)
                                {
                                    var approvedCount = DBContext.tbl_book.Where(e => e.offerRide_ID == item.offerRide_ID && e.status.Equals("approved")).ToList();

                                    offerRideCls offerRide = new offerRideCls();

                                    //offerRide.charter = item.charter;
                                    offerRide.middleSeat = item.middleSeat.ToString();
                                    offerRide.datetime = String.Format("{0:f}", item.datetime);
                                    offerRide.from_place = item.from_place;
                                    offerRide.no_seats = item.no_seats.ToString();
                                    offerRide.offerRide_ID = item.offerRide_ID;
                                    offerRide.price = item.price.ToString();
                                    offerRide.ride_comment = item.ride_comment;
                                    offerRide.status = item.status.ToString();
                                    offerRide.to_place = item.to_place;
                                    offerRide.user_id = item.user_id;
                                    offerRide.vehicle_type = item.vehicle_type;
                                    offerRide.profile_pic = userDetail.profile_pic;
                                    offerRide.type = "1";
                                    offerRide.rating = OtherRepos.getUserOwnRating(item.user_id);
                                    offerRide.seatsAvailable = approvedCount.Count.ToString();
                                    offerRide.statusType = item.statusType;
                                    offerRide.complaint = item.complaint == true ? "1" : "0";
                                    offerRide.from_latlong = item.from_latlong;
                                    offerRide.to_latlong = item.to_latlong;

                                    if (item.datetime >= currentDate)
                                    {
                                        if (offerRide.statusType.Equals("pending"))
                                        {
                                            Current.Add(offerRide);
                                        }
                                        else
                                        {
                                            History.Add(offerRide);
                                        }
                                    }
                                    else
                                    {
                                        History.Add(offerRide);
                                    }
                                }

                            }
                        }

                        offerRideListCls.Current = Current;
                        offerRideListCls.History = History;
                        return offerRideListCls;
                    }
                    else
                    {
                        return new ErrorMessage { error = "No data found" };
                    }
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
        public object getofferRideDetails(int user_id, int offerRide_ID)
        {
            try
            {
                var offerRideData = DBContext.tbl_offerRide.SingleOrDefault(e => e.offerRide_ID == offerRide_ID && e.status == true);
                if (offerRideData != null)
                {
                    {
                        var usersData = DBContext.tbl_profile.Where(e => e.approved == true && e.status.Equals("1"));
                        var carData = DBContext.tbl_vehicle.SingleOrDefault(e => e.vehicle_id == offerRideData.vehicle_id);
                        var BookRideUsers = DBContext.tbl_book.Where(e => e.offerRide_ID == offerRide_ID && (e.status.Equals("approved") || e.status.Equals("finished"))).ToList();
                        if (offerRideData.user_id == user_id && offerRideData.offerRide_ID == offerRide_ID)
                        {
                            double defaultPersent = 8;
                            double devide = double.Parse(offerRideData.price) / 100;
                            double PersentTotal = (double)devide * defaultPersent;
                            double TotalAmount = double.Parse(offerRideData.price) - PersentTotal;

                            List<ForPassenger_passengerDetailsCls> PassengerList = new List<ForPassenger_passengerDetailsCls>();
                            if (BookRideUsers.Count != 0)
                            {
                                foreach (var book in BookRideUsers)
                                {
                                    ForPassenger_passengerDetailsCls PassengerItem = new ForPassenger_passengerDetailsCls();
                                    var userDetails = usersData.SingleOrDefault(e => e.user_id == book.user_id);
                                    PassengerItem.full_name = userDetails.full_name;
                                    PassengerItem.profile_pic = userDetails.profile_pic;
                                    PassengerItem.number = userDetails.number;
                                    PassengerItem.user_id = userDetails.user_id;
                                    PassengerItem.status = book.status;
                                    PassengerList.Add(PassengerItem);
                                }
                            }

                            return new ForPassenger_offerRideDetailCls
                            {
                                rideOffer = new ForPassenger_rideOfferCls
                                {
                                    datetime = String.Format("{0:f}", offerRideData.datetime),
                                    discountCode = "258918",
                                    pricePerSeat = offerRideData.price.ToString(),
                                    route = offerRideData.from_place + ", " + offerRideData.to_place,
                                    seatsAvailable = (offerRideData.no_seats - BookRideUsers.Count) + " available out of " + offerRideData.no_seats,
                                    priceAfterCommision = (TotalAmount * BookRideUsers.Count).ToString()
                                },

                                carDetails = new ForPassenger_carDetailsCls
                                {
                                    brand = carData.brand,
                                    model = carData.model,
                                },
                                passengerDetails = PassengerList
                            };
                        }
                        else
                        {
                            var userData = usersData.SingleOrDefault(e => e.user_id == offerRideData.user_id);
                            return new ForDriver_offerRideDetailCls
                            {
                                rideOffer = new ForDriver_rideOfferCls
                                {
                                    datetime = String.Format("{0:f}", offerRideData.datetime),
                                    discountCode = "258918",
                                    pricePerSeat = offerRideData.price.ToString(),
                                    route = offerRideData.from_place + ", " + offerRideData.to_place,
                                    seatsAvailable = (offerRideData.no_seats - BookRideUsers.Count) + " available out of " + offerRideData.no_seats,
                                },

                                carDetails = new ForDriver_carDetailsCls
                                {
                                    brand = carData.brand,
                                    color = carData.color,
                                    model = carData.model,
                                    rating = "3.5",
                                    AC = offerRideData.AC,
                                    Cigarette = offerRideData.Cigarette,
                                    Music = offerRideData.Music,
                                    plateNumber = carData.plateNumber
                                },
                                driverDetails = new ForDriver_driverDetailsCls
                                {
                                    full_name = userData.full_name,
                                    profile_pic = userData.profile_pic,
                                    rating = "4.5",
                                    ride_comment = offerRideData.ride_comment,
                                    number = userData.number

                                }
                            };
                        }
                    }

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
        public object cancelOfferRide(int offerRide_ID, int user_id)
        {
            try
            {
                var result = DBContext.tbl_offerRide.SingleOrDefault(e => e.offerRide_ID == offerRide_ID && e.user_id == user_id && e.statusType.Equals("pending"));
                if (result == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    result.statusType = "canceled";
                    DBContext.SaveChanges();
                    List<tbl_book> bookUsers = DBContext.tbl_book.Where(e => e.offerRide_ID == result.offerRide_ID && (e.status.Equals("pending") || e.status.Equals("approved"))).ToList();
                    if (bookUsers.Count != 0)
                    {
                        foreach (tbl_book item in bookUsers)
                        {
                            var user = DBContext.tbl_profile.SingleOrDefault(e => e.user_id == item.user_id && e.status.Equals("1") && e.approved == true && e.deviceToken != null);
                            if (user != null)
                            {
                                var adminBank = DBContext.tbl_adminBank.SingleOrDefault(e => e.offerRide_ID == result.offerRide_ID && e.user_id == item.user_id && e.book_id == item.book_id && e.paymentStatus.Equals("pending"));
                                string returnAmount = "0";
                                if (adminBank != null)
                                {
                                    returnAmount = adminBank.amount;
                                    var userPassengerTrans = DBContext.tbl_WalletTransaction.Where(e => e.user_id == item.user_id).ToList().LastOrDefault();
                                    var passengerTransDetail = DBContext.tbl_transDetails.SingleOrDefault(e => e.transaction_ID == adminBank.transaction_ID);

                                    string passengerBalance = (double.Parse(userPassengerTrans.Balance) + double.Parse(returnAmount)).ToString();
                                    adminBank.paymentStatus = "canceled";
                                    item.status = "canceled";
                                    var passengerTrans = DBContext.tbl_WalletTransaction.Add(new tbl_WalletTransaction
                                    {
                                        Balance = passengerBalance,
                                        Debit = returnAmount,
                                        transaction_datetime = DateTime.Now,
                                        transaction_Title = "Return",
                                        user_id = item.user_id,
                                        Credit = "",
                                        rechargedBy = ""

                                    });

                                    DBContext.SaveChanges();

                                    DBContext.tbl_transDetails.Add(new tbl_transDetails
                                    {

                                        transaction_ID = passengerTrans.transaction_ID,
                                        KarenroDetect = passengerTransDetail.KarenroDetect,
                                        amount = passengerTransDetail.amount,
                                        total = passengerTransDetail.total,
                                        userType = "passenger",
                                        offerRide_ID = passengerTransDetail.offerRide_ID,

                                    });
                                }


                                DBContext.tbl_Notification.Add(new tbl_Notification
                                {
                                    message = "Ride canceled and amount " + returnAmount + " return to your wallet.|offerRide_ID=" + result.offerRide_ID,
                                    notification_user_id = user.user_id,
                                    notificationDatetime = DateTime.Now,
                                    user_id = user_id
                                });
                                DBContext.SaveChanges();

                                notificationCls Notification = new notificationCls();
                                Notification.sendPush(user.deviceToken, "Ride canceled and amount" + " " + returnAmount + " " + "return to your wallet." + "|offerRide_ID=" + result.offerRide_ID);
                            }
                        }
                    }
                    return new SuccessMessage { success = "Offer ride successfully canceled" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }
        public object doneOfferRide(int offerRide_ID, int user_id)
        {
            try
            {
                var result = DBContext.tbl_offerRide.SingleOrDefault(e => e.offerRide_ID == offerRide_ID && e.statusType.Equals("pending"));
                if (result == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    result.statusType = "completed";
                    DBContext.SaveChanges();
                    List<tbl_book> bookUsers = DBContext.tbl_book.Where(e => e.offerRide_ID == result.offerRide_ID).ToList();
                    if (bookUsers.Count != 0)
                    {
                        foreach (tbl_book item in bookUsers)
                        {
                            var user = DBContext.tbl_profile.SingleOrDefault(e => e.user_id == item.user_id && e.status.Equals("1") && e.approved == true && e.deviceToken != null);
                            if (user != null)
                            {

                                DBContext.tbl_Notification.Add(new tbl_Notification
                                {
                                    message = "Offer ride completed|offerRide_ID=" + offerRide_ID,
                                    notification_user_id = user.user_id,
                                    notificationDatetime = DateTime.Now,
                                    user_id = user_id
                                });
                                DBContext.SaveChanges();
                                notificationCls Notification = new notificationCls();
                                Notification.sendPush(user.deviceToken, "Offer ride completed" + "|offerRide_ID=" + offerRide_ID);
                            }
                        }
                    }
                    return new SuccessMessage { success = "Offer ride successfully completed" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object verifyPassengerCode(int user_id, int offerRide_ID, string code)
        {
            try
            {
                var result = DBContext.tbl_offerRide.SingleOrDefault(e => e.offerRide_ID == offerRide_ID && e.user_id == user_id && e.statusType.Equals("completed"));
                if (result == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    var passenger = DBContext.tbl_book.SingleOrDefault(e => e.status.Equals("approved") && e.offerRide_ID == offerRide_ID && e.passengerCode == code);
                    if (passenger == null)
                    {
                        return new ErrorMessage { error = "No data found" };
                    }

                    if (passenger != null)
                    {
                        tbl_profile passengerProfile = DBContext.tbl_profile.SingleOrDefault(e => e.user_id == passenger.user_id);
                        tbl_profile driverProfile = DBContext.tbl_profile.SingleOrDefault(e => e.user_id == result.user_id);
                        var adminBank = DBContext.tbl_adminBank.SingleOrDefault(e => e.offerRide_ID == passenger.offerRide_ID && e.user_id == passenger.user_id && e.book_id == passenger.book_id && e.paymentStatus.Equals("pending"));
                        string PassengerPaidAmount = "0";
                        if (adminBank != null)
                        {
                            var userDriverTrans = DBContext.tbl_WalletTransaction.Where(e => e.user_id == result.user_id).ToList().LastOrDefault();
                            string driverWalletBalance = "0";
                            if (userDriverTrans == null)
                            {
                                driverWalletBalance = "0";
                            }
                            else
                            {
                                driverWalletBalance = userDriverTrans.Balance;
                            }

                            var passengerTransDetails = DBContext.tbl_transDetails.SingleOrDefault(e => e.transaction_ID == adminBank.transaction_ID);
                            string driverPaidAmount = (double.Parse(adminBank.amount) - double.Parse(passengerTransDetails.KarenroDetect)).ToString();
                            PassengerPaidAmount = adminBank.amount;
                            double KarenroDetect = double.Parse(DBContext.tbl_commissionFee.FirstOrDefault().driversFee);
                            double DetectAmount = (double.Parse(driverPaidAmount) / 100) * KarenroDetect;
                            double driverPaidTotal = double.Parse(driverPaidAmount) - DetectAmount;
                            string driverBalance = (double.Parse(driverWalletBalance) + driverPaidTotal).ToString();
                            adminBank.paymentStatus = "finished";
                            passenger.status = "finished";
                            var driverTrans = DBContext.tbl_WalletTransaction.Add(new tbl_WalletTransaction
                            {
                                Balance = driverBalance,
                                Debit = driverPaidTotal.ToString(),
                                transaction_datetime = DateTime.Now,
                                transaction_Title = "Received",
                                user_id = result.user_id,
                                rechargedBy = "",
                                Credit = ""

                            });

                            DBContext.SaveChanges();

                            DBContext.tbl_transDetails.Add(new tbl_transDetails
                            {

                                transaction_ID = driverTrans.transaction_ID,
                                KarenroDetect = DetectAmount.ToString(),
                                amount = driverPaidAmount,
                                total = driverPaidTotal.ToString(),
                                userType = "driver",
                                offerRide_ID = result.offerRide_ID,

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
                            var driverAdminTrans = DBContext.tbl_adminTransaction.Add(new tbl_adminTransaction
                            {
                                Balance = (double.Parse(adminTransactionBalance) + double.Parse(driverPaidAmount)).ToString(),
                                Debit = driverPaidAmount,
                                transaction_datetime = DateTime.Now,
                                user_id = driverProfile.user_id,
                                type = "driver",
                                transaction_Title = "Received",
                                Credit = "",
                                receivedCommission = ""
                            });

                            //Paid to driver after detect
                            DBContext.tbl_adminTransaction.Add(new tbl_adminTransaction
                            {
                                Balance = (double.Parse(adminTransactionBalance) + DetectAmount).ToString(),
                                Credit = driverPaidTotal.ToString(),
                                transaction_datetime = DateTime.Now,
                                user_id = driverProfile.user_id,
                                type = "driver",
                                transaction_Title = "Paid",
                                Debit = "",
                                receivedCommission = DetectAmount.ToString()
                            });

                            DBContext.SaveChanges();

                            adminTransaction = DBContext.tbl_adminTransaction.ToList().LastOrDefault();
                            adminTransactionBalance = "0";
                            if (adminTransaction == null)
                            {
                                adminTransactionBalance = "0";
                            }
                            else
                            {
                                adminTransactionBalance = adminTransaction.Balance;
                            }

                            //Received passenger commission to admin account
                            DBContext.tbl_adminTransaction.Add(new tbl_adminTransaction
                            {
                                Balance = (double.Parse(adminTransactionBalance) + double.Parse(passengerTransDetails.KarenroDetect)).ToString(),
                                Debit = passengerTransDetails.KarenroDetect,
                                transaction_datetime = DateTime.Now,
                                user_id = passenger.user_id,
                                type = "passenger",
                                transaction_Title = "Received",
                                Credit = "",
                                receivedCommission = passengerTransDetails.KarenroDetect
                            });


                            notificationCls Notification = new notificationCls();

                            //Send Notification to Passenger
                            DBContext.tbl_Notification.Add(new tbl_Notification
                            {
                                message = "Ride has been finished and amount is " + PassengerPaidAmount + ".|offerRide_ID=" + result.offerRide_ID,
                                notification_user_id = passengerProfile.user_id,
                                notificationDatetime = DateTime.Now,
                                user_id = user_id
                            });
                            Notification.sendPush(passengerProfile.deviceToken, "Ride has been finished and amount charged" + " " + PassengerPaidAmount + ".|offerRide_ID=" + result.offerRide_ID);

                            //Send Notification to Driver
                            DBContext.tbl_Notification.Add(new tbl_Notification
                            {
                                message = "Ride has been finished and amount is " + driverPaidTotal + ".|offerRide_ID=" + result.offerRide_ID,
                                notification_user_id = result.user_id,
                                notificationDatetime = DateTime.Now,
                                user_id = passengerProfile.user_id
                            });

                            Notification.sendPush(driverProfile.deviceToken, "Ride has been finished and amount is" + " " + driverPaidTotal + ".|offerRide_ID=" + result.offerRide_ID);
                            DBContext.SaveChanges();

                        }

                    }

                    return new SuccessMessage { success = "Passenger ride successfully finished" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }
        public object deleteOfferRide(int offerRide_ID)
        {
            try
            {
                var result = DBContext.tbl_offerRide.SingleOrDefault(e => e.offerRide_ID == offerRide_ID && e.statusType.Equals("pending"));
                if (result == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {

                    List<tbl_book> bookUsers = DBContext.tbl_book.Where(e => e.offerRide_ID == result.offerRide_ID).ToList();
                    if (bookUsers.Count != 0)
                    {
                        return new ErrorMessage { error = "Unable to delete this ride." };
                    }
                    else
                    {
                        result.statusType = "deleted";
                        result.status = false;
                        DBContext.SaveChanges();
                        return new SuccessMessage { success = "Offer ride successfully deleted" };
                    }
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }
        private class offerRideList
        {
            public List<offerRideCls> Current { get; set; }
            public List<offerRideCls> History { get; set; }
        }
        private class ForDriver_offerRideDetailCls
        {
            public ForDriver_rideOfferCls rideOffer { get; set; }
            public ForDriver_carDetailsCls carDetails { get; set; }
            public ForDriver_driverDetailsCls driverDetails { get; set; }
        }

        private class ForDriver_rideOfferCls
        {
            public string datetime { get; set; }
            public string route { get; set; }
            public string seatsAvailable { get; set; }
            public string pricePerSeat { get; set; }
            public string discountCode { get; set; }
        }

        private class ForDriver_carDetailsCls
        {
            public string brand { get; set; }
            public string model { get; set; }
            public string color { get; set; }
            public string rating { get; set; }
            public string plateNumber { get; set; }
            public Nullable<bool> Cigarette { get; set; }
            public Nullable<bool> Music { get; set; }
            public Nullable<bool> AC { get; set; }
        }

        private class ForDriver_driverDetailsCls
        {
            public string profile_pic { get; set; }
            public string full_name { get; set; }
            public string ride_comment { get; set; }
            public string rating { get; set; }
            public string number { get; set; }
        }

        private class ForPassenger_offerRideDetailCls
        {
            public ForPassenger_rideOfferCls rideOffer { get; set; }
            public ForPassenger_carDetailsCls carDetails { get; set; }
            public List<ForPassenger_passengerDetailsCls> passengerDetails { get; set; }
        }

        private class ForPassenger_rideOfferCls
        {
            public string datetime { get; set; }
            public string route { get; set; }
            public string seatsAvailable { get; set; }
            public string pricePerSeat { get; set; }
            public string discountCode { get; set; }
            public string priceAfterCommision { get; set; }
        }

        private class ForPassenger_carDetailsCls
        {
            public string brand { get; set; }
            public string model { get; set; }
        }

        private class ForPassenger_passengerDetailsCls
        {
            public string profile_pic { get; set; }
            public string full_name { get; set; }
            public string number { get; set; }
            public int user_id { get; set; }
            public string status { get; set; }
        }
        private class offerRideCls
        {
            public int offerRide_ID { get; set; }
            public int user_id { get; set; }
            public string profile_pic { get; set; }
            public string type { get; set; }
            public string from_place { get; set; }
            public string to_place { get; set; }
            public string from_latlong { get; set; }
            public string to_latlong { get; set; }
            public string datetime { get; set; }
            public string vehicle_type { get; set; }
            public string no_seats { get; set; }
            //public Nullable<bool> charter { get; set; }
            public string middleSeat { get; set; }
            public string ride_comment { get; set; }
            public string price { get; set; }
            public string status { get; set; }
            public string rating { get; set; }
            public string seatsAvailable { get; set; }
            public string statusType { get; set; }
            public string complaint { get; set; }
        }

        public class SuccessMessage
        {
            public string success { get; set; }
        }

        public class ErrorMessage
        {
            public string error { get; set; }
        }

        public class DriverAcceptInfo
        {
            public int offerRide_ID { get; set; }
            public string profile_pic { get; set; }
            public string full_name { get; set; }
            public string from { get; set; }
            public string to { get; set; }
            public string currentLatLong { get; set; }
            public string datetime { get; set; }
            public string perSeatCash { get; set; }
            public string brand { get; set; }
            public string model { get; set; }
            public string color { get; set; }
            public string plateNumber { get; set; }
            public string carPhoto { get; set; }
            public string type { get; set; }
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