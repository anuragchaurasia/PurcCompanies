using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.DataHelper
{
    public class LeadDocumentHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;

        public int AddLeadDoc(LeadDocEntity leadDoc)
        {
            int docid = 0;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    LeadDoc leaddocdb = new LeadDoc();
                    leaddocdb.DocumentName = leadDoc.DocumentName;
                    leaddocdb.DocumentPath = leadDoc.DocumentPath;
                    leaddocdb.UploadDate = leadDoc.UploadDate;
                    leaddocdb.UploadedBy = leadDoc.UploadedBy;
                    leaddocdb.UploadedFor = leadDoc.UploadedFor;
                    uow.LeadDocRepository.Insert(leaddocdb);
                    uow.Save();
                    docid = leaddocdb.LeadDocID;
                }
                catch
                {
                    docid = 0;
                }
            }

            return docid;
        }

        public int CheckDoc(LeadDocEntity leadDoc)
        {
            int isDocAvailable = 0;
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    isDocAvailable = uow.LeadDocRepository.Get().Where(x => x.UploadedFor == leadDoc.UploadedFor && x.UploadDate == leadDoc.UploadDate).Select(x => x.LeadDocID).FirstOrDefault();
                }
                catch
                {
                    isDocAvailable = 0;
                }
            }
            return isDocAvailable;
        }

        public bool UpdateLeadDoc(LeadDocEntity leadDoc)
        {
            bool isDocUpdated = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    LeadDoc leaddocdb = uow.LeadDocRepository.Get().Where(x => x.LeadDocID == leadDoc.LeadDocID).FirstOrDefault();
                    leaddocdb.DocumentName = leadDoc.DocumentName;
                    leaddocdb.DocumentPath = leadDoc.DocumentPath;
                    leaddocdb.UploadDate = leadDoc.UploadDate;
                    leaddocdb.UploadedBy = leadDoc.UploadedBy;
                    leaddocdb.UploadedFor = leadDoc.UploadedFor;
                    uow.LeadDocRepository.Update(leaddocdb);
                    uow.Save();
                    isDocUpdated = true;
                }
                catch
                {
                    isDocUpdated = false;
                }
            }

            return isDocUpdated;
        }

        public List<LeadDocEntity> GetAllLeadDocsForUsers(int UserID)
        {
            List<LeadDocEntity> lstLeads = new List<LeadDocEntity>();

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstLeads = uow.LeadDocRepository.Get().Where(x => x.UploadedFor == UserID).Select(usd => new LeadDocEntity
                    {
                        DocumentName = usd.DocumentName,
                        DocumentPath = usd.DocumentPath,
                        LeadDocID = usd.LeadDocID,
                        UploadDate = usd.UploadDate,
                        UploadedBy = usd.UploadedBy,
                        UploadedFor = usd.UploadedFor
                    }).OrderByDescending(x => Convert.ToDateTime(x.UploadDate)).ToList();
                }
                catch
                {

                }
            }
            return lstLeads;
        }

    }
}
