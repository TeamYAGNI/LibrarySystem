using System.Collections.Generic;
using System.Linq;

using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Repositories.Data
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibrarySystemDbContext context) : base(context)
        {
        }

        private LibrarySystemDbContext LibraryDbContext
        {
            get
            {
                return this.Context as LibrarySystemDbContext;
            }
        }

        public Author GetAuthorByName(string authorFirstName, string authorLastName)
        {
            return this.LibraryDbContext.Authors.SingleOrDefault(
                a => a.FirstName == authorFirstName && a.LastName == authorLastName);
        }

        public IEnumerable<Author> GetAuthorsByBookTitle(string bookTitle)
        {
            return this.Find(a => a.Books.Any(b => b.Title == bookTitle));
        }

        public IEnumerable<Author> GetAuthorsByGenderType(GenderType genderType)
        {
            return this.Find(a => a.GenderType == genderType);
        }

        public int GetAuthorsCountByGenderType(GenderType genderType)
        {
            return this.Find(a => a.GenderType == genderType).Count();
        }

        public int GetBookCountByAuthorsGenderType(GenderType genderType)
        {
            return this.LibraryDbContext.Authors.Where(a => a.GenderType == genderType)
                .Sum(a => a.Books.Count);
        }
    }
}
