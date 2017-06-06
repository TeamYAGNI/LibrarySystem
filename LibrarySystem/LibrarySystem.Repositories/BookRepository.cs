using System;
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

        public int GetAvailableBookCopiesByBookTitle(string title)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.Title == title)
                .Select(b => b.Available)
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

        private LibrarySystemDbContext LibraryDbContext
        {
            get
            {
                return base.Context as LibrarySystemDbContext;
            }
        }
    }
}
