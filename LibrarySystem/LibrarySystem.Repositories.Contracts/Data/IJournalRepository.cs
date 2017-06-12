// <copyright file = "IJournalRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of IJournalRepository implementators.</summary>

using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Contracts.Data
{
    /// <summary>
    /// Represent a <see cref="IJournalRepository"/> interface. Heir of <see cref="IRepository{Journal}"/>
    /// </summary>
    public interface IJournalRepository : IRepository<Journal>
    {
        /// <summary>
        /// Provide a journal by a given ISSN.
        /// </summary>
        /// <param name="isbn">ISSN of the journal.</param>
        /// <returns>Journal with the given ISSN.</returns>
        Journal FindJournalByISSN(string isbn);

        /// <summary>
        /// Provide collection of journal by a given title.
        /// </summary>
        /// <param name="title">Title of the journal.</param>
        /// <returns>Collection of the journal with the given title.</returns>
        IEnumerable<Journal> FindJournalsByTitle(string title);

        /// <summary>
        /// Provide collection of journals by given publisher name and year of publishing.
        /// </summary>
        /// <param name="publisherName">Name of the publisher.</param>
        /// <param name="yearOfPublishing">Year when the journal have been published.</param>
        /// <returns>Collection of the journals of the publisher with the given name and the year of publishing.</returns>
        IEnumerable<Journal> GetAllJournalsByPublisherAndYearOfPublishing(string publisherName, int yearOfPublishing);

        /// <summary>
        /// Provide collection of journals by a given year of publishing.
        /// </summary>
        /// <param name="yearOfPublishing">Year when the journal have been published.</param>
        /// <returns>Collection of the journals from the given year of publishing.</returns>
        IEnumerable<Journal> GetAllJournalsByYearOfPublishing(int yearOfPublishing);

        /// <summary>
        /// Provide collection of journals that are not available.
        /// </summary>
        /// <returns>Collection of all unavailable journals.</returns>
        IEnumerable<Journal> GetAllJournalsThatAreInUse();

        /// <summary>
        /// Provide number of available copies of a specific journal by a given ISSN.
        /// </summary>
        /// <param name="isbn">ISSN of the journal.</param>
        /// <returns>Number of available copies of the journal with the given ISSN.</returns>
        int GetAvailableQuantityByISSN(string isbn);

        /// <summary>
        /// Provide number of copies of a specific journal by a given ISSN.
        /// </summary>
        /// <param name="isbn">ISSN of the journal.</param>
        /// <returns>Number of copies of the journal with the given ISSN.</returns>
        int GetInitialQuantityByISSN(string isbn);

        /// <summary>
        /// Provide issue number of a specific journal by a given ISSN.
        /// </summary>
        /// <param name="isbn">ISSN of the journal.</param>
        /// <returns>Issue number of the journal with the given ISSN.</returns>
        int GetIssueNumberByISSN(string isbn);

        /// <summary>
        /// Provide collection of journals by a given publisher name.
        /// </summary>
        /// <param name="publisherName">Name of the publisher.</param>
        /// <returns>Collection of the journals of the publisher with the given name.</returns>
        IEnumerable<Journal> GetJournalsByPublisherName(string publisherName);

        /// <summary>
        /// Provide collection of journals related to a specific subject by a given subject name.
        /// </summary>
        /// <param name="subjectName">Name of the subject</param>
        /// <returns>Collection of all journals related to the subject with the given name.</returns>
        IEnumerable<Journal> GetJournalsBySubject(string subjectName);

        /// <summary>
        /// Provide collection of the five topmost journals, ordered by impact factor.
        /// </summary>
        /// <returns>Collection of at most five journals, ordered by impact factor.</returns>
        IEnumerable<Journal> GetTop5JournalsOrderedByImpactFactor();

        /// <summary>
        /// Provide collection of journals borrowed by a specific client by a given PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Collection of the journals borrowed by the client with the given PIN.</returns>
        IEnumerable<Journal> GetAllClientJournals(string pin);
    }
}