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
    public partial class EditMasterSales : System.Web.UI.Page
    {
        UserHelper userHelper = new UserHelper();
        DailySalesHelper salesHelper = new DailySalesHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //this.BindSalesUsers();
                this.BindSales();
            }
        }

        public void BindSales()
        {
            int salesID = Convert.ToInt32(Request.QueryString["saleid"].ToString());
            SalesData lstSalesData = salesHelper.GetMonthYearSaleBySaleID(Convert.ToInt32(DateTime.Now.Month), Convert.ToInt32(DateTime.Now.Year), salesID);
            if (lstSalesData != null)
            {
                txtMonthlySales.Text = lstSalesData.MonthlySales;
                txtTotalCashBonus.Text = lstSalesData.CashBonus;
                if (Convert.ToInt32(lstSalesData.MonthlySales) > 0 && Convert.ToInt32(lstSalesData.MonthlySales) <= 4000)
                {
                    txtCommision.Text = (Convert.ToInt32(lstSalesData.MonthlySales) * 20 / 100).ToString();
                }
                else if (Convert.ToInt32(lstSalesData.MonthlySales) > 4000 && Convert.ToInt32(lstSalesData.MonthlySales) <= 7000)
                {
                    txtCommision.Text = (Convert.ToInt32(lstSalesData.MonthlySales) * 25 / 100).ToString();
                }
                else if (Convert.ToInt32(lstSalesData.MonthlySales) > 7000 && Convert.ToInt32(lstSalesData.MonthlySales) <= 9500)
                {
                    txtCommision.Text = (Convert.ToInt32(lstSalesData.MonthlySales) * 28 / 100).ToString();
                }
                else if (Convert.ToInt32(lstSalesData.MonthlySales) > 9501)
                {
                    txtCommision.Text = (Convert.ToInt32(lstSalesData.MonthlySales) * 30 / 100).ToString();
                }
                //var dailyBonus = Convert.ToDouble((lstSalesData.Select(x => x.DailyBonus)).FirstOrDefault());
                //var drawTakenMonthly = Convert.ToDouble((lstSalesData.Select(x => x.DrawTakenInMonth)).FirstOrDefault());
                //var monthlyRental = Convert.ToDouble((lstSalesData.Select(x => x.MonthlyOfficeRent)).FirstOrDefault());
                //txtQBTotalPay.Text = ((Convert.ToDouble(txtCommision.Text) + lstSalesData.Sum(y => Convert.ToDouble(y.CashBonus)) + dailyBonus) - drawTakenMonthly - monthlyRental).ToString();
                //txtActualPayout.Text = ((Convert.ToDouble(txtCommision.Text) + lstSalesData.Sum(y => Convert.ToDouble(y.CashBonus))) - drawTakenMonthly - monthlyRental).ToString();

            }
            else
            {
                txtMonthlySales.Text = "0.00";
                txtTotalCashBonus.Text = "0.00";
            }
        }

        protected void btnEditSales_Click(object sender, EventArgs e)
        {
            //bool isDateAdded = salesHelper.CheckSaleDate(txtDate.Text, Convert.ToInt32(drpSalesGuy.SelectedItem.Value));
            //if (!isDateAdded)
            //{
            //    int salesID = Convert.ToInt32(Request.QueryString["saleid"].ToString());
            //    SalesData dailySale = new SalesData();
            //    dailySale.EntryDate = txtDate.Text;
            //    dailySale.DailySaleAmount = txtDaySales.Text;
            //    dailySale.MonthlySales = txtMonthlySales.Text;
            //    dailySale.NetSales = txtNetSales.Text;
            //    dailySale.Refunds = txtRefunds.Text;
            //    dailySale.CashBonus = txtBonus.Text;
            //    dailySale.DrawTakenInMonth = txtMonthlyDrawsTaken.Text;
            //    dailySale.QBTotalPay = txtQBTotalPay.Text;
            //    dailySale.SalesPersonID = Convert.ToInt32(drpSalesGuy.SelectedItem.Value);
            //    dailySale.MonthlyOfficeRent = txtMonthlyOfficeRent.Text;
            //    dailySale.DailyBonus = txtDailyBonusForMonth.Text;
            //    dailySale.SaleID = salesID;
            //    bool isSalesAdded = salesHelper.EditSaleRecord(dailySale);
            //    if (isSalesAdded)
            //    {
            //        Response.Write("<script>alert('Sales record edited Successfully.');</script>");
            //        BindSales();
            //    }
            //    else
            //    {
            //        Response.Write("<script>alert('Some error occured.');</script>");
            //    }
            //}
            //else
            //{
            //    Response.Write("<script>alert('Sale for this already added.Kindly edit the sale if you want any changes.');</script>");
            //}
        }
    }
}