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
    public partial class ListSalesPerson : System.Web.UI.Page
    {
        UserHelper userHelper = new UserHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindSalesUsers();
            }
        }

        protected void lstUsers_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstUsers.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindSalesUsers();
        }

        protected void lstUsers_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditUser")
            {
                Response.Redirect("EditSalesByAdmin.aspx?UserID=" + e.CommandArgument);
            }
            else
                if (e.CommandName == "ViewSale")
                {
                    Response.Redirect("AdminDailySalesDisplay.aspx?UserID=" + e.CommandArgument);
                }
                else
                    if (e.CommandName == "ViewLeads")
                    {
                        Response.Redirect("AdminDailyLeadStatus.aspx?UserID=" + e.CommandArgument);
                    }
                    else
                        if (e.CommandName == "ViewOpportunityLeads")
                        {
                            Response.Redirect("DisplayLeads.aspx?UserID=" + e.CommandArgument);
                        }
                    else
                        if (e.CommandName == "DeleteSale")
                        {
                            if (userHelper.ArchiveSalesUser(Convert.ToInt32(e.CommandArgument)))
                            {
                                this.BindSalesUsers();
                            }
                        }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterSalesMan.aspx");
        }

        public void BindSalesUsers()
        {
            List<ComplianceUserData> lstUserData = userHelper.GetAllComplianceUsers();
            lstUsers.DataSource = lstUserData;
            lstUsers.DataBind();
        }
    }
}