using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Data.Contracts;

namespace LibrarySystem.Commands.Projection.Genres
{
    public class GetGenresWithMostBooksCommand : ICommand
    {
        private readonly IGenreRepository genreRepository;

        public GetGenresWithMostBooksCommand(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        public string Execute(IList<string> parameters)
        {
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
