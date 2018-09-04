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
    public partial class ListMCSaleAdmin : System.Web.UI.Page
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
            List<MCSaleEntity> mcSaleList = mcSaleHelper.GetAllMCSales();
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
                Response.Redirect("EditMCSaleAdmin.aspx?MCID=" + e.CommandArgument);
            }
            else
                if (e.CommandName == "DeleteSale")
                {
                    mcSaleHelper.DeleteMCSale(Convert.ToInt32(e.CommandArgument));
                    BindSavedMCSales(); 
                }
        }

        protected void drpPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataPager dtp = (DataPager)lstMCProfiles.FindControl("DataPager1");
            dtp.PageSize = Convert.ToInt32(drpPageSize.SelectedItem.Text);
            this.BindSavedMCSales();
        }
    }
}