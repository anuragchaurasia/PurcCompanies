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
    public partial class AdminDashboard : System.Web.UI.Page
    {
        DailySalesHelper salesHelper = new DailySalesHelper();
        SettingHelper settingHelper = new SettingHelper();
        UserHelper userHelper = new UserHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindSales();
            }
        }

        public void BindSales()
        {
            List<SalesData> SalesData = salesHelper.GetAllSalesDataByMonthYear(Convert.ToInt32(DateTime.Now.Month), Convert.ToInt32(DateTime.Now.Year));
            SettingEntity setting = settingHelper.GetSettings();
            List<ComplianceUserData> lstUserData = userHelper.GetAllComplianceUsers();
            StringBuilder dashboardString = new StringBuilder();
            foreach (ComplianceUserData user in lstUserData)
            {
                List<SalesData> lstSalesByUser = SalesData.Where(p => p.SalesPersonID == user.UserID).ToList();
               
                if (lstSalesByUser.Count > 0)
                {
                    string userid = user.UserID.ToString();
                    dashboardString.Append(String.Format( "<div class='col-lg-4 col-xs-6'><div class='small-box bg-gray'><div class='inner'><p>Sales Goals </br>" + user.Name + "</p><p>Sales to Date :  <a href='http://purcellcompanies.com/AdminDailySalesDisplay.aspx?UserID={0}'> " + (lstSalesByUser.Sum(y => Convert.ToDouble(y.DailySaleAmount)) - lstSalesByUser.Sum(y => Convert.ToDouble(y.Refunds))).ToString() + "</a></p><p>Monthly Goal : " + setting.MaxTarget + " USD " + "</p></div><div class='icon'> <i class='fa fa-dollar'></i></div></div></div>",user.UserID));
                    lblTargetAchieved.Text = (lstSalesByUser.Sum(y => Convert.ToDouble(y.DailySaleAmount)) - lstSalesByUser.Sum(y => Convert.ToDouble(y.Refunds))).ToString() + "/" + setting.MaxTarget + " USD";

                }
                else
                {
                    lblTargetAchieved.Text = "0.00/" + setting.MaxTarget + " USD";

                }
            }
            dashboard.InnerHtml = dashboardString.ToString();
        }
    }

}