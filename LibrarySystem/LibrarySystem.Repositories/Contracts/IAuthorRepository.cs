using System.Collections.Generic;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;

namespace LibrarySystem.Repositories.Contracts
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