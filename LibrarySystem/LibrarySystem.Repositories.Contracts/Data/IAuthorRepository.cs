// <copyright file = "IAuthorRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of IAuthorRepository implementators.</summary>

using System.Collections.Generic;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;

namespace LibrarySystem.Repositories.Contracts.Data
{
    /// <summary>
    /// Represent a <see cref="IAuthorRepository"/> interface. Heir of <see cref="IRepository{Author}"/>
    /// </summary>
    public interface IAuthorRepository : IRepository<Author>
    {
        /// <summary>
        /// Provide a <see cref="Author"/> instance by a given first and last names.
        /// </summary>
        /// <param name="authorFirstName">First name of the author.</param>
        /// <param name="authorLastName">Last name of the author.</param>
        /// <returns><see cref="Author"/> instance with given first and last names if exist. Otherwise <see cref="null"/>.</returns>
        Author GetAuthorByName(string authorFirstName, string authorLastName);

        /// <summary>
        /// Provide collection of authors of a specific book by given book title.
        /// </summary>
        /// <param name="bookTitle">Title of the book.</param>
        /// <returns>Collection of authors of the book.</returns>
        IEnumerable<Author> GetAuthorsByBookTitle(string bookTitle);

        /// <summary>
        /// Provide collection of Authors by a given GenderType.
        /// </summary>
        /// <param name="genderType">GenderType of the authors.</param>
        /// <returns>Collection of Authors with the given GenderType.</returns>
        IEnumerable<Author> GetAuthorsByGenderType(GenderType genderType);

        /// <summary>
        /// Provide count of the authors by a given GenderType.
        /// </summary>
        /// <param name="genderType">GenderType of the authors.</param>
        /// <returns>Count of the authors with the given GenderType.</returns>
        int GetAuthorsCountByGenderType(GenderType genderType);

        /// <summary>
        /// Provide count of the books from authors by a given GenderType.
        /// </summary>
        /// <param name="genderType">GenderType of the authors.</param>
        /// <returns>count of the books from authors with the given GenderType.</returns>
        int GetBookCountByAuthorsGenderType(GenderType genderType);
    }
}