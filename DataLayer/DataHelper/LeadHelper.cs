using DataLayer.Helper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.DataHelper
{
    public class LeadHelper
    {

        DataLayer.UnitOfWork.UnitOfWork uow = null;

        public bool AddLead(LeadData lead)
        {
            bool isSalesAdded = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    Lead leaddb = new Lead();
                    leaddb.BusinessName = lead.BusinessName;
                    leaddb.ComplianceAgent = lead.ComplianceAgent;
                    leaddb.ContactName = lead.ContactName;
                    leaddb.Date = DateTime.Now.Date.ToShortDateString();
                    leaddb.DOTNo = lead.DOTNo;
                    leaddb.Email = lead.Email;
                    leaddb.PhoneNoForContact = lead.PhoneNoForContact;
                    leaddb.ServiceDiscussed = lead.ServiceDiscussed;
                    leaddb.SalesPersonID = lead.SalesPersonID;
                    uow.LeadRepository.Insert(leaddb);
                    uow.Save();
                    LeadNote leadNote = new LeadNote();
                    leadNote.LeadID = leaddb.LeadID;
                    leadNote.Note = lead.Notes;
                    leadNote.Timeline = lead.TimeLine;
                    leadNote.NoteLeftAt = DateTimeJavaScript.GetCurrentTime().ToString();
                    uow.LeadNoteRepository.Insert(leadNote);
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

        public bool EditLead(LeadData lead)
        {
            bool isSalesEdited = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    Lead leaddb = uow.LeadRepository.Get().Where(x => x.LeadID == lead.LeadID).FirstOrDefault();
                    leaddb.BusinessName = lead.BusinessName;
                    leaddb.ComplianceAgent = lead.ComplianceAgent;
                    leaddb.ContactName = lead.ContactName;
                    leaddb.Date = DateTime.Now.Date.ToShortDateString();
                    leaddb.DOTNo = lead.DOTNo;
                    leaddb.Email = lead.Email;
                    leaddb.PhoneNoForContact = lead.PhoneNoForContact;
                    leaddb.ServiceDiscussed = lead.ServiceDiscussed;
                    leaddb.SalesPersonID = lead.SalesPersonID;
                    uow.LeadRepository.Update(leaddb);
                    uow.Save();
                    if (!String.IsNullOrEmpty(lead.Notes) && !String.IsNullOrEmpty(lead.TimeLine))
                    {
                        LeadNote leadNote = new LeadNote();
                        leadNote.LeadID = leaddb.LeadID;
                        leadNote.Note = lead.Notes;
                        leadNote.Timeline = lead.TimeLine;
                        leadNote.NoteLeftAt = DateTimeJavaScript.GetCurrentTime().ToString();
                        uow.LeadNoteRepository.Insert(leadNote);
                        uow.Save();
                    }
                    isSalesEdited = true;
                }
                catch
                {
                    isSalesEdited = false;
                }
            }

            return isSalesEdited;
        }

        public bool DeleteLead(int leadid)
        {
            bool isSalesDeleted = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    uow.LeadRepository.Delete(leadid);
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

        public List<LeadNoteEntity> GetAllLeadNotes(int leadID)
        {
            List<LeadNoteEntity> lstLeadNotes = new List<LeadNoteEntity>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstLeadNotes = uow.LeadNoteRepository.Get().Where(p => p.LeadID == leadID).Select(usd => new LeadNoteEntity
                    {
                        NoteLeftAt = usd.NoteLeftAt,
                        Note = usd.Note,
                        LeadNoteID = usd.LeadNoteID,
                        LeadID = usd.LeadID,
                        Timeline = usd.Timeline
                    }).ToList();
                }
                catch
                {

                }
            }
            return lstLeadNotes;
        }

        public List<LeadData> GetAllLeads()
        {
            List<LeadData> lstLeads = new List<LeadData>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstLeads = uow.LeadRepository.Get().Select(usd => new LeadData
                    {
                        BusinessName = usd.BusinessName,
                        ContactName = usd.ContactName,
                        Date = usd.Date,
                        DOTNo = usd.DOTNo,
                        Email = usd.Email,
                        LeadID = usd.LeadID,
                        PhoneNoForContact = usd.PhoneNoForContact,
                        SalesPersonID = usd.SalesPersonID,
                        ServiceDiscussed = usd.ServiceDiscussed
                    }).ToList();
                }
                catch
                {

                }
            }
            return lstLeads;
        }

        public List<LeadData> GetLeadsByUserID(int userid)
        {
            List<LeadData> lstLeads = new List<LeadData>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstLeads = uow.LeadRepository.Get().Where(x => x.SalesPersonID == userid).Select(usd => new LeadData
                    {
                        BusinessName = usd.BusinessName,
                        ContactName = usd.ContactName,
                        Date = usd.Date,
                        DOTNo = usd.DOTNo,
                        Email = usd.Email,
                        LeadID = usd.LeadID,
                        PhoneNoForContact = usd.PhoneNoForContact,
                        SalesPersonID = usd.SalesPersonID,
                        ServiceDiscussed = usd.ServiceDiscussed
                    }).ToList();
                }
                catch
                {

                }
            }
            return lstLeads;
        }

        public LeadData GetLeadsByDOTNo(string dotno)
        {
            LeadData lstLeads = new LeadData();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstLeads = uow.LeadRepository.Get().Where(x => x.DOTNo.Equals(dotno)).Select(usd => new LeadData
                    {
                        BusinessName = usd.BusinessName,
                        ContactName = usd.ContactName,
                        Date = usd.Date,
                        DOTNo = usd.DOTNo,
                        Email = usd.Email,
                        LeadID = usd.LeadID,
                        PhoneNoForContact = usd.PhoneNoForContact,
                        SalesPersonID = usd.SalesPersonID,
                        ServiceDiscussed = usd.ServiceDiscussed
                    }).FirstOrDefault();
                }
                catch
                {

                }
            }
            return lstLeads;
        }

        public LeadData GetLeadsByLeadID(int leadID)
        {
            LeadData lstLeads = new LeadData();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstLeads = uow.LeadRepository.Get().Where(x => x.LeadID == leadID).Select(usd => new LeadData
                    {
                        BusinessName = usd.BusinessName,
                        ContactName = usd.ContactName,
                        Date = usd.Date,
                        DOTNo = usd.DOTNo,
                        Email = usd.Email,
                        LeadID = usd.LeadID,
                        PhoneNoForContact = usd.PhoneNoForContact,
                        SalesPersonID = usd.SalesPersonID,
                        ServiceDiscussed = usd.ServiceDiscussed,
                        ComplianceAgent = usd.ComplianceAgent
                    }).FirstOrDefault();
                }
                catch
                {

                }
            }
            return lstLeads;
        }

    }
}
