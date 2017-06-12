// <copyright file="CityRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of CityRepository class.</summary>

using System.Collections.Generic;
using System.Linq;

using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Repositories.Data
{
    /// <summary>
    /// Represent a <see cref="CityRepository"/> class. Heir of <see cref="Repository{City}"/>.
    /// Implementator of <see cref="ICityRepository"/> interface.
    /// </summary>
    public class CityRepository : Repository<City>, ICityRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CityRepository"/> class.
        /// </summary>
        /// <param name="context">Context that provide connection to the database.</param>
        public CityRepository(LibrarySystemDbContext context) : base(context)
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
        /// Provide collection of cities by a given name.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        /// <returns>Collection of the cities with the given name.</returns>
        public IEnumerable<City> GetCitiesByName(string cityName)
        {
            return this.Find(c => c.Name == cityName);
        }

        /// <summary>
        /// Provide a city of a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>City of the client with the given PIN.</returns>
        public City GetCityByClientPIN(string pin)
        {
            return this.LibraryDbContext.Cities.FirstOrDefault(
                c => c.Addresses.Any(a => a.Clients.Any(cl => cl.PIN == pin)));
        }

        /// <summary>
        /// Provide a city of a specific employee by a given Id.
        /// </summary>
        /// <param name="id">Id of the employee.</param>
        /// <returns>City of the employee with the given Id.</returns>
        public City GetCityByEmployeeId(int id)
        {
            return this.LibraryDbContext.Cities.FirstOrDefault(
                c => c.Addresses.Any(a => a.Employees.Any(e => e.Id == id)));
        }

        /// <summary>
        /// Provide collection of cities by a given street name.
        /// </summary>
        /// <param name="streetName">Name of the street.</param>
        /// <returns>Collection of the cities with the given street name.</returns>
        public IEnumerable<City> GetCitiesByStreetName(string streetName)
        {
            return this.Find(c => c.Addresses.Any(a => a.Street == streetName));
        }
    }
}
