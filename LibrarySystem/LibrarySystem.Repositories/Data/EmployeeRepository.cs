using System.Collections.Generic;
using System.Linq;

using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Repositories.Data
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(LibrarySystemDbContext context) : base(context)
        {
        }

        private LibrarySystemDbContext LibraryDbContext
        {
            get
            {
                return this.Context as LibrarySystemDbContext;
            }
        }

        public IEnumerable<Employee> GetEmployeesByFullName(string firstName, string lastName)
        {
            return this.Find(e => e.FirstName == firstName && e.LastName == lastName);
        }

        public IEnumerable<Employee> GetEmployeesByJobTitle(JobTitle jobTitle)
        {
            return this.Find(e => e.JobTitle == jobTitle);
        }

        public IEnumerable<Employee> GetEmployeesByGenderType(GenderType genderType)
        {
            return this.Find(e => e.GenderType == genderType);
        }

        public IEnumerable<Employee> GetAllEmployeesWhoHaveManager()
        {
            return this.Find(e => e.ReportsTo != null);
        }

        public IEnumerable<Employee> GetAllEmployeesWithoutManager()
        {
            return this.Find(e => e.ReportsTo == null);
        }

        public IEnumerable<Employee> GetAllEmployeesByManagerName(string managerFirstName, string managerLastName)
        {
            var manager =
                this.LibraryDbContext.Employees.FirstOrDefault(
                    e => e.FirstName == managerFirstName && e.LastName == managerLastName);

            return (manager != null) ? this.Find(e => e.ReportsTo.Id == manager.Id) : new List<Employee>();
        }

        public IEnumerable<Employee> GetAllEmployeesFromCity(string cityName)
        {
            return this.Find(e => e.Address.City.Name == cityName);
        }

        public IEnumerable<Employee> GetAllEmployeesByStreetNameAndNumber(string streetName, int? streetNumber = null)
        {
            return this.Find(e => e.Address.Street == streetName && e.Address.StreetNumber == streetNumber);
        }

        public IEnumerable<Employee> GetAllEmployeesByJobTitleCityNameAndGenderType(JobTitle jobTitle, string cityName, GenderType genderType)
        {
            return this.Find(e => e.JobTitle == jobTitle && e.Address.City.Name == cityName &&
                                  e.GenderType == genderType);
        }
    }
}
