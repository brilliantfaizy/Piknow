using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portal.Repo;

namespace Portal
{
    public partial class GovernmentCode : System.Web.UI.Page
    {
        protected OtherRepo otherRepos;
        public GovernmentCode()
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

                getDetail();
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_government_code.Value) || string.IsNullOrWhiteSpace(txt_username.Value) || string.IsNullOrWhiteSpace(txt_password.Value))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('All fields required.');", true);
                return;
            }

            if (otherRepos.setGovernmentCode(new tbl_government
            {
                government_code = txt_government_code.Value.Trim(),
                username = txt_username.Value.Trim(),
                password = txt_password.Value.Trim(),
                government_id = 1,
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
            getDetail();
        }

        public void getDetail()
        {
            var data = otherRepos.getGovernmentCode();
            if (data != null)
            {
                txt_government_code.Value = data.government_code;
                txt_username.Value = data.username;
                txt_password.Value = data.password;
            }
        }
    }
}