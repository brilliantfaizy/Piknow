using Portal.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class Transactions : System.Web.UI.Page
    {
        protected OtherRepo OtherRepo;

        public Transactions()
        {
            
            OtherRepo = new OtherRepo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userType"] != "admin")
            {
                Response.Redirect("login.aspx");
            }
            var data = OtherRepo.getAdminTransactions();
            Transaction_ListView.DataSource = data;
            Transaction_ListView.DataBind();
        }
    }
}