using System;
using System.Collections.Generic;

namespace StudyGuide.Models
{
    public partial class QaDetails
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int QaId { get; set; }
        public int SubId { get; set; }

        public Subcategories Sub { get; set; }
    }
}
