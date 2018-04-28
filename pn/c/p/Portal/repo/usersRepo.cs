using Portal.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Portal.repo
{
    public class usersRepo
    {
        protected PN_Entities DBContext;

        public bool Authentication(string username, string password)
        {
            try
            {
                var result = DBContext.tbl_admin.SingleOrDefault(e => e.username.Equals(username) && e.password.Equals(password));
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

        public bool tokenValidate(string userNumber, string userToken)
        {
            try
            {
                var result = DBContext.tbl_profile.SingleOrDefault(e => e.number.Equals(userNumber) && e.forgetPasswordToken.Equals(userToken));
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
        public usersRepo()
        {
            DBContext = new PN_Entities();
        }

        public object getUsers()
        {
            var data = DBContext.tbl_profile.ToList().OrderByDescending(e=>e.createdAt);
            List<profile> UserList = new List<profile>();
            foreach (var item in data)
            {
                string gender = "";
                string language = "";
                if (!string.IsNullOrWhiteSpace(item.gender))
                {
                    if (item.gender.ToLower().Equals("male") || item.gender.Equals("1"))
                    {
                        gender = "Male";
                    }
                    else if (item.gender.ToLower().Equals("female") || item.gender.Equals("0"))
                    {
                        gender = "Female";
                    }
                }

                //if (!string.IsNullOrWhiteSpace(item.language))
                //{
                //    if (item.language.ToLower().Equals("english"))
                //    {
                //        language = "English";
                //    }
                //    else if (item.language.ToLower().Equals("farsi"))
                //    {
                //        language = "Farsi";
                //    }
                //}

                string birthday = "";

                if (string.IsNullOrWhiteSpace(item.birthday) || item.birthday.Equals("null"))
                {
                    birthday = "";

                }else
                {
                    try
                    {
                        birthday = String.Format("{0:dddd, MMMM d, yyyy}", DateTime.Parse(item.birthday));
                    }
                    catch (Exception)
                    {
                        
                        birthday = "";
                    }
                }

                string imagesServerPath = WebConfigurationManager.AppSettings["imagesServerPath"];
                UserList.Add(new profile
                {
                    birthday = birthday,
                    email = item.email,
                    full_name = item.full_name,
                    gender = gender,
                    number = item.number,
                    user_id = item.user_id,
                    approved = item.approved,
                    createdAt = String.Format("{0:g}", item.createdAt),
                    cnic_back = imagesServerPath + item.cnic_back,
                    cnic_frant = imagesServerPath + item.cnic_frant,
                    profile_pic = imagesServerPath + item.profile_pic,
                    
                });
            }

            return UserList;
        }

        public object getCompanyUsers(string email)
        {
            var data = DBContext.tbl_companyDetail.Where(e => e.tbl_company.email.Equals(email)).ToList();
            List<profile> UserList = new List<profile>();
            foreach (var items in data)
            {
                var item = items.tbl_profile;
                string gender = "";
                string language = "";
                if (!string.IsNullOrWhiteSpace(item.gender))
                {
                    if (item.gender.ToLower().Equals("male") || item.gender.Equals("1"))
                    {
                        gender = "Male";
                    }
                    else if (item.gender.ToLower().Equals("female") || item.gender.Equals("0"))
                    {
                        gender = "Female";
                    }
                }

                //if (!string.IsNullOrWhiteSpace(item.language))
                //{
                //    if (item.language.ToLower().Equals("english"))
                //    {
                //        language = "English";
                //    }
                //    else if (item.language.ToLower().Equals("farsi"))
                //    {
                //        language = "Farsi";
                //    }
                //}


                UserList.Add(new profile
                {
                    birthday = string.IsNullOrWhiteSpace(item.birthday) ? "" : String.Format("{0:dddd, MMMM d, yyyy}", DateTime.Parse(item.birthday)),
                    email = item.email,
                    full_name = item.full_name,
                    gender = gender,
                    language = language,
                    number = item.number,
                    status = string.IsNullOrEmpty(item.status) ? "" : item.status.Trim().Equals("0") ? "InActive" : "Active",
                    user_id = item.user_id,
                    approved = item.approved,
                    createdAt = String.Format("{0:g}", item.createdAt)
                });
            }

            return UserList;
        }

        public tbl_profile getUserDetail(int user_id)
        {
            var item = DBContext.tbl_profile.AsEnumerable().SingleOrDefault(e => e.user_id == user_id);
            return new tbl_profile
            {
                //birthday = string.IsNullOrWhiteSpace(item.birthday)?"":String.Format("{0:MMMM d, yyyy}", DateTime.Parse(item.birthday)),
                email = item.email,
                full_name = item.full_name,
                gender = item.gender,
                //language = item.language,
                number = item.number,
                password = item.password,
                //receive_email = item.receive_email,
                status = string.IsNullOrEmpty(item.status) ? "" : item.status.Trim().Equals("0") ? "InActive" : "Active",
                user_id = item.user_id,
                approved = item.approved,
                createdAt = item.createdAt,
                deviceToken = item.deviceToken,
                //fastTrackIsAuto = item.fastTrackIsAuto,
                cnic_back = item.cnic_back,
                cnic_frant = item.cnic_frant,
                profile_pic = item.profile_pic
            };
        }

        public tbl_profile getUserDetails(int user_id)
        {
            var UserDetails = DBContext.tbl_profile.SingleOrDefault(e => e.user_id == user_id);
            return UserDetails;
        }

        public bool updateUserInfo(tbl_profile data)
        {
            try
            {
                var result = DBContext.tbl_profile.SingleOrDefault(e => e.user_id == data.user_id);
                result.approved = data.approved;
                //result.birthday = data.birthday;
                //result.email = data.email;
                //result.fastTrackIsAuto = data.fastTrackIsAuto;
                //result.full_name = data.full_name;
                //result.gender = data.gender;
                //result.language = data.language;
                //result.number = data.number;
                //result.password = data.password;
                //result.receive_email = data.receive_email;
                //result.status = data.status;
                DBContext.SaveChanges();

                if(!string.IsNullOrWhiteSpace(result.deviceToken)){

                    notificationCls Notification = new notificationCls();
                    Notification.sendPush(result.deviceToken, "Your account approved by admin.");

                }
                

                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }

        public bool updateUserPassword(string number, string password)
        {
            try
            {
                var result = DBContext.tbl_profile.SingleOrDefault(e => e.number.Equals(number));
                result.password = password;
                result.forgetPasswordToken = "";
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public object getCanceledRides(){

            var data = DBContext.tbl_profile.ToList();
            List<CanceledRides> CanceledRidesLst = new List<CanceledRides>();
            foreach (var user in data)
            {
               var offerRides = user.tbl_offerRide.Where(e => e.statusType.Equals("canceled")).ToList();
               var fastRides = user.tbl_fastRide.Where(e => e.statusType.Equals("canceled")).ToList();

               if (offerRides != null)
               {
                   foreach (var offerRide in offerRides)
                   {
                       CanceledRidesLst.Add(new CanceledRides
                       {
                           email = user.email,
                           from_place = offerRide.from_place,
                           full_name = user.full_name,
                           number = user.number,
                           rideID = offerRide.offerRide_ID,
                           rideType = "Normal Ride",
                           to_place = offerRide.to_place
                       });
                   }
               }

               if (fastRides != null)
               {
                   foreach (var fastRide in fastRides)
                   {
                       CanceledRidesLst.Add(new CanceledRides
                       {
                           email = user.email,
                           from_place = fastRide.from_place,
                           full_name = user.full_name,
                           number = user.number,
                           rideID = fastRide.fastRide_ID,
                           rideType = "Fast Ride",
                           to_place = fastRide.to_place
                       });
                   }
               }
               
            }

            return CanceledRidesLst;
        }

        public class CanceledRides{
            public int rideID { get; set; }
            public string full_name { get; set; }
            public string email { get; set; }
            public string number { get; set; }
            public string from_place { get; set; }
            public string to_place { get; set; }
            public string rideType { get; set; }
        }


        private class profile
        {
            public int user_id { get; set; }
            public string full_name { get; set; }
            public string number { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string birthday { get; set; }
            public string cnic_frant { get; set; }
            public string cnic_back { get; set; }
            public string profile_pic { get; set; }
            public string language { get; set; }
            public string receive_email { get; set; }
            public string type { get; set; }
            public string status { get; set; }
            public string gender { get; set; }
            public Nullable<bool> approved { get; set; }
            public string deviceToken { get; set; }
            public string createdAt { get; set; }
            public Nullable<bool> fastTrackIsAuto { get; set; }
            public string forgetPasswordToken { get; set; }

        }

    }
}