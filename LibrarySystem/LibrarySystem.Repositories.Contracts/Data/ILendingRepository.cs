// <copyright file = "ILendingRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of ILendingRepository implementators.</summary>

using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Contracts.Data
{
    /// <summary>
    /// Represent a <see cref="ILendingRepository"/> interface. Heir of <see cref="IRepository{Lending}"/>
    /// </summary>
    public interface ILendingRepository : IRepository<Lending>
    {
        /// <summary>
        /// Provide collection of remarks from lendings of a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Collection of all remarks related to the client with the given PIN.</returns>
        IEnumerable<string> GetAllLendingsRemarksByClientPIN(string pin);

        /// <summary>
        /// Provide collection of lendings with remarks.
        /// </summary>
        /// <returns>Collection of all lendings with remarks.</returns>
        IEnumerable<Lending> GetAllLendingsWithRemarks();

        /// <summary>
        /// Provide collection of lendings of a specific book by a given ISBN.
        /// </summary>
        /// <param name="isbn">ISBN of the book.</param>
        /// <returns>Collection of all lendings of the book with the given ISBN.</returns>
        IEnumerable<Lending> GetLendingsByBookISBN(string isbn);

        /// <summary>
        /// Provide collection of not returned lendings of a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Collection of all not returned lendings of the client with the given PIN.</returns>
        IEnumerable<Lending> GetLendingsByClientPIN(string pin);

        /// <summary>
        /// Provide collection of all return lendings of a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Collection of all returned lendings of the client with the given PIN.</returns>
        IEnumerable<Lending> GetLendingsHistoryByClientPIN(string pin);

        /// <summary>
        /// Provide collection of lendings borrowed more than a month ago.
        /// </summary>
        /// <returns>Collection of all lendings borrowed more than a month ago.</returns>
        IEnumerable<Lending> GetLendingsOlderThanAMonth();
    }
}