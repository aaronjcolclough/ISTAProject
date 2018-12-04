using System;
using System.Collections;
using System.Collections.Generic;

namespace StudyGuide.Models
{
    public partial class Categories 
    {

        public Categories()
        {
            Subcategories = new HashSet<Subcategories>();
        }

        public int CatId { get; set; }
        public string CatName { get; set; }

        public ICollection<Subcategories> Subcategories { get; set; }
    }

}
