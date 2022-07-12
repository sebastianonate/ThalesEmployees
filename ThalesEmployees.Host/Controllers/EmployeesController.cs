using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThalesEmployees.Core.Application.Features.Queries;
using ThalesEmployees.Core.Domain;
using ThalesEmployees.Core.Domain.Contracts;

namespace ThalesEmployees.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<EmployeeForGetAllDto>> GetAll()
        {
            return await _mediator.Send(new GetAllEmployeeRequest());
        }
    }
}