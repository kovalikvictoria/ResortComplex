using Models.Filters;
using Models.Models;
using Repository.Concrete;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class ServiceServices : IServiceServices
    {
        public double MinPrice()
        {
            List<Service> services = new ServiceRepository().Get(new ServiceFilter());
            double minPrice = services[0].price;
            for (int i = 1; i < services.Count; i++)
                if (services[i].price < minPrice)
                    minPrice = services[i].price;
            return minPrice;
        }
        public double MaxPrice()
        {
            List<Service> services = new ServiceRepository().Get(new ServiceFilter());
            double maxPrice = services[0].price;
            for (int i = 1; i < services.Count; i++)
                if (services[i].price < maxPrice)
                    maxPrice = services[i].price;
            return maxPrice;
        }
    }
}
