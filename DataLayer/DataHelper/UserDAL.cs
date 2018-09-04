using DataLayer.Common;
using DataLayer.Helper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace DataLayer.DAL
{
    public class UserDAL
    {
        UnitOfWork.UnitOfWork uow = null;

        public void RegisterUser(UsersEL users)
        {
            Random randPassword = new Random();
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                try
                {
                    if (users != null)
                    {
                        using (uow = new UnitOfWork.UnitOfWork())
                        {
                            #region Create New User
                            string RandomPassword = randPassword.Next(10000, 99999).ToString();
                            User newUser = new User();
                            newUser.Name = users.Name;
                            newUser.Username = users.Username;
                            newUser.Email = users.Email;
                            newUser.PhoneNo = users.PhoneNo;
                            //newUser.Password = new Util().GetHashString(RandomPassword);
                            newUser.Password = EncryptionHelper.Encrypt(RandomPassword);
                            newUser.Address = users.Address;
                            newUser.Country = users.Country;
                            newUser.State = users.State;
                            newUser.Zipcode = users.Zipcode;
                            newUser.Active = true;
                            newUser.CreatedDate = System.DateTime.UtcNow;
                            newUser.UserRoleID = Convert.ToInt32(users.RoleID);
                            newUser.USDot = users.UsDot;
                            uow.UserRepository.Insert(newUser);
                            uow.Save();

                            #endregion
                            transactionScope.Complete();

                            EmailHelper emailHelper = new EmailHelper();
                          //  emailHelper.SendHtmlFormattedEmail("New account created", newUser, RandomPassword);
                        }
                    }
                }
                catch (Exception ex)
                {
                    transactionScope.Dispose();
                }
            }
        }

        public UsersEL Login(string usernameOrEmail, string password)
        {
            string loginMessage = "Login successfull.";
            UsersEL userEL = new UsersEL();
            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(usernameOrEmail))
                    {
                        string PasswordHash = EncryptionHelper.Encrypt(password);
                        User existUser = uow.UserRepository.Get()
                                                           .Where(u => PasswordHash.Equals(u.Password)
                                                                      && usernameOrEmail.Equals(u.Username)
                                                                 ).FirstOrDefault();

                        if (existUser == null)
                            existUser = uow.UserRepository.Get()
                                                          .Where(u => PasswordHash.Equals(u.Password)
                                                                     && usernameOrEmail.Equals(u.Email, StringComparison.OrdinalIgnoreCase)
                                                                ).FirstOrDefault();

                        if (existUser != null)
                        {
                            #region Get Existing User

                            // If token exists then return existing token otherwise generate new one 

                            AuthenticationToken existingToken = uow.AuthenticationTokenRepository.Get().
                                                              Where(auth => auth.FkUserID.Equals(existUser.UserID))

                                                              .FirstOrDefault();
                            string token;
                            if (existingToken != null)
                            {
                                token = existingToken.Token;
                            }
                            else
                            {
                                // Generate New Token and save 
                                AuthenticationToken authToken = new AuthenticationToken();
                                authToken.FkUserID = existUser.UserID;
                                token = authToken.Token = Guid.NewGuid().ToString().Replace("-", "");
                                authToken.CreatedDate = System.DateTime.UtcNow;

                                uow.AuthenticationTokenRepository.Insert(authToken);
                                uow.Save();
                                userEL.UserID = existUser.UserID;
                            }
                            userEL.Active = existUser.Active;
                            userEL.Email = existUser.Email;
                            userEL.Name = existUser.Name;
                            userEL.Username = existUser.Username;
                            userEL.UserID = existUser.UserID;
                            loginMessage = "Success";
                            #endregion
                        }
                        else
                        {

                            loginMessage = "You are passing wrong credentials.";
                        }
                    }
                    else
                    {

                        loginMessage = "Please pass value of all mandatory fields";
                    }
                }
            }
            catch (Exception ex)
            {
                loginMessage = "An error occurred while authentication";

            }
            return userEL;
        }

        public void Logout(string userID)
        {
            try
            {
                if (userID != null)
                {

                    using (uow = new UnitOfWork.UnitOfWork())
                    {
                        // If token exists then delete existing token  

                        AuthenticationToken existingToken = uow.AuthenticationTokenRepository.Get().
                                                          Where(auth => auth.FkUserID.Equals(userID))
                                                          .FirstOrDefault();

                        if (existingToken != null)
                        {
                            // Delete token
                            uow.AuthenticationTokenRepository.Delete(existingToken);
                            uow.Save();
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        public bool EditUser(UsersEL users)
        {
            bool isUpdated = false;
            try
            {
                if (users != null)
                {
                    User existingUser = null;

                    using (uow = new UnitOfWork.UnitOfWork())
                    {
                        existingUser = uow.UserRepository.Get().Where(u => u.UserID.Equals(users.UserID)).FirstOrDefault();

                        #region Get Existing User

                        if (existingUser == null)
                        {
                            return isUpdated;
                        }
                        // Check updating email id exists for other user 
                        if (!existingUser.Email.Equals(users.Email))
                        {
                            if (uow.UserRepository.Get().Any(u => u.Email.Equals(users.Email, StringComparison.OrdinalIgnoreCase)
                                                             && !u.UserID.Equals(existingUser.UserID)))
                            {

                                return false;
                            }
                        }
                        #endregion


                        #region Update User

                        existingUser.Name = users.Name;
                        existingUser.Email = users.Email;
                        existingUser.PhoneNo = users.PhoneNo;
                        existingUser.Address = users.Address;
                        existingUser.Country = users.Country;
                        existingUser.City = users.City;
                        existingUser.State = users.State;
                        existingUser.Zipcode = users.Zipcode;
                        uow.UserRepository.Update(existingUser);
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

        public List<UsersEL> GetAllCustomers()
        {
            List<UsersEL> lstUsersEL = new List<UsersEL>();
            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    List<User> lstUsers = uow.UserRepository.Get().Where(x => x.UserRoleID == 2).ToList();
                    foreach (User user in lstUsers)
                    {
                        UsersEL userEl = new UsersEL();
                        userEl.Active = user.Active;
                        userEl.Address = user.Address;
                        userEl.City = user.City;
                        userEl.Country = user.Country;
                        userEl.CreatedDate = user.CreatedDate;
                        userEl.Email = user.Email;
                        userEl.Name = user.Name;
                        userEl.PhoneNo = user.PhoneNo;
                        userEl.State = user.State;
                        userEl.Zipcode = user.Zipcode;
                        userEl.Username = user.Username;
                        userEl.UserID = user.UserID;
                        userEl.UsDot  = user.USDot ;
                        lstUsersEL.Add(userEl);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return lstUsersEL;
        }

        public UsersEL GetCustomerByID(string id)
        {
            UsersEL userEl = new UsersEL();
            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    User user = uow.UserRepository.Get().Where(x => x.UserID == Convert.ToInt32(id)).FirstOrDefault();
                    userEl.Active = user.Active;
                    userEl.Address = user.Address;
                    userEl.City = user.City;
                    userEl.Country = user.Country;
                    userEl.CreatedDate = user.CreatedDate;
                    userEl.Email = user.Email;
                    userEl.Name = user.Name;
                    userEl.PhoneNo = user.PhoneNo;
                    userEl.State = user.State;
                    userEl.Zipcode = user.Zipcode;
                    userEl.Username = user.Username;
                    userEl.UserID = user.UserID;
                    userEl.Password = user.Password;
                    userEl.DeviceType = user.DeviceType;
                    userEl.PushToken = user.PushToken;
                }
            }
            catch (Exception ex)
            {
            }
            return userEl;
        }

        public void AddLoginAnalytic(LoginAnalyticsEntity loginAnalyticEntity)
        {
            using (uow = new UnitOfWork.UnitOfWork())
            {
                LoginAnalytic loginAnalytic = new LoginAnalytic();
                loginAnalytic.Date = DateTime.Now.ToShortDateString();
                loginAnalytic.IPAddress = loginAnalyticEntity.IPAddress;
                loginAnalytic.OS = loginAnalyticEntity.OS;
                loginAnalytic.Platform = loginAnalyticEntity.Platform;
                loginAnalytic.Username = loginAnalyticEntity.Username;
                loginAnalytic.Browser = loginAnalyticEntity.Browser;
                uow.LoginAnalyticRepository.Insert(loginAnalytic);
                uow.Save();
            }
        }

        public void AddDocumentAnalytic(DocumentAnalyticEntity documentAnalyticEntity)
        {
            using (uow = new UnitOfWork.UnitOfWork())
            {
                DocumentAnalytic loginAnalytic = new DocumentAnalytic();
                loginAnalytic.Date = DateTime.Now.ToString();
                loginAnalytic.IPAddress = documentAnalyticEntity.IPAddress;
                loginAnalytic.OS = documentAnalyticEntity.OS;
                loginAnalytic.Platform = documentAnalyticEntity.Platform;
                loginAnalytic.Username = documentAnalyticEntity.Username;
                loginAnalytic.Browser = documentAnalyticEntity.Browser;
                loginAnalytic.DocumentName = documentAnalyticEntity.DocumentName;
                uow.DocumentAnalyticRepository.Insert(loginAnalytic);
                uow.Save();
            }
        }

        public List<DocumentAnalyticEntity> GetDocAnalytics()
        {
            List<DocumentAnalyticEntity> lstDocumentsEL = new List<DocumentAnalyticEntity>();
            try
            {
                using (uow = new UnitOfWork.UnitOfWork())
                {
                    lstDocumentsEL = uow.DocumentAnalyticRepository.Get().Select(p => new DocumentAnalyticEntity
                    {
                        AnalyticsID = p.AnalyticsID,
                        Browser = p.Browser,
                        Date = p.Date,
                        DocumentName = p.DocumentName,
                        IPAddress = p.IPAddress,
                        OS = p.OS,
                        Platform = p.Platform,
                        Username = p.Username
                    }).OrderByDescending(x => x.AnalyticsID).ToList();

                }
            }
            catch (Exception ex)
            {
            }
            return lstDocumentsEL;
        }

        
    }
}
