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
    public partial class ListUSDOTSaleAdmin : System.Web.UI.Page
    {
        DriverProfileHelper driverHelper = new DriverProfileHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDriverProfiles();
            }
        }

        public void LoadDriverProfiles()
        {
            DriverSaleEntity usdotDriverList = driverHelper.GetSales(true);
            if (usdotDriverList != null)
            {

                lstUSDOTProfiles.DataSource = usdotDriverList.completeOrderForm;
                lstUSDOTProfiles.DataBind();
            }
        }

        protected void lstUSDOTProfiles_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstUSDOTProfiles.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.LoadDriverProfiles();
        }

        protected void lstUSDOTProfiles_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditSale")
            {
                Response.Redirect("EditDOTSaleAdmin.aspx?USDotSaleID=" + e.CommandArgument);
            }
            else
                if (e.CommandName == "DeleteSale")
                {
                    driverHelper.DeleteUSDotSale(Convert.ToInt32(e.CommandArgument));
                    this.LoadDriverProfiles();
                }
        }

        protected void drpPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataPager dtp = (DataPager)lstUSDOTProfiles.FindControl("DataPager1");
            dtp.PageSize = Convert.ToInt32(drpPageSize.SelectedItem.Text);
            this.LoadDriverProfiles();
        }
    }

}