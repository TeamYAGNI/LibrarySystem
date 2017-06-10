using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(LibrarySystemDbContext context) : base(context)
        {
        }

        private LibrarySystemDbContext LibraryDbContext
        {
            get
            {
                return this.Context as LibrarySystemDbContext;
            }
        }

        public IEnumerable<City> GetCitiesByName(string cityName)
        {
            return this.Find(c => c.Name == cityName);
        }

        public City GetCityByClientPIN(string PIN)
        {
            return this.LibraryDbContext.Cities.FirstOrDefault(
                c => c.Addresses.Any(a => a.Clients.Any(cl => cl.PIN == PIN)));
        }

        public City GetCityByEmployeeId(int id)
        {
            return this.LibraryDbContext.Cities.FirstOrDefault(
                c => c.Addresses.Any(a => a.Employees.Any(e => e.Id == id)));
        }

        public IEnumerable<City> GetCitiesByStreetName(string streetName)
        {
            return this.Find(c => c.Addresses.Any(a => a.Street == streetName));
        }
    }
}
