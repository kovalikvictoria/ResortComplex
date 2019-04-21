using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Filters
{
    public class RoomFilter
    {
        public int? Number { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public int? Places { get; set; }

        public double? Price { get; set; }
        public double? PriceLowerThan { get; set; }
        public double? PriceUpperThan { get; set; }

        public string Status { get; set; }

        public string AssignedTo { get; set; }
    }
}
