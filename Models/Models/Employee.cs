using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Employee
    {
    //  Create table Employee
    //  (
    //      emp_id bigserial PRIMARY KEY,
    //      firstName varchar(20),
    //	    lastName varchar(20),
    //   	position varchar(30),
    //  	salary money
    //   );

        public long emp_id;
        public string firstName;
        public string lastName;
        public string position;
        public double salary;

        public Employee(long emp_id = 0, string firstName = "", 
                        string lastName = "", string position = "", 
                        double salary = 0.0)
        {
            this.emp_id = emp_id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.position = position;
            this.salary = salary;
        }
    }
}
