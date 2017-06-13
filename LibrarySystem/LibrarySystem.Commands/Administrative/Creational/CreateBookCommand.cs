using System.Collections.Generic;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;
using LibrarySystem.Repositories.Contracts.Data.UnitOfWork;
using LibrarySystem.Models;
using LibrarySystem.Models.Factory;

namespace LibrarySystem.Commands.Administrative.Creational
{
    class CreateBookCommand : Command, ICommand
    {
        private const string SuccessMessage = "Book {0} was created succesfully!";
        private const string ErrorMessage = "There is already a book with title {0} in the library.";
        private const string InvalidPageCountMessage = "Page count of the book cannot be {0}!";
        private const string InvalidYearOfPublishingMessage = "Year of publishing of the book cannot be {0}!";
        private const string InvalidQuantityMessage = "Initial quantity of the book cannot be {0}!";

        private readonly IPublisherRepository publishers;
        private readonly IBookRepository books;
        private readonly ILibraryUnitOfWork unitOfWork;
        private readonly IModelsFactory factory;

        public CreateBookCommand(
            IPublisherRepository publishers,
            IBookRepository books,
            ILibraryUnitOfWork unitOfWork,
            IModelsFactory factory) : base(new List<object>() { publishers, books, unitOfWork, factory }, 6)
        {
            this.publishers = publishers;
            this.books = books;
            this.unitOfWork = unitOfWork;
            this.factory = factory;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            string bookTitle = parameters[0];
            string bookISBN = parameters[1];
            string publisherName = parameters[4];


            int pageCount;
            if (int.TryParse(parameters[2], out pageCount))
            {
                return string.Format(InvalidPageCountMessage, parameters[2]);
            }

            int yearOfPublishing;
            if (int.TryParse(parameters[3], out yearOfPublishing))
            {
                return string.Format(InvalidYearOfPublishingMessage, parameters[3]);
            }

            int quantity;
            if (int.TryParse(parameters[5], out quantity))
            {
                return string.Format(InvalidQuantityMessage, parameters[5]);
            }

            int available = quantity;

            Publisher publisher = publishers.GetPublisherByName(publisherName) ?? this.factory.CreatePublisher(publisherName, null, null);
            Book book = books.GetBookByISBN(bookISBN);

            if (book != null)
            {
                return string.Format(ErrorMessage, bookTitle);
            }

            book = this.factory.CreateBook(bookTitle, bookISBN, null, null, null, pageCount, yearOfPublishing, publisher, quantity, available, null);

            this.books.Add(book);
            this.unitOfWork.Commit();

            return string.Format(SuccessMessage, bookTitle);
        }
    }
}
