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
    public partial class ViewDailyLeads : System.Web.UI.Page
    {
        LeadDocumentHelper leadDocHelper = new LeadDocumentHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindLeads();
            }
        }

        private void BindLeads()
        {
            List<LeadDocEntity> lstLeadsData = leadDocHelper.GetAllLeadDocsForUsers(Convert.ToInt32(Request.Cookies["UserID"].Value)).ToList();
            lstUsers.DataSource = lstLeadsData;
            lstUsers.DataBind();
        }

        protected void lstUsers_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DownloadLeads")
            {
                var SearchDoc = e.CommandArgument.ToString();
                string file = SearchDoc.ToString();
                Response.AddHeader("Content-Disposition", "attachment;filename=\"" + file + "\"");
                Response.TransmitFile(Server.MapPath(file));
                Response.End();
            }
        }
    }
}