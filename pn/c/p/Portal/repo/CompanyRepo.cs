using Portal.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Portal.repo
{
    public class CompanyRepo
    {
        protected PN_Entities DBContext;
        public CompanyRepo()
        {
            DBContext = new PN_Entities();
        }

        public object getCompanies()
        {

            var result = (from a in DBContext.tbl_company select new CompaniesCls { 
                comeFrom = a.comeFrom,
                company_id = a.company_id,
                company_name = a.company_name,
                createdAt = a.createdAt,
                email = a.email,
                isConfirmed = (a.isConfirmed) ? "Confirm" : "Not Comfirm",
                phoneNumber = a.phoneNumber
            }).ToList().OrderByDescending(e=>e.createdAt);

            return result;
        }

        public object getGovernmentCompanies()
        {

            var result = (from a in DBContext.tbl_company
                          where a.comeFrom == "Government"
                          select new CompaniesCls
                          {
                              comeFrom = a.comeFrom,
                              company_id = a.company_id,
                              company_name = a.company_name,
                              createdAt = a.createdAt,
                              email = a.email,
                              isConfirmed = (a.isConfirmed) ? "Confirm" : "Not Comfirm",
                              phoneNumber = a.phoneNumber
                          }).ToList().OrderByDescending(e => e.createdAt);

            return result;
        }

        public tbl_company getCompany(int company_id)
        {
            var result = DBContext.tbl_company.SingleOrDefault(e => e.company_id == company_id);
            return result;
        }

        public bool updateCompanyInfo(tbl_company data)
        {
            try
            {
                var result = DBContext.tbl_company.SingleOrDefault(e => e.company_id == data.company_id);
                result.company_name = data.company_name;
                result.password = data.password;
                result.isConfirmed = data.isConfirmed;
                result.phoneNumber = data.phoneNumber;
                DBContext.SaveChanges();

                if (!string.IsNullOrWhiteSpace(result.email))
                {
                    notificationCls Notification = new notificationCls();
                    
                    string isConfirm = (data.isConfirmed) ? "Confirm" : "Not Confirm";
                    
                    string body = "";
                    
                    body += "<table width='300'>";

                    body += "<tr>";
                    body += "<th>Company Name :</th>";
                    body += "<td>" + data.company_name + "</td>";
                    body += "</tr>";

                    body += "<tr>";
                    body += "<th>isConfirmed :</th>";
                    body += "<td>" + isConfirm + "</td>";
                    body += "</tr>";

                    body += "<tr>";
                    body += "<th>Phone Number :</th>";
                    body += "<td>" + data.phoneNumber + "</td>";
                    body += "</tr>";

                    body += "</table>";

                    Notification.SendEmail_toUser(result.email,"Confirmation","Account Confirmation Detail",body);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string Authentication(string email, string password)
        {
            try
            {
                var result = DBContext.tbl_company.SingleOrDefault(e => e.email.Equals(email) && e.password.Equals(password));
                if (result != null)
                {
                    if (!result.isConfirmed)
                    {
                        return "not confirm";
                    }
                    return "true";
                }
                else
                {
                    return "wrong";
                }
            }
            catch (Exception ex)
            {
                return "false";
            }
        }

        public string forgotPassword(string email)
        {
            try
            {
                var result = DBContext.tbl_company.SingleOrDefault(e => e.email.Equals(email));
                if (result != null)
                {
                    string toEmail = result.email;
                    string subject = "Your Password";
                    string heading = "Your Company Account Password";

                    {
                        string siteURL = WebConfigurationManager.AppSettings["siteURL"];
                        string mailBody = "<p>Your account password is: " + result.password + "</p><a href='" + siteURL + "Company.aspx' target='_blank'>Go to the login page click here.</a>";
                        notificationCls Notification = new notificationCls();
                        Notification.SendEmail_toUser(toEmail, subject, heading, mailBody);
                    }

                    return "true";
                }
                else
                {
                    return "wrong";
                }
            }
            catch (Exception ex)
            {
                return "false";
            }
        }

        public string addCompany(tbl_company data, string government_code)
        {
            try
            {
                var company_result = DBContext.tbl_company.SingleOrDefault(e => e.email.Equals(data.email));
                if (company_result != null)
                {
                    return "already";
                }

                var result = DBContext.tbl_company.Add(new tbl_company
                {
                     ceoID_path = data.ceoID_path,
                     comeFrom = data.comeFrom,
                     company_name = data.company_name,
                     companyCertificate_path = data.companyCertificate_path,
                     email = data.email,
                     isConfirmed = data.isConfirmed,
                     password = data.password,
                     permissions_path = data.permissions_path,
                     phoneNumber = data.phoneNumber,
                     createdAt = DateTime.Now
                 });

                if (!string.IsNullOrWhiteSpace(government_code))
                {
                    var govdata = DBContext.tbl_government.FirstOrDefault();
                    if (!govdata.government_code.Equals(government_code))
                    {
                        return "not correct";
                    }

                    DBContext.tbl_governmentDetail.Add(new tbl_governmentDetail
                    {
                        company_id = result.company_id,
                        government_id = govdata.government_id

                    });
                }

                DBContext.SaveChanges();
                return "true";
            }
            catch (Exception)
            {
                return "false";
            }
        }

        public class CompaniesCls {

            public int company_id { get; set; }
            public string company_name { get; set; }
            public string email { get; set; }
            public string phoneNumber { get; set; }
            public string comeFrom { get; set; }
            public string isConfirmed { get; set; }
            public System.DateTime createdAt { get; set; }

        }
    }
}