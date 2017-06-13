using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Administrative.Listings.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Administrative.Listings.Employee
{
    public class GetEmployeesByFullNameCommand : Command, IAdministratorCommand
    {
        private readonly IEmployeeRepository employeesRepository;

        public GetEmployeesByFullNameCommand(IEmployeeRepository employeesRepository) : base(new List<object>() { employeesRepository }, 2)
        {
            this.employeesRepository = employeesRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var employeeFirstName = parameters[0];
            var employeeLastName = parameters[1];

            var employees = this.employeesRepository.GetEmployeesByFullName(employeeFirstName, employeeLastName);

            if (employees.Count() == 0)
            {
                return $"There is no employee with name {employeeFirstName} {employeeLastName}";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"* Employees with Name {employeeFirstName} {employeeLastName}:");
            foreach (var employee in employees)
            {
                sb.AppendLine($"* Employee FullName: {employee.FullName}");
                sb.AppendLine($"* Employee JobTitle: {employee.JobTitle.ToString()}");
            }

            return sb.ToString();
        }
    }
}
