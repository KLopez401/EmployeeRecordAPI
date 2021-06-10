using EmployeeRecordAPI.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WatchPortal.Api.Source.Domain.BusinessRules;

namespace EmployeeRecordAPI.UseCases.Employee.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest
    {
        private int id;
        private UpdateEmployeeDto dto;
        public UpdateEmployeeCommand(int id, UpdateEmployeeDto dto)
        {
            this.id = id;
            this.dto = dto;
        }

        private class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
        {
            private readonly EmployeeContext employeeContext;
            public UpdateEmployeeCommandHandler(EmployeeContext employeeContext) => this.employeeContext = employeeContext;

            public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = await employeeContext.Employees.FindAsync(request.id);
                if (employee == null)
                {
                    throw new RecordNotFoundException();
                }

                employee.FirstName = request.dto.FirstName;
                employee.MiddleName = request.dto.MiddleName;
                employee.LastName = request.dto.LastName;

                await employeeContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
