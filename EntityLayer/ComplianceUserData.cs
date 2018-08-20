using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class ComplianceUserData
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<bool> IsContractor { get; set; }
        public string UserType { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreationTime { get; set; }
    }
}
