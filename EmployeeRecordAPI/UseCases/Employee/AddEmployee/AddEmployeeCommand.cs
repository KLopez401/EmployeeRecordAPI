using EmployeeRecordAPI.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeRecordAPI.UseCases.Employee.AddEmployee
{
    public class AddEmployeeCommand : IRequest
    {
        private AddEmployeeDto dto;

        public AddEmployeeCommand(AddEmployeeDto dto) => this.dto = dto;
        private class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand>
        {
            private readonly EmployeeContext employeeContext;
            public AddEmployeeCommandHandler(EmployeeContext employeeContext) => this.employeeContext = employeeContext;

            public async Task<Unit> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
            {

                employeeContext.Employees.Add(new Models.Employee
                {
                    FirstName = request.dto.FirstName,
                    MiddleName = request.dto.MiddleName,
                    LastName = request.dto.LastName
                });

                await employeeContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
