using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bytes2you.Validation;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Projection.Books
{
    public class GetBooksByPublisherCommand : ICommand
    {
        private readonly IBookRepository bookRepository;

        public GetBooksByPublisherCommand(IBookRepository bookRepository)
        {
            Guard.WhenArgument(bookRepository, "bookRepository").IsNull().Throw();

            this.bookRepository = bookRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var publisherName = parameters[0];

            var bookList = bookRepository.GetBooksByPublisher(publisherName);

            if (bookList.Count() == 0)
            {
                return $"Publisher {publisherName} has no books in our Library.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Publisher {publisherName} List of Books:");
            foreach (var book in bookList)
            {
                sb.AppendLine($"* Book Title: {book.Title}");
                sb.AppendLine($"* Book ISBN: {book.ISBN}");
                sb.AppendLine($"* Book Available Quantity: {book.Available}");
            }

            return sb.ToString();
        }
    }
}
