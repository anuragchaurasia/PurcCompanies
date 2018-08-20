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
    public partial class DailySale : System.Web.UI.Page
    {
        DailySalesHelper dailySalesHelper = new DailySalesHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddSales_Click(object sender, EventArgs e)
        {
            DailySalesData dailySale = new DailySalesData();
            dailySale.DateTime = DateTime.Now.ToString();
            dailySale.DaySales = txtDaySales.Text;
            dailySale.MonthlySales = txtMonthlySales.Text;
            dailySale.NetSales = txtNetSales.Text;
            dailySale.Refunds = txtRefunds.Text;
            dailySale.Tier1 = txtTier1.Text;
            dailySale.Tier2 = txtTier2.Text;
            dailySale.Tier3 = txtTier3.Text;
            dailySale.Tier4 = txtTier4.Text;
            dailySale.Bonus = txtBonus.Text;
            dailySale.MonthlyDrawsTaken = txtMonthlyDrawsTaken.Text;
            dailySale.QBTotalPay = txtQBTotalPay.Text;
            dailySale.UserID = Convert.ToInt32(Request.Cookies["UserID"].Value);
            dailySale.CashBonus = txtCashBonus.Text;
            dailySale.MonthlyOfficeRent = txtMonthlyOfficeRent.Text;
            dailySale.ActualPayoutTotal = txtActualPayout.Text;
            bool isSalesAdded = dailySalesHelper.AddSales(dailySale);
            if (isSalesAdded)
            {
                Response.Write("<script>alert('Sales record added Successfully.');</script>");
            }
            else
            {
                Response.Write("<script>alert('Some error occured.');</script>");
            }
        }
    }
}