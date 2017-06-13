using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Projection.Genres
{
    public class GetGenresWithMostBooksCommand : Command, ICommand
    {
        private readonly IGenreRepository genreRepository;

        public GetGenresWithMostBooksCommand(IGenreRepository genreRepository) : base(new List<object>() { genreRepository }, 0)
        {
            this.genreRepository = genreRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var genres = this.genreRepository.GetTop5GenresWithMostBooks();

            if (genres.Count() == 0)
            {
                return $"There are no specified genres at the moment.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"* Top {genres.Count()} Genres:");
            foreach (var genre in genres)
            {
                sb.AppendLine($"* Genre Name: {genre.Name}");
                sb.AppendLine($"* Books Count: {genre.Books.Count}");
            }

            return sb.ToString();
        }
    }
}
