using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bytes2you.Validation;
using LibrarySystem.Commands.Administrative.Listings.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Administrative.Listings.Employee
{
    public class GetAllEmployeesByManagerNameCommand : IAdministratorCommand
    {
        private readonly IEmployeeRepository employeesRepository;

        public GetAllEmployeesByManagerNameCommand(IEmployeeRepository employeesRepository)
        {
            Guard.WhenArgument(employeesRepository, "employeesRepository").IsNull().Throw();

            this.employeesRepository = employeesRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var managerFirstName = parameters[0];
            var managerLastName = parameters[1];

            var employees = this.employeesRepository.GetAllEmployeesByManagerName(managerFirstName, managerLastName);

            if (employees.Count() == 0)
            {
                return $"Manager {managerFirstName} {managerLastName} has no employees.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"* Employees of {managerFirstName} {managerLastName}");
            foreach (var employee in employees)
            {
                sb.AppendLine($"* Employee FullName: {employee.FullName}");
                sb.AppendLine($"* Employee JobTitle: {employee.JobTitle.ToString()}");
            }

            return sb.ToString();
        }
    }
}
