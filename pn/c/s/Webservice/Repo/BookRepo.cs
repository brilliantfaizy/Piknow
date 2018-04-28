using Webservice.helper;
using PersianDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webservice.Models;

namespace Webservice.Repo
{
    public class BookRepo
    {
        protected Service_DBEntities DBContext;
        
        public BookRepo()
        {
            DBContext = new Service_DBEntities();
            
        }

        public object bookRide(tbl_book data)
        {
            try
            {
                if (data.user_id != 0 && data.offerRide_ID != 0)
                {
                    tbl_offerRide offerRide = DBContext.tbl_offerRide.SingleOrDefault(e => e.offerRide_ID == data.offerRide_ID && e.statusType.Equals("pending") && e.no_seats != 0);
                    if (offerRide != null)
                    {
                        var passengerData = DBContext.tbl_WalletTransaction.Where(e => e.user_id == data.user_id).ToList();
                        if (passengerData == null)
                        {
                            return new ErrorMessage { error = "your wallet empty" };
                        }

                        double passengerBalance = double.Parse(passengerData.LastOrDefault().Balance);
                        if (passengerBalance == 0 || passengerBalance == 00.0 || passengerBalance == 0.0 || passengerBalance == 0.00)
                        {
                            return new ErrorMessage { error = "your wallet balance is too low" };
                        }

                        double driverPrice = double.Parse(offerRide.price);

                        if (driverPrice <= passengerBalance)
                        {
                            tbl_book bookRideUser = DBContext.tbl_book.SingleOrDefault(e=>e.user_id == data.user_id && e.offerRide_ID == data.offerRide_ID && (e.status.Equals("pending") || e.status.Equals("approved")));
                            if (bookRideUser != null)
                            {
                                return new ErrorMessage { error = "You already sent request to driver" };
                            }

                            var result = DBContext.tbl_book.Add(data);
                            string passengerCode = RandomString(6);
                            result.passengerCode = passengerCode;
                           

                            var userPassenger = DBContext.tbl_profile.SingleOrDefault(e => e.user_id == data.user_id && e.status.Equals("1") && e.deviceToken != null);
                            if (userPassenger != null && (!string.IsNullOrWhiteSpace(userPassenger.deviceToken)))
                            {

                                double karenroDetect = double.Parse(DBContext.tbl_commissionFee.FirstOrDefault().persianPassengerFee);
                                double DetectAmount = (driverPrice / 100) * karenroDetect;
                                double BalanceAmount = (passengerBalance - DetectAmount) - driverPrice;
                                double totalAmount = driverPrice + DetectAmount;
                                var passengerTrans = DBContext.tbl_WalletTransaction.Add(new tbl_WalletTransaction
                                {

                                    Balance = BalanceAmount.ToString(),
                                    Credit = (driverPrice + DetectAmount).ToString(),
                                    transaction_datetime = DateTime.Now,
                                    transaction_Title = "Paid",
                                    user_id = data.user_id,
                                    Debit = "",
                                    rechargedBy = ""

                                });

                                DBContext.SaveChanges();

                                DBContext.tbl_transDetails.Add(new tbl_transDetails {

                                    transaction_ID = passengerTrans.transaction_ID,
                                    KarenroDetect = DetectAmount.ToString(),
                                    amount = driverPrice.ToString(),
                                    total = totalAmount.ToString(),
                                    userType = "passenger",
                                    offerRide_ID = offerRide.offerRide_ID
                                
                                });

                                notificationCls Notification = new notificationCls();

                                var userDriver = DBContext.tbl_profile.SingleOrDefault(e => e.user_id == offerRide.user_id && e.status.Equals("1") && e.approved == true && e.deviceToken != null);
                                if (userDriver != null && (!string.IsNullOrWhiteSpace(userDriver.deviceToken)))
                                {

                                    Notification.sendPush(userDriver.deviceToken, "Offer ride request" + "|offerRide_ID=" + data.offerRide_ID + "|user_id=" + data.user_id + "|book_id=" + result.book_id);
                                    DBContext.tbl_Notification.Add(new tbl_Notification
                                    {
                                        message = "Offer ride request|offerRide_ID=" + data.offerRide_ID + "|user_id=" + data.user_id + "|book_id=" + result.book_id,
                                        notification_user_id = userDriver.user_id,
                                        notificationDatetime = DateTime.Now,
                                        user_id = data.user_id

                                    });

                                }

                                string Yourcode = "Your code";
                                string amountis = "and ride total amount is";

                                Notification.sendPush(userPassenger.deviceToken, Yourcode + " # " + passengerCode + " " + amountis + " " + totalAmount + " |offerRide_ID=" + data.offerRide_ID);
                                DBContext.tbl_Notification.Add(new tbl_Notification
                                {
                                    message = "Your code # " + passengerCode + " and ride total amount is " + totalAmount + " |offerRide_ID=" + data.offerRide_ID,
                                    notification_user_id = userPassenger.user_id,
                                    notificationDatetime = DateTime.Now,
                                    user_id = offerRide.user_id

                                });

                                DBContext.tbl_adminBank.Add(new tbl_adminBank {

                                    amount = totalAmount.ToString(),
                                    CreatedAt = DateTime.Now,
                                    offerRide_ID = offerRide.offerRide_ID,
                                    user_id = data.user_id,
                                    userType = "passenger",
                                    transaction_ID = passengerTrans.transaction_ID,
                                    paymentStatus = "pending",
                                    book_id = result.book_id

                                });

                                DBContext.SaveChanges();
                            }


                            return new SuccessMessage { success = "Submitted" };
                        }
                        else
                        {
                            return new ErrorMessage { error = "your wallet balance is low" };
                        }

                    }
                    else
                    {
                        return new ErrorMessage { error = "Offer ride not exist." };
                    }
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

        private Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public object getBookRides(int user_id)
        {

            try
            {
                var OfferRides = DBContext.tbl_offerRide.Where(e => e.user_id == user_id && e.status == true).ToList();
                if (OfferRides.Count != 0)
                {
                    var Users = DBContext.tbl_profile.Where(b => b.status.Equals("1") && b.approved == true);
                    List<bookRidesKeysCls> bookRidesKeysClsLst = new List<bookRidesKeysCls>();
                    var bookRidesLst = DBContext.tbl_book.ToList();
                    
                    {
                        foreach (tbl_offerRide offerItem in OfferRides)
                        {
                            var bookRides = bookRidesLst.SingleOrDefault(s => s.offerRide_ID == offerItem.offerRide_ID);
                            if (bookRides != null)
                            {
                                var UserDetail = Users.SingleOrDefault(s => s.user_id == bookRides.user_id);
                                if (UserDetail != null)
                                {
                                    bookRidesKeysClsLst.Add(new bookRidesKeysCls
                                    {
                                        datetime = String.Format("{0:f}", bookRides.datetime),
                                        full_name = UserDetail.full_name,
                                        message = "",
                                        profilePic = UserDetail.profile_pic,
                                        user_id = UserDetail.user_id,
                                        book_id = bookRides.book_id
                                    });
                                }

                            }

                        }
                    }
                    if (bookRidesKeysClsLst.Count != 0)
                    {
                        return bookRidesKeysClsLst;
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
        public object cancelRide(int book_id, int user_id)
        {

            try
            {
                var result = DBContext.tbl_book.SingleOrDefault(e => e.book_id == book_id && e.status.Equals("pending"));
                if (result == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    
                    tbl_profile user = DBContext.tbl_profile.SingleOrDefault(e => e.user_id == result.user_id);
                    if (user != null)
                    {
                        var adminBank = DBContext.tbl_adminBank.SingleOrDefault(e => e.offerRide_ID == result.offerRide_ID && e.user_id == user_id && e.book_id == book_id && e.paymentStatus.Equals("pending"));
                        string returnAmount = "0";
                        if (adminBank != null)
                        {
                            var userPassengerTrans = DBContext.tbl_WalletTransaction.Where(e => e.user_id == user_id).ToList().LastOrDefault();
                            var passengerTransDetail = DBContext.tbl_transDetails.SingleOrDefault(e => e.transaction_ID == adminBank.transaction_ID);

                            returnAmount = adminBank.amount;
                            string passengerBalance = (double.Parse(userPassengerTrans.Balance) + double.Parse(returnAmount)).ToString();
                            adminBank.paymentStatus = "canceled";
                            var passengerTrans = DBContext.tbl_WalletTransaction.Add(new tbl_WalletTransaction
                            {
                                Balance = passengerBalance,
                                Debit = returnAmount,
                                transaction_datetime = DateTime.Now,
                                transaction_Title = "Return",
                                user_id = user_id,
                                rechargedBy = "",
                                Credit = ""

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

                        result.status = "canceled";
                        DBContext.SaveChanges();

                        notificationCls Notification = new notificationCls();
                        Notification.sendPush(user.deviceToken, "Ride canceled and amount" + " " + returnAmount + " " + "return to your wallet." + " |offerRide_ID=" + result.offerRide_ID);

                    }
                    return new SuccessMessage { success = "Ride successfully canceled" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }

        }
        public object approvedRide(int book_id, int user_id)
        {
            try
            {
                var result = DBContext.tbl_book.SingleOrDefault(e => e.book_id == book_id && e.status.Equals("pending"));
                if (result == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    result.status = "approved";
                    DBContext.SaveChanges();
                    tbl_profile user = DBContext.tbl_profile.SingleOrDefault(e => e.user_id == result.user_id);
                    if (user != null)
                    {
                        DBContext.tbl_Notification.Add(new tbl_Notification
                        {
                            message = "Offer ride approved|book_id=" + result.book_id,
                            notification_user_id = user_id,
                            notificationDatetime = DateTime.Now,
                            user_id = user.user_id
                        });
                        DBContext.SaveChanges();
                        notificationCls Notification = new notificationCls();
                        Notification.sendPush(user.deviceToken, "Offer ride approved" + "|book_id=" + result.book_id);
                    }
                    return new SuccessMessage { success = "Ride successfully approved" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object startRide(int book_id)
        {
            try
            {
                var result = DBContext.tbl_book.SingleOrDefault(e => e.book_id == book_id && e.status.Equals("approved"));
                if (result == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    result.status = "started";
                    DBContext.SaveChanges();
                    DBContext.tbl_Notification.Add(new tbl_Notification
                    {
                        message = "Ride started.|book_id=" + result.book_id,
                        notification_user_id = result.tbl_offerRide.tbl_profile.user_id,
                        notificationDatetime = DateTime.Now,
                        user_id = result.user_id
                    });
                    DBContext.SaveChanges();
                    notificationCls Notification = new notificationCls();
                    Notification.sendPush(result.tbl_profile.deviceToken, "Ride started" + "|book_id=" + result.book_id);
                    return new SuccessMessage { success = "Ride successfully started" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object completeRide(int book_id)
        {
            try
            {
                var result = DBContext.tbl_book.SingleOrDefault(e => e.book_id == book_id && e.status.Equals("started"));
                if (result == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    result.status = "completed";
                    DBContext.SaveChanges();
                    DBContext.tbl_Notification.Add(new tbl_Notification
                    {
                        message = "Ride completed.|book_id=" + result.book_id,
                        notification_user_id = result.tbl_offerRide.tbl_profile.user_id,
                        notificationDatetime = DateTime.Now,
                        user_id = result.user_id
                    });
                    DBContext.SaveChanges();
                    notificationCls Notification = new notificationCls();
                    Notification.sendPush(result.tbl_profile.deviceToken, "Ride completed" + "|book_id=" + result.book_id);
                    return new SuccessMessage { success = "Ride successfully completed" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object iAmArrived(int book_id)
        {
            try
            {
                var result = DBContext.tbl_book.SingleOrDefault(e => e.book_id == book_id);
                if (result == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    DBContext.tbl_Notification.Add(new tbl_Notification
                    {
                        message = "I am arrived.|book_id=" + result.book_id,
                        notification_user_id = result.tbl_offerRide.tbl_profile.user_id,
                        notificationDatetime = DateTime.Now,
                        user_id = result.user_id
                    });
                    notificationCls Notification = new notificationCls();
                    Notification.sendPush(result.tbl_profile.deviceToken, "I am arrived." + "|book_id=" + result.book_id);
                    return new SuccessMessage { success = "Success" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object iAmComing(int book_id)
        {
            try
            {
                var result = DBContext.tbl_book.SingleOrDefault(e => e.book_id == book_id);
                if (result == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    DBContext.tbl_Notification.Add(new tbl_Notification
                    {
                        message = "I am coming.|book_id=" + result.book_id,
                        notification_user_id = result.user_id,
                        notificationDatetime = DateTime.Now,
                        user_id = result.tbl_offerRide.tbl_profile.user_id
                    });
                    notificationCls Notification = new notificationCls();
                    Notification.sendPush(result.tbl_offerRide.tbl_profile.deviceToken, "I am coming." + "|book_id=" + result.book_id);
                    return new SuccessMessage { success = "Success" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object getLocations(int book_id)
        {
            try
            {
                var result = DBContext.tbl_book.SingleOrDefault(e => e.book_id == book_id);
                if (result == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    return new locationsCls { driverLatLong = result.tbl_offerRide.tbl_profile.latLong, passengerLatLong = result.tbl_profile.latLong };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object canceledRide(int book_id, int user_id)
        {
            try
            {
                var result = DBContext.tbl_book.SingleOrDefault(e => e.book_id == book_id && e.status.Equals("pending"));
                if (result == null)
                {
                    return new ErrorMessage { error = "No data found" };
                }
                else
                {
                    result.status = "canceled";
                    DBContext.SaveChanges();
                    tbl_profile user = DBContext.tbl_profile.SingleOrDefault(e => e.user_id == result.user_id);
                    if (user != null)
                    {
                        DBContext.tbl_Notification.Add(new tbl_Notification
                        {
                            message = "Offer ride canceled|offerRide_ID=" + result.offerRide_ID,
                            notification_user_id = user_id,
                            notificationDatetime = DateTime.Now,
                            user_id = user.user_id
                        });
                        DBContext.SaveChanges();
                        notificationCls Notification = new notificationCls();
                        Notification.sendPush(user.deviceToken, "Offer ride canceled" + "|offerRide_ID=" + result.offerRide_ID);

                    }
                    return new SuccessMessage { success = "Ride successfully canceled" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        private class bookRidesKeysCls
        {
            public int user_id { get; set; }
            public int book_id { get; set; }
            public string profilePic { get; set; }
            public string full_name { get; set; }
            public string message { get; set; }
            public string datetime { get; set; }
        }
        public class SuccessMessage
        {
            public string success { get; set; }
        }

        public class locationsCls
        {
            public string driverLatLong { get; set; }
            public string passengerLatLong { get; set; }
        }

        public class ErrorMessage
        {
            public string error { get; set; }
        }
    }
}