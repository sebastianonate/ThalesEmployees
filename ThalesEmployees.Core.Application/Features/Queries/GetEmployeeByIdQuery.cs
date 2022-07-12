using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThalesEmployees.Core.Application.Exceptions;
using ThalesEmployees.Core.Domain.Contracts;

namespace ThalesEmployees.Core.Application.Features.Queries
{
    public record GetEmployeeByIdRequest(int Id) : IRequest<GetEmployeeByIdResponse>;
    public record GetEmployeeByIdResponse 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public string ProfileImage { get; set; }
        public decimal AnnualSalary { get; set; }
    }
    public class GetEmployeeByIdQuery : IRequestHandler<GetEmployeeByIdRequest, GetEmployeeByIdResponse>
    {
        private readonly IReadRepositoryEmployee _readRepositoryEmployee;

        public GetEmployeeByIdQuery(IReadRepositoryEmployee readRepositoryEmployee)
        {
            _readRepositoryEmployee = readRepositoryEmployee;
        }

        public async Task<GetEmployeeByIdResponse> Handle(GetEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            var employee = await _readRepositoryEmployee.GetByIdAsync(request.Id);
            _ = employee ?? throw new NotFoundException("Not found");

            return employee.Adapt<GetEmployeeByIdResponse>();
        }
    }
}
