using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(LibrarySystemDbContext context) : base(context)
        {
        }

        private LibrarySystemDbContext LibraryDbContext
        {
            get
            {
                return this.Context as LibrarySystemDbContext;
            }
        }

        public Genre GetGenreByName(string genreName)
        {
            return this.LibraryDbContext.Genres.FirstOrDefault(g => g.Name == genreName);
        }

        public IEnumerable<Genre> GetAllSuperGenres()
        {
            return this.Find(g => g.SuperGenreId == null);
        }

        public IEnumerable<Genre> GetTop5GenresWithMostBooks()
        {
            return this.LibraryDbContext.Genres
                .Where(g => g.Books != null)
                .OrderByDescending(g => g.Books.Count)
                .Take(5)
                .ToList();
        }

        public IEnumerable<Genre> GetAllSubGenresBySuperGenreName(string superGenreName)
        {
            var genre = this.LibraryDbContext.Genres.FirstOrDefault(g => g.Name == superGenreName);

            return (genre != null) ? genre.SubGenres : new List<Genre>();
        }

        public Genre GetSuperGenreBySubGenreName(string subGenreName)
        {
            return this.LibraryDbContext.Genres.FirstOrDefault(g => g.Name == subGenreName);
        }

        public IEnumerable<Genre> GetAllSubGenres()
        {
            return this.LibraryDbContext.Genres
                .Where(g => g.SuperGenreId != null);
        }
    }
}
