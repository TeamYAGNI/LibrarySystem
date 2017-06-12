using System.Collections.Generic;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories.Data.Contracts
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetBooksByGenreName(string genreName);

        IEnumerable<Book> GetBooksLendedByClient(string PIN);

        IEnumerable<Book> GetBooksLendingHistoryForClient(string PIN);

        IEnumerable<Book> GetAllBooksInUse();

        int GetAvailableQuantityByISBN(string ISBN);

        Book GetBookByISBN(string ISBN);

        string GetBookDescriptionByISBN(string ISBN);

        IEnumerable<Book> GetBooksByAuthor(string authorFirstName, string authorLastName);

        IEnumerable<Book> GetBooksByPublisher(string publisherName);

        IEnumerable<Book> GetBooksByPublisherAndAuthor(string publisherName, string authorFirstName, string authorLastName);

        IEnumerable<Book> GetBooksByTitle(string title);

        int GetInitialQuantityByISBN(string ISBN);

        Book GetMostRecentBookByAuthor(string authorFirstName, string authorLastName);

        Book GetMostRecentBookByPublisher(string publisherName);

        IEnumerable<Book> GetAllLendedBooks();

        IEnumerable<Book> GetAllBooksLendedBeforeMoreThanAMonth();
    }
}