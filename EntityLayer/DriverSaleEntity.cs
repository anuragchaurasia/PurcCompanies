using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class DriverSaleEntity
    {
        public DriverVehicleEntity driverVehicle { get; set; }
        public ProfileCardEntity profileCard { get; set; }
        public OrderFormEntity orderForm { get; set; }
        public List<OrderFormEntity> completeOrderForm { get; set; }
        public List<DriverInterviewProfileEntity> driverInterviewProfiles { get; set; }
        public List<DriverServiceEntity> driverServices { get; set; }
    }
}
