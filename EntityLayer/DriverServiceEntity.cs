using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class DriverServiceEntity
    {
        public int DriverServiceID { get; set; }
        public Nullable<int> DriverInterviewProfileID { get; set; }
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServicePrice { get; set; }
    }
}
