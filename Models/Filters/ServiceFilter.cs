using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Filters
{
    public class ServiceFilter
    {
        public string name { get; set; }

        public string description { get; set; }
        
        public double? price { get; set; }
        public double? priceLowerThan { get; set; }
        public double? priceUpperThan { get; set; }
    }
}
