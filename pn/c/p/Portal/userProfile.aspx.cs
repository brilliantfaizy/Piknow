using Portal.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class userProfile : System.Web.UI.Page
    {
        protected usersRepo usersRepos;
        public userProfile()
        {
            usersRepos = new usersRepo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userType"] == "government")
            {
                //Response.Redirect("login.aspx");
                LinkBtn_editProfile.Visible = false;
            }
            if (!IsPostBack)
            {
                userDetails();
            }
        }

        public void userDetails()
        {
            try
            {
                string user_id = Request.QueryString["user_id"];
                if ((!string.IsNullOrEmpty(user_id.Trim())) && (!user_id.Trim().Equals("0")))
                {
                    var userData = usersRepos.getUserDetails(int.Parse(user_id));
                    string imagesServerPath = WebConfigurationManager.AppSettings["imagesServerPath"];

                    //This code is used for get user profile info
                    {
                        LinkBtn_editProfile.PostBackUrl = "./userDetail.aspx?user_id=" + user_id;
                        profile_pic.Src = imagesServerPath + userData.profile_pic;

                        string gender = "";
                        if (!string.IsNullOrWhiteSpace(userData.gender))
                        {
                            if (userData.gender.ToLower().Equals("male") || userData.gender.Equals("1"))
                            {
                                gender = "Male";
                            }
                            else if (userData.gender.ToLower().Equals("female") || userData.gender.Equals("0"))
                            {
                                gender = "Female";
                            }
                        }

                        lbl_fullname.InnerText = "" + userData.full_name;
                        lbl_approved.InnerText = "User Is : " + (userData.approved == true ? "Approved" : "Not Approved");
                        lbl_email.InnerText = "Email : " + userData.email;
                        lbl_gender.InnerText = "Gender : " + gender;
                        //lbl_language.InnerText = "Language : " + userData.language;
                        lbl_number.InnerText = "Number : " + userData.number;
                        lbl_status.InnerText = "Status : " + (userData.status.Equals("1") ? "Active" : "Not Active");
                        lbl_birthday.InnerText = "Birthday : " + userData.birthday;
                        //lbl_receive_email.InnerText = "Receive Email : " + (userData.receive_email.Equals("1") ? "Active" : "Not Active");
                        //lbl_fastTrackIsAuto.InnerText = "Fast Track Is Auto : " + (((bool)userData.fastTrackIsAuto) ? "Active" : "Not Active").ToString();
                    }

                    //This code is used for get and set all offered rides
                    if (userData.tbl_offerRide.Count != 0)
                    {
                        var offerRideData = userData.tbl_offerRide.ToList().OrderByDescending(e => e.datetime);
                        List<offerRideCls> offerRideLst = new List<offerRideCls>();
                        foreach (var item in offerRideData)
                        {
                            offerRideLst.Add(new offerRideCls
                            {

                                brand = item.tbl_vehicle.brand,
                                charter = ((bool)item.charter) ? "Yes" : "No",
                                color = item.tbl_vehicle.color,
                                datetime = (DateTime)item.datetime,
                                from_place = item.from_place,
                                //insuranceNumber = item.tbl_vehicle.insuranceNumber,
                                model = item.tbl_vehicle.model,
                                no_seats = (int)item.no_seats,
                                offerRide_ID = item.offerRide_ID,
                                picture = imagesServerPath + item.tbl_vehicle.carPhoto,
                                plateNumber = item.tbl_vehicle.plateNumber,
                                price = item.price,
                                ride_comment = item.ride_comment,
                                status = ((bool)item.status) ? "Active" : "Not Active",
                                statusType = item.statusType,
                                to_place = item.to_place,
                                vehicleType = item.tbl_vehicle.type,
                                user_id = item.user_id

                            });
                        }

                        Offers_ListView.DataSource = offerRideLst;
                        Offers_ListView.DataBind();
                    }

                    //This code is used for get and set taken rides
                    if (userData.tbl_book.Count != 0)
                    {
                        var TakenNormalRideData = userData.tbl_book.ToList();
                        var TakenFastRideData = userData.tbl_fastRide.ToList();
                        List<takenRideCls> takenRideLst = new List<takenRideCls>();

                        foreach (var item in TakenNormalRideData)
                        {
                            takenRideLst.Add(new takenRideCls
                            {
                                brand = item.tbl_offerRide.tbl_vehicle.brand,
                                color = item.tbl_offerRide.tbl_vehicle.color,
                                datetime = (DateTime)item.datetime,
                                from_place = item.tbl_offerRide.from_place,
                                ride_id = item.offerRide_ID,
                                picture = imagesServerPath + item.tbl_offerRide.tbl_profile.profile_pic,
                                plateNumber = item.tbl_offerRide.tbl_vehicle.plateNumber,
                                price = item.tbl_offerRide.price,
                                to_place = item.tbl_offerRide.to_place,
                                vehicleType = item.tbl_offerRide.tbl_vehicle.type,
                                full_name = item.tbl_offerRide.tbl_profile.full_name,
                                rideType = "Normal Ride",
                                rideStatus = item.tbl_offerRide.statusType
                            });
                        }

                        foreach (var item in TakenFastRideData)
                        {
                            if (item.tbl_fastRideDetails.Count != 0)
                            {
                                takenRideCls takenRideData = new takenRideCls();
                                takenRideData.brand = item.tbl_fastRideDetails.SingleOrDefault().tbl_vehicle.brand;
                                takenRideData.color = item.tbl_fastRideDetails.SingleOrDefault().tbl_vehicle.color;
                                takenRideData.datetime = (DateTime)item.createdAt;
                                takenRideData.from_place = item.from_place;
                                takenRideData.full_name = item.tbl_fastRideDetails.SingleOrDefault().tbl_profile.full_name;
                                takenRideData.picture = imagesServerPath + item.tbl_fastRideDetails.SingleOrDefault().tbl_profile.profile_pic;
                                takenRideData.plateNumber = item.tbl_fastRideDetails.SingleOrDefault().tbl_vehicle.plateNumber;
                                takenRideData.price = item.tbl_fastRideDetails.SingleOrDefault().price;
                                takenRideData.rideType = "Fast Ride";
                                takenRideData.to_place = item.to_place;
                                takenRideData.vehicleType = item.tbl_fastRideDetails.SingleOrDefault().tbl_vehicle.type;
                                takenRideData.ride_id = item.fastRide_ID;
                                takenRideData.rideStatus = item.statusType;
                                takenRideLst.Add(takenRideData);
                            }
                        }

                        TakenRides_ListView.DataSource = takenRideLst.OrderByDescending(e => e.datetime);
                        TakenRides_ListView.DataBind();
                    }

                    //This code is used for get and set all transactions
                    if (userData.tbl_WalletTransaction.Count != 0)
                    {
                        Transaction_ListView.DataSource = userData.tbl_WalletTransaction.ToList().OrderByDescending(e => e.transaction_ID);
                        Transaction_ListView.DataBind();
                    }

                }
                else
                {
                    Response.Redirect("users.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("users.aspx");
            }
        }

        public class offerRideCls
        {
            public int offerRide_ID { get; set; }
            public int user_id { get; set; }
            public string from_place { get; set; }
            public string to_place { get; set; }
            public DateTime datetime { get; set; }
            public int no_seats { get; set; }
            public string charter { get; set; }
            public string ride_comment { get; set; }
            public string price { get; set; }
            public string status { get; set; }
            public string statusType { get; set; }
            public string vehicleType { get; set; }
            public string brand { get; set; }
            public string model { get; set; }
            public string color { get; set; }
            public string insuranceNumber { get; set; }
            public string plateNumber { get; set; }
            public string picture { get; set; }
        }

        public class takenRideCls
        {
            public int ride_id { get; set; }
            public string from_place { get; set; }
            public string to_place { get; set; }
            public DateTime datetime { get; set; }
            public string price { get; set; }
            public string vehicleType { get; set; }
            public string brand { get; set; }
            public string color { get; set; }
            public string plateNumber { get; set; }
            public string picture { get; set; }
            public string full_name { get; set; }
            public string rideType { get; set; }
            public string rideStatus { get; set; }
        }
    }
}