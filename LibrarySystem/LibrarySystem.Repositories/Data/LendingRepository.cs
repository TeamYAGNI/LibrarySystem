// <copyright file="LendingRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of LendingRepository class.</summary>

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using LibrarySystem.Data;
using LibrarySystem.Framework.Providers;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Repositories.Data
{
    /// <summary>
    /// Represent a <see cref="LendingRepository"/> class. Heir of <see cref="Repository{Lending}"/>.
    /// Implementator of <see cref="ILendingRepository"/> interface.
    /// </summary>
    public class LendingRepository : Repository<Lending>, ILendingRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LendingRepository"/> class.
        /// </summary>
        /// <param name="context">Context that provide connection to the database.</param>
        public LendingRepository(LibrarySystemDbContext context) : base(context)
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
        /// Provide collection of lendings borrowed more than a month ago.
        /// </summary>
        /// <returns>Collection of all lendings borrowed more than a month ago.</returns>
        public IEnumerable<Lending> GetLendingsOlderThanAMonth()
        {
            return this.Find(l => l.BorrоwDate.AddMonths(1) < TimeProvider.Current.Today);
        }

        /// <summary>
        /// Provide collection of not returned lendings of a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Collection of all not returned lendings of the client with the given PIN.</returns>
        public IEnumerable<Lending> GetLendingsByClientPIN(string pin)
        {
            return this.LibraryDbContext.Lendings.Include(l => l.Book)
                .Where(l => l.Client.PIN == pin && l.ReturnDate == null).ToList();
        }

        /// <summary>
        /// Provide collection of all return lendings of a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Collection of all returned lendings of the client with the given PIN.</returns>
        public IEnumerable<Lending> GetLendingsHistoryByClientPIN(string pin)
        {
            return this.LibraryDbContext.Lendings.Where(l => l.Client.PIN == pin && l.ReturnDate != null).ToList();
        }

        /// <summary>
        /// Provide collection of lendings of a specific book by a given ISBN.
        /// </summary>
        /// <param name="isbn">ISBN of the book.</param>
        /// <returns>Collection of all lendings of the book with the given ISBN.</returns>
        public IEnumerable<Lending> GetLendingsByBookISBN(string isbn)
        {
            return this.LibraryDbContext.Lendings.Where(l => l.Book.ISBN == isbn).ToList();
        }

        /// <summary>
        /// Provide collection of lendings with remarks.
        /// </summary>
        /// <returns>Collection of all lendings with remarks.</returns>
        public IEnumerable<Lending> GetAllLendingsWithRemarks()
        {
            return this.Find(l => l.Remarks != null);
        }

        /// <summary>
        /// Provide collection of remarks from lendings of a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Collection of all remarks related to the client with the given PIN.</returns>
        public IEnumerable<string> GetAllLendingsRemarksByClientPIN(string pin)
        {
            return this.LibraryDbContext.Lendings.Include(l => l.Book).Where(l => l.Client.PIN == pin)
                .Select(l => l.Remarks).ToList();
        }
    }
}
