using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Repository.Abstract;
using Models.Filters;
using Models.Models;

namespace Repository.Concrete
{
    public class EmployeeRepository : ConnectionManager, IEmployeeRepository
    {
        public void Add(Employee emp)
        {
            try
            {
                ExecuteNonQuery(string.Format(
                "INSERT INTO Employee (emp_id, firstName, lastName, position, salary)" +
                "VALUES ({0}, '{1}', '{2}', '{3}', {4})",
                emp.emp_id, emp.firstName, emp.lastName, emp.position, Helper.ToMyString(emp.salary.ToString())));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
                Console.ReadKey();
            }
        }
        public void Delete(EmployeeFilter filter)
        {
            try
            {
                string cmd = "Delete from Employee ";

                List<string> wcmd = new List<string>();
                if (!String.IsNullOrEmpty(filter.FirstName))
                {
                    wcmd.Add("firstName LIKE '" + filter.FirstName + "%'");
                }
                if (!String.IsNullOrEmpty(filter.LastName))
                {
                    wcmd.Add("lastName LIKE '" + filter.LastName + "%'");
                }
                if (!String.IsNullOrEmpty(filter.Position))
                {
                    wcmd.Add("position LIKE '" + filter.Position + "%'");
                }
                if (filter.Salary.HasValue)
                {
                    wcmd.Add("salary = " + Helper.ToMyString(filter.Salary.ToString()));
                }
                if (filter.SalaryLowerThan.HasValue)
                {
                    wcmd.Add("salary < " + Helper.ToMyString(filter.SalaryLowerThan.ToString()));
                }
                if (filter.SalaryUpperThan.HasValue)
                {
                    wcmd.Add("salary > " + Helper.ToMyString(filter.SalaryUpperThan.ToString()));
                }
                if (wcmd.Count() > 0)
                {
                    cmd += "where " + string.Join(" AND ", wcmd.ToArray());
                }

                ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
                Console.ReadKey();
            }
        }
        public void Update(Employee emp, EmployeeFilter filter)
        {
            try
            {

                string cmd = string.Format("Update Employee set " +
                "emp_id = {0}, firstName = '{1}', lastName = '{2}', position = '{3}', salary = {4} ",
                emp.emp_id, emp.firstName, emp.lastName, emp.position, emp.salary);

                List<string> fcmd = new List<string>();
                if (!String.IsNullOrEmpty(filter.FirstName))
                {
                    fcmd.Add("firstName LIKE '" + filter.FirstName + "%'");
                }
                if (!String.IsNullOrEmpty(filter.LastName))
                {
                    fcmd.Add("lastName LIKE '" + filter.LastName + "%'");
                }
                if (!String.IsNullOrEmpty(filter.Position))
                {
                    fcmd.Add("position LIKE '" + filter.Position + "%'");
                }
                if (filter.Salary.HasValue)
                {
                    fcmd.Add("salary = " + Helper.ToMyString(filter.Salary.ToString()));
                }
                if (filter.SalaryLowerThan.HasValue)
                {
                    fcmd.Add("salary < " + Helper.ToMyString(filter.SalaryLowerThan.ToString()));
                }
                if (filter.SalaryUpperThan.HasValue)
                {
                    fcmd.Add("salary > " + Helper.ToMyString(filter.SalaryUpperThan.ToString()));
                }
                if (fcmd.Count() > 0)
                {
                    cmd += "where " + string.Join(" AND ", fcmd.ToArray());
                }

                ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
                Console.ReadKey();
            }
        }
        public void Select(EmployeeFilter filter)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Repository: EMPLOYEE\n\n");

                string cmd = "Select * from Employee ";

                List<string> wcmd = new List<string>();
                if (String.IsNullOrEmpty(filter.FirstName))
                {
                    wcmd.Add("firstName LIKE '" + filter.FirstName + "%'");
                }
                if (String.IsNullOrEmpty(filter.LastName))
                {
                    wcmd.Add("lastName LIKE '" + filter.LastName + "%'");
                }
                if (String.IsNullOrEmpty(filter.Position))
                {
                    wcmd.Add("position LIKE '" + filter.Position + "%'");
                }
                if (filter.Salary.HasValue)
                {
                    wcmd.Add("salary = " + Helper.ToMyString(filter.Salary.ToString()));
                }
                if (filter.SalaryLowerThan.HasValue)
                {
                    wcmd.Add("salary < " + Helper.ToMyString(filter.SalaryLowerThan.ToString()));
                }
                if (filter.SalaryUpperThan.HasValue)
                {
                    wcmd.Add("salary > " + Helper.ToMyString(filter.SalaryUpperThan.ToString()));
                }
                if (wcmd.Count() > 0)
                {
                    cmd += "where " + string.Join(" AND ", wcmd.ToArray());
                }

                List<Employee> empList = new List<Employee>();
                DbDataReader reader = ExecuteReader(cmd);
                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.emp_id = (long)reader["emp_id"];
                    emp.firstName = (string)reader["firstName"];
                    emp.lastName = (string)reader["lastName"];
                    emp.position = (string)reader["position"];
                    emp.salary = (double)reader["salary"];

