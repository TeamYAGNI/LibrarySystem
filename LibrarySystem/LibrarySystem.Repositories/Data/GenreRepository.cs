// <copyright file="GenreRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of GenreRepository class.</summary>

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Repositories.Data
{
    /// <summary>
    /// Represent a <see cref="GenreRepository"/> class. Heir of <see cref="Repository{Genre}"/>.
    /// Implementator of <see cref="IGenreRepository"/> interface.
    /// </summary>
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenreRepository"/> class.
        /// </summary>
        /// <param name="context">Context that provide connection to the database.</param>
        public GenreRepository(LibrarySystemDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets the context as a <see cref="LibrarySystemDbContext"/>.
        /// </summary>
        private LibrarySystemDbContext LibraryDbContext
        {
            get
            {
                return this.Context as LibrarySystemDbContext;
            }
        }

        /// <summary>
        /// Provide a genre by a given name.
        /// </summary>
        /// <param name="genreName">Name of the genre.</param>
        /// <returns>Genre with the given name.</returns>
        public Genre GetGenreByName(string genreName)
        {
            return this.LibraryDbContext.Genres.FirstOrDefault(g => g.Name == genreName);
        }

        /// <summary>
        /// Provide collection of genres that has not a parrent genre.
        /// </summary>
        /// <returns>Collection of all the genres that has not a parrent genre.</returns>
        public IEnumerable<Genre> GetAllSuperGenres()
        {
            return this.Find(g => g.SuperGenreId == null);
        }

        /// <summary>
        /// Provide the five topmost genres ordered by related books count.
        /// </summary>
        /// <returns>Collection of at most five genres ordered by related books count.</returns>
        public IEnumerable<Genre> GetTop5GenresWithMostBooks()
        {
            return this.LibraryDbContext.Genres
                .Include(g => g.Books)
                .Where(g => g.Books != null)
                .OrderByDescending(g => g.Books.Count)
                .Take(5)
                .ToList();
        }

        /// <summary>
        /// Provide collection of child genres of a specific parrent genre by a given name.
        /// </summary>
        /// <param name="superGenreName">Name of the parrent genre.</param>
        /// <returns>Collection of the direct child genres of the genre with the given name.</returns>
        public IEnumerable<Genre> GetAllSubGenresBySuperGenreName(string superGenreName)
        {
            var genre = this.LibraryDbContext.Genres.FirstOrDefault(g => g.Name == superGenreName);

            return (genre != null) ? genre.SubGenres : new List<Genre>();
        }

        /// <summary>
        /// Provide a genre by a given name of child genre.
        /// </summary>
        /// <param name="subGenreName">Name of the child genre.</param>
        /// <returns>Parent genre of the genre with the given name.</returns>
        public Genre GetSuperGenreBySubGenreName(string subGenreName)
        {
            return this.LibraryDbContext.Genres.FirstOrDefault(g => g.Name == subGenreName);
        }

        /// <summary>
        /// Provide collection of genres that has a parrent genre.
        /// </summary>
        /// <returns>Collection of all the genres that has a parrent genre.</returns>
        public IEnumerable<Genre> GetAllSubGenres()
        {
            return this.LibraryDbContext.Genres
                .Where(g => g.SuperGenreId != null);
        }
    }
}
