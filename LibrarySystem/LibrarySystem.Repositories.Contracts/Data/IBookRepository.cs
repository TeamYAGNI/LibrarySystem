// <copyright file = "IBookRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of IBookRepository implementators.</summary>

using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Contracts.Data
{
    /// <summary>
    /// Represent a <see cref="IBookRepository"/> interface. Heir of <see cref="IRepository{Book}"/>
    /// </summary>
    public interface IBookRepository : IRepository<Book>
    {
        /// <summary>
        /// Provide collection of books of a specific genre by a given name.
        /// </summary>
        /// <param name="genreName">Name of the genre.</param>
        /// <returns>Collection of the books of the genre with the given name.</returns>
        IEnumerable<Book> GetBooksByGenreName(string genreName);

        /// <summary>
        /// Provide collection of books borrowed by a specific client by PIN but not returned.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Collection of books lended by the client.</returns>
        IEnumerable<Book> GetBooksLendedByClient(string pin);

        /// <summary>
        /// Provide collection of books borowed and returned by a specific client by PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Collection of books returned by the client.</returns>
        IEnumerable<Book> GetBooksLendingHistoryForClient(string pin);

        /// <summary>
        /// Provide collection of all books borowed and not returned yet.
        /// </summary>
        /// <returns>collection of all borowed books.</returns>
        IEnumerable<Book> GetAllBooksInUse();

        /// <summary>
        /// Provide the number of available copy of specific book by given ISBN.
        /// </summary>
        /// <param name="isbn">ISBN of the Book.</param>
        /// <returns>Number of available copy of the book.</returns>
        int GetAvailableQuantityByISBN(string isbn);

        /// <summary>
        /// Provide a Book by given ISBN.
        /// </summary>
        /// <param name="isbn">ISBN of the Book.</param>
        /// <returns>Book with the given ISBN if exist. Otherwise <see cref="null"/>.</returns>
        Book GetBookByISBN(string isbn);

        /// <summary>
        /// Provide specific book description by a given ISBN.
        /// </summary>
        /// <param name="isbn">ISBN of the Book.</param>
        /// <returns>Description of the book with the given ISBN, if exist. Otherwise <see cref="null"/>.</returns>
        string GetBookDescriptionByISBN(string isbn);

        /// <summary>
        /// Provide collection of books written by a specific author by given first and last names.
        /// </summary>
        /// <param name="authorFirstName">First name of the author.</param>
        /// <param name="authorLastName">Last name of the author.</param>
        /// <returns>Collection of the books by the author.</returns>
        IEnumerable<Book> GetBooksByAuthor(string authorFirstName, string authorLastName);

        /// <summary>
        /// Provide collection of books published by a specific publisher by a given publisher's name.
        /// </summary>
        /// <param name="publisherName">Name of the publisher.</param>
        /// <returns>Collection of the books of the published.</returns>
        IEnumerable<Book> GetBooksByPublisher(string publisherName);

        /// <summary>
        /// Provide collection of books with specific author and publisher by given names.
        /// </summary>
        /// <param name="publisherName">Name of the publisher.</param>
        /// <param name="authorFirstName">First name of the author.</param>
        /// <param name="authorLastName">Last name of the author.</param>
        /// <returns>Collection of all books of the author and publisher.</returns>
        IEnumerable<Book> GetBooksByPublisherAndAuthor(string publisherName, string authorFirstName, string authorLastName);

        /// <summary>
        /// Provide collection of books by a given title.
        /// </summary>
        /// <param name="title">Title of the book.</param>
        /// <returns>collection of the books with the given title.</returns>
        IEnumerable<Book> GetBooksByTitle(string title);

        /// <summary>
        /// Provide numder of copies of a specific book by a given ISBN. 
        /// </summary>
        /// <param name="isbn">ISBN of the Book.</param>
        /// <returns>Numder of the copies of the book.</returns>
        int GetInitialQuantityByISBN(string isbn);

        /// <summary>
        /// Provide the most recent book of specific author by given first and last names.
        /// </summary>
        /// <param name="authorFirstName">First name of the author.</param>
        /// <param name="authorLastName">Last name of the author.</param>
        /// <returns>The most recent book written by the author</returns>
        Book GetMostRecentBookByAuthor(string authorFirstName, string authorLastName);

        /// <summary>
        /// Provide the most recent book of specific publisher by a given publisher's name.
        /// </summary>
        /// <param name="publisherName">Name of the publisher.</param>
        /// <returns>The most recent book of the publisher.</returns>
        Book GetMostRecentBookByPublisher(string publisherName);

        /// <summary>
        /// Provide collection of all lended books.
        /// </summary>
        /// <returns>Collection of all lended books.</returns>
        IEnumerable<Book> GetAllLendedBooks();

        /// <summary>
        /// Provide collection of all books lended more than a month ago.
        /// </summary>
        /// <returns>Collection of all books lended more than a month ago.</returns>
        IEnumerable<Book> GetAllBooksLendedBeforeMoreThanAMonth();
    }
}