                    empList.Add(emp);
                }

                Console.WriteLine("You can choose columns: emp_id, " +
                    "firstname, lastname, position, salary");
                Helper h = new Helper();
                int n = h.AmountOfColumns();
                List<string> columns = h.NamesOfColumns(n);
                WriteTable(n, empList, columns);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
                Console.ReadKey();
            }
        }

        public List<Employee> Get(EmployeeFilter filter)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Repository: EMPLOYEE\n\n");

                string cmd = "Select * from Employee ";

                List<string> wcmd = new List<string>();
                if (String.IsNullOrEmpty(filter.FirstName))
                {
                    wcmd.Add("firstName LIKE '" + filter.FirstName + "%'");
                }
                if (String.IsNullOrEmpty(filter.LastName))
                {
                    wcmd.Add("lastName LIKE '" + filter.LastName + "%'");
                }
                if (String.IsNullOrEmpty(filter.Position))
                {
                    wcmd.Add("position LIKE '" + filter.Position + "%'");
                }
                if (filter.Salary.HasValue)
                {
                    wcmd.Add("salary = " + Helper.ToMyString(filter.Salary.ToString()));
                }
                if (filter.SalaryLowerThan.HasValue)
                {
                    wcmd.Add("salary < " + Helper.ToMyString(filter.SalaryLowerThan.ToString()));
                }
                if (filter.SalaryUpperThan.HasValue)
                {
                    wcmd.Add("salary > " + Helper.ToMyString(filter.SalaryUpperThan.ToString()));
                }
                if (wcmd.Count() > 0)
                {
                    cmd += "where " + string.Join(" AND ", wcmd.ToArray());
                }

                List<Employee> empList = new List<Employee>();
                DbDataReader reader = ExecuteReader(cmd);
                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.emp_id = (long)reader["emp_id"];
                    emp.firstName = (string)reader["firstName"];
                    emp.lastName = (string)reader["lastName"];
                    emp.position = (string)reader["position"];
                    emp.salary = (double)reader["salary"];

                    empList.Add(emp);
                }

                return empList;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
                Console.ReadKey();
                return new List<Employee>();
            }
        }
        public Employee CreateModel()
        {
            Console.Clear();
            Console.WriteLine("Repository: EMPLOYEE\n\n");
            Console.WriteLine("SET\n");

            Employee employee = new Employee();

            Console.WriteLine("ID: ");
            employee.emp_id = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("FIRSTNAME: ");
            employee.firstName = Console.ReadLine();

            Console.WriteLine("LASTNAME: ");
            employee.lastName = Console.ReadLine();

            Console.WriteLine("POSITION: ");
            employee.position = Console.ReadLine();

            Console.WriteLine("SALARY: ");
            employee.salary = Convert.ToDouble(Console.ReadLine());

            return employee;
        }
        public EmployeeFilter CreateFilter()
        {
            Console.Clear();
            Console.WriteLine("Repository: EMPLOYEE\n\n");
            Console.WriteLine("Creating conditions for rows\n" +
                "You can skip some conditions\n" +
                "(select ... , where): ");

            EmployeeFilter filter = new EmployeeFilter();

            Console.WriteLine("FIRSTNAME: ");
            filter.FirstName = Console.ReadLine();

            Console.WriteLine("LASTNAME: ");
            filter.LastName = Console.ReadLine();

            Console.WriteLine("POSITION: ");
            filter.Position = Console.ReadLine();

            Console.WriteLine("SALARY: ");
            string a = Console.ReadLine();
            if (a != "") filter.Salary = Convert.ToDouble(a);

            Console.WriteLine("SALARY lower than: ");
            string b = Console.ReadLine();
            if (b != "") filter.SalaryLowerThan = Convert.ToDouble(b);

            Console.WriteLine("SALARY upper than: ");
            string c = Console.ReadLine();
            if (c != "") filter.SalaryUpperThan = Convert.ToDouble(c);

            return filter;
        }
        public void WriteTable(int n, List<Employee> list, List<string> columns)
        {
            Console.Clear();
            Console.WriteLine("Repository: EMPLOYEE\n\n");

            for (int k = 0; k < list.Count(); k++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (columns[i] == "EMP_ID")
                    {
                        Console.WriteLine(string.Format("ID: {0}", list[k].emp_id));
                    }
                    else if (columns[i] == "FIRSTNAME")
                    {
                        Console.WriteLine(string.Format("{0}: {1}", columns[i], list[k].firstName));
                    }
                    else if (columns[i] == "LASTNAME")
                    {
                        Console.WriteLine(string.Format("{0}: {1}", columns[i], list[k].lastName));
                    }
                    else if (columns[i] == "POSITION")
                    {
                        Console.WriteLine(string.Format("{0}: {1}", columns[i], list[k].position));
                    }
                    else if (columns[i] == "SALARY")
                    {
                        Console.WriteLine(string.Format("{0}: {1} UAH", columns[i], list[k].salary));
                    }
                }
                Console.WriteLine("\n");
            }
            Console.ReadKey();
        }
    }
}
