// <copyright file="AddressRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of AddressRepository class.</summary>

using System.Collections.Generic;
using System.Linq;

using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Repositories.Data
{
    /// <summary>
    /// Represent a <see cref="AddressRepository"/> class. Heir of <see cref="Repository{Address}"/>. Implementator of <see cref="IAddressRepository"/> interface.
    /// </summary>
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRepository"/> class.
        /// </summary>
        /// <param name="context">Context that provide connection to the database.</param>
        public AddressRepository(LibrarySystemDbContext context) : base(context)
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
        /// Provide collection of <see cref="Address"/> instances by a given CityName.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        /// <returns>Collection of all the <see cref="Addres"/> instances from the given city.</returns>
        public IEnumerable<Address> GetAllAddressesByGivenCityName(string cityName)
        {
            return this.Find(a => a.City.Name == cityName);
        }

        /// <summary>
        /// Provide <see cref="Address"/> instance by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the Address.</param>
        /// <returns>The <see cref="Addres"/> instance with a given PIN.</returns>
        public Address GetAddressByClientPIN(string pin)
        {
            return this.LibraryDbContext.Addresses.FirstOrDefault(a => a.Clients.Any(c => c.PIN == pin));
        }

        /// <summary>
        /// Provide <see cref="Address"/> instance by a given EmployeeId.
        /// </summary>
        /// <param name="id">Id of the <see cref="Employee"/>.</param>
        /// <returns><see cref="Addres"/> instance witch has an employee with provided id.</returns>
        public Address GetAddressByEmployeeId(int id)
        {
            return this.LibraryDbContext.Addresses.FirstOrDefault(a => a.Employees.Any(e => e.Id == id));
        }
    }
}
