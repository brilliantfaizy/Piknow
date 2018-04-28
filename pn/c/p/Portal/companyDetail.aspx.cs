using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portal.repo;

namespace Portal
{
    public partial class companyDetail : System.Web.UI.Page
    {
        protected CompanyRepo CompanyRepos;
        public companyDetail()
        {
            CompanyRepos = new CompanyRepo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userType"] != "admin" && Session["userType"] != "government")
            {
                Response.Redirect("login.aspx");
            }
            

            if (!IsPostBack)
            {
                getCompanyDetail();
            }

        }

        public void getCompanyDetail()
        {
            try
            {
                string company_id = Request.QueryString["company_id"];
                if ((!string.IsNullOrEmpty(company_id.Trim())) && (!company_id.Trim().Equals("0")))
                {
                    var data = CompanyRepos.getCompany(int.Parse(company_id));
                        txt_comeFrom.Value = data.comeFrom;
                        txt_company_name.Value = data.company_name;
                        txt_email.Value = data.email;
                        txt_password.Value = data.password;
                        txt_phoneNumber.Value = data.phoneNumber;

                        img_ceoID_link.HRef = "./upload/" + data.ceoID_path;
                        img_ceoID_path.Src = "./upload/" + data.ceoID_path;
                        img_companyCertificate_link.HRef = "./upload/" + data.companyCertificate_path;
                        img_companyCertificate_path.Src = "./upload/" + data.companyCertificate_path;
                        img_permissions_link.HRef = "./upload/" + data.permissions_path;    
                        img_permissions_path.Src = "./upload/" + data.permissions_path;
                      

                    if (data.isConfirmed == true)
                    {
                        companyConfirm.Checked = true;
                        companyNotConfirm.Checked = false;
                    }
                    else if (data.isConfirmed == false)
                    {
                        companyConfirm.Checked = false;
                        companyNotConfirm.Checked = true;
                    }
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

        protected void reset_Data(object sender, EventArgs e)
        {
            getCompanyDetail();
        }

        protected void save_Data(object sender, EventArgs e)
        {
            string company_id = Request.QueryString["company_id"];
            if ((!string.IsNullOrEmpty(company_id.Trim())) && (!company_id.Trim().Equals("0")))
            {
                string company_name = txt_company_name.Value;
                string password = txt_password.Value;
                string phoneNumber = txt_phoneNumber.Value;
                bool Confirm = (companyConfirm.Checked) ? true : false;

                if ((string.IsNullOrWhiteSpace(company_name)) || (string.IsNullOrWhiteSpace(password)) || (string.IsNullOrWhiteSpace(phoneNumber)))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('All fields required.');", true);
                    return;
                }

                if (CompanyRepos.updateCompanyInfo(new tbl_company
                {
                    company_id = int.Parse(company_id),
                    password = password.Trim(),
                    company_name = company_name.Trim(),
                    phoneNumber = phoneNumber.Trim(),
                    isConfirmed = Confirm
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
    }
}