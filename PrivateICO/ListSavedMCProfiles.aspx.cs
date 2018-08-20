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
    public partial class ListSavedMCProfiles : System.Web.UI.Page
    {
        MCSaleHelper mcSaleHelper = new MCSaleHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSavedMCSales();
            }
        }

        public void BindSavedMCSales()
        {
            List<MCSaleEntity> mcSaleList = mcSaleHelper.GetAllTempMCSales(Convert.ToInt32(Request.Cookies["UserID"].Value));
            lstMCProfiles.DataSource = mcSaleList;
            lstMCProfiles.DataBind();
        }

        protected void lstMCProfiles_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstMCProfiles.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindSavedMCSales();
        }

        protected void lstMCProfiles_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditSale")
            {
                Response.Redirect("EditMCSale.aspx?MCID=" + e.CommandArgument);
            }
        }

        protected void btnAddMCSale_Click(object sender, EventArgs e)
        {
            Response.Redirect("MCDriverProfile.aspx");
        }

    }
}