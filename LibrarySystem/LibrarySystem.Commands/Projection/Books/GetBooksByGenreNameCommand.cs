using System.Collections.Generic;
using System.Linq;
using System.Text;

using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Projection.Books
{
    public class GetBooksByGenreNameCommand : ICommand
    {
        private readonly IBookRepository bookRepository;

        public GetBooksByGenreNameCommand(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var genreName = parameters[0];

            var bookList = bookRepository.GetBooksByGenreName(genreName);

            if (bookList.Count() == 0)
            {
                return $"There are no books on Genre {genreName} in our Library.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Genre {genreName} List of Books:");
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
