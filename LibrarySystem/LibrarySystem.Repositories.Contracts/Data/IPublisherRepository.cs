// <copyright file = "IPublisherRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of IPublisherRepository implementators.</summary>

using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Contracts.Data
{
    /// <summary>
    /// Represent a <see cref="IPublisherRepository"/> interface. Heir of <see cref="IRepository{Publisher}"/>
    /// </summary>
    public interface IPublisherRepository : IRepository<Publisher>
    {
        /// <summary>
        /// Provide a count of books of a specific publisher by a given name.
        /// </summary>
        /// <param name="publisherName">Name of the publisher.</param>
        /// <returns>Count of the books of the publisher with the given name.</returns>
        int GetBookCountByPublisherName(string publisherName);

        /// <summary>
        /// Provide a count of journals of a specific publisher by a given name.
        /// </summary>
        /// <param name="publisherName">Name of the publisher.</param>
        /// <returns>Count of the journals of the publisher with the given name.</returns>
        int GetJournalCountByPublisherName(string publisherName);

        /// <summary>
        /// Provide a publisher of a specific book by a given title.
        /// </summary>
        /// <param name="bookTitle">Title of the book.</param>
        /// <returns>Publisher of the book with the given title.</returns>
        Publisher GetPublisherByBookTitle(string bookTitle);

        /// <summary>
        /// Provide a publisher of a specific journal by a given title.
        /// </summary>
        /// <param name="journalTitle">Title of the journal.</param>
        /// <returns>Publisher of the journal with the given title.</returns>
        Publisher GetPublisherByJournalTitle(string journalTitle);

        /// <summary>
        /// Provide a publisher by a given name.
        /// </summary>
        /// <param name="publisherName">Name of the publisher.</param>
        /// <returns>Publisher with the given name.</returns>
        Publisher GetPublisherByName(string publisherName);
    }
}