using System;
using System.Collections.Generic;

namespace Expats.Models
{
    public partial class Details
    {
        public int Id { get; set; }
        public int Idlist { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Other { get; set; }

        public List IdlistNavigation { get; set; }
    }
}
