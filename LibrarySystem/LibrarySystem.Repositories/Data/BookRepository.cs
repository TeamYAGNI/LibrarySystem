// <copyright file="BookRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of BookRepository class.</summary>

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
    /// Represent a <see cref="BookRepository"/> class. Heir of <see cref="Repository{Book}"/>.
    /// Implementator of <see cref="IBookRepository"/> interface.
    /// </summary>
    public class BookRepository : Repository<Book>, IBookRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepository"/> class.
        /// </summary>
        /// <param name="context">Context that provide connection to the database.</param>
        public BookRepository(LibrarySystemDbContext context) : base(context)
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
        /// Provide collection of books of a specific genre by a given name.
        /// </summary>
        /// <param name="genreName">Name of the genre.</param>
        /// <returns>Collection of the books of the genre with the given name.</returns>
        public IEnumerable<Book> GetBooksByGenreName(string genreName)
        {
            return this.Find(b => b.Genres.Any(g => g.Name == genreName));
        }

        /// <summary>
        /// Provide collection of books borrowed by a specific client by PIN but not returned.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Collection of books lended by the client.</returns>
        public IEnumerable<Book> GetBooksLendedByClient(string pin)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.Lendings.Any(l => l.Client.PIN == pin && l.ReturnDate == null)).ToList();
        }

        /// <summary>
        /// Provide collection of books borowed and returned by a specific client by PIN.
        /// </summary>
        /// <param name="pin">PIN of the client.</param>
        /// <returns>Collection of books returned by the client.</returns>
        public IEnumerable<Book> GetBooksLendingHistoryForClient(string pin)
        {
            return this.LibraryDbContext.Books.Where(b => b.Lendings.Any(l => l.Client.PIN == pin && l.ReturnDate != null)).ToList();
        }

        /// <summary>
        /// Provide the most recent book of specific author by given first and last names.
        /// </summary>
        /// <param name="authorFirstName">First name of the author.</param>
        /// <param name="authorLastName">Last name of the author.</param>
        /// <returns>The most recent book written by the author</returns>
        public Book GetMostRecentBookByAuthor(string authorFirstName, string authorLastName)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.Authors
                    .Any(a => a.FirstName == authorFirstName && a.LastName == authorLastName))
                .OrderByDescending(b => b.YearOfPublishing)
                .FirstOrDefault();
        }

        /// <summary>
        /// Provide the most recent book of specific publisher by a given publisher's name.
        /// </summary>
        /// <param name="publisherName">Name of the publisher.</param>
        /// <returns>The most recent book of the publisher.</returns>
        public Book GetMostRecentBookByPublisher(string publisherName)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.Publisher.Name == publisherName)
                .OrderByDescending(b => b.YearOfPublishing)
                .FirstOrDefault();
        }

        /// <summary>
        /// Provide collection of books published by a specific publisher by a given publisher's name.
        /// </summary>
        /// <param name="publisherName">Name of the publisher.</param>
        /// <returns>Collection of the books of the published.</returns>
        public IEnumerable<Book> GetBooksByPublisher(string publisherName)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.Publisher.Name == publisherName)
                .ToList();
        }

        /// <summary>
        /// Provide collection of books written by a specific author by given first and last names.
        /// </summary>
        /// <param name="authorFirstName">First name of the author.</param>
        /// <param name="authorLastName">Last name of the author.</param>
        /// <returns>Collection of the books by the author.</returns>
        public IEnumerable<Book> GetBooksByAuthor(string authorFirstName, string authorLastName)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.Authors
                    .Any(a => a.FirstName == authorFirstName && a.LastName == authorLastName))
                .ToList();
        }

        /// <summary>
        /// Provide collection of books with specific author and publisher by given names.
        /// </summary>
        /// <param name="publisherName">Name of the publisher.</param>
        /// <param name="authorFirstName">First name of the author.</param>
        /// <param name="authorLastName">Last name of the author.</param>
        /// <returns>Collection of all books of the author and publisher.</returns>
        public IEnumerable<Book> GetBooksByPublisherAndAuthor(string publisherName, string authorFirstName, string authorLastName)
        {
            return this.LibraryDbContext.Books.Where(
                    b => b.Publisher.Name == publisherName &&
                         b.Authors.Any(a => a.FirstName == authorFirstName && a.LastName == authorLastName))
                .ToList();
        }

        /// <summary>
        /// Provide a Book by given ISBN.
        /// </summary>
        /// <param name="isbn">ISBN of the Book.</param>
        /// <returns>Book with the given ISBN if exist. Otherwise <see cref="null"/>.</returns>
        public Book GetBookByISBN(string isbn)
        {
            return this.LibraryDbContext.Books.FirstOrDefault(b => b.ISBN == isbn);
        }

        /// <summary>
        /// Provide specific book description by a given ISBN.
        /// </summary>
        /// <param name="isbn">ISBN of the Book.</param>
        /// <returns>Description of the book with the given ISBN, if exist. Otherwise <see cref="null"/>.</returns>
        public string GetBookDescriptionByISBN(string isbn)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.ISBN == isbn)
                .Select(b => b.Description)
                .FirstOrDefault();
        }

        /// <summary>
        /// Provide collection of books by a given title.
        /// </summary>
        /// <param name="title">Title of the book.</param>
        /// <returns>collection of the books with the given title.</returns>
        public IEnumerable<Book> GetBooksByTitle(string title)
        {
            return this.Find(b => b.Title == title);
        }

        /// <summary>
        /// Provide collection of all books borowed and not returned yet.
        /// </summary>
        /// <returns>collection of all borowed books.</returns>
        public IEnumerable<Book> GetAllBooksInUse()
        {
            return this.Find(b => b.Quantity != b.Available);
        }

        /// <summary>
        /// Provide numder of copies of a specific book by a given ISBN. 
        /// </summary>
        /// <param name="isbn">ISBN of the Book.</param>
        /// <returns>Numder of the copies of the book.</returns>
        public int GetInitialQuantityByISBN(string isbn)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.ISBN == isbn)
                .Select(b => b.Quantity)
                .FirstOrDefault();
        }

        /// <summary>
        /// Provide the number of available copy of specific book by given ISBN.
        /// </summary>
        /// <param name="isbn">ISBN of the Book.</param>
        /// <returns>Number of available copy of the book.</returns>
        public int GetAvailableQuantityByISBN(string isbn)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.ISBN == isbn)
                .Select(b => b.Available)
                .FirstOrDefault();
        }

        /// <summary>
        /// Provide collection of all lended books.
        /// </summary>
        /// <returns>Collection of all lended books.</returns>
        public IEnumerable<Book> GetAllLendedBooks()
        {
            return this.LibraryDbContext.Books.Where(b => b.Lendings.Any(l => l.BookId == b.Id)).ToList();
        }

        /// <summary>
        /// Provide collection of all books lended more than a month ago.
        /// </summary>
        /// <returns>Collection of all books lended more than a month ago.</returns>
        public IEnumerable<Book> GetAllBooksLendedBeforeMoreThanAMonth()
        {
            return this.LibraryDbContext.Books.Where(
                b => b.Lendings.Any(l => l.BorrоwDate.AddMonths(1) < TimeProvider.Current.Today)).ToList();
        }

        public override IEnumerable<Book> GetAll()
        {
            return this.LibraryDbContext.Books.Include(b => b.Publisher).Include(b => b.Genres).Include(b => b.Authors).ToList();
        }
    }
}
