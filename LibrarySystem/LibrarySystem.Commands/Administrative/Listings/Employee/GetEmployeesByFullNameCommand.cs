﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bytes2you.Validation;
using LibrarySystem.Commands.Administrative.Listings.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Administrative.Listings.Employee
{
    public class GetEmployeesByFullNameCommand : IAdministratorCommand
    {
        private readonly IEmployeeRepository employeesRepository;

        public GetEmployeesByFullNameCommand(IEmployeeRepository employeesRepository)
        {
            Guard.WhenArgument(employeesRepository, "employeesRepository").IsNull().Throw();

            this.employeesRepository = employeesRepository;
        }

        public string Execute(IList<string> parameters)
        {
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
