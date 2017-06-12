// <copyright file = "ICityRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of ICityRepository implementators.</summary>

using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Contracts.Data
{
    /// <summary>
    /// Represent a <see cref="ICityRepository"/> interface. Heir of <see cref="IRepository{City}"/>
    /// </summary>
    public interface ICityRepository : IRepository<City>
    {
        /// <summary>
        /// Provide collection of cities by a given name.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        /// <returns>Collection of the cities with the given name.</returns>
        IEnumerable<City> GetCitiesByName(string cityName);

        /// <summary>
        /// Provide collection of cities by a given street name.
        /// </summary>
        /// <param name="streetName">Name of the street.</param>
        /// <returns>Collection of the cities with the given street name.</returns>
        IEnumerable<City> GetCitiesByStreetName(string streetName);

        /// <summary>
        /// Provide a city of a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>City of the client with the given PIN.</returns>
        City GetCityByClientPIN(string pin);

        /// <summary>
        /// Provide a city of a specific employee by a given Id.
        /// </summary>
        /// <param name="id">Id of the employee.</param>
        /// <returns>City of the employee with the given Id.</returns>
        City GetCityByEmployeeId(int id);
    }
}