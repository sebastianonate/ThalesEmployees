using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThalesEmployees.Core.Domain.Contracts;

namespace ThalesEmployees.Core.Application.Features.Queries
{
    public record GetAllEmployeeRequest : IRequest<List<EmployeeForGetAllDto>>;
    public record EmployeeForGetAllDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public string ProfileImage { get; set; }
        public decimal AnualSalary { get; set; }

    }
    public class GetAllEmployeesQuery : IRequestHandler<GetAllEmployeeRequest, List<EmployeeForGetAllDto>>
    {
        private readonly IReadRepositoryEmployee _readRepositoryEmployee;

        public GetAllEmployeesQuery(IReadRepositoryEmployee readRepositoryEmployee)
        {
            _readRepositoryEmployee = readRepositoryEmployee;
        }

        public async Task<List<EmployeeForGetAllDto>> Handle(GetAllEmployeeRequest request, CancellationToken cancellationToken)
        {
            return (await _readRepositoryEmployee.GetAllAsync()).Adapt<List<EmployeeForGetAllDto>>();
        }
    }
}
