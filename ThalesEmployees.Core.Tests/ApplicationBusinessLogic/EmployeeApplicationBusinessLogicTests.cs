using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThalesEmployees.Core.Application.Features.Commands;
using ThalesEmployees.Core.Application.Features.Queries;
using ThalesEmployees.Core.Domain.Contracts;
using ThalesEmployees.Core.Tests.Fake;

namespace ThalesEmployees.Core.Tests.ApplicationBusinessLogic
{
    public class EmployeeApplicationBusinessLogicTests
    {
        private IReadRepositoryEmployee _readRepositoryEmployee;


        [SetUp]
        public void Setup()
        {
            _readRepositoryEmployee = new FakeReadRepostoryEmployee();
        }

        [Test]
        public async Task CanGetAllEmployees()
        {
            // Arrange
            var query = new GetAllEmployeesQuery(_readRepositoryEmployee);

            // Act
            var result = await query.Handle(new GetAllEmployeesRequest(), default);
            
            // Assert
            result.Should().HaveCountGreaterThan(0);
            result.First().Name.Should().NotBeNullOrWhiteSpace();
        }

        [Test]
        public async Task CanGetEmployeeById()
        {
            // Arrange
            var query = new GetEmployeeByIdQuery(_readRepositoryEmployee);

            // Act
            var result = await query.Handle(new GetEmployeeByIdRequest(1), default);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("Steban Manez");
        }


        [Test]
        public async Task CanCalculateAnnualSalary()
        {
            // Arrange
            var query = new CalculateEmployeeAnnualSalaryCommand();

            // Act
            var result = await query.Handle(new CalculateAnnualSalaryRequest(2000), default);

            // Assert
            result.Should().NotBe(0);
            result.Should().Be(24000);
        }

        [Test]
        public async Task CanCalculateAnnualSalaryOfAEmployeeById()
        {
            // Arrange
            var query = new CalculateAnnualSalaryByEmployeeCommand(_readRepositoryEmployee);

            // Act
            var result = await query.Handle(new CalculateAnnualSalaryByEmployeeRequest(1), default);

            // Assert
            result.Should().NotBe(0);
            result.Should().Be(36000);
        }

    }
}
