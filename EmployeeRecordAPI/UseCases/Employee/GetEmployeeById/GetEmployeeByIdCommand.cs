using EmployeeRecordAPI.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WatchPortal.Api.Source.Domain.BusinessRules;

namespace EmployeeRecordAPI.UseCases.Employee.GetEmployeeById
{
    public class GetEmployeeByIdCommand : IRequest<GetEmployeeByIdDto>
    {
        private int id;
        public GetEmployeeByIdCommand(int id) => this.id = id;

        private class GetEmployeeByIdCommandHandler : IRequestHandler<GetEmployeeByIdCommand, GetEmployeeByIdDto>
        {
            private readonly EmployeeContext employeeContext;
            public GetEmployeeByIdCommandHandler(EmployeeContext employeeContext) => this.employeeContext = employeeContext;

            public async Task<GetEmployeeByIdDto> Handle(GetEmployeeByIdCommand request, CancellationToken cancellationToken)
            {
                var employee = await employeeContext.Employees.FindAsync(request.id);
                if (employee == null)
                {
                    throw new RecordNotFoundException();
                }

                var result = new GetEmployeeByIdDto
                {
                    FirstName = employee.FirstName,
                    MiddleName = employee.MiddleName,
                    LastName = employee.LastName
                };

                return result;
            }
        }
    }
}
