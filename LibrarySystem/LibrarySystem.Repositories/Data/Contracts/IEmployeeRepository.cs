using System.Collections.Generic;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories.Data.Contracts
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetAllEmployeesByJobTitleCityNameAndGenderType(JobTitle jobTitle, string cityName, GenderType genderType);

        IEnumerable<Employee> GetAllEmployeesByManagerName(string managerFirstName, string managerLastName);

        IEnumerable<Employee> GetAllEmployeesByStreetNameAndNumber(string streetName, int? streetNumber = default(int?));

        IEnumerable<Employee> GetAllEmployeesFromCity(string cityName);

        IEnumerable<Employee> GetAllEmployeesWhoHaveManager();

        IEnumerable<Employee> GetAllEmployeesWithoutManager();

        IEnumerable<Employee> GetEmployeesByFullName(string firstName, string lastName);

        IEnumerable<Employee> GetEmployeesByGenderType(GenderType genderType);

        IEnumerable<Employee> GetEmployeesByJobTitle(JobTitle jobTitle);
    }
}