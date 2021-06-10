using EmployeeRecordAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeRecordAPI.UseCases.Employee.GetEmployees
{
    public class GetEmployeesCommand : IRequest<List<GetEmployeesDto>>
    {
        private class GetEmployeesCommandHandler : IRequestHandler<GetEmployeesCommand, List<GetEmployeesDto>>
        {
            private readonly EmployeeContext employeeContext;
            public GetEmployeesCommandHandler(EmployeeContext employeeContext) => this.employeeContext = employeeContext;

            public async Task<List<GetEmployeesDto>> Handle(GetEmployeesCommand request, CancellationToken cancellationToken)
            {
                var employees = await employeeContext.Employees
                    .OrderByDescending(e => e.Id)
                    .Select(o => new GetEmployeesDto
                    {
                        FirstName = o.FirstName,
                        MiddleName = o.MiddleName,
                        LastName = o.LastName
                    })
                    .ToListAsync();

                return employees;
            }
        }
    }
}
