using System;
using System.Collections.Generic;

namespace StudyGuide.Models
{
    public partial class Subcategories
    {
        public Subcategories()
        {
            Pdfs = new HashSet<Pdfs>();
            QaDetails = new HashSet<QaDetails>();
        }

        public int SubId { get; set; }
        public string SubName { get; set; }
        public int CatId { get; set; }

        public Categories Cat { get; set; }
        public ICollection<Pdfs> Pdfs { get; set; }
        public ICollection<QaDetails> QaDetails { get; set; }
    }
}
