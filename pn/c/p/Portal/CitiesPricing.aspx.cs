using Portal.repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class CitiesPricing : System.Web.UI.Page
    {
        protected CitiesRepo CitiesRepo;

       public CitiesPricing()
        {
            
            CitiesRepo = new CitiesRepo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userType"] != "admin")
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                citiesList();
            }
        }

         protected void Delete_Click(object sender, EventArgs e)
         {
             LinkButton data = (LinkButton)sender;
             string cityID = data.CommandName;
             if (CitiesRepo.deleteCityPrice(int.Parse(cityID)))
             {
                 ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Deleted successfully');", true);
                 citiesList();
             }
             else
             {
                 ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('you can not delete');", true);
             }
         }
         public void citiesList()
         {
             var data = CitiesRepo.getCitiesPricing();
             Cities_ListView.DataSource = data;
             Cities_ListView.DataBind();
         }
    }
}