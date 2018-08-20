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
    public partial class AdminDailySalesDisplay : System.Web.UI.Page
    {
        UserHelper userHelper = new UserHelper();
        DailySalesHelper dailySalesHelper = new DailySalesHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //this.BindSalesUsers();
                this.BindSales();
            }
        }

        public void BindSalesUsers()
        {

        }

        public void BindSales()
        {
            int salesUserID = Convert.ToInt32(Request.QueryString["UserID"].ToString());
            lstSales.DataSource = dailySalesHelper.GetUserSalesDataByMonthYear(Convert.ToInt32(DateTime.Now.Month), Convert.ToInt32(DateTime.Now.Year), salesUserID);
            lstSales.DataBind();
        }

        protected void drpSalesGuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(drpMonth.SelectedItem.Value) == 1)
            //{

            //}
            //else
            //{
            //    int salesUserID = Convert.ToInt32(Request.QueryString["UserID"].ToString());
            //    lstSales.DataSource = dailySalesHelper.GetSalesBySalesPersonID(salesUserID);
            //    lstSales.DataBind();
            //}

        }

        protected void btnAddSales_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMasterSales.aspx");
        }

        protected void lstSales_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

        }

        protected void btnViewSales_Click(object sender, EventArgs e)
        {
            int salesUserID = Convert.ToInt32(Request.QueryString["UserID"].ToString());
            lstSales.DataSource = dailySalesHelper.GetUserSalesDataByMonthYear(Convert.ToInt32(drpMonth.SelectedValue), Convert.ToInt32(drpYear.SelectedValue), salesUserID);
            lstSales.DataBind();
        }

        protected void lstSales_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditSale")
            {
                Response.Redirect("EditMasterSales.aspx?saleid=" + e.CommandArgument);
            }
        }

        protected void lstSales_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                
                int salesUserID = Convert.ToInt32(Request.QueryString["UserID"].ToString());
                 
                List<SalesData> lstSalesData = dailySalesHelper.GetUserSalesDataByMonthYear(Convert.ToInt32(DateTime.Now.Month), Convert.ToInt32(DateTime.Now.Year), Convert.ToInt32(salesUserID));
                if (lstSalesData.Count > 0)
                {
                    var currentMonthlySale = (lstSalesData.Sum(y => Convert.ToDouble(y.DailySaleAmount)) - lstSalesData.Sum(y => Convert.ToDouble(y.Refunds)));
                    var LBLtotal = (Label) lstSales.FindControl("lblTotals");
                    var lblTotalCashBonus = (Label)lstSales.FindControl("lblTotalCashBonus");
                    var lblDollarCommision = (Label)lstSales.FindControl("lblDollarCommision");
                    var lblQBtotalPayout = (Label)lstSales.FindControl("lblQBtotalPayout");
                    var lblActualPayOut = (Label)lstSales.FindControl("lblActualPayOut");

                    var lblDrawTakenInMonth = (Label)lstSales.FindControl("lblDrawTakenInMonth");
                    var lblDailyBonusForMonth = (Label)lstSales.FindControl("lblDailyBonusForMonth");
                    var lblMonthlyOfficeRent = (Label)lstSales.FindControl("lblMonthlyOfficeRent");
                    var lblPayName = (Label)lstSales.FindControl("lblPayName");
                    LBLtotal.Text = currentMonthlySale.ToString();
                    lblTotalCashBonus.Text = (lstSalesData.Sum(y => Convert.ToDouble(y.CashBonus))).ToString();
                    lblPayName.Text = userHelper.GetComplianceUserByID(salesUserID).Name;
                    if (currentMonthlySale > 0 && currentMonthlySale <= 4000)
                    {
                        lblDollarCommision.Text = (currentMonthlySale * 20 / 100).ToString();
                    }
                    else if (currentMonthlySale > 4000 && currentMonthlySale <= 7000)
                    {
                        lblDollarCommision.Text = (currentMonthlySale * 25 / 100).ToString();
                    }
                    else if (currentMonthlySale > 7000 && currentMonthlySale <= 9500)
                    {
                        lblDollarCommision.Text = (currentMonthlySale * 28 / 100).ToString();
                    }
                    else if (currentMonthlySale > 9501)
                    {
                        lblDollarCommision.Text = (currentMonthlySale * 30 / 100).ToString();
                    }
                    var dailyBonus = Convert.ToDouble((lstSalesData.Select(x => x.DailyBonus)).FirstOrDefault());
                    var drawTakenMonthly = Convert.ToDouble((lstSalesData.Select(x => x.DrawTakenInMonth)).FirstOrDefault());
                    var monthlyRental = Convert.ToDouble((lstSalesData.Select(x => x.MonthlyOfficeRent)).FirstOrDefault());
                    try
                    {
                        lblQBtotalPayout.Text = ((Convert.ToDouble(lblDollarCommision.Text) + lstSalesData.Sum(y => Convert.ToDouble(y.CashBonus)) + dailyBonus) - drawTakenMonthly - monthlyRental).ToString();
                    }
                    catch
                    {
                       
                    }
                    try
                    {
                        lblActualPayOut.Text = ((Convert.ToDouble(lblDollarCommision.Text) + dailyBonus) - drawTakenMonthly - monthlyRental).ToString();
                    }
                    catch 
                    {
                       
                    }
                    try
                    {
                        lblDrawTakenInMonth.Text = lstSalesData.Last().DrawTakenInMonth.ToString();
                    }
                    catch 
                    {
                        
                    }
                    try
                    {
                        lblDailyBonusForMonth.Text = lstSalesData.Last().DailyBonus.ToString();
                    }
                    catch 
                    {
                        
                    }
                    try
                    {
                        lblMonthlyOfficeRent.Text = lstSalesData.Last().MonthlyOfficeRent.ToString();
                    }
                    catch 
                    {
                        
                    }
                }

                
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}