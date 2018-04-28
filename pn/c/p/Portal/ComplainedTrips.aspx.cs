using Portal.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class ComplainedTrips : System.Web.UI.Page
    {
       protected OtherRepo OtherRepo;

       public ComplainedTrips()
        {
            
            OtherRepo = new OtherRepo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userType"] != "admin")
            {
                Response.Redirect("login.aspx");
            }
            var data = OtherRepo.getUsersComplaint();
            Complaint_ListView.DataSource = data;
            Complaint_ListView.DataBind();
        }

        public string myRating(string count)
        {
            string html = "";

            for (int i = 0; i < int.Parse(count); i++)
            {
                html = html + "<a href='#'><span class='fa fa-star' style='padding: 4px;'></span></a>";
            }

            for (int i = int.Parse(count); i < 5; i++)
            {
                html = html + "<a href='#'><span class='fa fa-star-o' style='padding: 4px;'></span></a>";
            }
            return html;
        }
    }
}