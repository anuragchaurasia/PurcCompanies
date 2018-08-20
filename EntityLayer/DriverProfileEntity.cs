using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class DriverProfileEntity
    {
        public int DriverProfileID { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleYear { get; set; }
        public string VehicleModel { get; set; }
        public string TrailerInformation { get; set; }
        public string Notes { get; set; }
    }
}
