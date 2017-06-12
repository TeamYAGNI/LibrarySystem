using System.Collections.Generic;
using System.Linq;
using System.Text;

using LibrarySystem.Commands.Administrative.Listings.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Administrative.Listings.Employee
{
    public class GetAllEmployeesWithoutManagerCommand : IAdministratorCommand
    {
        private readonly IEmployeeRepository employeesRepository;

        public GetAllEmployeesWithoutManagerCommand(IEmployeeRepository employeesRepository)
        {
            this.employeesRepository = employeesRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var employees = this.employeesRepository.GetAllEmployeesWithoutManager();

            if (employees.Count() == 0)
            {
                return $"There are no employees without manager.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"* Employees without manager: ");
            foreach (var employee in employees)
            {
                sb.AppendLine($"* Employee FullName: {employee.FullName}");
                sb.AppendLine($"* Employee JobTitle: {employee.JobTitle.ToString()}");
            }

            return sb.ToString();
        }
    }
}
