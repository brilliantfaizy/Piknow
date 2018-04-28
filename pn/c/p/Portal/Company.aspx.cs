using Portal.repo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class Company : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void login_click(object sender, EventArgs e)
        {
            string email = txt_email_login.Text;
            string password = txt_password_login.Text;

            if ((!string.IsNullOrWhiteSpace(email)) && (!string.IsNullOrWhiteSpace(password)))
            {
                CompanyRepo CompanyRepo = new CompanyRepo();
                string result = CompanyRepo.Authentication(email, password);
                if (result.Equals("true"))
                {
                    FormsAuthentication.RedirectFromLoginPage(email, Persist.Checked);
                    string ReturnUrl = Request.QueryString["ReturnUrl"];
                    Session["userType"] = "company";
                    Session["userEmail"] = email;
                    if ((!string.IsNullOrWhiteSpace(ReturnUrl)))
                    {
                        Response.Redirect(ReturnUrl.Trim());
                    }
                    else
                    {
                        Response.Redirect("users.aspx");
                    }
                }
               
                if (result.Equals("wrong")){

                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid email or password.');", true);
                    return;
                }
               
                if (result.Equals("not confirm"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('User not confirm by admin.');", true);
                    return;
                }

                if (result.Equals("false"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Something went wrong.');", true);
                    return;
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Email and password are required.');", true);
                return;
            }
        }

        protected void register_click(object sender, EventArgs e)
        {
            string company_name = txt_company_name.Text;
            string email = txt_email.Text;
            string phoneNumber = txt_phoneNumber.Text;
            string password = txt_password.Text;
            string comeFrom = dropdown_comeFrom.SelectedValue;
            string government_code = "";

            if (comeFrom.Equals("Government"))
            {
                government_code = txt_government_code.Text;
                if ((!file_CEO_ID.HasFile) || (!file_company_certificate.HasFile) || (!file_their_permissions.HasFile) || (string.IsNullOrWhiteSpace(company_name)) || (string.IsNullOrWhiteSpace(email)) || (string.IsNullOrWhiteSpace(phoneNumber)) || (string.IsNullOrWhiteSpace(password)) || (string.IsNullOrWhiteSpace(government_code)))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('All fields required.');", true);
                    return;
                }
            }
            else
            {
                if ((!file_CEO_ID.HasFile) || (!file_company_certificate.HasFile) || (!file_their_permissions.HasFile) || (string.IsNullOrWhiteSpace(company_name)) || (string.IsNullOrWhiteSpace(email)) || (string.IsNullOrWhiteSpace(phoneNumber)) || (string.IsNullOrWhiteSpace(password)))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('All fields required.');", true);
                    return;
                }
            }

            string CEO_ID = PutFile(file_CEO_ID);
            string TheirPermissions = PutFile(file_their_permissions);
            string CompanyCertificate = PutFile(file_company_certificate);

            CompanyRepo CompanyRepo = new CompanyRepo();
            string result = CompanyRepo.addCompany(new tbl_company
            {
                ceoID_path = CEO_ID,
                comeFrom = comeFrom,
                company_name = company_name,
                companyCertificate_path = CompanyCertificate,
                email = email,
                isConfirmed = false,
                password = password,
                permissions_path = TheirPermissions,
                phoneNumber = phoneNumber
            }, government_code);

            if (result.Equals("not correct"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Government code not corrected.');", true);
                return;
            }

            if (result.Equals("already"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('This email address is already exist.');", true);
                return;
            }

            if (result.Equals("true"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Account successfully created.');", true);
                txt_company_name.Text = "";
                txt_email.Text = "";
                txt_government_code.Text = "";
                txt_password.Text = "";
                txt_phoneNumber.Text = "";
                return;
            }

            if (result.Equals("false"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Something went wrong.');", true);
                return;
            }
        }

        protected void comefrom_onChange(object sender, EventArgs e)
        {
            if (dropdown_comeFrom.SelectedValue.Equals("Government"))
            {
                government_code_container.Visible = true;
            }
            else
            {
                government_code_container.Visible = false;
            }
        }

        public string PutFile(FileUpload file)
        {
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
    }
}