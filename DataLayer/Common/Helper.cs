using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace DataLayer.Common
{
    public class Helper
    {
        UnitOfWork.UnitOfWork uow = null;
        string _connectionString = string.Empty;

        public Helper()
        {

        }

        public Helper(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public bool IsEmailExist(string EmailAddress)
        {
            bool isEmailIdAlreadyExists = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {

                isEmailIdAlreadyExists = uow.UserRepository.Get().
                                         Any(sp => EmailAddress.Equals(sp.Email, StringComparison.OrdinalIgnoreCase));
            }
            return isEmailIdAlreadyExists;
        }

        public bool IsUserNameExist(string UserName)
        {
            bool isUserNameAlreadyExists = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {

                isUserNameAlreadyExists = uow.UserRepository.Get().
                                         Any(sp => UserName.Equals(sp.Username, StringComparison.OrdinalIgnoreCase));
            }
            return isUserNameAlreadyExists;
        }
        // Authorized
        public bool IsAuthorizedUser(string Token)
        {
            bool isUserAuthorized = false;

            using (uow = new UnitOfWork.UnitOfWork())
            {

                isUserAuthorized = uow.AuthenticationTokenRepository.Get().
                                         Any(sp => Token.Equals(sp.Token, StringComparison.OrdinalIgnoreCase));
            }
            return isUserAuthorized;
        }

        // Authorized
        public DataLayer.AuthenticationToken GetAuthenticationToken(string Token)
        {
            DataLayer.AuthenticationToken auth = null;

            using (uow = new UnitOfWork.UnitOfWork())
            {

                auth = uow.AuthenticationTokenRepository.Get().Join(uow.UserRepository.Get(), authTkn => authTkn.FkUserID, usr => usr.UserID, (authTkn, usr) => new { authTkn, usr })
                                                        .Where(sp => Token.Equals(sp.authTkn.Token, StringComparison.OrdinalIgnoreCase))
                                                        .Select(aut => aut.authTkn)
                                                        .FirstOrDefault();


            }
            return auth;
        }

        
    }
}