using Webservice.helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Webservice.Models;

namespace Webservice.Repo
{
    public class UserRepo
    {
        protected Service_DBEntities DBContext;
        protected OtherRepo OtherRepos;
        
        public UserRepo()
        {
            DBContext = new Service_DBEntities();
            OtherRepos = new OtherRepo();
            
        }

        public object Registration(tbl_profile data, HttpPostedFile Profile, HttpPostedFile frant, HttpPostedFile back)
        {
            try
            {
                var result = DBContext.tbl_profile.SingleOrDefault(e => e.email.Equals(data.email));
                if (result == null)
                {
                    var user = DBContext.tbl_profile.Add(data);
                                if (Profile != null)
                                {
                                    string Profiles = PutFile(Profile);
                                    if (Profiles != "")
                                    {
                                        user.profile_pic = Profiles;
                                    }
                                }
                                if (frant != null)
                                {
                                    string frants = PutFile(frant);
                                    if (frants != "")
                                    {
                                        user.cnic_frant = frants;
                                    }
                                }

                                if (back != null)
                                {
                                    string backs = PutFile(back);
                                    if (backs != "")
                                    {
                                        user.cnic_back = backs;
                                    }
                                }
                    if (!string.IsNullOrWhiteSpace(user.deviceToken))
                    {
                      

                        /*notificationCls Notification = new notificationCls();
                        Notification.sendPush(user.deviceToken, "You have been successfully registered." + "");

                        DBContext.tbl_Notification.Add(new tbl_Notification
                        {
                            message = "You have been successfully registered.",
                            notification_user_id = user.user_id,
                            notificationDatetime = DateTime.Now,
                            user_id = user.user_id
                        });
                        DBContext.SaveChanges();*/
                    }
                    DBContext.SaveChanges();
                    return new SuccessMessage { success = user.user_id.ToString() };
                }
                else
                {
                    return new ErrorMessage { error = "Email is already exist." };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object editProfile(tbl_profile data, HttpPostedFile Profile, HttpPostedFile frant, HttpPostedFile back)
        {
            try
            {
                if (data.user_id == 0)
                {
                    return new ErrorMessage { error = "user not exist." };
                }
                else
                {
                    var result = DBContext.tbl_profile.Where(u => u.user_id == data.user_id).FirstOrDefault();
                    result.birthday = data.birthday;
                    result.full_name = data.full_name;
                    result.gender = data.gender;
                    result.password = data.password;
                    result.country = data.country;
                    //result.receive_email = data.receive_email;
                    result.number = data.number;
                    DBContext.SaveChanges();

                    /*if (cardFront != null)
                    {
                        string cardFronts = PutFile(cardFront);
                        if (cardFronts != "")
                        {
                            deleteFile(result.id_card_front);
                            result.id_card_front = cardFronts;
                        }
                    }

                    if (cardBack != null)
                    {
                        string cardBacks = PutFile(cardBack);
                        if (cardBacks != "")
                        {
                            deleteFile(result.id_card_back);
                            result.id_card_back = cardBacks;
                        }
                    }*/

                    if (Profile != null)
                    {
                        string Profiles = PutFile(Profile);
                        if (Profiles != "")
                        {
                            deleteFile(result.profile_pic);
                            result.profile_pic = Profiles;
                        }
                    }

                    if (frant != null)
                    {
                        string frants = PutFile(frant);
                        if (frants != "")
                        {
                            deleteFile(result.cnic_frant);
                            result.cnic_frant = frants;
                        }
                    }

                    if (back != null)
                    {
                        string backs = PutFile(back);
                        if (backs != "")
                        {
                            deleteFile(result.cnic_back);
                            result.cnic_back = backs;
                        }
                    }


                    /*if (!string.IsNullOrWhiteSpace(accountData.accountNumber))
                    {
                        var Data = DBContext.tbl_accountDetail.SingleOrDefault(e => e.user_id == accountData.user_id);
                        if (Data == null)
                        {
                            DBContext.tbl_accountDetail.Add(accountData);
                        }
                        else
                        {
                            Data.accountHolder = accountData.accountHolder;
                            Data.accountNumber = accountData.accountNumber;
                            Data.bankName = accountData.bankName;
                            Data.shabaNumber = accountData.shabaNumber;
                        }
                    }*/

                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "updated" };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object updateLocation(string user_id, string latLong)
        {
            try
            {
                var result = DBContext.tbl_profile.AsEnumerable().Where(u => u.user_id == int.Parse(user_id)).SingleOrDefault();
                result.latLong = latLong;
                DBContext.SaveChanges();
                return new SuccessMessage { success = "updated" };
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        private string accountDetail(tbl_accountDetail data)
        {
            try
            {
                var result = DBContext.tbl_profile.SingleOrDefault(e => e.user_id.Equals(data.user_id));
                if (result == null)
                {
                    return "User not exist.";
                }
                else
                {

                    DBContext.tbl_accountDetail.Add(new tbl_accountDetail { 
                        
                        accountHolder = data.accountHolder,
                        accountNumber = data.accountNumber,
                        bankName = data.bankName,
                        shabaNumber = data.shabaNumber,
                        user_id = data.user_id
                    });

                    DBContext.SaveChanges();
                    return "Account detail added.";
                }


            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return "error";
            }
        }

        public object userComes(tbl_userComesFrom data)
        {
            try
            {
                if (data.company_id == 0 || data.company_id == null)
                {
                    DBContext.tbl_userComesFrom.Add(data);
                }
                else
                {
                    DBContext.tbl_companyDetail.Add(new tbl_companyDetail
                    {
                        company_id = (int)data.company_id,
                        user_id = data.user_id
                    });
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

        public object checkUserExist(string email)
        {
            if (DBContext.tbl_profile.Where(e => e.email.Equals(email)).ToList().Count > 0)
            {
                return new ErrorMessage { error = "Provided email is already in use." };
            }
            else
            {
                return new SuccessMessage { success = "ok" };
            }
        }

        public object UserExist(string email)
        {
            var user = DBContext.tbl_profile.SingleOrDefault(e => e.email.Equals(email));
            if (user != null)
            {
                return new SuccessMessage { success = user.user_id.ToString() };
            }
            else
            {
                return new ErrorMessage { error = "Provided email not in use." };
            }
        }

        public object forgetPassword(string email)
        {
            var user = DBContext.tbl_profile.SingleOrDefault(e => e.email.Equals(email));
            if (user != null)
            {

                byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
                byte[] key = Guid.NewGuid().ToByteArray();
                string token = Convert.ToBase64String(time.Concat(key).ToArray());
                string ChangePassword_Page = WebConfigurationManager.AppSettings["ChangePassword_Page"];

                notificationCls Notification = new notificationCls();
                string toEmail = user.email;
                string subject = "Changing Password";
                string heading = "Password Change Instructions";
                string passwordChangeURL = "" + ChangePassword_Page + "?number=" + user.number.Replace("+", "") + "&token=" + token + "";

                    string mailBody = "<p>Fill in the fields to change your password and submit the form. You will not see the password you submitted, so you need to remember it.</p><a href='" + passwordChangeURL + "' target='_blank'>Go to the password change page here.</a>";

                    if(Notification.SendEmail_toUser(toEmail, subject, heading, mailBody))
                    {
                        user.forgetPasswordToken = token;
                        DBContext.SaveChanges();
                        return new SuccessMessage { success = "Password changing instructions sent to your email address." };
                    }
                    else
                    {
                        return new ErrorMessage { error = "Provided email not in use." };
                    }
            }
            else
            {
                return new ErrorMessage { error = "Provided email not in use." };
            }
        }
       

        public object Authentication(string email, string password, string deviceToken)
        {

            try
            {
                var result = DBContext.tbl_profile.SingleOrDefault(e => e.email.Equals(email) && e.password.Equals(password) && e.status.Equals("1"));
                if (result != null && (!string.IsNullOrEmpty(deviceToken)))
                {
                    result.deviceToken = deviceToken;
                    DBContext.SaveChanges();
                    return new SuccessMessageId { id = result.user_id.ToString() };
                }
                else
                {
                    return new ErrorMessage { error = "Wrong email/password or device token is empty"};
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong"};
            }

        }

        public object logout(string email)
        {
            try
            {
                var result = DBContext.tbl_profile.SingleOrDefault(e => e.email.Equals(email));
                if (result != null)
                {
                    result.deviceToken = "";
                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Logout successfully." };
                }
                else
                {
                    return new ErrorMessage { error = "Wrong email" };
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public object getProfile(int user_id)
        {

            try
            {
                var resultData = DBContext.tbl_profile.Where(e => e.user_id == user_id && e.status.Equals("1")).SingleOrDefault();
                if (resultData != null)
                {
                    if (resultData.tbl_accountDetail.SingleOrDefault() != null)
                    {
                        return new profile
                        {
                            country = resultData.country,
                            birthday = resultData.birthday,
                            email = resultData.email,
                            fname = resultData.full_name,
                            gender = resultData.gender,
                            //id_cardBack = resultData.id_card_back,
                            //id_cardFront = resultData.id_card_front,
                            password = resultData.password,
                            profilePic = resultData.profile_pic,
                            cnicFrant = resultData.cnic_frant,
                            cnicBack = resultData.cnic_back,
                            //receive_email = resultData.receive_email,
                            type = resultData.type,
                            approved = resultData.approved,
                            rating = OtherRepos.getUserOwnRating(user_id),
                            amount = Math.Round(decimal.Parse(OtherRepos.getAmount(user_id)), 2).ToString(),
                            //fastTrackIsAuto = ((bool)resultData.fastTrackIsAuto) ? "1" : "0",
                            number = resultData.number.Replace("+", ""),
                            latLong = resultData.latLong
                            //accountHolder = resultData.tbl_accountDetail.SingleOrDefault().accountHolder,
                            //accountNumber = resultData.tbl_accountDetail.SingleOrDefault().accountNumber,
                            //shabaNumber = resultData.tbl_accountDetail.SingleOrDefault().shabaNumber,
                            //bankName = resultData.tbl_accountDetail.SingleOrDefault().bankName,
                        };

                    }
                    else
                    {
                        return new profile
                        {
                            country = resultData.country,
                            birthday = resultData.birthday,
                            email = resultData.email,
                            fname = resultData.full_name,
                            gender = resultData.gender,
                            //id_cardBack = resultData.id_card_back,
                            //id_cardFront = resultData.id_card_front,
                            password = resultData.password,
                            profilePic = resultData.profile_pic,
                            cnicFrant = resultData.cnic_frant,
                            cnicBack = resultData.cnic_back,
                            //receive_email = resultData.receive_email,
                            type = resultData.type,
                            approved = resultData.approved,
                            rating = OtherRepos.getUserOwnRating(user_id),
                            amount = Math.Round(decimal.Parse(OtherRepos.getAmount(user_id)), 2).ToString(),
                            //fastTrackIsAuto = ((bool)resultData.fastTrackIsAuto) ? "1" : "0",
                            number = resultData.number.Replace("+", ""),
                            latLong = resultData.latLong
                            //accountHolder = "",
                            //accountNumber = "",
                            //shabaNumber = "",
                            //bankName = ""
                        };
                    }

                       
                    //}
                    
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

        public tbl_profile getUserProfile(int user_id)
        {
            //var user = DBContext.tbl_profile.SingleOrDefault(e => e.status.Equals("1") && e.approved == true && e.type != "" && e.type != null && e.user_id == user_id);
            var user = DBContext.tbl_profile.SingleOrDefault(e => e.status.Equals("1") && e.approved == true && e.user_id == user_id);
            if (user != null)
            {
                return user;
            }
            else
            {
                tbl_profile a = new tbl_profile();
                return a;
            }
        }

        public object isApproved(int user_id)
        {

            try
            {
                var resultData = DBContext.tbl_profile.Where(e => e.user_id == user_id && e.status.Equals("1")).FirstOrDefault();
                if (resultData != null)
                {
                    return new profileApproved
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

        public string PutFile(HttpPostedFile file)
        {
            // string ret = "";
            // HttpRequest request = this.Context.Request;
            // HttpPostedFile file = request.Files["upload"];
            // string FileName = file.FileName;
            // string cropName = request["cropName"];

            /* string ext = Path.GetExtension(FileName).ToLower();

             if (!(ext == ".png" || ext == ".jpg" || ext == ".jpeg"))// for only images file
             {
                 ret = string.Format("File extension {0} not allowed.", ext);

                 // return ret;
             }*/

            if (file.FileName != "")
            {
                string path = HttpContext.Current.Server.MapPath(".");
                string UUID = System.Guid.NewGuid().ToString();
                string filepath = path + "/upload/" + UUID + ".png";

                file.SaveAs(filepath);
                // add your code if any
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

        public class SuccessMessageId
        {
            public string id { get; set; }
        }

        public class SuccessMessage
        {
            public string success { get; set; }
        }

        public class ErrorMessage
        {
            public string error { get; set; }
        }

        public class profile
        {
            public string country { get; set; }
            public string fname { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string gender { get; set; }
            public string birthday { get; set; }
            public string profilePic { get; set; }
            public string cnicFrant { get; set; }
            public string cnicBack { get; set; }
            
            //public string receive_email { get; set; }
            public string type { get; set; }
            //public string id_cardFront { get; set; }
            //public string id_cardBack { get; set; }
            public string rating { get; set; }
            public string amount { get; set; }
            public Nullable<bool> approved { get; set; }
            //public string fastTrackIsAuto { get; set; }
            public string number { get; set; }

            public string latLong { get; set; }

            //public string accountHolder { get; set; }
            //public string accountNumber { get; set; }
            //public string bankName { get; set; }
            //public string shabaNumber { get; set; }
        }

        public class profileApproved
        {
            public string approved { get; set; }
        }
    }
}