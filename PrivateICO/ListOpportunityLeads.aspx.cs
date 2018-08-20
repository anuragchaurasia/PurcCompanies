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
    public partial class ListOpportunityLeads : System.Web.UI.Page
    {
        LeadHelper leadHelper = new LeadHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindLeads();
            }
        }

        private void BindLeads()
        {
            int userid = Convert.ToInt32(Request.Cookies["UserID"].Value);
            List<LeadData> lstLeadsData = leadHelper.GetLeadsByUserID(userid);
            lstOfLeads.DataSource = lstLeadsData;
            lstOfLeads.DataBind();
        }

        protected void lstOfLeads_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstOfLeads.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindLeads();
        }

        protected void btnAddOpportunity_Click(object sender, EventArgs e)
        {
            Response.Redirect("LeadsEntry.aspx");
        }

        protected void btnSearchByDOTNo_Click(object sender, EventArgs e)
        {
            LeadData LeadsData = leadHelper.GetLeadsByDOTNo(txtDOTNo.Text);
            List<LeadData> lstLeadsData = new List<LeadData>();
            lstLeadsData.Add(LeadsData);
            lstOfLeads.DataSource = lstLeadsData;
            lstOfLeads.DataBind();
        }

        protected void lstOfLeads_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditLead")
            {
                Response.Redirect("EditOpportunityLead.aspx?leadid=" + e.CommandArgument);
            }
            else
                if (e.CommandName == "DeleteLead")
            {
                leadHelper.DeleteLead(Convert.ToInt32(e.CommandArgument));
                this.BindLeads();
            }
        }
    }
}