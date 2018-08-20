using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class DailySalesData
    {
        public int DailySalesRecordID { get; set; }
        public string DaySales { get; set; }
        public string Refunds { get; set; }
        public string NetSales { get; set; }
        public string MonthlySales { get; set; }
        public string Tier1 { get; set; }
        public string Tier2 { get; set; }
        public string Tier3 { get; set; }
        public string Tier4 { get; set; }
        public string DateTime { get; set; }
        public string Bonus { get; set; }
        public string MonthlyDrawsTaken { get; set; }
        public string QBTotalPay { get; set; }
        public Nullable<int> UserID { get; set; }
        public string CashBonus { get; set; }
        public string MonthlyOfficeRent { get; set; }
        public string ActualPayoutTotal { get; set; }
    }
}
