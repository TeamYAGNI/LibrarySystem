// <copyright file = "IAddressRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of IAddressRepository implementators.</summary>

using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Contracts.Data
{
    /// <summary>
    /// Represent a <see cref="IAddressRepository"/> interface. Heir of <see cref="IRepository{Address}"/>
    /// </summary>
    public interface IAddressRepository : IRepository<Address>
    {
        /// <summary>
        /// Provide <see cref="Address"/> instance by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the Address.</param>
        /// <returns>The <see cref="Addres"/> instance with a given PIN.</returns>
        Address GetAddressByClientPIN(string pin);

        /// <summary>
        /// Provide <see cref="Address"/> instance by a given EmployeeId.
        /// </summary>
        /// <param name="id">Id of the <see cref="Employee"/>.</param>
        /// <returns><see cref="Addres"/> instance witch has an employee with provided id.</returns>
        Address GetAddressByEmployeeId(int id);

        /// <summary>
        /// Provide collection of <see cref="Address"/> instances by a given CityName.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        /// <returns>Collection of all the <see cref="Addres"/> instances from the given city.</returns>
        IEnumerable<Address> GetAllAddressesByGivenCityName(string cityName);
    }
}