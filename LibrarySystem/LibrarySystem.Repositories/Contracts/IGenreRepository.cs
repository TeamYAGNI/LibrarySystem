using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Contracts
{
    public interface IGenreRepository : IRepository<Genre>
    {
        IEnumerable<Genre> GetAllSubGenres();

        IEnumerable<Genre> GetAllSubGenresBySuperGenreName(string superGenreName);

        IEnumerable<Genre> GetAllSuperGenres();

        Genre GetGenreByName(string genreName);

        Genre GetSuperGenreBySubGenreName(string subGenreName);

        IEnumerable<Genre> GetTop5GenresWithMostBooks();
    }
}