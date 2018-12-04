using System;
using System.Collections.Generic;

namespace StudyGuide.Models
{
    public partial class Pdfs
    {
        public int PdfId { get; set; }
        public string PdfName { get; set; }
        public int SubId { get; set; }

        public Subcategories Sub { get; set; }
    }
}
