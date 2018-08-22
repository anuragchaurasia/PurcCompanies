using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class SettingEntity
    {
        public int SettingID { get; set; }
        public string MaxTarget { get; set; }
        public string AdminEmails { get; set; }
        public string ProcessedEmails { get; set; }
        public string VoidedEmails { get; set; }
        public string RefundEmails { get; set; }
    }
}
