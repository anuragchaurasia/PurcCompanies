using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using EntityLayer;
using DataLayer;
using DataLayer.Common;
using PurcellCompliance.UnitOfWork;
using EntityLayer.Response;
using System.Security.Cryptography;

namespace PurcellComplianceServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PurcellService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PurcellService.svc or PurcellService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PurcellService : IPurcellService
    {
        UnitOfWork uow = null;

        public UserLoginResponse Login(UserLoginRequest userRequest)
        {
            UserLoginResponse userLoginResponse = new UserLoginResponse();
            userLoginResponse.IsSuccess = userLoginResponse.IsLoggedIn = false;
            userLoginResponse.Message = "Login unsuccessful";
            try
            {
                if (userRequest != null)
                {

                    using (uow = new UnitOfWork())
                    {
                        if (!string.IsNullOrEmpty(userRequest.PasswordHash) && !string.IsNullOrEmpty(userRequest.UserNameOREmail))
                        {
                            //string PasswordHash = new Util().GetHashString(userRequest.PasswordHash);
                            string PasswordHash = userRequest.PasswordHash;
                            User existUser = existUser = uow.UserRepository.Get()
                                                               .Where(u => PasswordHash.Equals(u.Password)
                                                                          && userRequest.UserNameOREmail.Equals(u.Username)
                                                                     ).FirstOrDefault();

                            if (existUser == null)
                                existUser = uow.UserRepository.Get()
                                                              .Where(u => PasswordHash.Equals(u.Password)
                                                                         && userRequest.UserNameOREmail.Equals(u.Email, StringComparison.OrdinalIgnoreCase)
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
                                }

                                #endregion

                                #region PrepareResponse

                                userLoginResponse.UserID = existUser.UserID;
                                userLoginResponse.FullName = existUser.Name;
                                userLoginResponse.PhoneNo = existUser.PhoneNo;
                                userLoginResponse.Token = token;
                                userLoginResponse.IsSuccess = true;
                                userLoginResponse.IsLoggedIn = true;

                                userLoginResponse.Message = "Successfully Logged-in ";
                                UsersEL userEl = new UsersEL();
                                userEl.Active = existUser.Active;
                                userEl.Address = existUser.Address;
                                userEl.City = existUser.City == null ? "" : existUser.City;
                                userEl.Country = existUser.Country;
                                userEl.CreatedDate = existUser.CreatedDate;
                                userEl.Email = existUser.Email;
                                userEl.Name = existUser.Name;
                                userEl.PhoneNo = existUser.PhoneNo;
                                userEl.UserID = existUser.UserID;
                                userEl.Username = existUser.Username;
                                userEl.Zipcode = existUser.Zipcode;
                                userEl.CreatedDate = existUser.CreatedDate == null ? DateTime.Now : existUser.CreatedDate;
                                userEl.Password = "";
                                userEl.ProfilePic = "";
                                userEl.RoleID = "2";
                                userEl.State = "";
                                userEl.DeviceType = existUser.DeviceType == null ? "" : existUser.DeviceType;
                                userEl.PushToken = existUser.PushToken == null ? "" : existUser.PushToken;
                                userLoginResponse.userData = userEl;



                                #endregion
                            }
                            else
                            {

                                userLoginResponse.Message = "You are passing wrong credentials.";
                            }
                        }
                        else
                        {

                            userLoginResponse.Message = "Please pass value of all mandatory fields";
                        }

                    }

                }
            }
            catch
            {
                userLoginResponse.Message = "An error occurred while authentication";

            }

            return userLoginResponse;
        }

        public UserLogoutResponse UserLogout(UserLogoutRequest userRequest)
        {
            UserLogoutResponse userLogoutResponse = new UserLogoutResponse();
            userLogoutResponse.IsSuccess = userLogoutResponse.IsLoggedIn = false;
            userLogoutResponse.Message = "Logout unsuccessful";

            try
            {
                if (userRequest != null)
                {

                    using (uow = new UnitOfWork())
                    {
                        // If token exists then delete existing token  

                        AuthenticationToken existingToken = uow.AuthenticationTokenRepository.Get().
                                                          Where(auth => auth.FkUserID.Equals(userRequest.UserID))
                                                          .FirstOrDefault();

                        if (existingToken != null)
                        {
                            // Delete token
                            uow.AuthenticationTokenRepository.Delete(existingToken);
                            uow.Save();
                        }

                        #region PrepareResponse

                        userLogoutResponse.IsSuccess = true;
                        userLogoutResponse.IsLoggedIn = false;

                        userLogoutResponse.Message = "Successfully Logout ";

                        #endregion
                    }

                }
            }
            catch (Exception ex)
            {
                userLogoutResponse.Message = "An error occurred while user logout";

            }

            return userLogoutResponse;

        }

        public UpdateUserResponse UpdateProfile(UpdateUserRequest userRequest)
        {
            UpdateUserResponse userResponse = new UpdateUserResponse();

            userResponse.IsSuccess = false;
            userResponse.Message = "User Update unsuccessful";

            #region Validate Input

            if (string.IsNullOrEmpty(userRequest.AuthToken))
            {
                userResponse.Message = "Please pass value of all mandatory fields";
                return userResponse;
            }

            AuthenticationToken authToken = new Helper().GetAuthenticationToken(userRequest.AuthToken);

            if (authToken == null)
            {
                userResponse.Message = "Unauthorizes user.";
                return userResponse;
            }
            #endregion
            try
            {
                if (userRequest.UserInfo != null)
                {
                    User existingUser = null;

                    using (uow = new UnitOfWork())
                    {
                        existingUser = uow.UserRepository.Get().Where(u => u.UserID.Equals(authToken.FkUserID)).FirstOrDefault();

                        #region Get Existing User

                        if (existingUser == null)
                        {
                            userResponse.Message = "User not found";
                            return userResponse;
                        }
                        // Check updating email id exists for other user 
                        if (!existingUser.Email.Equals(userRequest.UserInfo.Email))
                        {
                            if (uow.UserRepository.Get().Any(u => u.Email.Equals(userRequest.UserInfo.Email, StringComparison.OrdinalIgnoreCase)
                                                             && !u.UserID.Equals(existingUser.UserID)))
                            {
                                userResponse.Message = "Email id you trying to update is already exists for other user.";
                                return userResponse;
                            }
                        }
                        #endregion


                        #region Update User

                        existingUser.Name = userRequest.UserInfo.Name;
                        existingUser.Email = userRequest.UserInfo.Email;
                        existingUser.PhoneNo = userRequest.UserInfo.PhoneNo;
                        existingUser.Password = new Util().GetHashString(userRequest.UserInfo.PasswordHash);
                        existingUser.Address = userRequest.UserInfo.Address;
                        existingUser.Country = userRequest.UserInfo.Country;
                        existingUser.City = userRequest.UserInfo.City;
                        existingUser.State = userRequest.UserInfo.State;
                        existingUser.Zipcode = userRequest.UserInfo.Zipcode;
                        existingUser.CreatedDate = System.DateTime.UtcNow;
                        uow.UserRepository.Update(existingUser);
                        uow.Save();

                        #endregion

                        #region PrepareResponse

                        userResponse.IsSuccess = true;
                        userResponse.Message = "Successfully Updated";

                        #endregion


                    }
                }
            }
            catch (Exception ex)
            {

                userResponse.Message = "An error occurred while updating user.";
            }

            return userResponse;
        }

        public UpdateDeviceTokenResponse UpdatePushToken(UpdateDeviceTokenRequest userRequest)
        {
            UpdateDeviceTokenResponse updateTokenResponse = new UpdateDeviceTokenResponse();
            updateTokenResponse.IsSuccess = false;
            updateTokenResponse.Message = "Update device push token unsuccessful";
            try
            {
                if (!string.IsNullOrEmpty(userRequest.AuthToken)
                     && !string.IsNullOrEmpty(userRequest.DevicePushToken)
                     && !string.IsNullOrEmpty(userRequest.DeviceType)
                    )
                {
                    AuthenticationToken authToken = new Helper().GetAuthenticationToken(userRequest.AuthToken);

                    if (authToken != null)
                    {
                        using (uow = new UnitOfWork())
                        {

                            User existingUser = null;

                            existingUser = uow.UserRepository.Get().Where(u => u.UserID.Equals(authToken.FkUserID)).FirstOrDefault();

                            #region Get Existing User

                            if (existingUser != null)
                            {
                                existingUser.PushToken = userRequest.DevicePushToken;
                                existingUser.DeviceType = userRequest.DeviceType;
                                uow.UserRepository.Update(existingUser);
                                uow.Save();

                                updateTokenResponse.IsSuccess = true;
                                updateTokenResponse.Message = "Update device push token successfully";
                            }
                            else
                            {
                                updateTokenResponse.Message = "User not found";
                            }


                            #endregion
                        }
                    }
                    else
                    {

                        updateTokenResponse.Message = "Unauthorizes user";
                    }

                }
                else
                {
                    updateTokenResponse.Message = "Please pass value of all mandatory fields";
                }
            }
            catch (Exception ex)
            {
                updateTokenResponse.Message = "An error occurred while update device push token.";

            }
            return updateTokenResponse;

        }

        public GetUserDocResponse GetUserDocs(string UserID)
        {
            GetUserDocResponse getUserDocResponse = new GetUserDocResponse();
            getUserDocResponse.IsSuccess = false;
            getUserDocResponse.Message = "Get docs for user is not successfull.";

            try
            {
                using (uow = new UnitOfWork())
                {
                    List<UserDocument> lstUserdocs = uow.UserDocumentRepository.Get().Where(x => x.UserID == Convert.ToInt32(UserID)).ToList();
                    List<DocumentEL> docsListEL = new List<DocumentEL>();
                    foreach (var item in lstUserdocs)
                    {
                        DocumentEL docEL = new DocumentEL();
                        docEL.DocumentID = Convert.ToInt32(item.DocID);
                        docEL.DocumentPath = "http://purcell.opilab.com/web/" + item.UploadPath;
                        docEL.UserID = item.UserDocID;
                        docEL.Description = "";
                        docEL.DocumentTypeName = "";
                        docsListEL.Add(docEL);
                    }
                    getUserDocResponse.docList = docsListEL;
                    getUserDocResponse.IsSuccess = true;
                    getUserDocResponse.Message = "Get docs for user is successfull.";
                }
            }
            catch
            {

            }

            return getUserDocResponse;
        }

        public string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        public DocumentUploadResponse SendDocument(DocumentUploadRequest docUploadRequest)
        {
            DocumentUploadResponse documentUploadResponse = new DocumentUploadResponse();
            documentUploadResponse.IsSuccess = false;
            documentUploadResponse.Message = "Document not sent successfully.";
            #region Validate Input

            if (string.IsNullOrEmpty(docUploadRequest.AuthToken))
            {
                documentUploadResponse.Message = "Please pass value of all mandatory fields";
                return documentUploadResponse;
            }

            AuthenticationToken authToken = new Helper().GetAuthenticationToken(docUploadRequest.AuthToken);



            if (authToken == null)
            {
                documentUploadResponse.Message = "Unauthorizes user.";
                return documentUploadResponse;
            }
            #endregion

            try
            {
                using (uow = new UnitOfWork())
                {
                    User user = uow.UserRepository.GetById(authToken.FkUserID);
                    EmailHelper emailHelper = new EmailHelper();
                    emailHelper.SendHtmlEmailWithImage("Document Sent By Customer", docUploadRequest.DocumentName, user, docUploadRequest.ImagePath, docUploadRequest.Description);
                    documentUploadResponse.IsSuccess = true;
                    documentUploadResponse.Message = "Document sent successfully.";
                }

            }
            catch
            {

            }

            return documentUploadResponse;
        }

        public DocumentUploadResponse SendChangeRequest(DocumentUploadRequest docUploadRequest)
        {
            DocumentUploadResponse documentUploadResponse = new DocumentUploadResponse();
            documentUploadResponse.IsSuccess = false;
            documentUploadResponse.Message = "Document not sent successfully.";
            #region Validate Input

            if (string.IsNullOrEmpty(docUploadRequest.AuthToken))
            {
                documentUploadResponse.Message = "Please pass value of all mandatory fields";
                return documentUploadResponse;
            }

            AuthenticationToken authToken = new Helper().GetAuthenticationToken(docUploadRequest.AuthToken);



            if (authToken == null)
            {
                documentUploadResponse.Message = "Unauthorizes user.";
                return documentUploadResponse;
            }
            #endregion

            try
            {
                using (uow = new UnitOfWork())
                {
                    User user = uow.UserRepository.GetById(authToken.FkUserID);
                    EmailHelper emailHelper = new EmailHelper();
                    emailHelper.SendHtmlEmailWithImage("Document Sent By Customer", docUploadRequest.DocumentName, user, docUploadRequest.ImagePath, docUploadRequest.Description);
                    documentUploadResponse.IsSuccess = true;
                    documentUploadResponse.Message = "Document sent successfully.";
                }

            }
            catch
            {

            }

            return documentUploadResponse;
        }

        private byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create();  //or use SHA1.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public string[] GetMobileLoginText()
        {
            string[] _textName = new string[2];
            using (uow = new UnitOfWork())
            {
                // Setting _setRec = uow.SettingRepository.Get().Where(x=>x.SettingID>0).FirstOrDefault();
                Setting _setRec = uow.SettingRepository.Get().FirstOrDefault();
                if (_setRec != null)
                {
                    _textName[0] = _setRec.Mob_login_text1;
                    _textName[1] = _setRec.Mob_login_text2;
                }
            }


            return _textName;
        }

        public GetUserDocResponse GetDocumentList(UploadUserRequest docRequest)
        {
            GetUserDocResponse getUserDocResponse = new GetUserDocResponse();
            getUserDocResponse.IsSuccess = false;
            getUserDocResponse.Message = "Get docs for user is not successfull.";

            #region Validate Input

            if (string.IsNullOrEmpty(docRequest.AuthToken))
            {
                getUserDocResponse.Message = "Please pass value of all mandatory fields";
                return getUserDocResponse;
            }

            AuthenticationToken authToken = new Helper().GetAuthenticationToken(docRequest.AuthToken);

            if (authToken == null)
            {
                getUserDocResponse.Message = "Unauthorizes user.";
                return getUserDocResponse;
            }
            #endregion validate input
            try
            {
                using (uow = new UnitOfWork())
                {
                    List<UserDocument> lstUserdocs = uow.UserDocumentRepository.Get().Where(x => x.UserID == Convert.ToInt32(docRequest.userId)).ToList();

                    List<DocumentEL> docsListEL = new List<DocumentEL>();
                    foreach (var item in lstUserdocs)
                    {
                        var _docRec = uow.DocumentMasterRepository.Get().Where(x => x.DocumentID == Convert.ToInt32(item.DocID)).SingleOrDefault();
                        DocumentEL docEL = new DocumentEL();
                        docEL.DocumentID = Convert.ToInt32(item.DocID);
                        //docEL.DocumentPath = "http://purcell.opilab.com/web/" + item.UploadPath;
                        docEL.DocumentPath = "https://purcellcompanies.com/uploads/" + item.UploadPath;
                        docEL.UserID = item.UserDocID;
                        docEL.Description = _docRec.Description;
                        docEL.DocumentTypeName = _docRec.DocumentName + " " + _docRec.Description;
                        docsListEL.Add(docEL);
                    }
                    getUserDocResponse.docList = docsListEL;
                    getUserDocResponse.IsSuccess = true;
                    getUserDocResponse.Message = "Get docs for user is successfull.";
                }
            }
            catch
            {

            }

            return getUserDocResponse;
        }

        //public GetUploadDocumentResponse GetUsGetDocUploaderDocs(string UserID)
        //{
        //    GetUploadDocumentResponse getUserDocResponse = new GetUploadDocumentResponse();
        //    getUserDocResponse.IsSuccess = false;
        //    getUserDocResponse.Message = "Get docs for user is not successfull.";

        //    try
        //    {
        //        using (uow = new UnitOfWork())
        //        {
        //            List<DocumentUpload> lstUserdocs = uow.DocUploadRepository.Get().Where(x => x.UserId == Convert.ToInt32(UserID)).ToList();
        //            List<DocumentUploadEL> docsListEL = new List<DocumentUploadEL>();
        //            foreach (var item in lstUserdocs)
        //            {
        //                DocumentUploadEL docEL = new DocumentUploadEL();
        //                docEL.doc_id = Convert.ToInt32(item.doc_id);
        //                docEL.filepath = "http://purcell.opilab.com/web/" + item.filepath;
        //                docEL.UserId = item.UserId;
        //              //  docEL.Description = "";
        //                docEL.doctypename = item.doctypename;
        //                docsListEL.Add(docEL);
        //            }
        //            getUserDocResponse.docUploadList = docsListEL;
        //            getUserDocResponse.IsSuccess = true;
        //            getUserDocResponse.Message = "Get docs for user is successfull.";
        //        }
        //    }
        //    catch
        //    {

        //    }

        //    return getUserDocResponse;
        //}
    }

}