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
    
    public partial class ComplianceUser
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsContractor { get; set; }
        public string UserType { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreationTime { get; set; }
        public Nullable<bool> IsArchive { get; set; }
        public string ExtensionNo { get; set; }
    }
}
