// <copyright file="PublisherRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of PublisherRepository class.</summary>

using System.Linq;

using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Repositories.Data
{
    /// <summary>
    /// Represent a <see cref="PublisherRepository"/> class. Heir of <see cref="Repository{Publisher}"/>.
    /// Implementator of <see cref="IPublisherRepository"/> interface.
    /// </summary>
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PublisherRepository"/> class.
        /// </summary>
        /// <param name="context">Context that provide connection to the database.</param>
        public PublisherRepository(LibrarySystemDbContext context) : base(context)
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
        /// Provide a publisher by a given name.
        /// </summary>
        /// <param name="publisherName">Name of the publisher.</param>
        /// <returns>Publisher with the given name.</returns>
        public Publisher GetPublisherByName(string publisherName)
        {
            return this.LibraryDbContext.Publishers.FirstOrDefault(p => p.Name == publisherName);
        }

        /// <summary>
        /// Provide a count of books of a specific publisher by a given name.
        /// </summary>
        /// <param name="publisherName">Name of the publisher.</param>
        /// <returns>Count of the books of the publisher with the given name.</returns>
        public int GetBookCountByPublisherName(string publisherName)
        {
            return this.LibraryDbContext.Publishers
                .Where(p => p.Name == publisherName)
                .Select(p => p.Books)
                .Count();
        }

        /// <summary>
        /// Provide a count of journals of a specific publisher by a given name.
        /// </summary>
        /// <param name="publisherName">Name of the publisher.</param>
        /// <returns>Count of the journals of the publisher with the given name.</returns>
        public int GetJournalCountByPublisherName(string publisherName)
        {
            return this.LibraryDbContext.Publishers
                .Where(p => p.Name == publisherName)
                .Select(p => p.Journals)
                .Count();
        }

        /// <summary>
        /// Provide a publisher of a specific book by a given title.
        /// </summary>
        /// <param name="bookTitle">Title of the book.</param>
        /// <returns>Publisher of the book with the given title.</returns>
        public Publisher GetPublisherByBookTitle(string bookTitle)
        {
            return this.Find(a => a.Books.Any(b => b.Title == bookTitle)).FirstOrDefault();
        }

        /// <summary>
        /// Provide a publisher of a specific journal by a given title.
        /// </summary>
        /// <param name="journalTitle">Title of the journal.</param>
        /// <returns>Publisher of the journal with the given title.</returns>
        public Publisher GetPublisherByJournalTitle(string journalTitle)
        {
            return this.Find(a => a.Books.Any(b => b.Title == journalTitle)).FirstOrDefault();
        }
    }
}
