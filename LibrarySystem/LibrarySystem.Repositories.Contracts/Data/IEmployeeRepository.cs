// <copyright file = "IEmployeeRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of IEmployeeRepository implementators.</summary>

using System.Collections.Generic;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;

namespace LibrarySystem.Repositories.Contracts.Data
{
    /// <summary>
    /// Represent a <see cref="IEmployeeRepository"/> interface. Heir of <see cref="IRepository{Employee}"/>
    /// </summary>
    public interface IEmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        /// Provide collection of employees by given JobTitle, city name and GenderType.
        /// </summary>
        /// <param name="jobTitle">JobTitle of the employees.</param>
        /// <param name="cityName">City name of the employees.</param>
        /// <param name="genderType">GenderType of the employees.</param>
        /// <returns>Collection of the employees with the given JobTitle, city name and GenderType.</returns>
        IEnumerable<Employee> GetAllEmployeesByJobTitleCityNameAndGenderType(JobTitle jobTitle, string cityName, GenderType genderType);

        /// <summary>
        /// Provide collection of employees by a given ManagerName.
        /// </summary>
        /// <param name="managerFirstName">First name of the manager.</param>
        /// <param name="managerLastName">Last name of the manager.</param>
        /// <returns>collection of the employees with the given ManagerName.</returns>
        IEnumerable<Employee> GetAllEmployeesByManagerName(string managerFirstName, string managerLastName);

        /// <summary>
        /// Provide collection of employees by given street name and number.
        /// </summary>
        /// <param name="streetName">Name of the street.</param>
        /// <param name="streetNumber">Number of the street.</param>
        /// <returns>Collection of the employees from the given address.</returns>
        IEnumerable<Employee> GetAllEmployeesByStreetNameAndNumber(string streetName, int? streetNumber = default(int?));

        /// <summary>
        /// Provide collection of employees from a specific city by given city name.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        /// <returns>Collection of the employees from the city with the given city name.</returns>
        IEnumerable<Employee> GetAllEmployeesFromCity(string cityName);

        /// <summary>
        /// Provide collection of employees witch have a manager.
        /// </summary>
        /// <returns>Collection of the employees witch have a manager.</returns>
        IEnumerable<Employee> GetAllEmployeesWhoHaveManager();

        /// <summary>
        /// Provide collection of employees witch have not a manager.
        /// </summary>
        /// <returns>Collection of the employees witch have not a manager.</returns>
        IEnumerable<Employee> GetAllEmployeesWithoutManager();

        /// <summary>
        /// Provide collection of employees by given first and last names.
        /// </summary>
        /// <param name="firstName">First name of the employee.</param>
        /// <param name="lastName">Last name of the employee.</param>
        /// <returns>Collection of the employees with the names.</returns>
        IEnumerable<Employee> GetEmployeesByFullName(string firstName, string lastName);

        /// <summary>
        /// Provide collection of employees by a given GenderType.
        /// </summary>
        /// <param name="genderType">GenderType of the employees.</param>
        /// <returns>Collection of the employees with the given GenderType.</returns>
        IEnumerable<Employee> GetEmployeesByGenderType(GenderType genderType);

        /// <summary>
        /// Provide collection of employees by a given JobTytle.
        /// </summary>
        /// <param name="jobTitle">JobTitle of the employees.</param>
        /// <returns>Collection of the employees with the given JobTitle.</returns>
        IEnumerable<Employee> GetEmployeesByJobTitle(JobTitle jobTitle);
    }
}