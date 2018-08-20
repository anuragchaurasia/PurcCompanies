using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer.UnitOfWork;
using EntityLayer;
using DataLayer.Helper;

namespace DataLayer.DataHelper
{
    public class UserHelper
    {

        DataLayer.UnitOfWork.UnitOfWork uow = null;

       

        public bool IsEmailAvailable(string Email)
        {
            bool isAvailable = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                //try
                //{
                isAvailable = uow.ComplianceUserRepository.Get().Any(u => u.Email.Equals(Email));
                //}
                //catch
                //{
                //    isAvailable = false;
                //}
            }

            return isAvailable;
        }


       
        //Compliance Operations

        public bool RegisterSalesUser(ComplianceUserData user)
        {
            bool isRegsitered = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    ComplianceUser userdb = new ComplianceUser();
                    userdb.CreationTime = DateTime.Now.ToString();
                    userdb.Email = user.Email;
                    userdb.IsActive = true;
                    userdb.Password = EncryptionHelper.Encrypt(user.Password);
                    userdb.IsContractor = user.IsContractor;
                    userdb.UserType = user.UserType;
                    userdb.Name = user.Name;
                    userdb.IsArchive = false;
                    uow.ComplianceUserRepository.Insert(userdb);
                    uow.Save();
                    isRegsitered = true;
                }
                catch
                {
                    isRegsitered = false;
                }
            }

            return isRegsitered;
        }

        public ComplianceUserData GetComplianceUserByID(int uID)
        {
            ComplianceUserData usrData = new ComplianceUserData();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    usrData = uow.ComplianceUserRepository.Get().Where(x => x.UserID == uID && x.IsArchive == false).Select(usd => new ComplianceUserData
                    {
                        CreationTime = usd.CreationTime,
                        Email = usd.Email,
                        Name = usd.Name,
                        IsActive = usd.IsActive,
                        IsContractor = usd.IsContractor,
                        Password = usd.Password,
                        UserID = usd.UserID,
                        UserType = usd.UserType
                    }).FirstOrDefault();
                }
                catch
                {

                }
            }
            return usrData;
        }

        public ComplianceUserData GetComplianceUserEmail(string email)
        {
            ComplianceUserData usrData = new ComplianceUserData();
            using (uow = new UnitOfWork.UnitOfWork())
            {

                usrData = uow.ComplianceUserRepository.Get().Where(x => x.Email == email && x.IsArchive == false).Select(usd => new ComplianceUserData
                {
                    CreationTime = usd.CreationTime,
                    Email = usd.Email,
                    Name = usd.Name,
                    IsActive = usd.IsActive,
                    IsContractor = usd.IsContractor,
                    Password = usd.Password,
                    UserID = usd.UserID
                }).FirstOrDefault();

            }
            return usrData;
        }

        public bool EditSalesUser(ComplianceUserData user)
        {
            bool isEdited = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    ComplianceUser userdb = uow.ComplianceUserRepository.Get().Where(u => u.UserID.Equals(user.UserID)).FirstOrDefault();
                    userdb.Email = user.Email;
                    userdb.IsActive = user.IsActive;
                    if (!String.IsNullOrEmpty(user.Password))
                    {
                        userdb.Password = EncryptionHelper.Encrypt(user.Password);
                    }
                    userdb.IsContractor = user.IsContractor;
                    userdb.UserType = user.UserType;
                    userdb.Name = user.Name;
                    uow.ComplianceUserRepository.Update(userdb);
                    uow.Save();
                    isEdited = true;
                }
                catch
                {
                    isEdited = false;
                }
            }

            return isEdited;
        }

        public bool ArchiveSalesUser(int userid)
        {
            bool isEdited = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    ComplianceUser userdb = uow.ComplianceUserRepository.Get().Where(u => u.UserID.Equals(userid)).FirstOrDefault();
                    userdb.IsArchive = true;
                    uow.ComplianceUserRepository.Update(userdb);
                    uow.Save();
                    isEdited = true;
                }
                catch
                {
                    isEdited = false;
                }
            }

            return isEdited;
        }

        public bool EditSalesUserPassword(ComplianceUserData user)
        {
            bool isEdited = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    ComplianceUser userdb = uow.ComplianceUserRepository.Get().Where(u => u.UserID.Equals(user.UserID)).FirstOrDefault();
                    userdb.Password = EncryptionHelper.Encrypt(user.Password);
                    uow.ComplianceUserRepository.Update(userdb);
                    uow.Save();
                    isEdited = true;
                }
                catch
                {
                    isEdited = false;
                }
            }

            return isEdited;
        }

        public List<ComplianceUserData> GetAllComplianceUsers()
        {
            List<ComplianceUserData> lstUsers = new List<ComplianceUserData>();

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstUsers = uow.ComplianceUserRepository.Get().Where(x => x.IsArchive == false).Select(usd => new ComplianceUserData
                    {
                        CreationTime = usd.CreationTime,
                        Email = usd.Email,
                        IsActive = usd.IsActive,
                        IsContractor = usd.IsContractor,
                        Password = usd.Password,
                        UserID = usd.UserID,
                        Name = usd.Name,
                        UserType = usd.UserType
                    }).ToList();
                }
                catch
                {

                }
            }
            return lstUsers;
        }

        public ComplianceUserData LoginComplianceUser(string email, string pwd)
        {
            ComplianceUserData usrdt = new ComplianceUserData();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    ComplianceUser usd = uow.ComplianceUserRepository.Get().Where(x => x.Email == email && x.Password == EncryptionHelper.Encrypt(pwd) && x.IsActive == true && x.IsArchive == false).FirstOrDefault();
                    usrdt.CreationTime = DateTime.Now.ToString();
                    usrdt.Email = usd.Email;
                    usrdt.IsActive = usd.IsActive;
                    usrdt.Password = usd.Password;
                    usrdt.IsContractor = usd.IsContractor;
                    usrdt.UserType = usd.UserType;
                    usrdt.Name = usd.Name;
                    usrdt.UserID = usd.UserID;
                }
                catch
                {
                    usrdt = null;
                }
            }
            return usrdt;
        }

        public ComplianceUserData DirectLogin(string email, string pwd)
        {
            ComplianceUserData usrdt = new ComplianceUserData();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    ComplianceUser usd = uow.ComplianceUserRepository.Get().Where(x => x.Email == email && x.Password == pwd && x.IsActive == true && x.IsArchive == false).FirstOrDefault();
                    usrdt.CreationTime = DateTime.Now.ToString();
                    usrdt.Email = usd.Email;
                    usrdt.IsActive = usd.IsActive;
                    usrdt.Password = usd.Password;
                    usrdt.IsContractor = usd.IsContractor;
                    usrdt.UserType = usd.UserType;
                    usrdt.Name = usd.Name;
                    usrdt.UserID = usd.UserID;
                }
                catch
                {
                    usrdt = null;
                }
            }
            return usrdt;
        }

        public bool IsPasswordAssociated(string password, int userid)
        {
            bool isAvailable = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                isAvailable = uow.ComplianceUserRepository.Get().Where(u => u.UserID == userid).Select(x => x.Password).FirstOrDefault().Equals(password);
                }
                catch
                {
                    isAvailable = false;
                }
            }

            return isAvailable;
        }

        //End

    }
}
