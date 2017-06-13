// <copyright file="JournalRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of JournalRepository class.</summary>

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Repositories.Data
{
    /// <summary>
    /// Represent a <see cref="JournalRepository"/> class. Heir of <see cref="Repository{Journal}"/>.
    /// Implementator of <see cref="IJournalRepository"/> interface.
    /// </summary>
    public class JournalRepository : Repository<Journal>, IJournalRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JournalRepository"/> class.
        /// </summary>
        /// <param name="context">Context that provide connection to the database.</param>
        public JournalRepository(LibrarySystemDbContext context) : base(context)
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
        /// Provide a journal by a given ISSN.
        /// </summary>
        /// <param name="issn">ISSN of the journal.</param>
        /// <returns>Journal with the given ISSN.</returns>
        public Journal FindJournalByISSN(string issn)
        {
            return this.LibraryDbContext.Journals
                .FirstOrDefault(j => j.ISSN == issn);
        }

        /// <summary>
        /// Provide collection of journal by a given title.
        /// </summary>
        /// <param name="title">Title of the journal.</param>
        /// <returns>Collection of the journal with the given title.</returns>
        public IEnumerable<Journal> FindJournalsByTitle(string title)
        {
            return this.Find(j => j.Title == title);
        }

        /// <summary>
        /// Provide issue number of a specific journal by a given ISSN.
        /// </summary>
        /// <param name="issn">ISSN of the journal.</param>
        /// <returns>Issue number of the journal with the given ISSN.</returns>
        public int GetIssueNumberByISSN(string issn)
        {
            return this.LibraryDbContext.Journals
                .Where(j => j.ISSN == issn)
                .Select(j => j.IssueNumber)
                .FirstOrDefault();
        }

        /// <summary>
        /// Provide number of copies of a specific journal by a given ISSN.
        /// </summary>
        /// <param name="issn">ISSN of the journal.</param>
        /// <returns>Number of copies of the journal with the given ISSN.</returns>
        public int GetInitialQuantityByISSN(string issn)
        {
            return this.LibraryDbContext.Journals
                .Where(j => j.ISSN == issn)
                .Select(j => j.Quantity)
                .FirstOrDefault();
        }

        /// <summary>
        /// Provide number of available copies of a specific journal by a given ISSN.
        /// </summary>
        /// <param name="issn">ISSN of the journal.</param>
        /// <returns>Number of available copies of the journal with the given ISSN.</returns>
        public int GetAvailableQuantityByISSN(string issn)
        {
            return this.LibraryDbContext.Journals
                .Where(j => j.ISSN == issn)
                .Select(j => j.Available)
                .FirstOrDefault();
        }

        /// <summary>
        /// Provide collection of journals related to a specific subject by a given subject name.
        /// </summary>
        /// <param name="subjectName">Name of the subject</param>
        /// <returns>Collection of all journals related to the subject with the given name.</returns>
        public IEnumerable<Journal> GetJournalsBySubject(string subjectName)
        {
            return this.LibraryDbContext.Journals.Where(j => j.Subjects.Any(s => s.Name == subjectName)).ToList();
        }

        /// <summary>
        /// Provide collection of journals by a given publisher name.
        /// </summary>
        /// <param name="publisherName">Name of the publisher.</param>
        /// <returns>Collection of the journals of the publisher with the given name.</returns>
        public IEnumerable<Journal> GetJournalsByPublisherName(string publisherName)
        {
            return this.Find(j => j.Publisher.Name == publisherName);
        }

        /// <summary>
        /// Provide collection of journals by a given year of publishing.
        /// </summary>
        /// <param name="yearOfPublishing">Year when the journal have been published.</param>
        /// <returns>Collection of the journals from the given year of publishing.</returns>
        public IEnumerable<Journal> GetAllJournalsByYearOfPublishing(int yearOfPublishing)
        {
            return this.Find(j => j.YearOfPublishing == yearOfPublishing);
        }

        /// <summary>
        /// Provide collection of journals by given publisher name and year of publishing.
        /// </summary>
        /// <param name="publisherName">Name of the publisher.</param>
        /// <param name="yearOfPublishing">Year when the journal have been published.</param>
        /// <returns>Collection of the journals of the publisher with the given name and the year of publishing.</returns>
        public IEnumerable<Journal> GetAllJournalsByPublisherAndYearOfPublishing(string publisherName, int yearOfPublishing)
        {
            return this.Find(j => j.Publisher.Name == publisherName && j.YearOfPublishing == yearOfPublishing);
        }

        /// <summary>
        /// Provide collection of the five topmost journals, ordered by impact factor.
        /// </summary>
        /// <returns>Collection of at most five journals, ordered by impact factor.</returns>
        public IEnumerable<Journal> GetTop5JournalsOrderedByImpactFactor()
        {
            return this.LibraryDbContext.Journals
                .Where(j => j.ImpactFactor != null)
                .OrderByDescending(j => j.ImpactFactor)
                .Take(5)
                .ToList();
        }

        /// <summary>
        /// Provide collection of journals that are not available.
        /// </summary>
        /// <returns>Collection of all unavailable journals.</returns>
        public IEnumerable<Journal> GetAllJournalsThatAreInUse()
        {
            return this.Find(j => j.Quantity != j.Available);
        }

        /// <summary>
        /// Provide collection of journals borrowed by a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Collection of the journals borrowed by the client with the given PIN.</returns>
        public IEnumerable<Journal> GetAllClientJournals(string pin)
        {
            return this.LibraryDbContext.Journals.Include(j => j.Client).Where(j => j.Client.PIN == pin).ToList();
        }

        public override IEnumerable<Journal> GetAll()
        {
            return this.LibraryDbContext.Journals.Include(j => j.Publisher).Include(j => j.Subjects).ToList();
        }
    }
}
