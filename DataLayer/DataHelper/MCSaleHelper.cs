using DataLayer.Helper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.DataHelper
{
    public class MCSaleHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;

        public bool AddMCSales(MCSaleEntity mcSale)
        {
            bool isAdded = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    if (mcSale.saleType == SaleType.Submitted)
                    {

                        MCSale mcSaledb = new MCSale();
                        mcSaledb.AddressOnCard = mcSale.AddressOnCard;
                        mcSaledb.DotNo = mcSale.DotNo;
                        mcSaledb.Email = mcSale.Email;
                        mcSaledb.MCID = mcSale.MCID;
                        mcSaledb.MCNo = mcSale.MCNo;
                        mcSaledb.NameOnCard = mcSale.NameOnCard;
                        mcSaledb.CardNo = mcSale.CardNo;
                        mcSaledb.PhoneNo = mcSale.PhoneNo;
                        mcSaledb.PhysicalAddress = mcSale.PhysicalAddress;
                        mcSaledb.SoldAt = DateTimeJavaScript.GetCurrentTime().ToString();
                        mcSaledb.SalesPersonID = mcSale.SalesPersonID;
                        mcSaledb.CardType = mcSale.CardType;
                        mcSaledb.CVC = mcSale.CVC;
                        mcSaledb.MCSaleNo = mcSale.MCSaleNo;
                        mcSaledb.ExpirationDate = mcSale.ExpirationDate;
                        mcSaledb.LegalName = mcSale.LegalName;
                        mcSaledb.DBA = mcSale.DBA;
                        mcSaledb.DotPin = mcSale.DotPin;
                        uow.MCSaleRepository.Insert(mcSaledb);
                        uow.Save();

                        foreach (MCServiceSaleEntity item in mcSale.serviceSaleData)
                        {
                            MCServiceSale mcServiceSaledb = new MCServiceSale();
                            mcServiceSaledb.MCSaleID = mcSaledb.MCID;
                            mcServiceSaledb.ServiceID = item.ServiceID;
                            uow.MCServiceSaleRepository.Insert(mcServiceSaledb);
                            uow.Save();
                        }
                        if (mcSale.MCID == 0)
                        {
                            mcSale.MCID = mcSaledb.MCID;
                        }
                        DeleteTempSale(mcSale.MCID);
                    }
                    else
                        if (mcSale.saleType == SaleType.Saved)
                        {
                            MCSaleTemp mcSaleTempdb = new MCSaleTemp();
                            mcSaleTempdb.AddressOnCard = mcSale.AddressOnCard;
                            mcSaleTempdb.DotNo = mcSale.DotNo;
                            mcSaleTempdb.Email = mcSale.Email;
                            mcSaleTempdb.MCID = mcSale.MCID;
                            mcSaleTempdb.MCNo = mcSale.MCNo;
                            mcSaleTempdb.PhoneNo = mcSale.PhoneNo;
                            mcSaleTempdb.CardNo = mcSale.CardNo;
                            mcSaleTempdb.NameOnCard = mcSale.NameOnCard;
                            mcSaleTempdb.PhysicalAddress = mcSale.PhysicalAddress;
                            mcSaleTempdb.SalesPersonID = mcSale.SalesPersonID;
                            mcSaleTempdb.CardType = mcSale.CardType;
                            mcSaleTempdb.CVC = mcSale.CVC;
                            mcSaleTempdb.MCSaleNo = mcSale.MCSaleNo;
                            mcSaleTempdb.ExpirationDate = mcSale.ExpirationDate;
                            mcSaleTempdb.LegalName = mcSale.LegalName;
                            mcSaleTempdb.DBA = mcSale.DBA;
                            mcSaleTempdb.DotPin = mcSale.DotPin;
                            uow.MCSaleTempRepository.Insert(mcSaleTempdb);
                            uow.Save();

                            foreach (MCServiceSaleEntity item in mcSale.serviceSaleData)
                            {
                                MCServiceSaleTemp mcServiceSaledb = new MCServiceSaleTemp();
                                mcServiceSaledb.MCSaleID = mcSaleTempdb.MCID;
                                mcServiceSaledb.ServiceID = item.ServiceID;
                                uow.MCServiceSaleTempRepository.Insert(mcServiceSaledb);
                                uow.Save();
                            }
                        }
                    isAdded = true;
                }
                catch
                {
                    isAdded = false;
                }
            }

            return isAdded;
        }

        public bool EditTempMCSales(MCSaleEntity mcSale)
        {
            bool isEdited = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    MCSaleTemp mcSaledb = new MCSaleTemp();
                    mcSaledb = uow.MCSaleTempRepository.Get().Where(mcdata => mcdata.MCID == mcSale.MCID).FirstOrDefault();
                    mcSaledb.AddressOnCard = mcSale.AddressOnCard;
                    mcSaledb.DotNo = mcSale.DotNo;
                    mcSaledb.Email = mcSale.Email;
                    mcSaledb.MCID = mcSale.MCID;
                    mcSaledb.MCNo = mcSale.MCNo;
                    mcSaledb.PhoneNo = mcSale.PhoneNo;
                    mcSaledb.CardNo = mcSale.CardNo;
                    mcSaledb.NameOnCard = mcSale.NameOnCard;
                    mcSaledb.PhysicalAddress = mcSale.PhysicalAddress;
                    mcSaledb.CardType = mcSale.CardType;
                    mcSaledb.CVC = mcSale.CVC;
                    mcSaledb.ExpirationDate = mcSale.ExpirationDate;
                    mcSaledb.MCSaleNo = mcSale.MCSaleNo;
                    mcSaledb.LegalName = mcSale.LegalName;
                    mcSaledb.DBA = mcSale.DBA;
                    mcSaledb.DotPin = mcSale.DotPin;
                    uow.MCSaleTempRepository.Update(mcSaledb);
                    uow.Save();

                    List<MCServiceSaleTemp> mcTemp = uow.MCServiceSaleTempRepository.Get().Where(x => x.MCSaleID == mcSale.MCID).ToList();
                    foreach (MCServiceSaleTemp item in mcTemp)
                    {
                        uow.MCServiceSaleTempRepository.Delete(item);
                        uow.Save();
                    }

                    foreach (MCServiceSaleEntity item in mcSale.serviceSaleData)
                    {
                        MCServiceSaleTemp mcServiceSaledb = new MCServiceSaleTemp();
                        mcServiceSaledb.MCSaleID = mcSaledb.MCID;
                        mcServiceSaledb.ServiceID = item.ServiceID;
                        uow.MCServiceSaleTempRepository.Insert(mcServiceSaledb);
                        uow.Save();
                    }

                    isEdited = true;
                }
                catch
                {
                    isEdited = false;
                }
            }

            return isEdited;
        }

        public bool EditMCSales(MCSaleEntity mcSale)
        {
            bool isEdited = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    MCSale mcSaledb = new MCSale();
                    mcSaledb = uow.MCSaleRepository.Get().Where(mcdata => mcdata.MCID == mcSale.MCID).FirstOrDefault();
                    mcSaledb.AddressOnCard = mcSale.AddressOnCard;
                    mcSaledb.DotNo = mcSale.DotNo;
                    mcSaledb.Email = mcSale.Email;
                    mcSaledb.MCID = mcSale.MCID;
                    mcSaledb.MCNo = mcSale.MCNo;
                    mcSaledb.CardNo = mcSale.CardNo;
                    mcSaledb.PhoneNo = mcSale.PhoneNo;
                    mcSaledb.NameOnCard = mcSale.NameOnCard;
                    mcSaledb.PhysicalAddress = mcSale.PhysicalAddress;
                    mcSaledb.CardType = mcSale.CardType;
                    mcSaledb.CVC = mcSale.CVC;
                    mcSaledb.MCSaleNo = mcSale.MCSaleNo;
                    mcSaledb.ExpirationDate = mcSale.ExpirationDate;
                    mcSaledb.LegalName = mcSale.LegalName;
                    mcSaledb.DBA = mcSale.DBA;
                    mcSaledb.DotPin = mcSale.DotPin;
                    uow.MCSaleRepository.Update(mcSaledb);
                    uow.Save();

                    List<MCServiceSale> mcTemp = uow.MCServiceSaleRepository.Get().Where(x => x.MCSaleID == mcSale.MCID).ToList();
                    foreach (MCServiceSale item in mcTemp)
                    {
                        uow.MCServiceSaleRepository.Delete(item);
                        uow.Save();
                    }

                    foreach (MCServiceSaleEntity item in mcSale.serviceSaleData)
                    {
                        MCServiceSale mcServiceSaledb = new MCServiceSale();
                        mcServiceSaledb.MCSaleID = mcSaledb.MCID;
                        mcServiceSaledb.ServiceID = item.ServiceID;
                        uow.MCServiceSaleRepository.Insert(mcServiceSaledb);
                        uow.Save();
                    }

                    isEdited = true;
                }
                catch
                {
                    isEdited = false;
                }
            }

            return isEdited;
        }

        public List<MCSaleEntity> GetAllMCSalesBySalesPerson(int salesPersonID)
        {
            List<MCSaleEntity> lstMCSales = new List<MCSaleEntity>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstMCSales = uow.MCSaleRepository.Get().Select(sale => new MCSaleEntity
                    {
                        AddressOnCard = sale.AddressOnCard,
                        DotNo = sale.DotNo,
                        Email = sale.Email,
                        MCID = sale.MCID,
                        MCNo = sale.MCNo,
                        CardNo = sale.CardNo,
                        PhoneNo = sale.PhoneNo,
                        NameOnCard = sale.NameOnCard,
                        SalesPersonID = sale.SalesPersonID,
                        PhysicalAddress = sale.PhysicalAddress,
                        SoldAt = sale.SoldAt,
                        ExpirationDate = sale.ExpirationDate,
                        CardType = sale.CardType,
                        CVC = sale.CVC,
                        MCSaleNo = sale.MCSaleNo,
                        LegalName = sale.LegalName,
                        DBA = sale.DBA,
                        DotPin = sale.DotPin,
                        serviceSaleData = uow.MCServiceSaleRepository.Get().Join(uow.DocumentMasterRepository.Get(), msd => msd.ServiceID, dms => dms.DocumentID, (msd, dms) => new { msd, dms })
                        .Select(p => new MCServiceSaleEntity { MCSaleID = p.msd.MCSaleID, MCServiceID = p.msd.MCServiceID, ServiceID = p.msd.ServiceID, ServiceName = p.dms.DocumentName, ServicePrice = p.dms.Description })
                        .Where(x => x.MCSaleID == sale.MCID).ToList()
                    }).OrderByDescending(p => p.MCID).Where(p => p.SalesPersonID == salesPersonID).ToList();
                }
                catch
                {

                }
            }
            return lstMCSales;
        }

        public List<MCSaleEntity> GetAllTempMCSales(int salesPersonID)
        {
            List<MCSaleEntity> lstMCSales = new List<MCSaleEntity>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstMCSales = uow.MCSaleTempRepository.Get().Select(sale => new MCSaleEntity
                    {
                        AddressOnCard = sale.AddressOnCard,
                        DotNo = sale.DotNo,
                        Email = sale.Email,
                        MCID = sale.MCID,
                        MCNo = sale.MCNo,
                        PhoneNo = sale.PhoneNo,
                        CardNo = sale.CardNo,
                        SalesPersonID = sale.SalesPersonID,
                        NameOnCard = sale.NameOnCard,
                        PhysicalAddress = sale.PhysicalAddress,
                        ExpirationDate = sale.ExpirationDate,
                        CardType = sale.CardType,
                        CVC = sale.CVC,
                        MCSaleNo = sale.MCSaleNo,
                        LegalName = sale.LegalName,
                        DBA = sale.DBA,
                        DotPin = sale.DotPin,
                        serviceSaleData = uow.MCServiceSaleTempRepository.Get().Join(uow.DocumentMasterRepository.Get(), msd => msd.ServiceID, dms => dms.DocumentID, (msd, dms) => new { msd, dms })
                        .Select(p => new MCServiceSaleEntity { MCSaleID = p.msd.MCSaleID, MCServiceID = p.msd.MCServiceID, ServiceID = p.msd.ServiceID, ServiceName = p.dms.DocumentName, ServicePrice = p.dms.Description })
                        .Where(x => x.MCSaleID == sale.MCID).ToList()
                    }).OrderByDescending(p => p.MCID).Where(p => p.SalesPersonID == p.SalesPersonID).ToList();
                }
                catch
                {

                }
            }
            return lstMCSales;
        }

        public List<MCSaleEntity> GetAllMCSales()
        {
            List<MCSaleEntity> lstMCSales = new List<MCSaleEntity>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstMCSales = uow.MCSaleRepository.Get().Select(sale => new MCSaleEntity
                    {
                        AddressOnCard = sale.AddressOnCard,
                        DotNo = sale.DotNo,
                        Email = sale.Email,
                        MCID = sale.MCID,
                        MCNo = sale.MCNo,
                        CardNo = sale.CardNo,
                        PhoneNo = sale.PhoneNo,
                        NameOnCard = sale.NameOnCard,
                        PhysicalAddress = sale.PhysicalAddress,
                        SoldAt = sale.SoldAt,
                        ExpirationDate = sale.ExpirationDate,
                        CardType = sale.CardType,
                        CVC = sale.CVC,
                        MCSaleNo = sale.MCSaleNo,
                        LegalName = sale.LegalName,
                        DBA = sale.DBA,
                        DotPin = sale.DotPin,
                        SalesPersonName = uow.ComplianceUserRepository.Get().Where(x => x.UserID == sale.SalesPersonID).FirstOrDefault().Name,
                        serviceSaleData = uow.MCServiceSaleRepository.Get().Join(uow.DocumentMasterRepository.Get(), msd => msd.ServiceID, dms => dms.DocumentID, (msd, dms) => new { msd, dms })
                        .Select(p => new MCServiceSaleEntity { MCSaleID = p.msd.MCSaleID, MCServiceID = p.msd.MCServiceID, ServiceID = p.msd.ServiceID, ServiceName = p.dms.DocumentName, ServicePrice = p.dms.Description })
                        .Where(x => x.MCSaleID == sale.MCID).ToList()
                    }).OrderByDescending(p => p.MCID).ToList();
                }
                catch
                {

                }
            }
            return lstMCSales;
        }

        public MCSaleEntity GetTempMCSale(int MCID)
        {
            MCSaleEntity MCSale = new MCSaleEntity();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    MCSale = uow.MCSaleTempRepository.Get().Select(sale => new MCSaleEntity
                    {
                        AddressOnCard = sale.AddressOnCard,
                        DotNo = sale.DotNo,
                        Email = sale.Email,
                        MCID = sale.MCID,
                        MCNo = sale.MCNo,
                        CardNo = sale.CardNo,
                        PhoneNo = sale.PhoneNo,
                        NameOnCard = sale.NameOnCard,
                        PhysicalAddress = sale.PhysicalAddress,
                        ExpirationDate = sale.ExpirationDate,
                        CardType = sale.CardType,
                        CVC = sale.CVC,
                        MCSaleNo = sale.MCSaleNo,
                        DBA = sale.DBA,
                        LegalName = sale.LegalName,
                        DotPin = sale.DotPin,
                        serviceSaleData = uow.MCServiceSaleTempRepository.Get().Join(uow.DocumentMasterRepository.Get(), msd => msd.ServiceID, dms => dms.DocumentID, (msd, dms) => new { msd, dms })
                        .Select(p => new MCServiceSaleEntity { MCSaleID = p.msd.MCSaleID, MCServiceID = p.msd.MCServiceID, ServiceID = p.msd.ServiceID, ServiceName = p.dms.DocumentName, ServicePrice = p.dms.Description })
                        .Where(x => x.MCSaleID == sale.MCID).ToList()
                    }).Where(p => p.MCID == MCID).FirstOrDefault();
                }
                catch
                {

                }
            }
            return MCSale;
        }

        public MCSaleEntity GetMCSale(int MCID)
        {
            MCSaleEntity MCSale = new MCSaleEntity();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    MCSale = uow.MCSaleRepository.Get().Select(sale => new MCSaleEntity
                    {
                        AddressOnCard = sale.AddressOnCard,
                        DotNo = sale.DotNo,
                        Email = sale.Email,
                        MCID = sale.MCID,
                        MCNo = sale.MCNo,
                        CardNo = sale.CardNo,
                        PhoneNo = sale.PhoneNo,
                        NameOnCard = sale.NameOnCard,
                        PhysicalAddress = sale.PhysicalAddress,
                        ExpirationDate = sale.ExpirationDate,
                        CardType = sale.CardType,
                        CVC = sale.CVC,
                        MCSaleNo = sale.MCSaleNo,
                        DBA = sale.DBA,
                        LegalName = sale.LegalName,
                        SalesPersonID = sale.SalesPersonID,
                        DotPin = sale.DotPin,
                        serviceSaleData = uow.MCServiceSaleRepository.Get().Join(uow.DocumentMasterRepository.Get(), msd => msd.ServiceID, dms => dms.DocumentID, (msd, dms) => new { msd, dms })
                        .Select(p => new MCServiceSaleEntity { MCSaleID = p.msd.MCSaleID, MCServiceID = p.msd.MCServiceID, ServiceID = p.msd.ServiceID, ServiceName = p.dms.DocumentName, ServicePrice = p.dms.Description })
                        .Where(x => x.MCSaleID == sale.MCID).ToList()
                    }).Where(p => p.MCID == MCID).FirstOrDefault();
                }
                catch
                {

                }
            }
            return MCSale;
        }

        public bool DeleteTempSale(int MCID)
        {
            bool isDeleted = false;
            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    MCSaleTemp sale = uow.MCSaleTempRepository.Get().Where(x => x.MCID == MCID).FirstOrDefault();
                    uow.MCSaleTempRepository.Delete(sale);
                    uow.Save();

                    List<MCServiceSaleTemp> mcTemp = uow.MCServiceSaleTempRepository.Get().Where(x => x.MCSaleID == MCID).ToList();
                    foreach (MCServiceSaleTemp item in mcTemp)
                    {
                        uow.MCServiceSaleTempRepository.Delete(item);
                        uow.Save();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return isDeleted;
        }

        public bool DeleteMCSale(int MCID)
        {
            bool isDeleted = false;
            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    MCSale sale = uow.MCSaleRepository.Get().Where(x => x.MCID == MCID).FirstOrDefault();
                    uow.MCSaleRepository.Delete(sale);
                    uow.Save();

                    List<MCServiceSale> mcTemp = uow.MCServiceSaleRepository.Get().Where(x => x.MCSaleID == MCID).ToList();
                    foreach (MCServiceSale item in mcTemp)
                    {
                        uow.MCServiceSaleRepository.Delete(item);
                        uow.Save();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return isDeleted;
        }

    }
}
