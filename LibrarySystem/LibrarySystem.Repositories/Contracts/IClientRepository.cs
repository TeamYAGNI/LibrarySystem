using System.Collections.Generic;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;

namespace LibrarySystem.Repositories.Contracts
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClientsByStreetNameAndNumber(string streetName, int? number = default(int?));

        IEnumerable<Client> GetAllClientsFromCity(string cityName);

        string GetClientEmailByPIN(string PIN);

        string GetClientFullNameByPIN(string PIN);

        string GetClientPhoneByPIN(string PIN);

        IEnumerable<Client> GetClientsByGenderType(GenderType genderType);
    }
}