using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Contracts
{
    public interface IBookRepository : IRepository<Book>
    {
        int GetAvailableBookCopiesByBookTitle(string title);

        IEnumerable<Book> GetBooksByPublisher(string publisherName);

        IEnumerable<Book> GetBooksByAuthor(string firstName, string lastName);
    }
}
