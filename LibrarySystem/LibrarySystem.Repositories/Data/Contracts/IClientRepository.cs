using System.Collections.Generic;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories.Data.Contracts
{
    public interface IClientRepository : IRepository<Client>
    {
        bool ClientHasJournal(string PIN);

        IEnumerable<Client> GetAllClientsByStreetNameAndNumber(string streetName, int? number = default(int?));

        IEnumerable<Client> GetAllClientsFromCity(string cityName);

        IEnumerable<Client> GetAllClientsWithJournals();

        string GetClientEmailByPIN(string PIN);

        string GetClientFullNameByPIN(string PIN);

        string GetClientPhoneByPIN(string PIN);

        IEnumerable<Client> GetClientsByGenderType(GenderType genderType);

        IEnumerable<Client> GetAllClientsWithLendings();

        IEnumerable<Client> GetAllClientsWithLendingsOlderThanAMonth();

        Client GetClientByPin(string PIN);
    }
}