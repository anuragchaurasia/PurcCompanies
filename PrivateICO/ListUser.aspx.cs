using DataLayer.DataHelper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrivateICO
{
    public partial class ListUser : System.Web.UI.Page
    {
        UserHelper userHelper = new UserHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindUsers();
            }
        }

        private void BindUsers()
        {
           
        }

        protected void lstUsers_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstUsers.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindUsers();
        }

        protected void lstUsers_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "AddCoin")
            {
                Session["UserIDTransaction"] = e.CommandArgument;
                Response.Redirect("RegisterTransaction.aspx");
            }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterUser.aspx");
        }
    }
}