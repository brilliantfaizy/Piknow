using Portal.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class TotalAmount : System.Web.UI.Page
    {

        protected OtherRepo OtherRepos;
        public TotalAmount()
        {
            OtherRepos = new OtherRepo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userType"] == "company")
            {
                Response.Redirect("Government.aspx");
            }

            if (!IsPostBack)
            {
                companyDetails();
            }
        }

        public void companyDetails()
        {
            try
            {
                string company_id = Request.QueryString["company_id"];
                if ((!string.IsNullOrEmpty(company_id.Trim())) && (!company_id.Trim().Equals("0")))
                {
                    var CompanyData = OtherRepos.getCompanyDetails(int.Parse(company_id));
                    lbl_comeFrom.Text = CompanyData.comeFrom;
                    lbl_companyName1.Text = CompanyData.company_name;
                    lbl_companyName2.Text = CompanyData.company_name;
                    lbl_date.Text = CompanyData.createdAt.ToString();
                    lbl_email.Text = CompanyData.email;
                    lbl_phone.Text = CompanyData.phoneNumber;
                    img_CEO_ID.ImageUrl = "./upload/"+CompanyData.ceoID_path;
                    img_CompanyCertificate.ImageUrl = "./upload/" + CompanyData.companyCertificate_path;
                    img_Permissions.ImageUrl = "./upload/" + CompanyData.permissions_path;
                    lbtn_CEO_ID.NavigateUrl = "./upload/" + CompanyData.ceoID_path;
                    lbtn_CompanyCertificate.NavigateUrl = "./upload/" + CompanyData.companyCertificate_path;
                    lbtn_Permissions.NavigateUrl = "./upload/" + CompanyData.ceoID_path;

                    List<tbl_companyDetail> companyDetails = CompanyData.tbl_companyDetail.ToList();
                    List<userProfile> usersData = new List<userProfile>();
                    double companyTotal = 0.0;
                    foreach (var item in companyDetails)
                    {
                        
                        string gender = "";
                        if (!string.IsNullOrWhiteSpace(item.tbl_profile.gender))
                        {
                            if (item.tbl_profile.gender.ToLower().Equals("male") || item.tbl_profile.gender.Equals("1"))
                            {
                                gender = "Male";
                            }
                            else if (item.tbl_profile.gender.ToLower().Equals("female") || item.tbl_profile.gender.Equals("0"))
                            {
                                gender = "Female";
                            }
                        }

                        string amount = "0";

                        var passengerData = item.tbl_profile.tbl_WalletTransaction.ToList();
                        if (passengerData.Count != 0)
                        {
                            amount = passengerData.LastOrDefault().Balance;
                        }

                        usersData.Add(new userProfile { 
                            
                            user_id = item.tbl_profile.user_id,
                            gender = gender,
                            approved = item.tbl_profile.approved == true ? "Approved" : "Not Approved",
                            email = item.tbl_profile.email,
                            full_name = item.tbl_profile.full_name,
                            //language = item.tbl_profile.language,
                            number = item.tbl_profile.number,
                            amount = String.Format("{0:0.00}", double.Parse(amount))
                        });

                        companyTotal = double.Parse(amount) + companyTotal;
                    }

                    lbl_companiesTotal.Text = String.Format("{0:0.00}", companyTotal);

                    User_ListView.DataSource = usersData;
                    User_ListView.DataBind();
                }
                else
                {
                    Response.Redirect("Companies.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("Companies.aspx");
            }
        }

        private class userProfile
        {
            public int user_id { get; set; }
            public string full_name { get; set; }
            public string number { get; set; }
            public string email { get; set; }
            public string language { get; set; }
            public string gender { get; set; }
            public string approved { get; set; }
            public string amount { get; set; }
        }


    }
}