// <copyright file="ClientRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of ClientRepository class.</summary>

using System.Collections.Generic;
using System.Linq;

using LibrarySystem.Data;
using LibrarySystem.Framework.Providers;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Repositories.Data
{
    /// <summary>
    /// Represent a <see cref="ClientRepository"/> class. Heir of <see cref="Repository{Client}"/>.
    /// Implementator of <see cref="IClientRepository"/> interface.
    /// </summary>
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientRepository"/> class.
        /// </summary>
        /// <param name="context">Context that provide connection to the database.</param>
        public ClientRepository(LibrarySystemDbContext context) : base(context)
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
        /// Provide collection of clients by a given GenderType.
        /// </summary>
        /// <param name="genderType">GenderType of the clients.</param>
        /// <returns>Collection of the clients with the given GenderType.</returns>
        public IEnumerable<Client> GetClientsByGenderType(GenderType genderType)
        {
            return this.LibraryDbContext.Clients.Where(c => c.GenderType == genderType).ToList();
        }

        /// <summary>
        /// Provide full name of a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Full name of the client with the given PIN.</returns>
        public string GetClientFullNameByPIN(string pin)
        {
            return this.LibraryDbContext.Clients
                .Where(c => c.PIN == pin)
                .Select(c => c.FirstName + " " + c.LastName)
                .FirstOrDefault();
        }

        /// <summary>
        /// Provide email of a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Email of the client with the given PIN.</returns>
        public string GetClientEmailByPIN(string pin)
        {
            return this.LibraryDbContext.Clients
                .Where(c => c.PIN == pin)
                .Select(c => c.Email)
                .FirstOrDefault();
        }

        /// <summary>
        /// Provide phone number of a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Phone number of the client with the given PIN.</returns>
        public string GetClientPhoneByPIN(string pin)
        {
            return this.LibraryDbContext.Clients
                .Where(c => c.PIN == pin)
                .Select(c => c.Phone)
                .FirstOrDefault();
        }

        /// <summary>
        /// Provide collection of clients from a specific city by a given city name.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        /// <returns>Collection of clients from the city.</returns>
        public IEnumerable<Client> GetAllClientsFromCity(string cityName)
        {
            return this.LibraryDbContext.Clients.Where(c => c.Address.City.Name == cityName).ToList();
        }

        /// <summary>
        /// Provide collection of clients by given street name and number.
        /// </summary>
        /// <param name="streetName">Name of the street.</param>
        /// <param name="streetNumber">Number of the street.</param>
        /// <returns>Collection of the clients from the given address.</returns>
        public IEnumerable<Client> GetAllClientsByStreetNameAndNumber(string streetName, int? streetNumber = null)
        {
            return this.LibraryDbContext.Clients
                .Where(c => c.Address.Street == streetName && c.Address.StreetNumber == streetNumber).ToList();
        }

        /// <summary>
        /// Provide collection of clients borrowed journals.
        /// </summary>
        /// <returns>Collection of the clients that had not return journals.</returns>
        public IEnumerable<Client> GetAllClientsWithJournals()
        {
            return this.LibraryDbContext.Clients.Where(c => c.Journals.Count > 0).ToList();
        }

        /// <summary>
        /// Provide wether a specific client has borrowed a jornal by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Wether the client has borrowed a jornal.</returns>
        public bool ClientHasJournal(string pin)
        {
            return this.LibraryDbContext.Clients.FirstOrDefault(c => c.PIN == pin)?.Journals.Count > 0;
        }

        /// <summary>
        /// Provide collection of clients borrowed Books.
        /// </summary>
        /// <returns>Collection of the clients borrowed Books.</returns>
        public IEnumerable<Client> GetAllClientsWithLendings()
        {
            return this.LibraryDbContext.Clients.Where(c => c.Lendings.Any(l => l.ClientId == c.Id)).ToList();
        }

        /// <summary>
        /// Provide collection of clients borrowed Books over a month ago.
        /// </summary>
        /// <returns>Collection of the clients borrowed Books over a month ago.</returns>
        public IEnumerable<Client> GetAllClientsWithLendingsOlderThanAMonth()
        {
            return this.LibraryDbContext.Clients.Where(
                c => c.Lendings.Any(l => l.BorrоwDate.AddMonths(1) < TimeProvider.Current.Today && l.ReturnDate == null)).ToList();
        }

        /// <summary>
        /// Provide a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Client with the given PIN.</returns>
        public Client GetClientByPin(string pin)
        {
            return this.LibraryDbContext.Clients.FirstOrDefault(c => c.PIN == pin);
        }
    }
}
