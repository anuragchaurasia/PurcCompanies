using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.DataHelper
{
    public class TransactionHelper
    {
        DataLayer.UnitOfWork.UnitOfWork uow = null;

        UserHelper userHelper = new UserHelper();

        public bool RegisterTransaction(CoinTransaction trans)
        {
            bool isRegistered = false;
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    Transaction transactiondb = new Transaction();
                    transactiondb.NoOfCoins = trans.NoOfCoins;
                    transactiondb.TransactionCurrency = trans.TransactionCurrency;
                    transactiondb.TransactionTime = DateTime.Now.ToString();
                    transactiondb.UserID = trans.UserID;
                    transactiondb.Cryptoamount = trans.Cryptoamount;
                    uow.TransactionRepository.Insert(transactiondb);
                    uow.Save();
                    isRegistered = true;
                    
                }
                catch
                {
                    isRegistered = false;
                }
            }
            return isRegistered;
        }

        public List<CoinTransaction> GetAllTransactions()
        {
            List<CoinTransaction> lstTransactions = new List<CoinTransaction>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstTransactions = uow.TransactionRepository.Get().Select(usd => new CoinTransaction
                    {
                        Cryptoamount = usd.Cryptoamount,
                        NoOfCoins = usd.NoOfCoins,
                        TransactionCurrency = usd.TransactionCurrency,
                        TransactionID = usd.TransactionID,
                        TransactionTime = usd.TransactionTime,
                        UserID = usd.UserID
                    }).ToList();
                }
                catch
                {

                }
            }
            return lstTransactions;
        }

        public List<CoinTransaction> GetTransactionsByUserID(int uid)
        {
            List<CoinTransaction> lstTransactions = new List<CoinTransaction>();
            using (uow = new UnitOfWork.UnitOfWork())
            {
                try
                {
                    lstTransactions = uow.TransactionRepository.Get().Where(x => x.UserID == uid).Select(usd => new CoinTransaction
                    {
                        Cryptoamount = usd.Cryptoamount,
                        NoOfCoins = usd.NoOfCoins,
                        TransactionCurrency = usd.TransactionCurrency,
                        TransactionID = usd.TransactionID,
                        TransactionTime = usd.TransactionTime,
                        UserID = usd.UserID
                    }).ToList();
                }
                catch
                {

                }
            }
            return lstTransactions;
        }

       
    }
}
