using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(LibrarySystemDbContext context) : base(context)
        {
        }

        private LibrarySystemDbContext LibraryDbContext
        {
            get
            {
                return this.Context as LibrarySystemDbContext;
            }
        }

        public IEnumerable<Client> GetClientsByGenderType(GenderType genderType)
        {
            return this.LibraryDbContext.Clients.Where(c => c.GenderType == genderType).ToList();
        }

        public string GetClientFullNameByPIN(string PIN)
        {
            return this.LibraryDbContext.Clients
                .Where(c => c.PIN == PIN)
                .Select(c => c.FirstName + " " + c.LastName)
                .FirstOrDefault();
        }

        public string GetClientEmailByPIN(string PIN)
        {
            return this.LibraryDbContext.Clients
                .Where(c => c.PIN == PIN)
                .Select(c => c.Email)
                .FirstOrDefault();
        }

        public string GetClientPhoneByPIN(string PIN)
        {
            return this.LibraryDbContext.Clients
                .Where(c => c.PIN == PIN)
                .Select(c => c.Phone)
                .FirstOrDefault();
        }

        public IEnumerable<Client> GetAllClientsFromCity(string cityName)
        {
            return this.LibraryDbContext.Clients.Where(c => c.Address.City.Name == cityName).ToList();
        }

        public IEnumerable<Client> GetAllClientsByStreetNameAndNumber(string streetName, int? number = null)
        {
            return this.LibraryDbContext.Clients
                .Where(c => c.Address.Street == streetName && c.Address.StreetNumber == number).ToList();
        }

        public IEnumerable<Client> GetAllClientsWithJournals()
        {
            return this.LibraryDbContext.Clients.Where(c => c.Journals.Count > 0).ToList();
        }

        public bool ClientHasJournal(string PIN)
        {
            return this.LibraryDbContext.Clients.FirstOrDefault(c => c.PIN == PIN)?.Journals.Count > 0;
        }
    }
}
