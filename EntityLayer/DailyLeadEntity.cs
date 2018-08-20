﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class DailyLeadEntity
    {
        public int DailyLeadID { get; set; }
        public string DOTNumber { get; set; }
        public string LegalName { get; set; }
        public string PhysicalAddress { get; set; }
        public string ZipCode { get; set; }
        public string MailingAddress { get; set; }
        public string PhoneNo { get; set; }
        public string TimeZone { get; set; }
        public string OperatingStatus { get; set; }
        public string Interstate { get; set; }
        public string AuthForHire { get; set; }
        public string PowerUnits { get; set; }
        public string Drivers { get; set; }
        public string DateFiled { get; set; }
        public string Status { get; set; }
        public Nullable<int> LeadDocID { get; set; }
        public string SavedOn { get; set; }
    }
}
