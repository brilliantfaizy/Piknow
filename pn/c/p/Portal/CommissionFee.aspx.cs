using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portal.Repo;

namespace Portal
{
    public partial class CommissionFee : System.Web.UI.Page
    {
        protected OtherRepo otherRepos;
        public CommissionFee()
        {
           
            otherRepos = new OtherRepo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userType"] != "admin")
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack) {

                CommissionFeeDetails();
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_driversFee.Value) || string.IsNullOrWhiteSpace(txt_foreignPassengerFee.Value) || string.IsNullOrWhiteSpace(txt_minFastInBalance.Value) || string.IsNullOrWhiteSpace(txt_persianPassengerFee.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('All fields required.');", true);
                return;
            }

            if (otherRepos.setCommissionFee(new tbl_commissionFee
            {
                driversFee = txt_driversFee.Value,
                FeeID = 1,
                foreignPassengerFee = txt_foreignPassengerFee.Value,
                minFastInBalance = txt_minFastInBalance.Value,
                persianPassengerFee = txt_persianPassengerFee.Value,
                updatedAt = DateTime.Now

            }))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Updated Successfully.');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Something went wrong.');", true);
            }
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            CommissionFeeDetails();
        }

        public void CommissionFeeDetails()
        {
            var data = otherRepos.getCommissionFee();
            if (data != null)
            {
                txt_driversFee.Value = data.driversFee;
                txt_foreignPassengerFee.Value = data.foreignPassengerFee;
                txt_minFastInBalance.Value = data.minFastInBalance;
                txt_persianPassengerFee.Value = data.persianPassengerFee;
            }
        }
    }
}