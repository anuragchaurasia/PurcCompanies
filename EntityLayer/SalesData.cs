using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class SalesData
    {
        public int SaleID { get; set; }
        public string DailySaleAmount { get; set; }
        public string Refunds { get; set; }
        public string NetSales { get; set; }
        public string MonthlySales { get; set; }
        public string CashBonus { get; set; }
        public string DrawTakenInMonth { get; set; }
        public string DailyBonus { get; set; }
        public string MonthlyOfficeRent { get; set; }
        public string QBTotalPay { get; set; }
        public Nullable<int> SalesPersonID { get; set; }
        public string EntryDate { get; set; }
        public string CommisionInUSD { get; set; }
        public string CommisionPercentage { get; set; }
    }
}
