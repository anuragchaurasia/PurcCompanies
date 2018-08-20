using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class CoinTransaction
    {
        public int TransactionID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string TransactionCurrency { get; set; }
        public string Cryptoamount { get; set; }
        public string NoOfCoins { get; set; }
        public string TransactionTime { get; set; }
    }
}
