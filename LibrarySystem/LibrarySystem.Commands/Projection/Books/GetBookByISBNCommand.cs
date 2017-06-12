using System.Collections.Generic;
using System.Text;

using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Projection.Books
{
    public class GetBookByISBNCommand : ICommand
    {
        private readonly IBookRepository bookRepository;

        public GetBookByISBNCommand(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var ISBN = parameters[0];

            var book = bookRepository.GetBookByISBN(ISBN);

            if (book == null)
            {
                return $"There is no book with ISBN: {ISBN} in our Library.";
            }

            var sb = new StringBuilder();

            sb.AppendLine($"* Book Title: {book.Title}");
            sb.AppendLine($"* Book Year Of Publishing: {book.YearOfPublishing}");
            sb.AppendLine($"* Book Page Count: {book.PageCount}");
            sb.AppendLine($"* Book Available Quantity: {book.Available}");
            sb.AppendLine($"* Book Description: {book.Description}");

            return sb.ToString();
        }
    }
}
