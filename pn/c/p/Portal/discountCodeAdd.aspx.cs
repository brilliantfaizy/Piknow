using Portal.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class discountCodeAdd : System.Web.UI.Page
    {
        protected OtherRepo OtherRepos;
        public discountCodeAdd()
        {
           
            OtherRepos = new OtherRepo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userType"] != "admin")
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                
            }
        }
        protected void add_Click(object sender, EventArgs e)
        {
            string availableNumber = txt_availableNumber.Value;
            string discountCode = txt_discountCode.Value;
            string discountFee = txt_discountFee.Value;
            string expireDate = txt_expireDate.Value;

            if (string.IsNullOrWhiteSpace(availableNumber) || string.IsNullOrWhiteSpace(discountCode) || string.IsNullOrWhiteSpace(discountFee) || string.IsNullOrWhiteSpace(expireDate))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('All fields required.');", true);
                return;
            }

            string result = OtherRepos.addDiscountCode(new tbl_discountCode
            {
                createdAt = DateTime.Now,
                availableNumber = availableNumber.Trim(),
                discountCode = discountCode.Trim(),
                discountFee = discountFee.Trim(),
                expireDate = DateTime.Parse(expireDate)
            });

            if (result.Equals("true"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Added Successfully.');", true);
                txt_availableNumber.Value = "";
                txt_discountCode.Value = "";
                txt_discountFee.Value = "";
                txt_expireDate.Value = "";

            } else if(result.Equals("already")){

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('This code is already exist.');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Something went wrong.');", true);
            }
        }
       
    }
}