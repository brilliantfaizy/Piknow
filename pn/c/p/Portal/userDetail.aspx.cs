using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portal.repo;

namespace Portal
{
    public partial class userDetail : System.Web.UI.Page
    {
        protected usersRepo usersRepos;
        public userDetail()
        {
            usersRepos = new usersRepo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userType"] == "government")
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                userDetails();
            }

        }
        protected void saveUser_Profile(object sender, EventArgs e)
        {
            string user_id = Request.QueryString["user_id"];
            if ((!string.IsNullOrEmpty(user_id.Trim())) && (!user_id.Trim().Equals("0")))
            {
                bool approved = (userApproved.Checked) ? true : false;
                //string birthday = txt_birthday.Value;
                //string email = txt_email.Value;
                //bool fastTrackIsAuto = (fastTrackIsAutoActive.Checked) ? true : false;
                //string full_name = txt_fullname.Value;
                //string gender = (maleGender.Checked) ? "1" : "0";
                //string language = (englishLanguage.Checked) ? "English" : "Farsi";
                //string number = txt_number.Value;
                //string password = txt_password.Value;
                //string receive_email = (activeReceiveEmail.Checked) ? "1" : "0";
                //string status = (activeStatus.Checked) ? "1" : "0";

                //if ((string.IsNullOrWhiteSpace(birthday)) ||
                //    (string.IsNullOrWhiteSpace(email)) ||
                //    (string.IsNullOrWhiteSpace(full_name)) ||
                //    (string.IsNullOrWhiteSpace(gender)) ||
                //    (string.IsNullOrWhiteSpace(number)) ||
                //    (string.IsNullOrWhiteSpace(language)) ||
                //    (string.IsNullOrWhiteSpace(password)) ||
                //    (string.IsNullOrWhiteSpace(receive_email)) ||
                //    (string.IsNullOrWhiteSpace(status)))
                //{

                //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('All fields required.');", true);
                //    return;
                //}

                if (usersRepos.updateUserInfo(new tbl_profile
                {
                    approved = approved,
                   // birthday = birthday,
                    //email = email,
                    //fastTrackIsAuto = fastTrackIsAuto,
                    //full_name = full_name,
                    //gender = gender,
                    //language = language,
                    //number = number,
                    //password = password,
                    //receive_email = receive_email,
                    //status = status,
                    user_id = int.Parse(user_id)
                }))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated Successfully.');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Something went wrong.');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Something went wrong.');", true);
            }
        }
        protected void resetUser_Profile(object sender, EventArgs e)
        {
            userDetails();
        }

        public void userDetails()
        {
            try
            {
                string user_id = Request.QueryString["user_id"];
                if ((!string.IsNullOrEmpty(user_id.Trim())) && (!user_id.Trim().Equals("0")))
                {
                    var data = usersRepos.getUserDetail(int.Parse(user_id));
                    txt_email.Value = data.email;
                    txt_fullname.Value = data.full_name;
                    txt_number.Value = data.number;
                    txt_password.Value = data.password;

                    txt_email.Disabled = true;
                    txt_fullname.Disabled = true;
                    txt_number.Disabled = true;
                    txt_password.Disabled = true;
                    //txt_birthday.Value = string.IsNullOrWhiteSpace(data.birthday) ? "" : data.birthday;

                    //if (!string.IsNullOrWhiteSpace(data.gender))
                    //{
                    //    if (data.gender.ToLower().Equals("male") || data.gender.Equals("1"))
                    //    {
                    //        maleGender.Checked = true;
                    //        femaleGender.Checked = false;
                    //    }
                    //    else if (data.gender.ToLower().Equals("female") || data.gender.Equals("0"))
                    //    {
                    //        maleGender.Checked = false;
                    //        femaleGender.Checked = true;
                    //    }
                    //}

                    //if (!string.IsNullOrWhiteSpace(data.language))
                    //{
                    //    if (data.language.ToLower().Equals("english"))
                    //    {
                    //        englishLanguage.Checked = true;
                    //        farsiLanguage.Checked = false;
                    //    }
                    //    else if (data.language.ToLower().Equals("farsi"))
                    //    {
                    //        englishLanguage.Checked = false;
                    //        farsiLanguage.Checked = true;
                    //    }
                    //}

                    //if (!string.IsNullOrWhiteSpace(data.receive_email))
                    //{
                    //    if (data.receive_email.Equals("1"))
                    //    {
                    //        activeReceiveEmail.Checked = true;
                    //        inactiveReceiveEmail.Checked = false;
                    //    }
                    //    else if (data.receive_email.Equals("0"))
                    //    {
                    //        activeReceiveEmail.Checked = false;
                    //        inactiveReceiveEmail.Checked = true;
                    //    }
                    //}

                    //if (data.status.Equals("Active"))
                    //{
                    //    activeStatus.Checked = true;
                    //    inactiveStatus.Checked = false;
                    //}
                    //else if (data.status.Equals("InActive"))
                    //{
                    //    activeStatus.Checked = false;
                    //    inactiveStatus.Checked = true;
                    //}

                    if (data.approved == true)
                    {
                        userApproved.Checked = true;
                        userNotApproved.Checked = false;
                    }
                    else if (data.approved == false)
                    {
                        userApproved.Checked = false;
                        userNotApproved.Checked = true;
                    }


                    //if (data.fastTrackIsAuto == true)
                    //{
                    //    fastTrackIsAutoActive.Checked = true;
                    //    fastTrackIsAutoNotActive.Checked = false;
                    //}
                    //else if (data.fastTrackIsAuto == false)
                    //{
                    //    fastTrackIsAutoActive.Checked = false;
                    //    fastTrackIsAutoNotActive.Checked = true;
                    //}

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
    }
}