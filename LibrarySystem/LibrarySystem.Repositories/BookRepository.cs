using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Data;
using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Abstractions;

namespace LibrarySystem.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibrarySystemDbContext context) : base(context)
        {
        }

        private LibrarySystemDbContext LibraryDbContext
        {
            get
            {
                return this.Context as LibrarySystemDbContext;
            }
        }

        public Book GetMostRecentBookByAuthor(string authorFirstName, string authorLastName)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.Authors
                    .Any(a => a.FirstName == authorFirstName && a.LastName == authorLastName))
                .OrderByDescending(b => b.YearOfPublishing)
                .FirstOrDefault();
        }

        public Book GetMostRecentBookByPublisher(string publisherName)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.Publisher.Name == publisherName)
                .OrderByDescending(b => b.YearOfPublishing)
                .FirstOrDefault();
        }

        public IEnumerable<Book> GetBooksByPublisher(string publisherName)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.Publisher.Name == publisherName)
                .ToList();
        }

        public IEnumerable<Book> GetBooksByAuthor(string firstName, string lastName)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.Authors
                    .Any(a => a.FirstName == firstName && a.LastName == lastName))
                .ToList();
        }

        public IEnumerable<Book> GetBooksByPublisherAndAuthor(string publisherName, string authorFirstName, string authorLastName)
        {
            return this.LibraryDbContext.Books.Where(
                b => b.Publisher.Name == publisherName &&
                     b.Authors.Any(a => a.FirstName == authorFirstName && a.LastName == authorLastName))
                     .AsEnumerable();
        }   

        public Book GetBookByISBN(string ISBN)
        {
            return this.LibraryDbContext.Books.FirstOrDefault(b => b.ISBN == ISBN);
        }

        public string GetBookDescriptionByISBN(string ISBN)
        {
            var description = this.LibraryDbContext.Books
                .Where(b => b.ISBN == ISBN)
                .Select(b => b.Description)
                .FirstOrDefault();

            if (description != null)
            {
                return description;
            }

            return "Book has no description";
        }

        public IEnumerable<Book> GetBooksByTitle(string title)
        {
            return this.Find(b => b.Title == title);
        }

        public IEnumerable<Book> GetAllBooksThatAreInUse()
        {
            return this.Find(b => b.Quantity != b.Available);
        }

        public int GetInitialQuantityByISBN(string ISBN)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.ISBN == ISBN)
                .Select(b => b.Quantity)
                .FirstOrDefault();
        }

        public int GetAvailableQuantityByISBN(string ISBN)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.ISBN == ISBN)
                .Select(b => b.Available)
                .FirstOrDefault();
        }
    }
}
