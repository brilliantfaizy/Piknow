using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Portal.Repo
{
    public class OtherRepo
    {
        protected PN_Entities DBContext;
        public OtherRepo()
        {
            DBContext = new PN_Entities();
        }

        public int totalUsers()
        {
            return DBContext.tbl_profile.Count();
        }

        public int companyUsers()
        {
            return DBContext.tbl_company.Count();
        }

        public int governmentUsers()
        {
            return DBContext.tbl_governmentDetail.Count();
        }

        public int canceledTrips()
        {
            return DBContext.tbl_fastRide.Where(e => e.statusType == "canceled").Count() + DBContext.tbl_offerRide.Where(e => e.statusType == "canceled").Count();
        }

        public int pendingTrips()
        {
            return DBContext.tbl_fastRide.Where(e => e.statusType == "pending" || e.statusType == "approved" || e.statusType == "started").Count() + DBContext.tbl_offerRide.Where(e => e.statusType == "pending").Count();
        }

        public int completedTrips()
        {
            return DBContext.tbl_fastRide.Where(e => e.statusType == "finished").Count() + DBContext.tbl_offerRide.Where(e => e.statusType == "completed").Count();
        }

        public bool Authentication(string username, string password)
        {
            try
            {
                var result = DBContext.tbl_government.SingleOrDefault(e => e.username.Equals(username) && e.password.Equals(password));
                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public tbl_general getGeneraldata()
        {

            try
            {
                var result = DBContext.tbl_general.FirstOrDefault();
                if (result == null)
                {
                    return null;
                }
                else
                {
                    return result;
                }

            }
            catch (Exception)
            {
                return null;
            }

        }
        public bool setGeneraldata(tbl_general data)
        {

            try
            {
                var result = DBContext.tbl_general.SingleOrDefault(e => e.ID == data.ID);
                if (result == null)
                {
                    return false;
                }
                else
                {
                    result.percentDetect = data.percentDetect;
                    result.perKM = data.perKM;
                    result.passengerDetect = data.passengerDetect;
                    result.fastTrackAmount = data.fastTrackAmount;
                    DBContext.SaveChanges();
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }

        public object getAdminTransactions()
        {
            try
            {
                var result = DBContext.tbl_adminTransaction;
                if (result == null)
                {
                    return null;
                }
                else
                {
                    List<adminTransactionCls> adminTransactionLst = new List<adminTransactionCls>();
                    foreach (var item in result)
                    {
                        adminTransactionLst.Add(new adminTransactionCls {
                            
                            Balance = item.Balance,
                            Credit = item.Credit,
                            Debit = item.Debit,
                            full_name = item.tbl_profile.full_name,
                            transaction_datetime = item.transaction_datetime,
                            transaction_ID = item.transaction_ID,
                            transaction_Title = item.transaction_Title,
                            type = item.type,
                            receivedCommission = item.receivedCommission
                        });
                    }
                    return adminTransactionLst.ToList().OrderByDescending(e => e.transaction_datetime);
                }

            }
            catch (Exception)
            {
                return null;
            }

        }

        public object getUsersComplaint()
        {
            try
            {
                var result = DBContext.tbl_complaint.ToList().OrderByDescending(e=>e.datetime);
                if (result == null)
                {
                    return null;
                }
                else
                {
                    string imagesServerPath = WebConfigurationManager.AppSettings["imagesServerPath"];
                    List<complaintCls> complaintLst = new List<complaintCls>();
                    foreach (var item in result)
                    {
                        complaintLst.Add(new complaintCls
                        {
                            complaint_id = item.id,
                            datetime = String.Format("{0:f}", item.datetime),
                            from_place = item.tbl_offerRide.from_place,
                            full_name = item.tbl_profile.full_name,
                            message = item.message,
                            profile_pic = imagesServerPath+item.tbl_profile.profile_pic,
                            rating = getUserOwnRating(item.user_id),
                            to_place = item.tbl_offerRide.to_place,
                            tripAs = item.user_id == item.tbl_offerRide.user_id ? "Driver" : "Passenger",
                            user_id = item.user_id,
                            number = item.tbl_profile.number
                        });
                    }
                    return complaintLst;
                }

            }
            catch (Exception)
            {
                return null;
            }

        }

        public string getUserOwnRating(int rate_user_id)
        {
            string rating = "0";
            var userRatingData = DBContext.tbl_userRating.Where(e => e.rate_user_id == rate_user_id).ToList();
            if (userRatingData.Count != 0)
            {
                int usersRateCount = userRatingData.Count();
                int RateCount = userRatingData.Sum(e => e.ratingCount);
                rating = String.Format("{0:0.##}", double.Parse((RateCount / usersRateCount).ToString()));
                return rating;
            }
            else
            {
                return rating;
            }
        }

        public class adminTransactionCls
        {
            public int transaction_ID { get; set; }
            public string full_name { get; set; }
            public string type { get; set; }
            public string transaction_Title { get; set; }
            public DateTime transaction_datetime { get; set; }
            public string Debit { get; set; }
            public string Credit { get; set; }
            public string Balance { get; set; }
            public string receivedCommission { get; set; }
        }

        public class complaintCls
        {
            public int complaint_id { get; set; }
            public int user_id { get; set; }
            public string message { get; set; }
            public string profile_pic { get; set; }
            public string full_name { get; set; }
            public string tripAs { get; set; }
            public string from_place { get; set; }
            public string to_place { get; set; }
            public string datetime { get; set; }
            public string rating { get; set; }
            public string number { get; set; }
        }

        public tbl_commissionFee getCommissionFee()
        {

            try
            {
                var result = DBContext.tbl_commissionFee.FirstOrDefault();
                if (result == null)
                {
                    return null;
                }
                else
                {
                    return result;
                }

            }
            catch (Exception)
            {
                return null;
            }

        }
        public bool setCommissionFee(tbl_commissionFee data)
        {
            try
            {
                var result = DBContext.tbl_commissionFee.SingleOrDefault(e => e.FeeID == data.FeeID);
                if (result == null)
                {
                    return false;
                }
                else
                {
                    result.driversFee = data.driversFee;
                    result.foreignPassengerFee = data.foreignPassengerFee;
                    result.persianPassengerFee = data.persianPassengerFee;
                    result.minFastInBalance = data.minFastInBalance;
                    result.updatedAt = data.updatedAt;
                    DBContext.SaveChanges();
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public tbl_government getGovernmentCode()
        {

            try
            {
                var result = DBContext.tbl_government.FirstOrDefault();
                if (result == null)
                {
                    return null;
                }
                else
                {
                    return result;
                }

            }
            catch (Exception)
            {
                return null;
            }

        }
        public bool setGovernmentCode(tbl_government data)
        {
            try
            {
                var result = DBContext.tbl_government.SingleOrDefault(e => e.government_id == data.government_id);
                if (result == null)
                {
                    return false;
                }
                else
                {
                    result.government_code = data.government_code;
                    result.updatedAt = data.updatedAt;
                    DBContext.SaveChanges();
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public tbl_company getCompanyDetails(int company_id)
        {
            var CompanyDetails = DBContext.tbl_company.SingleOrDefault(e => e.company_id == company_id);
            return CompanyDetails;
        }

        #region Discount functions

        public object getDiscountCodes()
        {
            try
            {
                return DBContext.tbl_discountCode.ToList().OrderByDescending(e => e.createdAt);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public tbl_discountCode getDiscountCode(int discountID)
        {
            try
            {
                return DBContext.tbl_discountCode.SingleOrDefault(e => e.discountID == discountID);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string addDiscountCode(tbl_discountCode data)
        {
            try
            {
                var details = DBContext.tbl_discountCode.SingleOrDefault(e => e.discountCode.ToLower() == data.discountCode.ToLower() && e.expireDate == data.expireDate);
                if (details != null)
                {
                    return "already";
                }
                else
                {
                    DBContext.tbl_discountCode.Add(data);
                    DBContext.SaveChanges();
                    return "true";
                }

            }
            catch (Exception)
            {
                return "false";
            }
        }

        public bool deleteDiscountCode(int discountID)
        {
            try
            {
                var data = DBContext.tbl_discountCode.SingleOrDefault(e => e.discountID == discountID);
                DBContext.tbl_discountCode.Remove(data);
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updateDiscountCode(tbl_discountCode data)
        {
            try
            {
                var result = DBContext.tbl_discountCode.SingleOrDefault(e => e.discountID == data.discountID);
                result.availableNumber = data.availableNumber;
                result.discountCode = data.discountCode;
                result.discountFee = data.discountFee;
                result.expireDate = data.expireDate;
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

    }
}