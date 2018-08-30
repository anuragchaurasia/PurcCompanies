using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class OrderFormEntity
    {
        public int OrderFormID { get; set; }
        public string USDot { get; set; }
        public string CA { get; set; }
        public string NameOnCard { get; set; }
        public string Name { get; set; }
        public string DBA { get; set; }
        public string LegalName { get; set; }
        public string PhysicalAddress { get; set; }
        public string BillingAddress { get; set; }
        public string Email { get; set; }
        public string DateTime { get; set; }
        public string DriverPhone { get; set; }
        public string ComplianceSupervisor { get; set; }
        public string CompanyType { get; set; }
        public Nullable<bool> IsSubmitted { get; set; }
        public string SaleID { get; set; }
        public Nullable<int> ComplianceUserID { get; set; }
        public string DOTPinNo { get; set; }
        public string SubmissionTime { get; set; }
        public string SubmittedBy { get; set; }
        public string AdditionalPhoneType { get; set; }
        public string AdditionalPhoneNo { get; set; }
    }
}
