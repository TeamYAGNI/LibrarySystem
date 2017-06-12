// <copyright file="AuthorRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of AuthorRepository class.</summary>

using System.Collections.Generic;
using System.Linq;

using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Repositories.Data
{
    /// <summary>
    /// Represent a <see cref="AuthorRepository"/> class. Heir of <see cref="Repository{Author}"/>. Implementator of <see cref="IAuthorRepository"/> interface.
    /// </summary>
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorRepository"/> class.
        /// </summary>
        /// <param name="context">Context that provide connection to the database.</param>
        public AuthorRepository(LibrarySystemDbContext context) : base(context)
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
        /// Provide a <see cref="Author"/> instance by a given first and last names.
        /// </summary>
        /// <param name="authorFirstName">First name of the author.</param>
        /// <param name="authorLastName">Last name of the author.</param>
        /// <returns><see cref="Author"/> instance with given first and last names if exist. Otherwise <see cref="null"/>.</returns>
        public Author GetAuthorByName(string authorFirstName, string authorLastName)
        {
            return this.LibraryDbContext.Authors.SingleOrDefault(
                a => a.FirstName == authorFirstName && a.LastName == authorLastName);
        }

        /// <summary>
        /// Provide collection of authors of a specific book by given book title.
        /// </summary>
        /// <param name="bookTitle">Title of the book.</param>
        /// <returns>Collection of authors of the book.</returns>
        public IEnumerable<Author> GetAuthorsByBookTitle(string bookTitle)
        {
            return this.Find(a => a.Books.Any(b => b.Title == bookTitle));
        }

        /// <summary>
        /// Provide collection of Authors by a given GenderType.
        /// </summary>
        /// <param name="genderType">GenderType of the authors.</param>
        /// <returns>Collection of Authors with the given GenderType.</returns>
        public IEnumerable<Author> GetAuthorsByGenderType(GenderType genderType)
        {
            return this.Find(a => a.GenderType == genderType);
        }

        /// <summary>
        /// Provide count of the authors by a given GenderType.
        /// </summary>
        /// <param name="genderType">GenderType of the authors.</param>
        /// <returns>Count of the authors with the given GenderType.</returns>
        public int GetAuthorsCountByGenderType(GenderType genderType)
        {
            return this.Find(a => a.GenderType == genderType).Count();
        }

        /// <summary>
        /// Provide count of the books from authors by a given GenderType.
        /// </summary>
        /// <param name="genderType">GenderType of the authors.</param>
        /// <returns>count of the books from authors with the given GenderType.</returns>
        public int GetBookCountByAuthorsGenderType(GenderType genderType)
        {
            return this.LibraryDbContext.Authors.Where(a => a.GenderType == genderType)
                .Sum(a => a.Books.Count);
        }
    }
}
