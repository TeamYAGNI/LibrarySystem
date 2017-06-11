using System.Collections.Generic;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories.Data.Contracts
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author GetAuthorByName(string authorFirstName, string authorLastName);

        IEnumerable<Author> GetAuthorsByBookTitle(string bookTitle);

        IEnumerable<Author> GetAuthorsByGenderType(GenderType genderType);

        int GetAuthorsCountByGenderType(GenderType genderType);

        int GetBookCountByAuthorsGenderType(GenderType genderType);
    }
}