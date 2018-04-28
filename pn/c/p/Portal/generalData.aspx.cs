using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portal.Repo;

namespace Portal
{
    public partial class generalData : System.Web.UI.Page
    {
        protected OtherRepo otherRepos;
        public generalData()
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

                generalDetails();
            }
        }

        protected void saveGeneral_Data(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_percentDetect.Value.Trim()))
            {
                if (string.IsNullOrWhiteSpace(txt_fastTrackAmount.Value) || string.IsNullOrWhiteSpace(txt_passengerDetect.Value) || string.IsNullOrWhiteSpace(txt_percentDetect.Value) || string.IsNullOrWhiteSpace(txt_perKM.Value))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('All fields required.');", true);
                    return;
                }

                if (otherRepos.setGeneraldata(new tbl_general { 
                    
                    fastTrackAmount = txt_fastTrackAmount.Value.Trim(),
                    passengerDetect = txt_passengerDetect.Value.Trim(),
                    percentDetect = txt_percentDetect.Value.Trim(),
                    perKM = txt_perKM.Value.Trim(),
                    ID = 1

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

        protected void resetGeneral_Data(object sender, EventArgs e)
        {
            generalDetails();
        }

        public void generalDetails()
        {
            var data = otherRepos.getGeneraldata();
            if (data != null)
            {
                txt_percentDetect.Value = data.percentDetect;
                txt_fastTrackAmount.Value = data.fastTrackAmount;
                txt_passengerDetect.Value = data.passengerDetect;
                txt_perKM.Value = data.perKM;
            }
        }
    }
}