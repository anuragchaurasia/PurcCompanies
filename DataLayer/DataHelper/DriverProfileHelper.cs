using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.DataHelper
{
    public class DriverProfileHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;
        UserHelper userHelper = new UserHelper();
        public int AddDriverProfile(ProfileCardEntity profileCard, OrderFormEntity orderForm, List<DriverInterviewProfileEntity> driverInterviewProfiles, List<DriverServiceEntity> driverServices)
        {
            int driverProfileID = 0;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {

                    OrderForm orderFormdb = new OrderForm();
                    orderFormdb.PhysicalAddress = orderForm.PhysicalAddress;
                    orderFormdb.BillingAddress = orderForm.BillingAddress;
                    orderFormdb.CA = orderForm.CA;
                    orderFormdb.ComplianceSupervisor = orderForm.ComplianceSupervisor;
                    orderFormdb.DateTime = Helper.DateTimeJavaScript.GetCurrentTime().ToString();
                    orderFormdb.DBA = orderForm.DBA;
                    orderFormdb.LegalName = orderForm.LegalName;
                    orderFormdb.Name = orderForm.Name;
                    orderFormdb.Email = orderForm.Email;
                    orderFormdb.NameOnCard = orderForm.NameOnCard;
                    orderFormdb.OrderFormID = orderForm.OrderFormID;
                    orderFormdb.USDot = orderForm.USDot;
                    orderFormdb.DriverPhone = orderForm.DriverPhone;
                    orderFormdb.CompanyType = orderForm.CompanyType;
                    orderFormdb.IsSubmitted = orderForm.IsSubmitted;
                    orderFormdb.ComplianceUserID = orderForm.ComplianceUserID;
                    orderFormdb.SaleID = orderForm.SaleID;
                    orderFormdb.DOTPinNo = orderForm.DOTPinNo;

                    uow.OrderFormRepository.Insert(orderFormdb);
                    uow.Save();

                    ProfileCard profileCarddb = new ProfileCard();
                    profileCarddb.CardType = profileCard.CardType;
                    profileCarddb.CorDC = profileCard.CorDC;
                    profileCarddb.CVC = profileCard.CVC;
                    profileCarddb.OrderFormID = orderFormdb.OrderFormID;
                    profileCarddb.Expiration = profileCard.Expiration;
                    profileCarddb.ProfileCardInfo = profileCard.ProfileCardInfo;
                    profileCarddb.IsSubmitted = profileCard.IsSubmitted;
                    uow.ProfileCardRepository.Insert(profileCarddb);
                    uow.Save();

                    foreach (DriverServiceEntity driverService in driverServices)
                    {
                        DriverService driverServicedb = new DriverService();
                        driverServicedb.DriverInterviewProfileID = orderFormdb.OrderFormID;
                        driverServicedb.ServiceID = driverService.ServiceID;
                        uow.DriverServiceRepository.Insert(driverServicedb);
                        uow.Save();
                    }

                    foreach (DriverInterviewProfileEntity driverInterviewProfile in driverInterviewProfiles)
                    {
                        DriverInterviewProfile driverInterviewProfiledb = new DriverInterviewProfile();
                        driverInterviewProfiledb.Class = driverInterviewProfile.Class;
                        driverInterviewProfiledb.Date = driverInterviewProfile.Date;
                        driverInterviewProfiledb.DOB = driverInterviewProfile.DOB;
                        driverInterviewProfiledb.DriverName = driverInterviewProfile.DriverName;
                        driverInterviewProfiledb.OrderFormID = orderFormdb.OrderFormID;
                        driverInterviewProfiledb.EIN = driverInterviewProfile.EIN;
                        driverInterviewProfiledb.Email = driverInterviewProfile.Email;
                        driverInterviewProfiledb.ExpirationDate = driverInterviewProfile.ExpirationDate;
                        driverInterviewProfiledb.LegalName = driverInterviewProfile.LegalName;
                        driverInterviewProfiledb.LicenseNo = driverInterviewProfile.LicenseNo;
                        driverInterviewProfiledb.Notes = driverInterviewProfile.Notes;
                        driverInterviewProfiledb.Phone = driverInterviewProfile.Phone;
                        driverInterviewProfiledb.SSN = driverInterviewProfile.SSN;
                        driverInterviewProfiledb.StatusIssued = driverInterviewProfile.StatusIssued;
                        driverInterviewProfiledb.Supervisor = driverInterviewProfile.Supervisor;
                        driverInterviewProfiledb.USDOT = driverInterviewProfile.USDOT;
                        driverInterviewProfiledb.CDLNonCDL = driverInterviewProfile.CDLNonCDL;
                        driverInterviewProfiledb.IsSubmitted = driverInterviewProfile.IsSubmitted;
                        uow.DriverInterviewProfileRepository.Insert(driverInterviewProfiledb);
                        uow.Save();



                        foreach (DriverVehicleCargoEntity drivercargo in driverInterviewProfile.DriverCargos)
                        {
                            DriverVehicleCargo driverVehicleCargodb = new DriverVehicleCargo();
                            driverVehicleCargodb.DriverVehicleID = driverInterviewProfiledb.DriverInterviewID;
                            driverVehicleCargodb.CargoCarriedName = drivercargo.CargoCarriedName;
                            uow.DriverVehicleCargoRepository.Insert(driverVehicleCargodb);
                            uow.Save();
                        }


                        DriverVehicle driverVehicledb = new DriverVehicle();
                        driverVehicledb.OrderFormID = driverInterviewProfiledb.DriverInterviewID;
                        driverVehicledb.DriverVehicleInfo = driverInterviewProfile.DriverVehicle.DriverVehicleInfo;
                        driverVehicledb.GVW = driverInterviewProfile.DriverVehicle.GVW;
                        driverVehicledb.Make = driverInterviewProfile.DriverVehicle.Make;
                        driverVehicledb.Model = driverInterviewProfile.DriverVehicle.Model;
                        driverVehicledb.Year = driverInterviewProfile.DriverVehicle.Year;
                        uow.DriverVehicleRepository.Insert(driverVehicledb);
                        uow.Save();

                    }



                }
                catch
                {
                    driverProfileID = 0;
                }
            }

            return driverProfileID;
        }

        public DriverSaleEntity GetSalesByOrderID(bool isSubmitted, int orderid)
        {
            DriverSaleEntity driverSale = new DriverSaleEntity();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                driverSale.orderForm = uow.OrderFormRepository.Get().Select(of => new OrderFormEntity
                {
                    BillingAddress = of.BillingAddress,
                    CA = of.CA,
                    CompanyType = of.CompanyType,
                    ComplianceSupervisor = of.ComplianceSupervisor,
                    DateTime = of.DateTime,
                    DBA = of.DBA,
                    DriverPhone = of.DriverPhone,
                    Email = of.Email,
                    LegalName = of.LegalName,
                    IsSubmitted = of.IsSubmitted,
                    Name = of.Name,
                    NameOnCard = of.NameOnCard,
                    OrderFormID = of.OrderFormID,
                    PhysicalAddress = of.PhysicalAddress,
                    USDot = of.USDot,
                    DOTPinNo = of.DOTPinNo,
                    ComplianceUserID = of.ComplianceUserID,
                    SaleID = of.SaleID
                }).Where(x => x.IsSubmitted == isSubmitted && x.OrderFormID == orderid).FirstOrDefault();

                driverSale.profileCard = uow.ProfileCardRepository.Get().Select(pc => new ProfileCardEntity
                {
                    CardType = pc.CardType,
                    CorDC = pc.CorDC,
                    CVC = pc.CVC,
                    Expiration = pc.Expiration,
                    IsSubmitted = pc.IsSubmitted,
                    OrderFormID = pc.OrderFormID,
                    ProfileCardInfo = pc.ProfileCardInfo
                }).Where(x => x.IsSubmitted == isSubmitted && x.OrderFormID == orderid).FirstOrDefault();

                driverSale.driverServices = uow.DriverServiceRepository.Get().Join(uow.DocumentMasterRepository.Get(), msd => msd.ServiceID, dms => dms.DocumentID, (msd, dms) => new { msd, dms })
                        .Select(p => new DriverServiceEntity { DriverServiceID = p.msd.DriverServiceID, ServiceID = (int)p.msd.ServiceID, DriverInterviewProfileID = p.msd.DriverInterviewProfileID, ServiceName = p.dms.DocumentName, ServicePrice = p.dms.Description })
                        .Where(x => x.DriverInterviewProfileID == orderid).ToList();

                driverSale.driverInterviewProfiles = uow.DriverInterviewProfileRepository.Get().Select(dv => new DriverInterviewProfileEntity
                {
                    CDLNonCDL = dv.CDLNonCDL,
                    Class = dv.Class,
                    IsSubmitted = isSubmitted,
                    Date = dv.Date,
                    DOB = dv.DOB,
                    OrderFormID = dv.OrderFormID,
                    DriverInterviewID = dv.DriverInterviewID,
                    DriverName = dv.DriverName,
                    EIN = dv.EIN,
                    Email = dv.Email,
                    ExpirationDate = dv.ExpirationDate,
                    LegalName = dv.LegalName,
                    LicenseNo = dv.LicenseNo,
                    Notes = dv.Notes,
                    Phone = dv.Phone,
                    SSN = dv.SSN,
                    StatusIssued = dv.StatusIssued,
                    Supervisor = dv.Supervisor,
                    USDOT = dv.USDOT,
                    DriverCargos = uow.DriverVehicleCargoRepository.Get().Where(x => x.DriverVehicleID == dv.DriverInterviewID).Select(p => new DriverVehicleCargoEntity { CargoCarriedName = p.CargoCarriedName, DriverVehicleID = p.DriverVehicleID, VehicleCargoID = p.VehicleCargoID }).ToList(),

                    DriverVehicle = uow.DriverVehicleRepository.Get().Where(x => x.DriverVehicleInfo == dv.DriverInterviewID).Select(p => new DriverVehicleEntity { DriverVehicleInfo = p.DriverVehicleInfo, GVW = p.GVW, Make = p.Make, Model = p.Model, OrderFormID = p.OrderFormID, Year = p.Year }).FirstOrDefault(),
                    listDriverVehicle = uow.DriverVehicleRepository.Get().Where(x => x.DriverVehicleInfo == dv.DriverInterviewID).Select(p => new DriverVehicleEntity { DriverVehicleInfo = p.DriverVehicleInfo, GVW = p.GVW, Make = p.Make, Model = p.Model, OrderFormID = p.OrderFormID, Year = p.Year }).ToList(),
                }).Where(x => x.OrderFormID == orderid && x.IsSubmitted == isSubmitted).ToList();
            }
            return driverSale;
        }

        public DriverSaleEntity GetSales(bool isSubmitted)
        {
            DriverSaleEntity driverSale = new DriverSaleEntity();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                driverSale.completeOrderForm = uow.OrderFormRepository.Get().Select(of => new OrderFormEntity
                {
                    BillingAddress = of.BillingAddress,
                    CA = of.CA,
                    CompanyType = of.CompanyType,
                    ComplianceSupervisor = of.ComplianceSupervisor,
                    DateTime = of.DateTime,
                    DBA = of.DBA,
                    DriverPhone = of.DriverPhone,
                    Email = of.Email,
                    LegalName = of.LegalName,
                    IsSubmitted = of.IsSubmitted,
                    Name = of.Name,
                    NameOnCard = of.NameOnCard,
                    OrderFormID = of.OrderFormID,
                    PhysicalAddress = of.PhysicalAddress,
                    USDot = of.USDot,
                    DOTPinNo = of.DOTPinNo,
                    ComplianceUserID = of.ComplianceUserID,
                    SaleID = of.SaleID,
                    SubmittedBy = of.ComplianceUserID != null ? userHelper.GetComplianceUserByID(Convert.ToInt32(of.ComplianceUserID)).Email : "N/A",
                }).Where(x => x.IsSubmitted == isSubmitted).OrderByDescending(p => p.OrderFormID).ToList();

                driverSale.profileCard = uow.ProfileCardRepository.Get().Select(pc => new ProfileCardEntity
                {
                    CardType = pc.CardType,
                    CorDC = pc.CorDC,
                    CVC = pc.CVC,
                    Expiration = pc.Expiration,
                    IsSubmitted = pc.IsSubmitted,
                    OrderFormID = pc.OrderFormID,
                    ProfileCardInfo = pc.ProfileCardInfo
                }).Where(x => x.IsSubmitted == isSubmitted).FirstOrDefault();

                driverSale.driverInterviewProfiles = uow.DriverInterviewProfileRepository.Get().Select(dv => new DriverInterviewProfileEntity
                {
                    CDLNonCDL = dv.CDLNonCDL,
                    Class = dv.Class,
                    IsSubmitted = isSubmitted,
                    Date = dv.Date,
                    DOB = dv.DOB,
                    OrderFormID = dv.OrderFormID,
                    DriverInterviewID = dv.DriverInterviewID,
                    DriverName = dv.DriverName,
                    EIN = dv.EIN,
                    Email = dv.Email,
                    ExpirationDate = dv.ExpirationDate,
                    LegalName = dv.LegalName,
                    LicenseNo = dv.LicenseNo,
                    Notes = dv.Notes,
                    Phone = dv.Phone,
                    SSN = dv.SSN,
                    StatusIssued = dv.StatusIssued,
                    Supervisor = dv.Supervisor,
                    USDOT = dv.USDOT,
                    DriverCargos = uow.DriverVehicleCargoRepository.Get().Where(x => x.DriverVehicleID == dv.DriverInterviewID).Select(p => new DriverVehicleCargoEntity { CargoCarriedName = p.CargoCarriedName, DriverVehicleID = p.DriverVehicleID, VehicleCargoID = p.VehicleCargoID }).ToList(),
                    DriverServices = uow.DriverServiceRepository.Get().Join(uow.DocumentMasterRepository.Get(), msd => msd.ServiceID, dms => dms.DocumentID, (msd, dms) => new { msd, dms })
                        .Select(p => new DriverServiceEntity { DriverServiceID = p.msd.DriverServiceID, ServiceID = (int)p.msd.ServiceID, DriverInterviewProfileID = p.msd.DriverInterviewProfileID, ServiceName = p.dms.DocumentName, ServicePrice = p.dms.Description })
                        .Where(x => x.DriverInterviewProfileID == dv.DriverInterviewID).ToList(),
                    DriverVehicle = uow.DriverVehicleRepository.Get().Where(x => x.OrderFormID == dv.OrderFormID).Select(p => new DriverVehicleEntity { DriverVehicleInfo = p.DriverVehicleInfo, GVW = p.GVW, Make = p.Make, Model = p.Model, OrderFormID = p.OrderFormID, Year = p.Year }).FirstOrDefault(),
                }).ToList();
            }
            return driverSale;
        }

        public bool SaveDriverServices(int driverProfileID, DriverInterviewProfileEntity driverInterviewProfile, List<DriverServiceEntity> driverServices)
        {
            bool isDriverProfileSaved = false;
            DriverInterviewProfile driverInterviewProfiledb = new DriverInterviewProfile();
            driverInterviewProfiledb.Class = driverInterviewProfile.Class;
            driverInterviewProfiledb.Date = driverInterviewProfile.Date;
            driverInterviewProfiledb.DOB = driverInterviewProfile.DOB;
            driverInterviewProfiledb.DriverInterviewID = driverInterviewProfile.DriverInterviewID;
            driverInterviewProfiledb.DriverName = driverInterviewProfile.DriverName;
            driverInterviewProfiledb.OrderFormID = driverProfileID;
            driverInterviewProfiledb.EIN = driverInterviewProfile.EIN;
            driverInterviewProfiledb.Email = driverInterviewProfile.Email;
            driverInterviewProfiledb.ExpirationDate = driverInterviewProfile.ExpirationDate;
            driverInterviewProfiledb.LegalName = driverInterviewProfile.LegalName;
            driverInterviewProfiledb.LicenseNo = driverInterviewProfile.LicenseNo;
            driverInterviewProfiledb.Notes = driverInterviewProfile.Notes;
            driverInterviewProfiledb.Phone = driverInterviewProfile.Phone;
            driverInterviewProfiledb.SSN = driverInterviewProfile.SSN;
            driverInterviewProfiledb.StatusIssued = driverInterviewProfile.StatusIssued;
            driverInterviewProfiledb.Supervisor = driverInterviewProfile.Supervisor;
            driverInterviewProfiledb.USDOT = driverInterviewProfile.USDOT;
            uow.DriverInterviewProfileRepository.Insert(driverInterviewProfiledb);
            uow.Save();

            foreach (DriverServiceEntity driverService in driverServices)
            {
                DriverService driverServicedb = new DriverService();
                driverServicedb.DriverInterviewProfileID = driverInterviewProfiledb.DriverInterviewID;
                driverServicedb.ServiceID = driverService.ServiceID;
                uow.DriverServiceRepository.Insert(driverServicedb);
                uow.Save();
            }

            return isDriverProfileSaved;
        }

        public bool EditDriverProfile(int driverProfileID, ProfileCardEntity profileCard, OrderFormEntity orderForm, List<DriverInterviewProfileEntity> driverInterviewProfiles, bool isSubmitted, List<DriverServiceEntity> driverServices)
        {
            bool isDriverProfileEdited = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {

                    OrderForm orderFormdb = uow.OrderFormRepository.Get().Where(x => x.OrderFormID == driverProfileID).FirstOrDefault();
                    orderFormdb.PhysicalAddress = orderForm.PhysicalAddress;
                    orderFormdb.BillingAddress = orderForm.BillingAddress;
                    orderFormdb.CA = orderForm.CA;
                    orderFormdb.ComplianceSupervisor = orderForm.ComplianceSupervisor;
                    orderFormdb.DateTime = Helper.DateTimeJavaScript.GetCurrentTime().ToString();
                    orderFormdb.DBA = orderForm.DBA;
                    orderFormdb.LegalName = orderForm.LegalName;
                    orderFormdb.Name = orderForm.Name;
                    orderFormdb.Email = orderForm.Email;
                    orderFormdb.NameOnCard = orderForm.NameOnCard;
                    orderFormdb.USDot = orderForm.USDot;
                    orderFormdb.DriverPhone = orderForm.DriverPhone;
                    orderFormdb.CompanyType = orderForm.CompanyType;
                    orderFormdb.IsSubmitted = orderForm.IsSubmitted;
                    orderFormdb.DOTPinNo = orderForm.DOTPinNo;


                    uow.OrderFormRepository.Update(orderFormdb);
                    uow.Save();

                    ProfileCard profileCarddb = uow.ProfileCardRepository.Get().Where(x => x.OrderFormID == driverProfileID).FirstOrDefault();
                    profileCarddb.CardType = profileCard.CardType;
                    profileCarddb.CorDC = profileCard.CorDC;
                    profileCarddb.CVC = profileCard.CVC;
                    profileCarddb.OrderFormID = orderFormdb.OrderFormID;
                    profileCarddb.Expiration = profileCard.Expiration;
                    profileCarddb.IsSubmitted = profileCard.IsSubmitted;
                    uow.ProfileCardRepository.Update(profileCarddb);
                    uow.Save();

                    List<DriverService> usDotServiceTemp = uow.DriverServiceRepository.Get().Where(x => x.DriverInterviewProfileID == orderFormdb.OrderFormID).ToList();
                    foreach (DriverService service in usDotServiceTemp)
                    {
                        uow.DriverServiceRepository.Delete(service);
                        uow.Save();
                    }

                    if (driverServices != null)
                    {
                        foreach (DriverServiceEntity driverService in driverServices)
                        {
                            DriverService driverServicedb = new DriverService();
                            driverServicedb.DriverInterviewProfileID = orderFormdb.OrderFormID;
                            driverServicedb.ServiceID = driverService.ServiceID;
                            uow.DriverServiceRepository.Insert(driverServicedb);
                            uow.Save();
                        }
                    }

                    List<DriverInterviewProfile> usDotDriverInterviewProfileTemp = uow.DriverInterviewProfileRepository.Get().Where(x => x.OrderFormID == driverProfileID).ToList();
                    foreach (DriverInterviewProfile item in usDotDriverInterviewProfileTemp)
                    {


                        List<DriverVehicleCargo> usDotVehicleCargoTemp = uow.DriverVehicleCargoRepository.Get().Where(x => x.DriverVehicleID == item.DriverInterviewID).ToList();
                        foreach (DriverVehicleCargo vehicleCargo in usDotVehicleCargoTemp)
                        {
                            uow.DriverVehicleCargoRepository.Delete(vehicleCargo);
                            uow.Save();
                        }

                        List<DriverVehicle> usDotVehicleTemp = uow.DriverVehicleRepository.Get().Where(x => x.OrderFormID == item.DriverInterviewID).ToList();
                        foreach (DriverVehicle vehicleCargo in usDotVehicleTemp)
                        {
                            uow.DriverVehicleRepository.Delete(vehicleCargo);
                            uow.Save();
                        }

                        uow.DriverInterviewProfileRepository.Delete(item);
                        uow.Save();
                    }

                    foreach (DriverInterviewProfileEntity driverInterviewProfile in driverInterviewProfiles)
                    {
                        DriverInterviewProfile driverInterviewProfiledb = new DriverInterviewProfile();
                        driverInterviewProfiledb.Class = driverInterviewProfile.Class;
                        driverInterviewProfiledb.Date = driverInterviewProfile.Date;
                        driverInterviewProfiledb.DOB = driverInterviewProfile.DOB;
                        driverInterviewProfiledb.DriverName = driverInterviewProfile.DriverName;
                        driverInterviewProfiledb.OrderFormID = orderFormdb.OrderFormID;
                        driverInterviewProfiledb.EIN = driverInterviewProfile.EIN;
                        driverInterviewProfiledb.Email = driverInterviewProfile.Email;
                        driverInterviewProfiledb.ExpirationDate = driverInterviewProfile.ExpirationDate;
                        driverInterviewProfiledb.LegalName = driverInterviewProfile.LegalName;
                        driverInterviewProfiledb.LicenseNo = driverInterviewProfile.LicenseNo;
                        driverInterviewProfiledb.Notes = driverInterviewProfile.Notes;
                        driverInterviewProfiledb.Phone = driverInterviewProfile.Phone;
                        driverInterviewProfiledb.SSN = driverInterviewProfile.SSN;
                        driverInterviewProfiledb.StatusIssued = driverInterviewProfile.StatusIssued;
                        driverInterviewProfiledb.Supervisor = driverInterviewProfile.Supervisor;
                        driverInterviewProfiledb.USDOT = driverInterviewProfile.USDOT;
                        driverInterviewProfiledb.CDLNonCDL = driverInterviewProfile.CDLNonCDL;
                        driverInterviewProfiledb.IsSubmitted = driverInterviewProfile.IsSubmitted;
                        uow.DriverInterviewProfileRepository.Insert(driverInterviewProfiledb);
                        uow.Save();

                        if (driverInterviewProfile.DriverCargos != null)
                        {
                            foreach (DriverVehicleCargoEntity drivercargo in driverInterviewProfile.DriverCargos)
                            {
                                DriverVehicleCargo driverVehicleCargodb = new DriverVehicleCargo();
                                driverVehicleCargodb.DriverVehicleID = driverInterviewProfiledb.DriverInterviewID;
                                driverVehicleCargodb.CargoCarriedName = drivercargo.CargoCarriedName;
                                uow.DriverVehicleCargoRepository.Insert(driverVehicleCargodb);
                                uow.Save();
                            }
                        }

                        DriverVehicle driverVehicledb = new DriverVehicle();
                        driverVehicledb.OrderFormID = driverInterviewProfiledb.DriverInterviewID;
                        driverVehicledb.DriverVehicleInfo = driverInterviewProfile.DriverVehicle.DriverVehicleInfo;
                        driverVehicledb.GVW = driverInterviewProfile.DriverVehicle.GVW;
                        driverVehicledb.Make = driverInterviewProfile.DriverVehicle.Make;
                        driverVehicledb.Model = driverInterviewProfile.DriverVehicle.Model;
                        driverVehicledb.Year = driverInterviewProfile.DriverVehicle.Year;
                        uow.DriverVehicleRepository.Insert(driverVehicledb);
                        uow.Save();

                    }

                    isDriverProfileEdited = true;
                }
                catch
                {
                    isDriverProfileEdited = false;
                }
            }


            return isDriverProfileEdited;
        }

        public DriverInterviewProfileEntity GetDriverDataByInterviewProfileID(bool isSubmitted, int interviewprofileid)
        {
            DriverInterviewProfileEntity driverSale = new DriverInterviewProfileEntity();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                driverSale = uow.DriverInterviewProfileRepository.Get().Select(dv => new DriverInterviewProfileEntity
                {
                    CDLNonCDL = dv.CDLNonCDL,
                    Class = dv.Class,
                    IsSubmitted = isSubmitted,
                    Date = dv.Date,
                    DOB = dv.DOB,
                    OrderFormID = dv.OrderFormID,
                    DriverInterviewID = dv.DriverInterviewID,
                    DriverName = dv.DriverName,
                    EIN = dv.EIN,
                    Email = dv.Email,
                    ExpirationDate = dv.ExpirationDate,
                    LegalName = dv.LegalName,
                    LicenseNo = dv.LicenseNo,
                    Notes = dv.Notes,
                    Phone = dv.Phone,
                    SSN = dv.SSN,
                    StatusIssued = dv.StatusIssued,
                    Supervisor = dv.Supervisor,
                    USDOT = dv.USDOT,
                    DriverCargos = uow.DriverVehicleCargoRepository.Get().Where(x => x.DriverVehicleID == interviewprofileid).Select(p => new DriverVehicleCargoEntity { CargoCarriedName = p.CargoCarriedName, DriverVehicleID = p.DriverVehicleID, VehicleCargoID = p.VehicleCargoID }).ToList(),
                    DriverServices = uow.DriverServiceRepository.Get().Join(uow.DocumentMasterRepository.Get(), msd => msd.ServiceID, dms => dms.DocumentID, (msd, dms) => new { msd, dms })
                        .Select(p => new DriverServiceEntity { DriverServiceID = p.msd.DriverServiceID, ServiceID = (int)p.msd.ServiceID, DriverInterviewProfileID = p.msd.DriverInterviewProfileID, ServiceName = p.dms.DocumentName, ServicePrice = p.dms.Description })
                        .Where(x => x.DriverInterviewProfileID == interviewprofileid).ToList(),
                    DriverVehicle = uow.DriverVehicleRepository.Get().Where(x => x.OrderFormID == interviewprofileid).Select(p => new DriverVehicleEntity { DriverVehicleInfo = p.DriverVehicleInfo, GVW = p.GVW, Make = p.Make, Model = p.Model, OrderFormID = p.OrderFormID, Year = p.Year }).FirstOrDefault(),
                }).Where(x => x.DriverInterviewID == interviewprofileid && x.IsSubmitted == isSubmitted).FirstOrDefault();
            }
            return driverSale;
        }

        public bool DeleteUSDotSale(int USDOTSaleID)
        {
            bool isDriverProfileDeleted = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {

                    OrderForm orderFormdb = uow.OrderFormRepository.Get().Where(x => x.OrderFormID == USDOTSaleID).FirstOrDefault();
                    uow.OrderFormRepository.Delete(orderFormdb);
                    uow.Save();


                    ProfileCard profileCarddb = uow.ProfileCardRepository.Get().Where(x => x.OrderFormID == USDOTSaleID).FirstOrDefault();
                    uow.ProfileCardRepository.Delete(profileCarddb);
                    uow.Save();

                    List<DriverService> usDotServiceTemp = uow.DriverServiceRepository.Get().Where(x => x.DriverInterviewProfileID == orderFormdb.OrderFormID).ToList();
                    foreach (DriverService service in usDotServiceTemp)
                    {
                        uow.DriverServiceRepository.Delete(service);
                        uow.Save();
                    }

                    List<DriverInterviewProfile> usDotDriverInterviewProfileTemp = uow.DriverInterviewProfileRepository.Get().Where(x => x.OrderFormID == USDOTSaleID).ToList();
                    foreach (DriverInterviewProfile item in usDotDriverInterviewProfileTemp)
                    {
                        List<DriverVehicleCargo> usDotVehicleCargoTemp = uow.DriverVehicleCargoRepository.Get().Where(x => x.DriverVehicleID == item.DriverInterviewID).ToList();
                        foreach (DriverVehicleCargo vehicleCargo in usDotVehicleCargoTemp)
                        {
                            uow.DriverVehicleCargoRepository.Delete(vehicleCargo);
                            uow.Save();
                        }

                        List<DriverVehicle> usDotVehicleTemp = uow.DriverVehicleRepository.Get().Where(x => x.OrderFormID == item.DriverInterviewID).ToList();
                        foreach (DriverVehicle vehicleCargo in usDotVehicleTemp)
                        {
                            uow.DriverVehicleRepository.Delete(vehicleCargo);
                            uow.Save();
                        }

                        uow.DriverInterviewProfileRepository.Delete(item);
                        uow.Save();
                    }

                    isDriverProfileDeleted = true;
                }
                catch
                {
                    isDriverProfileDeleted = false;
                }
            }


            return isDriverProfileDeleted;
        }

        public DriverSaleEntity GetSalesByOrderID(bool isSubmitted, string dotno)
        {
            DriverSaleEntity driverSale = new DriverSaleEntity();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                driverSale.orderForm = uow.OrderFormRepository.Get().Select(of => new OrderFormEntity
                {
                    BillingAddress = of.BillingAddress,
                    CA = of.CA,
                    CompanyType = of.CompanyType,
                    ComplianceSupervisor = of.ComplianceSupervisor,
                    DateTime = of.DateTime,
                    DBA = of.DBA,
                    DriverPhone = of.DriverPhone,
                    Email = of.Email,
                    LegalName = of.LegalName,
                    IsSubmitted = of.IsSubmitted,
                    Name = of.Name,
                    NameOnCard = of.NameOnCard,
                    OrderFormID = of.OrderFormID,
                    PhysicalAddress = of.PhysicalAddress,
                    USDot = of.USDot,
                    DOTPinNo = of.DOTPinNo,
                    ComplianceUserID = of.ComplianceUserID,
                    SaleID = of.SaleID
                }).Where(x => x.IsSubmitted == isSubmitted && x.USDot == dotno).FirstOrDefault();

                driverSale.profileCard = uow.ProfileCardRepository.Get().Select(pc => new ProfileCardEntity
                {
                    CardType = pc.CardType,
                    CorDC = pc.CorDC,
                    CVC = pc.CVC,
                    Expiration = pc.Expiration,
                    IsSubmitted = pc.IsSubmitted,
                    OrderFormID = pc.OrderFormID,
                    ProfileCardInfo = pc.ProfileCardInfo
                }).Where(x => x.IsSubmitted == isSubmitted && x.OrderFormID == driverSale.orderForm.OrderFormID).FirstOrDefault();

                driverSale.driverServices = uow.DriverServiceRepository.Get().Join(uow.DocumentMasterRepository.Get(), msd => msd.ServiceID, dms => dms.DocumentID, (msd, dms) => new { msd, dms })
                        .Select(p => new DriverServiceEntity { DriverServiceID = p.msd.DriverServiceID, ServiceID = (int)p.msd.ServiceID, DriverInterviewProfileID = p.msd.DriverInterviewProfileID, ServiceName = p.dms.DocumentName, ServicePrice = p.dms.Description })
                        .Where(x => x.DriverInterviewProfileID == driverSale.orderForm.OrderFormID).ToList();

                driverSale.driverInterviewProfiles = uow.DriverInterviewProfileRepository.Get().Select(dv => new DriverInterviewProfileEntity
                {
                    CDLNonCDL = dv.CDLNonCDL,
                    Class = dv.Class,
                    IsSubmitted = isSubmitted,
                    Date = dv.Date,
                    DOB = dv.DOB,
                    OrderFormID = dv.OrderFormID,
                    DriverInterviewID = dv.DriverInterviewID,
                    DriverName = dv.DriverName,
                    EIN = dv.EIN,
                    Email = dv.Email,
                    ExpirationDate = dv.ExpirationDate,
                    LegalName = dv.LegalName,
                    LicenseNo = dv.LicenseNo,
                    Notes = dv.Notes,
                    Phone = dv.Phone,
                    SSN = dv.SSN,
                    StatusIssued = dv.StatusIssued,
                    Supervisor = dv.Supervisor,
                    USDOT = dv.USDOT,
                    DriverCargos = uow.DriverVehicleCargoRepository.Get().Where(x => x.DriverVehicleID == dv.DriverInterviewID).Select(p => new DriverVehicleCargoEntity { CargoCarriedName = p.CargoCarriedName, DriverVehicleID = p.DriverVehicleID, VehicleCargoID = p.VehicleCargoID }).ToList(),

                    DriverVehicle = uow.DriverVehicleRepository.Get().Where(x => x.DriverVehicleInfo == dv.DriverInterviewID).Select(p => new DriverVehicleEntity { DriverVehicleInfo = p.DriverVehicleInfo, GVW = p.GVW, Make = p.Make, Model = p.Model, OrderFormID = p.OrderFormID, Year = p.Year }).FirstOrDefault(),
                    listDriverVehicle = uow.DriverVehicleRepository.Get().Where(x => x.DriverVehicleInfo == dv.DriverInterviewID).Select(p => new DriverVehicleEntity { DriverVehicleInfo = p.DriverVehicleInfo, GVW = p.GVW, Make = p.Make, Model = p.Model, OrderFormID = p.OrderFormID, Year = p.Year }).ToList(),
                }).Where(x => x.OrderFormID == driverSale.orderForm.OrderFormID && x.IsSubmitted == isSubmitted).ToList();
            }
            return driverSale;
        }
    }
}
