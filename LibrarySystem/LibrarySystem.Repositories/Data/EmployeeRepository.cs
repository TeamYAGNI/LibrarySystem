// <copyright file="EmployeeRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of EmployeeRepository class.</summary>

using System.Collections.Generic;
using System.Linq;

using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Repositories.Data
{
    /// <summary>
    /// Represent a <see cref="EmployeeRepository"/> class. Heir of <see cref="Repository{Employee}"/>. Implementator of <see cref="IEmployeeRepository"/> interface.
    /// </summary>
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// </summary>
        /// <param name="context">Context that provide connection to the database.</param>
        public EmployeeRepository(LibrarySystemDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets the context as a <see cref="LibrarySystemDbContext"/>.
        /// </summary>
        private LibrarySystemDbContext LibraryDbContext
        {
            get
            {
                return this.Context as LibrarySystemDbContext;
            }
        }

        /// <summary>
        /// Provide collection of employees by given first and last names.
        /// </summary>
        /// <param name="firstName">First name of the employee.</param>
        /// <param name="lastName">Last name of the employee.</param>
        /// <returns>Collection of the employees with the names.</returns>
        public IEnumerable<Employee> GetEmployeesByFullName(string firstName, string lastName)
        {
            return this.Find(e => e.FirstName == firstName && e.LastName == lastName);
        }

        /// <summary>
        /// Provide collection of employees by a given JobTytle.
        /// </summary>
        /// <param name="jobTitle">JobTitle of the employees.</param>
        /// <returns>Collection of the employees with the given JobTitle.</returns>
        public IEnumerable<Employee> GetEmployeesByJobTitle(JobTitle jobTitle)
        {
            return this.Find(e => e.JobTitle == jobTitle);
        }

        /// <summary>
        /// Provide collection of employees by a given GenderType.
        /// </summary>
        /// <param name="genderType">GenderType of the employees.</param>
        /// <returns>Collection of the employees with the given GenderType.</returns>
        public IEnumerable<Employee> GetEmployeesByGenderType(GenderType genderType)
        {
            return this.Find(e => e.GenderType == genderType);
        }

        /// <summary>
        /// Provide collection of employees witch have a manager.
        /// </summary>
        /// <returns>Collection of the employees witch have a manager.</returns>
        public IEnumerable<Employee> GetAllEmployeesWhoHaveManager()
        {
            return this.Find(e => e.ReportsTo != null);
        }
        
        /// <summary>
        /// Provide collection of employees witch have not a manager.
        /// </summary>
        /// <returns>Collection of the employees witch have not a manager.</returns>
        public IEnumerable<Employee> GetAllEmployeesWithoutManager()
        {
            return this.Find(e => e.ReportsTo == null);
        }

        /// <summary>
        /// Provide collection of employees by a given ManagerName.
        /// </summary>
        /// <param name="managerFirstName">First name of the manager.</param>
        /// <param name="managerLastName">Last name of the manager.</param>
        /// <returns>collection of the employees with the given ManagerName.</returns>
        public IEnumerable<Employee> GetAllEmployeesByManagerName(string managerFirstName, string managerLastName)
        {
            var manager =
                this.LibraryDbContext.Employees.FirstOrDefault(
                    e => e.FirstName == managerFirstName && e.LastName == managerLastName);

            return (manager != null) ? this.Find(e => e.ReportsTo.Id == manager.Id) : new List<Employee>();
        }

        /// <summary>
        /// Provide collection of employees from a specific city by given city name.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        /// <returns>Collection of the employees from the city with the given city name.</returns>
        public IEnumerable<Employee> GetAllEmployeesFromCity(string cityName)
        {
            return this.Find(e => e.Address.City.Name == cityName);
        }

        /// <summary>
        /// Provide collection of employees by given street name and number.
        /// </summary>
        /// <param name="streetName">Name of the street.</param>
        /// <param name="streetNumber">Number of the street.</param>
        /// <returns>Collection of the employees from the given address.</returns>
        public IEnumerable<Employee> GetAllEmployeesByStreetNameAndNumber(string streetName, int? streetNumber = null)
        {
            return this.Find(e => e.Address.Street == streetName && e.Address.StreetNumber == streetNumber);
        }

        /// <summary>
        /// Provide collection of employees by given JobTitle, city name and GenderType.
        /// </summary>
        /// <param name="jobTitle">JobTitle of the employees.</param>
        /// <param name="cityName">City name of the employees.</param>
        /// <param name="genderType">GenderType of the employees.</param>
        /// <returns>Collection of the employees with the given JobTitle, city name and GenderType.</returns>
        public IEnumerable<Employee> GetAllEmployeesByJobTitleCityNameAndGenderType(JobTitle jobTitle, string cityName, GenderType genderType)
        {
            return this.Find(e => e.JobTitle == jobTitle && e.Address.City.Name == cityName &&
                                  e.GenderType == genderType);
        }
    }
}
