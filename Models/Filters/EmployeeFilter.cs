namespace Models.Filters
{
    public class EmployeeFilter
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Position { get; set; }

        public double? Salary { get; set; }
        public double? SalaryUpperThan { get; set; }
        public double? SalaryLowerThan { get; set; }
    }
}
