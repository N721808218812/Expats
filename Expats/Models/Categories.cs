using System;
using System.Collections.Generic;

namespace Expats.Models
{
    public partial class Categories
    {
        public Categories()
        {
            List = new HashSet<List>();
            SubCategories = new HashSet<SubCategories>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<List> List { get; set; }
        public ICollection<SubCategories> SubCategories { get; set; }
    }
}
