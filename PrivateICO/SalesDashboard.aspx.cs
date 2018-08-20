using DataLayer.DataHelper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrivateICO
{
    public partial class SalesDashboard : System.Web.UI.Page
    {
        DailySalesHelper salesHelper = new DailySalesHelper();
        SettingHelper settingHelper = new SettingHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindSales();
            }
        }

        public void BindSales()
        {
            List<SalesData> lstSalesData = salesHelper.GetUserSalesDataByMonthYear(Convert.ToInt32(DateTime.Now.Month), Convert.ToInt32(DateTime.Now.Year), Convert.ToInt32(Request.Cookies["UserID"].Value));
            SettingEntity setting = settingHelper.GetSettings();
            StringBuilder dashboardString = new StringBuilder();
            if (lstSalesData.Count > 0)
            {
                string userid = Request.Cookies["UserID"].Value;
                dashboardString.Append(String.Format("<div class='col-lg-4 col-xs-6'><div class='small-box bg-gray'><div class='inner'><p>Sales Goals </br>" + Request.Cookies["Name"].Value + "</p><p>Sales to Date :  <a href='http://purcellcompanies.com/DailySalesDisplay.aspx?UserID={0}'> " + (lstSalesData.Sum(y => Convert.ToDouble(y.DailySaleAmount)) - lstSalesData.Sum(y => Convert.ToDouble(y.Refunds))).ToString() + "</a></p><p>Monthly Goal : " + setting.MaxTarget + " USD " + "</p></div><div class='icon'> <i class='fa fa-dollar'></i></div></div></div>", userid));
                lblTargetAchieved.Text = (lstSalesData.Sum(y => Convert.ToDouble(y.DailySaleAmount)) - lstSalesData.Sum(y => Convert.ToDouble(y.Refunds))).ToString() + "/" + setting.MaxTarget + " USD";

            }
            else
            {
                lblTargetAchieved.Text =  "0.00/" + setting.MaxTarget + " USD";

            }
            dashboard.InnerHtml = dashboardString.ToString();
        }
    }
}