// <copyright file = "IClientRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of IClientRepository implementators.</summary>

using System.Collections.Generic;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;

namespace LibrarySystem.Repositories.Contracts.Data
{
    /// <summary>
    /// Represent a <see cref="IClientRepository"/> interface. Heir of <see cref="IRepository{Client}"/>
    /// </summary>
    public interface IClientRepository : IRepository<Client>
    {
        /// <summary>
        /// Provide wether a specific client has borrowed a jornal by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Wether the client has borrowed a jornal.</returns>
        bool ClientHasJournal(string pin);

        /// <summary>
        /// Provide collection of clients by given street name and number.
        /// </summary>
        /// <param name="streetName">Name of the street.</param>
        /// <param name="number">Number of the street.</param>
        /// <returns>Collection of the clients from the given address.</returns>
        IEnumerable<Client> GetAllClientsByStreetNameAndNumber(string streetName, int? number = default(int?));

        /// <summary>
        /// Provide collection of clients from a specific city by a given city name.
        /// </summary>
        /// <param name="cityName">Name of the city.</param>
        /// <returns>Collection of clients from the city.</returns>
        IEnumerable<Client> GetAllClientsFromCity(string cityName);

        /// <summary>
        /// Provide collection of clients borrowed journals.
        /// </summary>
        /// <returns>Collection of the clients that had not return journals.</returns>
        IEnumerable<Client> GetAllClientsWithJournals();

        /// <summary>
        /// Provide email of a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Email of the client with the given PIN.</returns>
        string GetClientEmailByPIN(string pin);

        /// <summary>
        /// Provide full name of a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Full name of the client with the given PIN.</returns>
        string GetClientFullNameByPIN(string pin);

        /// <summary>
        /// Provide phone number of a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Phone number of the client with the given PIN.</returns>
        string GetClientPhoneByPIN(string pin);

        /// <summary>
        /// Provide collection of clients by a given GenderType.
        /// </summary>
        /// <param name="genderType">GenderType of the clients.</param>
        /// <returns>Collection of the clients with the given GenderType.</returns>
        IEnumerable<Client> GetClientsByGenderType(GenderType genderType);

        /// <summary>
        /// Provide collection of clients borrowed Books.
        /// </summary>
        /// <returns>Collection of the clients borrowed Books.</returns>
        IEnumerable<Client> GetAllClientsWithLendings();

        /// <summary>
        /// Provide collection of clients borrowed Books over a month ago.
        /// </summary>
        /// <returns>Collection of the clients borrowed Books over a month ago.</returns>
        IEnumerable<Client> GetAllClientsWithLendingsOlderThanAMonth();

        /// <summary>
        /// Provide a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Client with the given PIN.</returns>
        Client GetClientByPin(string pin);
    }
}