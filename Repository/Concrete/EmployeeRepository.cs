using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Repository;
using Repository.Abstract;
using Models.Filters;
using Models.Models;

namespace Repository.Concrete
{
    public class EmployeeRepository : ConnectionManager, IEmployeeRepository
    {
        public void Add(Employee emp)
        {
            ExecuteNonQuery(string.Format(
                "INSERT INTO Employee (emp_id, firstName, lastName, position, salary)" +
                "VALUES ({0}, '{1}', '{2}', '{3}', {4})",
                emp.emp_id, emp.firstName, emp.lastName, emp.position, emp.salary));
        }

        public void Delete(EmployeeFilter filter)
        {
            string cmd = "Delete from Employee ";
            List<string> wcmd = new List<string>();

            if (!String.IsNullOrEmpty(filter.FirstName))
            {
                wcmd.Add("firstName = " + filter.FirstName);
            }

            if (!String.IsNullOrEmpty(filter.FirstNameStartWith))
            {
                wcmd.Add("firstName LIKE %" + filter.FirstNameStartWith + "%");
            }

            if (!String.IsNullOrEmpty(filter.LastName))
            {
                wcmd.Add("lastName = " + filter.LastName);
            }

            if (!String.IsNullOrEmpty(filter.LastNameStartWith))
            {
                wcmd.Add("lastName LIKE %" + filter.LastNameStartWith + "%");
            }

            if (!String.IsNullOrEmpty(filter.Position))
            {
                wcmd.Add("position = " + filter.Position);
            }

            if (filter.Salary.HasValue)
            {
                wcmd.Add("salary = " + filter.Salary);
            }

            if (filter.SalaryLowerThan.HasValue)
            {
                wcmd.Add("salary < " + filter.SalaryLowerThan);
            }

            if (filter.SalaryUpperThan.HasValue)
            {
                wcmd.Add("salary > " + filter.SalaryUpperThan);
            }

            if (wcmd.Count() > 0)
            {
                cmd += "where " + string.Join(" AND ", wcmd.ToArray());
            }

            ExecuteNonQuery(cmd);
        }

        public void Update(Employee emp, EmployeeFilter filter)
        {
            string cmd = string.Format("Update Employee set " +
                "emp_id = {0}, firstName = '{1}', lastName = '{2}', position = '{3}', salary = {4} ", 
                emp.emp_id, emp.firstName, emp.lastName, emp.position, emp.salary);

            List<string> fcmd = new List<string>();

            if (!String.IsNullOrEmpty(filter.FirstName))
            {
                fcmd.Add("firstName = " + filter.FirstName);
            }

            if (!String.IsNullOrEmpty(filter.FirstNameStartWith))
            {
                fcmd.Add("firstName LIKE %" + filter.FirstNameStartWith + "%");
            }

            if (!String.IsNullOrEmpty(filter.LastName))
            {
                fcmd.Add("lastName = " + filter.LastName);
            }

            if (!String.IsNullOrEmpty(filter.LastNameStartWith))
            {
                fcmd.Add("lastName LIKE %" + filter.LastNameStartWith + "%");
            }

            if (!String.IsNullOrEmpty(filter.Position))
            {
                fcmd.Add("position = " + filter.Position);
            }

            if (filter.Salary.HasValue)
            {
                fcmd.Add("salary = " + filter.Salary);
            }

            if (filter.SalaryLowerThan.HasValue)
            {
                fcmd.Add("salary < " + filter.SalaryLowerThan);
            }

            if (filter.SalaryUpperThan.HasValue)
            {
                fcmd.Add("salary > " + filter.SalaryUpperThan);
            }

            if (fcmd.Count() > 0)
            {
                cmd += "where " + string.Join(" AND ", fcmd.ToArray());
            }

            ExecuteNonQuery(cmd);
        }

        public List<Employee> Get(EmployeeFilter filter)
        {
            string cmd = "Select * from Employee ";
            List<string> wcmd = new List<string>();

            if (String.IsNullOrEmpty(filter.FirstName))
            {
                wcmd.Add("firstName = " + filter.FirstName);
            }

            if (String.IsNullOrEmpty(filter.FirstNameStartWith))
            {
                wcmd.Add("firstName LIKE %" + filter.FirstNameStartWith + "%");
            }

            if (String.IsNullOrEmpty(filter.LastName))
            {
                wcmd.Add("lastName = " + filter.LastName);
            }

            if (String.IsNullOrEmpty(filter.LastNameStartWith))
            {
                wcmd.Add("lastName LIKE %" + filter.LastNameStartWith + "%");
            }

            if (String.IsNullOrEmpty(filter.Position))
            {
                wcmd.Add("position = " + filter.Position);
            }

            if (filter.Salary.HasValue)
            {
                wcmd.Add("salary = " + filter.Salary);
            }

            if (filter.SalaryLowerThan.HasValue)
            {
                wcmd.Add("salary < " + filter.SalaryLowerThan);
            }

            if (filter.SalaryUpperThan.HasValue)
            {
                wcmd.Add("salary > " + filter.SalaryUpperThan);
            }

            if (wcmd.Count() > 0)
            {
                cmd += "where " + string.Join(" AND ", wcmd.ToArray());
            }

            List<Employee> empList = new List<Employee>();
            DbDataReader reader = ExecuteReader(cmd);
            while(reader.Read())
            {
                Employee emp = new Employee();
                emp.firstName = (string)reader["firstName"];
                emp.lastName = (string)reader["lastName"];
                emp.position = (string)reader["position"];
                emp.salary = (double)reader["salary"];

                empList.Add(emp);
            }
            RefreshDataReader();

            return empList;
        }
    }
}
