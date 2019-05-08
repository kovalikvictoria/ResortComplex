using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Filters;
using Models.Models;
using Repository.Concrete;
using Services.Abstract;

namespace Services.Concrete
{
    public class EmployeeServices : IEmployeeServices
    {
        public double MinSalary()
        {
            List<Employee> employees = new EmployeeRepository().Get(new EmployeeFilter());
            double minSalary = employees[0].salary;
            for (int i = 1; i < employees.Count; i++)
                if (employees[i].salary < minSalary)
                    minSalary = employees[i].salary;
            return minSalary;
        }
        public double MaxSalary()
        {
            List<Employee> employees = new EmployeeRepository().Get(new EmployeeFilter());
            double maxSalary = employees[0].salary;
            for (int i = 1; i < employees.Count; i++)
                if (employees[i].salary > maxSalary)
                    maxSalary = employees[i].salary;
            return maxSalary;
        }
    }
}
