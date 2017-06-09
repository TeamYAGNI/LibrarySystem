using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Contracts
{
    public interface ICityRepository : IRepository<City>
    {
        IEnumerable<City> GetCitiesByName(string cityName);

        IEnumerable<City> GetCitiesByStreetName(string streetName);

        City GetCityByClientPIN(string PIN);

        City GetCityByEmployeeId(int id);
    }
}