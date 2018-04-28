using Portal.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class DiscountCode : System.Web.UI.Page
    {
        protected OtherRepo OtherRepos;

        public DiscountCode()
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
                discountCodesList();
            }
        }

         protected void Delete_Click(object sender, EventArgs e)
         {
             LinkButton data = (LinkButton)sender;
             string discountID = data.CommandName;
             if (OtherRepos.deleteDiscountCode(int.Parse(discountID)))
             {
                 ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted successfully');", true);
                 discountCodesList();
             }
             else
             {
                 ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('This code has been used, you can not delete');", true);
             }
         }

         public void discountCodesList()
         {
             var data = OtherRepos.getDiscountCodes();
             DiscountCode_ListView.DataSource = data;
             DiscountCode_ListView.DataBind();
         }
    }
}