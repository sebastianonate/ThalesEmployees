using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThalesEmployees.Core.Domain;
using ThalesEmployees.Core.Domain.Contracts;

namespace ThalesEmployees.Core.Tests.Fake
{
    public class FakeReadRepostoryEmployee : IReadRepositoryEmployee
    {
        private readonly List<Employee> _employees = new List<Employee>() {
            new Employee
            {
                Id = 1,
                Name = "Steban Manez",
                Age = 38,
                ProfileImage = "",
                Salary = 3000
            },

            new Employee
            {
                Id = 2,
                Name = "Hana Medina",
                Age = 40,
                ProfileImage = "",
                Salary = 3500
            },
            new Employee
            {
                Id = 3,
                Name = "Martha Valencia",
                Age = 35,
                ProfileImage = "",
                Salary = 2100
            },
        }; 
        public Task<List<Employee>> GetAllAsync()
        {
            return Task.FromResult(_employees);
        }

        public Task<Employee?> GetByIdAsync(int id)
        {
            return Task.FromResult(_employees.FirstOrDefault(x => x.Id == id)); 
        }
    }
}
