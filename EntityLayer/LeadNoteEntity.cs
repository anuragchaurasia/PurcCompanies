using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class LeadNoteEntity
    {
        public int LeadNoteID { get; set; }
        public string Note { get; set; }
        public string Timeline { get; set; }
        public Nullable<int> LeadID { get; set; }
        public string NoteLeftAt { get; set; }
    }
}
