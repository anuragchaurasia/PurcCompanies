using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class ProfileCardEntity
    {
        public int ProfileCardInfo { get; set; }
        public Nullable<int> OrderFormID { get; set; }
        public string CardType { get; set; }
        public string CorDC { get; set; }
        public string Expiration { get; set; }
        public string CVC { get; set; }
        public Nullable<bool> IsSubmitted { get; set; }
    }
}
