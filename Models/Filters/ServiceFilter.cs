using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Filters
{
    public class ServiceFilter
    {
        public string Name { get; set; }
        public string NameStartWith { get; set; }

        public string Description { get; set; }

        public double? Duration { get; set; }
        public double? DurationLowerThan { get; set; }
        public double? DurationUpperThan { get; set; }

        public double? Price { get; set; }
        public double? PriceLowerThan { get; set; }
        public double? PriceUpperThan { get; set; }
    }
}
