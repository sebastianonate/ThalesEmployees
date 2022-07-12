using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThalesEmployees.Core.Application.Features.Commands
{
    public record CalculateAnnualSalaryRequest(decimal Salary) : IRequest<decimal>;

    public class CalculateEmployeeAnnualSalaryCommand : IRequestHandler<CalculateAnnualSalaryRequest, decimal>
    {
        public Task<decimal> Handle(CalculateAnnualSalaryRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request.Salary * 12);
        }
    }
}
