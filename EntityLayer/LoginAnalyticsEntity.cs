using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class LoginAnalyticsEntity
    {
        public int AnalyticsID { get; set; }
        public string Date { get; set; }
        public string Username { get; set; }
        public string IPAddress { get; set; }
        public string Platform { get; set; }
        public string OS { get; set; }
        public string Browser { get; set; }
    }
}
