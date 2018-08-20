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
    public partial class HiringManagement : System.Web.UI.Page
    {

        CandidateHelper candidateHelper = new CandidateHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindCandidates();
            }
        }

        private void BindCandidates()
        {
            List<CandidateEntity> lstLeadsData = candidateHelper.GetAllCandidates();
            lstCandidates.DataSource = lstLeadsData;
            lstCandidates.DataBind();
        }

        protected void lstCandidates_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstCandidates.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindCandidates();
        }

        protected void lstCandidates_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                Response.Redirect("CandidateDetails.aspx?candidateid=" + e.CommandArgument);
            }
        }
    }
}