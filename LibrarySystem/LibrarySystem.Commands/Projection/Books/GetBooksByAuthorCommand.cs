using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bytes2you.Validation;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Projection.Books
{
    public class GetBooksByAuthorCommand : Command, ICommand
    {
        private readonly IBookRepository bookRepository;

        public GetBooksByAuthorCommand(IBookRepository bookRepository) : base(new List<object>() { bookRepository }, 2)
        {
            this.bookRepository = bookRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var authorFirstName = parameters[0];
            var authorLastName = parameters[1];

            var bookList = bookRepository.GetBooksByAuthor(authorFirstName, authorLastName);

            if (bookList.Count() == 0)
            {
                return $"Author {authorFirstName} {authorLastName} has no books in our Library.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Author {authorFirstName} {authorLastName} List of Books:");
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
