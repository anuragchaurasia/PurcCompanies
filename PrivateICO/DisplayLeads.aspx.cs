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
    public partial class DisplayLeads : System.Web.UI.Page
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
            int userid = Convert.ToInt32(Request.QueryString["UserID"].ToString());
            List<LeadData> lstLeadsData = leadHelper.GetLeadsByUserID(userid);
            lstOfLeads.DataSource = lstLeadsData;
            lstOfLeads.DataBind();
        }

        protected void lstOfLeads_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstOfLeads.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindLeads();
        }
    }
}