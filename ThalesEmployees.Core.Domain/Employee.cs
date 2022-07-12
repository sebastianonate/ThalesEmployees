namespace ThalesEmployees.Core.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public string ProfileImage { get; set; }
        public decimal AnnualSalary => Salary * 12;
    }
}