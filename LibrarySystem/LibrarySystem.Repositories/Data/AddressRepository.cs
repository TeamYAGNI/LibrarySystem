using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Data.Contracts;

namespace LibrarySystem.Repositories.Data
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(LibrarySystemDbContext context) : base(context)
        {
        }

        private LibrarySystemDbContext LibraryDbContext
        {
            get
            {
                return this.Context as LibrarySystemDbContext;
            }
        }

        public IEnumerable<Address> GetAllAddressesByGivenCityName(string cityName)
        {
            return this.Find(a => a.City.Name == cityName);
        }

        public Address GetAddressByClientPIN(string PIN)
        {
            return this.LibraryDbContext.Addresses.FirstOrDefault(a => a.Clients.Any(c => c.PIN == PIN));
        }

        public Address GetAddressByEmployeeId(int id)
        {
            return this.LibraryDbContext.Addresses.FirstOrDefault(a => a.Employees.Any(e => e.Id == id));
        }
    }
}
