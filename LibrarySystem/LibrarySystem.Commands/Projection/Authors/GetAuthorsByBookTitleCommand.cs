using System.Collections.Generic;
using System.Linq;
using System.Text;

using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Projection.Authors
{
    public class GetAuthorsByBookTitleCommand : ICommand
    {
        private readonly IAuthorRepository authorRepository;

        public GetAuthorsByBookTitleCommand(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var bookTitle = parameters[0];

            var authors = this.authorRepository.GetAuthorsByBookTitle(bookTitle);

            if (authors.Count() == 0)
            {
                return $"There is no such book title {bookTitle} in our Library";
            }

            var sb = new StringBuilder();

            sb.AppendLine($"Book Title {bookTitle} List of Authors:");
            foreach (var author in authors)
            {
                sb.AppendLine($"* Author Name: {author.FullName}");
            }

            return sb.ToString();
        }
    }
}
