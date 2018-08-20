using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class DocumentEL
    {
        public int DocumentTypeID { get; set; }
        public string DocumentTypeName { get; set; }
        public string Description { get; set; }
        public int DocumentID { get; set; }
        public int UserID { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentName { get; set; }
    }
}
