using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class DriverVehicleEntity
    {
        public int DriverVehicleInfo { get; set; }
        public Nullable<int> OrderFormID { get; set; }
        public string Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string GVW { get; set; }
        public Nullable<bool> IsSubmitted { get; set; }
    }
}
