using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class DriverVehicleCargoEntity
    {
        public int VehicleCargoID { get; set; }
        public Nullable<int> DriverVehicleID { get; set; }
        public string CargoCarriedName { get; set; }
    }
}
