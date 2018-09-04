using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
  public class DocumentUploadEL
    {
        
            public int docUpload_id { get; set; }
            public int UserId { get; set; }
            public int doc_id { get; set; }
            public string doctypename { get; set; }
            public string filepath { get; set; }
       
    }
}
