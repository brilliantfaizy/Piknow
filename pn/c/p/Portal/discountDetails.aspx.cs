
using Portal.repo;
using Portal.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class discountDetails : System.Web.UI.Page
    {
        protected OtherRepo OtherRepos;
        public discountDetails()
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
                discountCodeDetail();
            }

        }
        protected void save_Click(object sender, EventArgs e)
        {
            string discountID = Request.QueryString["discountID"];
            if ((!string.IsNullOrEmpty(discountID.Trim())) && (!discountID.Trim().Equals("0")))
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

                if (OtherRepos.updateDiscountCode(new tbl_discountCode
                {
                    updatedAt = DateTime.Now,
                    availableNumber = availableNumber.Trim(),
                    discountCode = discountCode.Trim(),
                    discountFee = discountFee.Trim(),
                    expireDate = DateTime.Parse(expireDate),
                    discountID = int.Parse(discountID)
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
        protected void reset_Click(object sender, EventArgs e)
        {
            discountCodeDetail();
        }

        public void discountCodeDetail()
        {
            try
            {
                string discountID = Request.QueryString["discountID"];
                if ((!string.IsNullOrEmpty(discountID.Trim())) && (!discountID.Trim().Equals("0")))
                {
                    var data = OtherRepos.getDiscountCode(int.Parse(discountID));
                    txt_availableNumber.Value = data.availableNumber;
                    txt_discountCode.Value = data.discountCode;
                    txt_discountFee.Value = data.discountFee;
                    txt_expireDate.Value = String.Format("{0:MM/dd/yyyy}", data.expireDate.Date);
                }
                else
                {
                    Response.Redirect("DiscountCode.aspx");
                }
            }
            catch (Exception)
            {

                Response.Redirect("DiscountCode.aspx");
            }
        }
    }
}