using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Filters
{
    public class EmployeeFilter
    {
        public string FirstName { get; set; }
        public string FirstNameStartWith { get; set; }

        public string LastName { get; set; }
        public string LastNameStartWith { get; set; }

        public string Position { get; set; }

        public double? Salary { get; set; }
        public double? SalaryUpperThan { get; set; }
        public double? SalaryLowerThan { get; set; }
    }
}
