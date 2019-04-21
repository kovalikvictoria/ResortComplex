using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Models.Filters;

namespace Repository.Abstract
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        void Delete(EmployeeFilter filter);
        void Update(Employee emp, EmployeeFilter filter);
        
        List<Employee> Get(EmployeeFilter filter);
    }
}
