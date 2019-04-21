using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Models.Filters;

namespace Repository.Abstract
{
    public interface IServiceRepository
    {
        void Add(Service service);
        void Delete(ServiceFilter filter);
        void Update(Service service, ServiceFilter filter);
        
        List<Service> Get(ServiceFilter filter);
    }
}
