using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class LeadData
    {
        public int LeadID { get; set; }
        public string DOTNo { get; set; }
        public string BusinessName { get; set; }
        public string ComplianceAgent { get; set; }
        public string Date { get; set; }
        public string ContactName { get; set; }
        public string PhoneNoForContact { get; set; }
        public string Email { get; set; }
        public string TimeLine { get; set; }
        public string ServiceDiscussed { get; set; }
        public string Notes { get; set; }
        public Nullable<int> SalesPersonID { get; set; }
    }
}
