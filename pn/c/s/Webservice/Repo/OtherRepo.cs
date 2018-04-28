using Webservice.helper;
using PersianDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webservice.Models;

namespace Webservice.Repo
{
    public class OtherRepo
    {
        protected Service_DBEntities DBContext;
        
        public OtherRepo()
        {
            DBContext = new Service_DBEntities();
            
        }

        public object getCompany()
        {
            try
            {
                var data = DBContext.tbl_company.Where(e => e.isConfirmed == true).ToList();
                List<companyCls> companyClsLst = new List<companyCls>();

                {
                    foreach (var a in data)
                    {
                        companyClsLst.Add(new companyCls
                        {
                            company_id = a.company_id,
                            company_name = a.company_name
                        });
                    }
                }
                
                if (companyClsLst.Count == 0)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    return companyClsLst;
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }


        public class companyCls
        {
            public int company_id { get; set; }
            public string company_name { get; set; }
        }

        public object getGeneraldata()
        {
            try
            {
                int ID = 1;
                var generalData = DBContext.tbl_general.SingleOrDefault(e=>e.ID == ID);
                var commissionFeeData = DBContext.tbl_commissionFee.FirstOrDefault();
                if (generalData == null || commissionFeeData == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    generalData = new tbl_general
                    {
                        aboutPath = generalData.aboutPath,
                        hostAddress = generalData.hostAddress,
                        ID = generalData.ID,
                        passengerDetect = commissionFeeData.persianPassengerFee,
                        percentDetect = commissionFeeData.driversFee,
                        fastTrackAmount = commissionFeeData.minFastInBalance,
                        perKM = generalData.perKM,
                        privacyPolicyPath = generalData.privacyPolicyPath,
                        termConditionPath = generalData.termConditionPath
                    };
                    return generalData;
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object userRating(tbl_userRating data)
        {
            try
            {
                var a = DBContext.tbl_book.Where(e => e.book_id == data.offerRide_ID).SingleOrDefault();
                if (data.user_id != 0 && data.ratingCount != 0 && data.rate_user_id != 0 && data.offerRide_ID != 0)
                {
                    data.offerRide_ID = a.offerRide_ID;
                    DBContext.tbl_userRating.Add(data);
                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Submitted" };
                }
                else
                {
                    return new ErrorMessage { error = "user not exist." };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

       /* public object userChat(tbl_chat data)
        {
            try
            {
                var offerData = DBContext.tbl_offerRide.SingleOrDefault(e => e.offerRide_ID == data.offerRide_ID);
                if (offerData != null)
                {
                    var chatData = DBContext.tbl_chat.SingleOrDefault(e=>e.offerRide_ID == data.offerRide_ID);
                }
                else
                {
                    return new ErrorMessage { error = "Ride not exist." };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }*/

        public object getUsersRating(int user_id)
        {

            try
            {
                //this is return list of your rate to users
                var yourRatingLst = DBContext.tbl_userRating.Where(e => e.user_id == user_id).OrderByDescending(e => e.rateDatetime).ToList();

                //this is return list of users rate for you
                var usersRatingLst = DBContext.tbl_userRating.Where(e => e.rate_user_id == user_id).OrderByDescending(e => e.rateDatetime).ToList();

                if (yourRatingLst.Count == 0 && usersRatingLst.Count == 0)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    List<usersRating> RatingList = new List<usersRating>();
                    foreach (var item in yourRatingLst)
                    {
                        var user = DBContext.tbl_profile.SingleOrDefault(e => e.user_id == item.rate_user_id);
                        RatingList.Add(new usersRating
                        {

                            full_name = user.full_name,//language.Trim().Equals("Persian") ? TranslateCls.Translate(user.full_name, "English", "Persian") : user.full_name,
                            user_id = user.user_id,
                            profile_pic = user.profile_pic,
                            rateDatetime = String.Format("{0:f}", item.rateDatetime),
                            ratingCount = item.ratingCount.ToString(),
                            rateType = "your rate to user"

                        });
                    }

                    foreach (var item in usersRatingLst)
                    {
                        var user = DBContext.tbl_profile.SingleOrDefault(e => e.user_id == item.user_id);
                        RatingList.Add(new usersRating
                        {
                            full_name = user.full_name,
                            user_id = user.user_id,
                            profile_pic = user.profile_pic,
                            rateDatetime = String.Format("{0:f}", item.rateDatetime),
                            ratingCount = item.ratingCount.ToString(),
                            rateType = "user rate to you"

                        });

                    }

                    return RatingList;
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }

        }

        public object getUserRating(int user_id, int rate_user_id, int offerRide_ID)
        {

            try
            {
                var result = DBContext.tbl_userRating.SingleOrDefault(e => e.offerRide_ID == offerRide_ID && e.user_id == user_id && e.rate_user_id == rate_user_id);
                if (result == null)
                {
                    return new SuccessMessage { success = "No data found" };
                }
                else
                {
                    return result;
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }

        }

        public object getPassengerAcceptInfo(int book_id)
        {
            try
            {
                tbl_book bookData = DBContext.tbl_book.AsEnumerable().Where(e => e.book_id == book_id).SingleOrDefault();

                if (bookData == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    return new PassengerAcceptInfo
                    {
                        full_name = bookData.tbl_profile.full_name,
                        user_id = bookData.tbl_profile.user_id,
                        profile_pic = bookData.tbl_profile.profile_pic,
                        from = bookData.tbl_offerRide.from_place,
                        to = bookData.tbl_offerRide.to_place,
                        book_id = book_id.ToString(),
                        currentLatLong = bookData.tbl_profile.latLong
                    };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }

        }

        public object getDriverAcceptInfo(int book_id)
        {
            try
            {
                tbl_book bookData = DBContext.tbl_book.AsEnumerable().Where(e => e.book_id == book_id).SingleOrDefault();

                if (bookData == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    return new DriverAcceptInfo
                    {
                        full_name = bookData.tbl_offerRide.tbl_profile.full_name,
                        user_id = bookData.tbl_offerRide.tbl_profile.user_id,
                        profile_pic = bookData.tbl_offerRide.tbl_profile.profile_pic,
                        from = bookData.tbl_offerRide.from_place,
                        to = bookData.tbl_offerRide.to_place,
                        book_id = book_id.ToString(),
                        currentLatLong = bookData.tbl_offerRide.tbl_profile.latLong,
                        datetime = String.Format("{0:f}", bookData.tbl_offerRide.datetime),
                        perSeatCash = (double.Parse(bookData.tbl_offerRide.price) / bookData.tbl_offerRide.no_seats).ToString(),
                        brand = bookData.tbl_offerRide.tbl_vehicle.brand,
                        carPhoto = bookData.tbl_offerRide.tbl_vehicle.carPhoto,
                        color = bookData.tbl_offerRide.tbl_vehicle.color,
                        model = bookData.tbl_offerRide.tbl_vehicle.model,
                        type = bookData.tbl_offerRide.tbl_vehicle.type,
                        plateNumber = bookData.tbl_offerRide.tbl_vehicle.plateNumber
                    };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }

        }

        public object getUsersNotification(int user_id)
        {
            try
            {
                //this is return list of users notification for you
                var usersNotificationLst = DBContext.tbl_Notification.Where(e => e.user_id == user_id).OrderByDescending(e => e.notificationDatetime).ToList();

                if (usersNotificationLst.Count == 0)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    List<usersNotification> NotificationList = new List<usersNotification>();
                    notificationCls Notification = new notificationCls();
                    //int i = 1;
                    foreach (var item in usersNotificationLst)
                    {
                        //var user = DBContext.tbl_profile.SingleOrDefault(e => e.user_id == item.user_id);
                        string[] messageObj = item.message.Split('|');
                        string book_id = messageObj[1].Split('=')[1];
                        tbl_book bookData = DBContext.tbl_book.AsEnumerable().Where(e => e.book_id == int.Parse(book_id)).SingleOrDefault();

                        NotificationList.Add(new usersNotification
                        {
                            seat = "1",
                            full_name = bookData.tbl_profile.full_name,
                            user_id = bookData.tbl_profile.user_id,
                            profile_pic = bookData.tbl_profile.profile_pic,
                            notificationDatetime = Notification.myTime(DateTime.Parse(item.notificationDatetime.ToString())),
                            message = messageObj[0],        
                            ID = item.ID,
                            from = bookData.tbl_offerRide.from_place,
                            to = bookData.tbl_offerRide.to_place,
                            rating = "4.9",
                            status = bookData.status,
                            book_id = book_id,
                            currentLatLong = bookData.tbl_profile.latLong
                        });

                       /* i++;

                        if (i == 11)
                        {
                            break;
                        }*/
                    }

                    return NotificationList;
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }

        }

        public object sendTestPush(int user_id, string msg)
        {
            try
            {
                var user = DBContext.tbl_profile.SingleOrDefault(e => e.user_id == user_id && e.deviceToken != "");
                if (user != null)
                {
                    notificationCls Notification = new notificationCls();
                    /*if (language.Trim().Equals("Persian"))
                    {
                        return Notification.sendTestPush(user.deviceToken, TranslateCls.Translate(msg,"English","Persian"));
                    }
                    else*/
                    {
                        return Notification.sendTestPush(user.deviceToken, msg);
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

        public object complaint(tbl_complaint data)
        {
            try
            {
                if (data.user_id != 0 && data.offerRide_ID != 0)
                {
                    DBContext.tbl_complaint.Add(data);
                    var result = DBContext.tbl_offerRide.SingleOrDefault(e => e.offerRide_ID == data.offerRide_ID);
                        result.complaint = true;
                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Submitted" };
                }
                else
                {
                    return new ErrorMessage { error = "user not exist." };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public string getAmount(int user_id)
        {
            var passengerData = DBContext.tbl_WalletTransaction.Where(e => e.user_id == user_id).ToList();
            if (passengerData.Count != 0)
            {
                return passengerData.LastOrDefault().Balance;
            }
            else
            {
                return "0";
            }
        }

        public object deleteNotfication(int ID)
        {
            try
            {
                tbl_Notification notficationData = DBContext.tbl_Notification.SingleOrDefault(e => e.ID == ID && e.isDeleted == null);
                if (notficationData != null)
                {
                    notficationData.isDeleted = true;
                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Notification successfully deleted" };
                }
                else
                {
                    return new ErrorMessage { error = "item not exist." };
                }
            }
            catch (Exception ex)
            {

                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public string getUserOwnRating(int rate_user_id)
        {
            var userRatingData = DBContext.tbl_userRating.Where(e => e.rate_user_id == rate_user_id).ToList();
            if (userRatingData.Count != 0)
            {
                int usersRateCount = userRatingData.Count();
                int RateCount = userRatingData.Sum(e => e.ratingCount);
                return (RateCount / usersRateCount).ToString();
            }
            else
            {
                return "0";
            }
        }

       
        public class SuccessMessage
        {
            public string success { get; set; }
        }

        public class ConvertMessage
        {
            public string text { get; set; }
        }

        public class ErrorMessage
        {
            public string error { get; set; }
        }

        public class usersRating
        {
            public int user_id { get; set; }
            public string profile_pic { get; set; }
            public string full_name { get; set; }
            public string ratingCount { get; set; }
            public string rateDatetime { get; set; }
            public string rateType { get; set; }

        }

        public class usersNotification
        {
            public int ID { get; set; }
            public int user_id { get; set; }
            public string profile_pic { get; set; }
            public string full_name { get; set; }
            public string notificationDatetime { get; set; }
            public string message { get; set; }
            public string from { get; set; }
            public string to { get; set; }
            public string seat { get; set; }
            public string rating { get; set; }
            public string status { get; set; }
            public string book_id { get; set; }
            public string currentLatLong { get; set; }
        }

        public class PassengerAcceptInfo
        {
            public int user_id { get; set; }
            public string profile_pic { get; set; }
            public string full_name { get; set; }
            public string from { get; set; }
            public string to { get; set; }
            public string book_id { get; set; }
            public string currentLatLong { get; set; }
        }

        public class DriverAcceptInfo
        {
            public int user_id { get; set; }
            public string profile_pic { get; set; }
            public string full_name { get; set; }
            public string from { get; set; }
            public string to { get; set; }
            public string book_id { get; set; }
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
    }
}