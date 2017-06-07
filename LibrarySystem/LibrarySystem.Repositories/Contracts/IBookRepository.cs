using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Contracts
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetAllBooksThatAreInUse();

        int GetAvailableQuantityByISBN(string ISBN);

        Book GetBookByISBN(string ISBN);

        string GetBookDescriptionByISBN(string ISBN);

        IEnumerable<Book> GetBooksByAuthor(string firstName, string lastName);

        IEnumerable<Book> GetBooksByPublisher(string publisherName);

        IEnumerable<Book> GetBooksByPublisherAndAuthor(string publisherName, string authorFirstName, string authorLastName);

        IEnumerable<Book> GetBooksByTitle(string title);

        int GetInitialQuantityByISBN(string ISBN);

        Book GetMostRecentBookByAuthor(string authorFirstName, string authorLastName);

        Book GetMostRecentBookByPublisher(string publisherName);
    }
}