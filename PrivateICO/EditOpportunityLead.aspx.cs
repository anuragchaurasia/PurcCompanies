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
    public partial class EditOpportunityLead : System.Web.UI.Page
    {
        LeadHelper leadHelper = new LeadHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                int leadID = Convert.ToInt32(Request.QueryString["leadid"]);
                LeadData leadData = leadHelper.GetLeadsByLeadID(leadID);
                txtBestPhone.Text = leadData.PhoneNoForContact;
                txtBusinessName.Text = leadData.BusinessName;
                txtComplianceAgent.Text = leadData.ComplianceAgent;
                txtContactName.Text = leadData.ContactName;
                txtDoT.Text = leadData.DOTNo;
                txtEmail.Text = leadData.Email;
                txtServiceDiscussed.Text = leadData.ServiceDiscussed;
                BindLeads();
            }
        }

        private void BindLeads()
        {
            int leadid = Convert.ToInt32(Request.QueryString["leadid"]);
            List<LeadNoteEntity> lstLeadsData = leadHelper.GetAllLeadNotes(leadid);
            lstOfLeads.DataSource = lstLeadsData;
            lstOfLeads.DataBind();
        }

        protected void btnEditLead_Click(object sender, EventArgs e)
        {
             int leadID = Convert.ToInt32(Request.QueryString["leadid"]);
            LeadData lead = new LeadData();
            lead.BusinessName = txtBusinessName.Text;
            lead.ComplianceAgent = txtComplianceAgent.Text;
            lead.ContactName = txtContactName.Text;
            lead.DOTNo = txtDoT.Text;
            lead.Email = txtEmail.Text;
            lead.Notes = txtNotes.Text;
            lead.PhoneNoForContact = txtBestPhone.Text;
            lead.SalesPersonID = Convert.ToInt32(Request.Cookies["UserID"].Value);
            lead.ServiceDiscussed = txtServiceDiscussed.Text;
            lead.TimeLine = txtTimeLine.Text;
            lead.LeadID = leadID;
            bool isLeadUpdated = leadHelper.EditLead(lead);
            if (isLeadUpdated)
            {
                BindLeads();
                Response.Write("<script>alert('Lead updated Successfully.');</script>");
            }
            else
            {
                Response.Write("<script>alert('Some error occured.');</script>");
            }
        }

        protected void lstOfLeads_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstOfLeads.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindLeads();
        }
    }
}