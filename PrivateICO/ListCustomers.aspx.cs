using DataLayer.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;

namespace PrivateICO
{
    public partial class ListCustomers : System.Web.UI.Page
    {
        UserDAL userdal = new UserDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindCustomers();
            }
        }

        private void BindCustomers()
        {
            List<UsersEL> lstUsers = userdal.GetAllCustomers();
            lstCustomers.DataSource = lstUsers;
            lstCustomers.DataBind();
        }

        protected void lstCustomers_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Response.Redirect("EditUsers.aspx?id=" + e.CommandArgument);
            }
            else
                if (e.CommandName == "Document")
                {
                    Response.Redirect("DocumentUpload.aspx?id=" + e.CommandArgument);
                }
        }

        protected void lstCustomers_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstCustomers.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindCustomers();
        }
    }
}