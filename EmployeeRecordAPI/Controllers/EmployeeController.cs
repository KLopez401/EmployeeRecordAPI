using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using EmployeeRecordAPI.UseCases.Employee.AddEmployee;
using EmployeeRecordAPI.UseCases.Employee.DeleteEmployee;
using EmployeeRecordAPI.UseCases.Employee.GetEmployees;
using EmployeeRecordAPI.UseCases.Employee.GetEmployeeById;
using EmployeeRecordAPI.UseCases.Employee.UpdateEmployee;

namespace EmployeeRecordAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IMediator mediator;

        public EmployeeController(IMediator mediator) => this.mediator = mediator;

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            var result = await mediator.Send(new GetEmployeesCommand());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployee(int id)
        {
            var result = await mediator.Send(new GetEmployeeByIdCommand(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] AddEmployeeDto dto)
        {
            var result = await mediator.Send(new AddEmployeeCommand(dto));

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id,  [FromBody] UpdateEmployeeDto dto)
        {
            var result = await mediator.Send(new UpdateEmployeeCommand(id, dto));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var result = await mediator.Send(new DeleteEmployeeCommand(id));

            return Ok(result);
        }
    }
}
