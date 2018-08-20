using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class DriverInterviewProfileEntity
    {
        public int DriverInterviewID { get; set; }
        public string Date { get; set; }
        public string LegalName { get; set; }
        public string USDOT { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string DriverName { get; set; }
        public string Supervisor { get; set; }
        public string LicenseNo { get; set; }
        public string ExpirationDate { get; set; }
        public string Class { get; set; }
        public string StatusIssued { get; set; }
        public string DOB { get; set; }
        public string SSN { get; set; }
        public string EIN { get; set; }
        public string Notes { get; set; }
        public Nullable<int> OrderFormID { get; set; }
        public string CDLNonCDL { get; set; }
        public Nullable<bool> IsSubmitted { get; set; }
        public List<DriverServiceEntity> DriverServices { get; set; }
        public List<DriverVehicleCargoEntity> DriverCargos { get; set; }
        public DriverVehicleEntity DriverVehicle { get; set; }
        public List<DriverVehicleEntity> listDriverVehicle { get; set; }
    }
}
