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
    public partial class DailySaleEntry : System.Web.UI.Page
    {
        DailySalesHelper salesHelper = new DailySalesHelper();
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
            if (lstSalesData.Count > 0)
            {
                var currentMonthlySale = (lstSalesData.Sum(y => Convert.ToDouble(y.DailySaleAmount)) - lstSalesData.Sum(y => Convert.ToDouble(y.Refunds)));
                txtMonthlySales.Text = currentMonthlySale.ToString();
                txtTotalCashBonus.Text = (lstSalesData.Sum(y => Convert.ToDouble(y.CashBonus))).ToString();
                if (currentMonthlySale > 0 && currentMonthlySale <= 4000)
                {
                    txtCommision.Text = (currentMonthlySale * 20 / 100).ToString();
                }
                else if (currentMonthlySale > 4000 && currentMonthlySale <= 7000)
                {
                    txtCommision.Text = (currentMonthlySale * 25 / 100).ToString();
                }
                else if (currentMonthlySale > 7000 && currentMonthlySale <= 9500)
                {
                    txtCommision.Text = (currentMonthlySale * 28 / 100).ToString();
                }
                else if (currentMonthlySale > 9501)
                {
                    txtCommision.Text = (currentMonthlySale * 30 / 100).ToString();
                }
                var dailyBonus = Convert.ToDouble((lstSalesData.Select(x => x.DailyBonus)).FirstOrDefault());
                var drawTakenMonthly = Convert.ToDouble((lstSalesData.Select(x => x.DrawTakenInMonth)).FirstOrDefault());
                var monthlyRental = Convert.ToDouble((lstSalesData.Select(x => x.MonthlyOfficeRent)).FirstOrDefault());
                txtQBTotalPay.Text = ((Convert.ToDouble(txtCommision.Text) + lstSalesData.Sum(y => Convert.ToDouble(y.CashBonus)) + dailyBonus) - drawTakenMonthly - monthlyRental).ToString();
                txtActualPayout.Text = ((Convert.ToDouble(txtCommision.Text) + lstSalesData.Sum(y => Convert.ToDouble(y.CashBonus))) - drawTakenMonthly - monthlyRental).ToString();

            }
            else
            {
                txtMonthlySales.Text = "0.00";
                txtTotalCashBonus.Text = "0.00";
            }
        }

        protected void btnAddSales_Click(object sender, EventArgs e)
        {
            bool isDateAdded = salesHelper.CheckSaleDate(txtDate.Text, Convert.ToInt32(Request.Cookies["UserID"].Value));
            if (!isDateAdded)
            {
                SalesData dailySale = new SalesData();
                dailySale.EntryDate = txtDate.Text;
                dailySale.DailySaleAmount = txtDaySales.Text;
                dailySale.MonthlySales = Request.Form[txtMonthlySales.UniqueID]; //txtMonthlySales.Text;
                dailySale.NetSales = Request.Form[txtNetSales.UniqueID];//txtNetSales.Text;
                if (Convert.ToInt32(dailySale.MonthlySales) > 0 && Convert.ToInt32(dailySale.MonthlySales) <= 4000)
                {
                    dailySale.CommisionPercentage = "20%";
                }
                else if (Convert.ToInt32(dailySale.MonthlySales) > 4000 && Convert.ToInt32(dailySale.MonthlySales) <= 7000)
                {
                    dailySale.CommisionPercentage = "25%";
                }
                else if (Convert.ToInt32(dailySale.MonthlySales) > 7000 && Convert.ToInt32(dailySale.MonthlySales) <= 9500)
                {
                    dailySale.CommisionPercentage = "28%";
                }
                else if (Convert.ToInt32(dailySale.MonthlySales) > 9501)
                {
                    dailySale.CommisionPercentage = "30%";
                }


                dailySale.Refunds = txtRefunds.Text;
                dailySale.CashBonus = txtBonus.Text;
                dailySale.DrawTakenInMonth = txtMonthlyDrawsTaken.Text;
                dailySale.QBTotalPay = Request.Form[txtQBTotalPay.UniqueID]; //txtQBTotalPay.Text;
                dailySale.SalesPersonID = Convert.ToInt32(Request.Cookies["UserID"].Value);
                dailySale.MonthlyOfficeRent = txtMonthlyOfficeRent.Text;
                dailySale.DailyBonus = txtDailyBonusForMonth.Text;
                dailySale.CommisionInUSD = Request.Form[txtCommision.UniqueID];
                bool isSalesAdded = salesHelper.AddSaleRecord(dailySale);
                if (isSalesAdded)
                {
                    Response.Write("<script>alert('Sales record added Successfully.');</script>");
                    ResetAll();
                }
                else
                {
                    Response.Write("<script>alert('Some error occured.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Sale for this already added.Kindly edit the sale if you want any changes.');</script>");
            }
        }

        public void ResetAll()
        {
            
            txtDate.Text = "";
            txtDaySales.Text = "0";

            txtDaySales.Text = "0";
            txtRefunds.Text = "0";
            txtNetSales.Text = "0";
            txtMonthlySales.Text = "0";
            txtCommision.Text = "0";
            txtBonus.Text = "0";
            txtMonthlyDrawsTaken.Text = "0";
            txtQBTotalPay.Text = "0";
            txtTotalCashBonus.Text = "0";
            txtMonthlyOfficeRent.Text = "0";
            txtActualPayout.Text = "0";
            txtDailyBonusForMonth.Text = "0";
        }
    }
}