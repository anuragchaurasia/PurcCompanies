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
    
    public partial class LeadDoc
    {
        public int LeadDocID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public string UploadedBy { get; set; }
        public Nullable<int> UploadedFor { get; set; }
        public string UploadDate { get; set; }
    }
}
