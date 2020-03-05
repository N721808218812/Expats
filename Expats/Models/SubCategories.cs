using System;
using System.Collections.Generic;

namespace Expats.Models
{
    public partial class SubCategories
    {
        public SubCategories()
        {
            List = new HashSet<List>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Idcategory { get; set; }

        public Categories IdcategoryNavigation { get; set; }
        public ICollection<List> List { get; set; }
    }
}
