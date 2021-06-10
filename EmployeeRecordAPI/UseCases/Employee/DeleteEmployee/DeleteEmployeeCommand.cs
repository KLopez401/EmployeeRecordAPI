using EmployeeRecordAPI.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WatchPortal.Api.Source.Domain.BusinessRules;

namespace EmployeeRecordAPI.UseCases.Employee.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest
    {
        private int id;
        public DeleteEmployeeCommand(int id) => this.id = id;

        private class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
        {
            private readonly EmployeeContext employeeContext;
            public DeleteEmployeeCommandHandler(EmployeeContext employeeContext) => this.employeeContext = employeeContext;

            public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var employee = await employeeContext.Employees.FindAsync(request.id);
                if (employee == null)
                {
                    throw new RecordNotFoundException();
                }

                employeeContext.Employees.Remove(employee);
                await employeeContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
