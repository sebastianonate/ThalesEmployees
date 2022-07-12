using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThalesEmployees.Core.Domain;

namespace ThalesEmployees.Core.Tests.DomainBusinessLogic
{

    public class EmployeeDomainBusinessLogicTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CanCalculateEmployeeAnnualSalary()
        {
            // Arrange
            var employee = new Employee
            {
                Id = 1,
                Name = "Testing Employee",
                Age = 21,
                ProfileImage = "",
                Salary = 1500
            };

            // Act
            var annualSalary = employee.GetAnnualSalary();

            // Assert
            annualSalary.Should().Be(18000);
        }
    }
}
