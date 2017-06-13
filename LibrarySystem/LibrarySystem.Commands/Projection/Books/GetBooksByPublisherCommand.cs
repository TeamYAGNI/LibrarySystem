using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Projection.Books
{
    public class GetBooksByPublisherCommand : Command, ICommand
    {
        private readonly IBookRepository bookRepository;

        public GetBooksByPublisherCommand(IBookRepository bookRepository) : base(new List<object>() { bookRepository }, 1)
        {
            this.bookRepository = bookRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

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
