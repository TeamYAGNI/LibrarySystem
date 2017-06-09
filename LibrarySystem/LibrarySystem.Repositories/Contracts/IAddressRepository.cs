using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Contracts
{
    public interface IAddressRepository : IRepository<Address>
    {
        Address GetAddressByClientPIN(string PIN);

        Address GetAddressByEmployeeId(int id);

        IEnumerable<Address> GetAllAddressesByGivenCityName(string cityName);
    }
}