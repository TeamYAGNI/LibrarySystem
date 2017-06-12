// <copyright file = "IGenreRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of IGenreRepository implementators.</summary>

using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Contracts.Data
{
    /// <summary>
    /// Represent a <see cref="IGenreRepository"/> interface. Heir of <see cref="IRepository{Genre}"/>
    /// </summary>
    public interface IGenreRepository : IRepository<Genre>
    {
        /// <summary>
        /// Provide collection of genres that has a parrent genre.
        /// </summary>
        /// <returns>Collection of all the genres that has a parrent genre.</returns>
        IEnumerable<Genre> GetAllSubGenres();

        /// <summary>
        /// Provide collection of child genres of a specific parrent genre by a given name.
        /// </summary>
        /// <param name="superGenreName">Name of the parrent genre.</param>
        /// <returns>Collection of the direct child genres of the genre with the given name.</returns>
        IEnumerable<Genre> GetAllSubGenresBySuperGenreName(string superGenreName);

        /// <summary>
        /// Provide collection of genres that has not a parrent genre.
        /// </summary>
        /// <returns>Collection of all the genres that has not a parrent genre.</returns>
        IEnumerable<Genre> GetAllSuperGenres();

        /// <summary>
        /// Provide a genre by a given name.
        /// </summary>
        /// <param name="genreName">Name of the genre.</param>
        /// <returns>Genre with the given name.</returns>
        Genre GetGenreByName(string genreName);

        /// <summary>
        /// Provide a genre by a given name of child genre.
        /// </summary>
        /// <param name="subGenreName">Name of the child genre.</param>
        /// <returns>Parent genre of the genre with the given name.</returns>
        Genre GetSuperGenreBySubGenreName(string subGenreName);

        /// <summary>
        /// Provide the five topmost genres ordered by related books count.
        /// </summary>
        /// <returns>Collection of at most five genres ordered by related books count.</returns>
        IEnumerable<Genre> GetTop5GenresWithMostBooks();
    }
}