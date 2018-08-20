using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class MCServiceSaleEntity
    {
        public int MCServiceID { get; set; }
        public Nullable<int> MCSaleID { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServicePrice { get; set; }
    }
}
