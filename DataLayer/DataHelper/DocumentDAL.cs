using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace DataLayer.DAL
{
    public class DocumentDAL
    {
        UnitOfWork.UnitOfWork uow = null;

        public DocumentMaster AddDocumentType(DocumentEL document)
        {
            DocumentMaster newDoc = new DocumentMaster();
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                try
                {
                    if (document != null)
                    {
                        using (uow = new UnitOfWork.UnitOfWork())
                        {
                            #region Add New Document
                            newDoc.Description = document.Description;
                            newDoc.DocumentName = document.DocumentTypeName;
                            uow.DocumentMasterRepository.Insert(newDoc);
                            uow.Save();
                            #endregion
                            transactionScope.Complete();
                        }
                    }
                }
                catch (Exception ex)
                {
                    transactionScope.Dispose();
                }
                return newDoc;
            }
        }

        public bool EditDocumentType(DocumentEL document)
        {
            bool isUpdated = false;
            try
            {
                if (document != null)
                {
                    DocumentMaster existingDoc = null;

                    using (uow = new UnitOfWork.UnitOfWork())
                    {
                        existingDoc = uow.DocumentMasterRepository.Get().Where(u => u.DocumentID.Equals(document.DocumentTypeID)).FirstOrDefault();

                        #region Get Existing User

                        if (existingDoc == null)
                        {
                            return isUpdated;
                        }
                        // Check updating email id exists for other user 

                        #endregion


                        #region Update Document

                        existingDoc.DocumentName = document.DocumentTypeName;
                        existingDoc.Description = document.Description;

                        uow.DocumentMasterRepository.Update(existingDoc);
                        uow.Save();

                        #endregion

                        #region PrepareResponse

                        isUpdated = true;

                        #endregion


                    }
                }
            }
            catch (Exception ex)
            {
                isUpdated = false;
                return isUpdated;
            }

            return isUpdated;
        }

        public List<DocumentEL> GetAllDocumentType()
        {
            List<DocumentEL> lstDocumentEL = new List<DocumentEL>();
            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    List<DocumentMaster> lstDocs = uow.DocumentMasterRepository.Get().OrderBy(x => x.DocumentID).ToList();
                    foreach (DocumentMaster doc in lstDocs)
                    {
                        DocumentEL docEl = new DocumentEL();
                        docEl.DocumentTypeName = doc.DocumentName;
                        docEl.Description = doc.Description;
                        docEl.DocumentTypeID = doc.DocumentID;
                        docEl.DocumentID = doc.DocumentID;
                        lstDocumentEL.Add(docEl);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return lstDocumentEL;
        }

        public DocumentEL GetDocumentTypeByID(string id)
        {
            DocumentEL docEl = new DocumentEL();
            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    DocumentMaster doc = uow.DocumentMasterRepository.Get().Where(x => x.DocumentID == Convert.ToInt32(id)).FirstOrDefault();
                    docEl.DocumentTypeID = doc.DocumentID;
                    docEl.DocumentTypeName = doc.DocumentName;
                    docEl.Description = doc.Description;
                }
            }
            catch (Exception ex)
            {
            }
            return docEl;
        }

        public DocumentEL GetDocumentTypeByName(string documentname)
        {
            DocumentEL docEl = new DocumentEL();
            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    DocumentMaster doc = uow.DocumentMasterRepository.Get().Where(x => x.DocumentName == documentname).FirstOrDefault();
                    docEl.DocumentTypeID = doc.DocumentID;
                    docEl.DocumentTypeName = doc.DocumentName;
                    docEl.Description = doc.Description;
                }
            }
            catch (Exception ex)
            {
            }
            return docEl;
        }

        public bool DeleteDocumentType(string id)
        {
            bool isDeleted = false;
            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    DocumentMaster doc = uow.DocumentMasterRepository.Get().Where(x => x.DocumentID == Convert.ToInt32(id)).FirstOrDefault();
                    uow.DocumentMasterRepository.Delete(doc);
                    uow.Save();
                }
            }
            catch (Exception ex)
            {

            }
            return isDeleted;
        }

        public bool AddDocument(DocumentEL document)
        {
            bool isInserted = false;
            UserDocument newDoc = new UserDocument();
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                try
                {
                    if (document != null)
                    {
                        using (uow = new UnitOfWork.UnitOfWork())
                        {
                            #region Add New Document
                            newDoc.DocID = document.DocumentID;
                            newDoc.UserID = document.UserID;
                            newDoc.UploadPath = document.DocumentPath;
                            uow.UserDocumentRepository.Insert(newDoc);
                            uow.Save();
                            #endregion
                            transactionScope.Complete();
                            isInserted = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    transactionScope.Dispose();
                }
                return isInserted;
            }
        }

        public List<DocumentEL> GetUserDocuments(string id)
        {
            List<DocumentEL> lstDocumentEL = new List<DocumentEL>();
            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    lstDocumentEL = uow.UserDocumentRepository.Get().Join(uow.DocumentMasterRepository.Get(), ud => ud.DocID, dm => dm.DocumentID, (ud, dm) => new { ud, dm }).Where(x => x.ud.UserID == Convert.ToInt32(id))
                        .Select(po => new DocumentEL
                        {
                            DocumentID = (int)po.ud.DocID,
                            DocumentName = po.dm.DocumentName,
                            DocumentPath = po.ud.UploadPath,
                            UserID = (int)po.ud.UserID,
                            DocumentTypeID = po.ud.UserDocID,
                        }).ToList();
                    //foreach (UserDocument doc in lstDocs)
                    //{
                    //    DocumentEL docEl = new DocumentEL();
                    //    docEl.DocumentID = Convert.ToInt32(doc.DocID);
                    //    docEl.DocumentPath = doc.UploadPath;
                    //    lstDocumentEL.Add(docEl);
                    //}
                }
            }
            catch (Exception ex)
            {
            }
            return lstDocumentEL;
        }
    }
}
