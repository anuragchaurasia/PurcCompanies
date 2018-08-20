using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class LeadDocEntity
    {
        public int LeadDocID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public string UploadedBy { get; set; }
        public Nullable<int> UploadedFor { get; set; }
        public string UploadDate { get; set; }
    }
}
