//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lead
    {
        public int LeadID { get; set; }
        public string DOTNo { get; set; }
        public string BusinessName { get; set; }
        public string ComplianceAgent { get; set; }
        public string Date { get; set; }
        public string ContactName { get; set; }
        public string PhoneNoForContact { get; set; }
        public string Email { get; set; }
        public string ServiceDiscussed { get; set; }
        public Nullable<int> SalesPersonID { get; set; }
    }
}