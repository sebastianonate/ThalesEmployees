using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThalesEmployees.Core.Application.Exceptions;
using ThalesEmployees.Core.Domain.Contracts;

namespace ThalesEmployees.Core.Application.Features.Commands
{
    public record CalculateAnnualSalaryByEmployeeRequest(int EmployeeId) : IRequest<decimal>;
    public class CalculateAnnualSalaryByEmployeeCommand : IRequestHandler<CalculateAnnualSalaryByEmployeeRequest, decimal>
    {
        private readonly IReadRepositoryEmployee _readRepositoryEmployee;

        public CalculateAnnualSalaryByEmployeeCommand(IReadRepositoryEmployee readRepositoryEmployee)
        {
            _readRepositoryEmployee = readRepositoryEmployee;
        }

        public async Task<decimal> Handle(CalculateAnnualSalaryByEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = await _readRepositoryEmployee.GetByIdAsync(request.EmployeeId);
            _ = employee ?? throw new NotFoundException("Employee not found");

            return employee.AnnualSalary;
        }
    }
}
