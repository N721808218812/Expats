using System;
using System.Collections.Generic;

namespace Expats.Models
{
    public partial class List
    {
        public List()
        {
            Details = new HashSet<Details>();
        }

        public int Id { get; set; }
        public int Idcategory { get; set; }
        public int? Idsubcategory { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public Categories IdcategoryNavigation { get; set; }
        public SubCategories IdsubcategoryNavigation { get; set; }
        public ICollection<Details> Details { get; set; }
    }
}
