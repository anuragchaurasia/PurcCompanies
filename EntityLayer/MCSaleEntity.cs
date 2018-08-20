using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class MCSaleEntity
    {
        public int MCID { get; set; }
        public string DotNo { get; set; }
        public string MCNo { get; set; }
        public string NameOnCard { get; set; }
        public string AddressOnCard { get; set; }
        public string PhysicalAddress { get; set; }
        public string Email { get; set; }
        public string SoldAt { get; set; }
        public SaleType saleType { get; set; }
        public Nullable<int> SalesPersonID { get; set; }
        public List<MCServiceSaleEntity> serviceSaleData { get; set; }
        public string CardNo { get; set; }
        public string CardType { get; set; }
        public string ExpirationDate { get; set; }
        public string CVC { get; set; }
        public string SalesPersonName { get; set; }
        public string PhoneNo { get; set; }
        public string MCSaleNo { get; set; }
        public string LegalName { get; set; }
        public string DBA { get; set; }
        public string DotPin { get; set; }
    }

    public enum SaleType
    {
        Saved,
        Submitted
    }
}
