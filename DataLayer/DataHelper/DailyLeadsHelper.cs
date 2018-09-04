using DataLayer.Helper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.DataHelper
{
    public class DailyLeadsHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;

        public bool AddBulkLeads(List<DailyLeadEntity> leads)
        {
            bool isSalesAdded = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    foreach (DailyLeadEntity leaddb in leads)
                    {
                        DailyLead lead = new DailyLead();
                        lead.AuthForHire = leaddb.AuthForHire;
                        lead.DailyLeadID = leaddb.DailyLeadID;
                        lead.DateFiled = leaddb.DateFiled;
                        lead.DOTNumber = leaddb.DOTNumber;
                        lead.Drivers = leaddb.Drivers;
                        lead.Interstate = leaddb.Interstate;
                        lead.LeadDocID = leaddb.LeadDocID;
                        lead.LegalName = leaddb.LegalName;
                        lead.MailingAddress = leaddb.MailingAddress;
                        lead.OperatingStatus = leaddb.OperatingStatus;
                        lead.PhoneNo = leaddb.PhoneNo;
                        lead.PhysicalAddress = leaddb.PhysicalAddress;
                        lead.PowerUnits = leaddb.PowerUnits;
                        lead.Status = leaddb.Status;
                        lead.TimeZone = leaddb.TimeZone;
                        lead.ZipCode = leaddb.ZipCode;
                        lead.SavedOn = DateTimeJavaScript.GetCurrentTime().ToString();
                        uow.DailyLeadRepository.Insert(lead);
                    }
                    uow.Save();
                    isSalesAdded = true;
                }
                catch
                {
                    isSalesAdded = false;
                }
            }

            return isSalesAdded;
        }

        public List<DailyLeadEntity> GetLeadRecordsByUserID(int userID)
        {
            List<DailyLeadEntity> dailyLeadRecords = new List<DailyLeadEntity>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    dailyLeadRecords = uow.DailyLeadRepository.Get().Join(uow.LeadDocRepository.Get(), dl => dl.LeadDocID, ld => ld.LeadDocID, (dl, ld) => new { dl, ld })
                        .Join(uow.ComplianceUserRepository.Get(), us => Convert.ToInt32(us.ld.UploadedFor), a => a.UserID, (us, a) => new { us, a }).Where(x => x.a.UserID == userID)
                        .Select(po => new DailyLeadEntity
                        {
                            AuthForHire = po.us.dl.AuthForHire,
                            DailyLeadID = po.us.dl.DailyLeadID,
                            DateFiled = po.us.dl.DateFiled,
                            DOTNumber = po.us.dl.DOTNumber,
                            Drivers = po.us.dl.Drivers,
                            Interstate = po.us.dl.Interstate,
                            LeadDocID = po.us.dl.LeadDocID,
                            LegalName = po.us.dl.LegalName,
                            MailingAddress = po.us.dl.MailingAddress,
                            OperatingStatus = po.us.dl.OperatingStatus,
                            PhoneNo = po.us.dl.PhoneNo,
                            PhysicalAddress = po.us.dl.PhysicalAddress,
                            PowerUnits = po.us.dl.PowerUnits,
                            Status = po.us.dl.Status,
                            TimeZone = po.us.dl.TimeZone,
                            ZipCode = po.us.dl.ZipCode,
                            SavedOn = po.us.dl.SavedOn
                            //}).OrderByDescending(x => Convert.ToDateTime(x.SavedOn)).ToList();
                        }).ToList();
                }
                catch
                {

                }
            }
            return dailyLeadRecords;
        }

        public List<DailyLeadEntity> GetLeadRecordsByUserIDDesc(int userID)
        {
            List<DailyLeadEntity> dailyLeadRecords = new List<DailyLeadEntity>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    dailyLeadRecords = uow.DailyLeadRepository.Get().Join(uow.LeadDocRepository.Get(), dl => dl.LeadDocID, ld => ld.LeadDocID, (dl, ld) => new { dl, ld })
                        .Join(uow.ComplianceUserRepository.Get(), us => Convert.ToInt32(us.ld.UploadedFor), a => a.UserID, (us, a) => new { us, a }).Where(x => x.a.UserID == userID)
                        .Select(po => new DailyLeadEntity
                        {
                            AuthForHire = po.us.dl.AuthForHire,
                            DailyLeadID = po.us.dl.DailyLeadID,
                            DateFiled = po.us.dl.DateFiled,
                            DOTNumber = po.us.dl.DOTNumber,
                            Drivers = po.us.dl.Drivers,
                            Interstate = po.us.dl.Interstate,
                            LeadDocID = po.us.dl.LeadDocID,
                            LegalName = po.us.dl.LegalName,
                            MailingAddress = po.us.dl.MailingAddress,
                            OperatingStatus = po.us.dl.OperatingStatus,
                            PhoneNo = po.us.dl.PhoneNo,
                            PhysicalAddress = po.us.dl.PhysicalAddress,
                            PowerUnits = po.us.dl.PowerUnits,
                            Status = po.us.dl.Status,
                            TimeZone = po.us.dl.TimeZone,
                            ZipCode = po.us.dl.ZipCode,
                            SavedOn = po.us.dl.SavedOn
                        }).OrderByDescending(x => Convert.ToDateTime(x.SavedOn)).ToList();
                    //}).ToList();
                }
                catch
                {

                }
            }
            return dailyLeadRecords;
        }

        public List<DailyLeadEntity> GetAllLeads()
        {
            List<DailyLeadEntity> dailyLeadRecords = new List<DailyLeadEntity>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    dailyLeadRecords = uow.DailyLeadRepository.Get().Where(x => Convert.ToDateTime(x.SavedOn) >= DateTime.Now.AddDays(-1) && Convert.ToDateTime(x.SavedOn) < DateTime.Now)
                        .Select(po => new DailyLeadEntity
                        {
                            AuthForHire = po.AuthForHire,
                            DailyLeadID = po.DailyLeadID,
                            DateFiled = po.DateFiled,
                            DOTNumber = po.DOTNumber,
                            Drivers = po.Drivers,
                            Interstate = po.Interstate,
                            LeadDocID = po.LeadDocID,
                            LegalName = po.LegalName,
                            MailingAddress = po.MailingAddress,
                            OperatingStatus = po.OperatingStatus,
                            PhoneNo = po.PhoneNo,
                            PhysicalAddress = po.PhysicalAddress,
                            PowerUnits = po.PowerUnits,
                            Status = po.Status,
                            TimeZone = po.TimeZone,
                            ZipCode = po.ZipCode,
                            SavedOn = po.SavedOn
                        }).OrderByDescending(x => Convert.ToDateTime(x.SavedOn)).ToList();
                    //}).ToList();
                }
                catch
                {

                }
            }
            return dailyLeadRecords;
        }

        public bool UpdateLeadStatus(int leadid, string status)
        {
            bool isSalesUpdated = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    DailyLead lead = uow.DailyLeadRepository.Get().Where(x => x.DailyLeadID == leadid).FirstOrDefault();
                    lead.Status = status;
                    uow.DailyLeadRepository.Update(lead);
                    uow.Save();
                    isSalesUpdated = true;
                }
                catch
                {
                    isSalesUpdated = false;
                }
            }

            return isSalesUpdated;
        }

        public bool DeleteLead(int leadid)
        {
            bool isSalesDeleted = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    uow.DailyLeadRepository.Delete(leadid);
                    uow.Save();
                    isSalesDeleted = true;
                }
                catch
                {
                    isSalesDeleted = false;
                }
            }

            return isSalesDeleted;
        }

        public DailyLeadEntity GetLeadRecordsByLeadID(int leadID)
        {
            DailyLeadEntity dailyLeadRecord = new DailyLeadEntity();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    dailyLeadRecord = uow.DailyLeadRepository.Get().Where(x => x.DailyLeadID == leadID).Select(po => new DailyLeadEntity
                        {
                            AuthForHire = po.AuthForHire,
                            DailyLeadID = po.DailyLeadID,
                            DateFiled = po.DateFiled,
                            DOTNumber = po.DOTNumber,
                            Drivers = po.Drivers,
                            Interstate = po.Interstate,
                            LeadDocID = po.LeadDocID,
                            LegalName = po.LegalName,
                            MailingAddress = po.MailingAddress,
                            OperatingStatus = po.OperatingStatus,
                            PhoneNo = po.PhoneNo,
                            PhysicalAddress = po.PhysicalAddress,
                            PowerUnits = po.PowerUnits,
                            Status = po.Status,
                            TimeZone = po.TimeZone,
                            ZipCode = po.ZipCode,
                            SavedOn = po.SavedOn
                            //}).OrderByDescending(x => Convert.ToDateTime(x.SavedOn)).ToList();
                        }).FirstOrDefault();
                }
                catch
                {

                }
            }
            return dailyLeadRecord;
        }

        public DailyLeadEntity GetLeadRecordsByDOTNo(string DOTNo)
        {
            DailyLeadEntity dailyLeadRecord = new DailyLeadEntity();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    dailyLeadRecord = uow.DailyLeadRepository.Get().Where(x => x.DOTNumber.Equals(DOTNo)).Select(po => new DailyLeadEntity
                    {
                        AuthForHire = po.AuthForHire,
                        DailyLeadID = po.DailyLeadID,
                        DateFiled = po.DateFiled,
                        DOTNumber = po.DOTNumber,
                        Drivers = po.Drivers,
                        Interstate = po.Interstate,
                        LeadDocID = po.LeadDocID,
                        LegalName = po.LegalName,
                        MailingAddress = po.MailingAddress,
                        OperatingStatus = po.OperatingStatus,
                        PhoneNo = po.PhoneNo,
                        PhysicalAddress = po.PhysicalAddress,
                        PowerUnits = po.PowerUnits,
                        Status = po.Status,
                        TimeZone = po.TimeZone,
                        ZipCode = po.ZipCode,
                        SavedOn = po.SavedOn
                        //}).OrderByDescending(x => Convert.ToDateTime(x.SavedOn)).ToList();
                    }).FirstOrDefault();
                }
                catch
                {

                }
            }
            return dailyLeadRecord;
        }
    }
}
