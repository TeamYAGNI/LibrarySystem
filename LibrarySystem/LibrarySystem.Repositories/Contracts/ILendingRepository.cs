using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Contracts
{
    public interface ILendingRepository : IRepository<Lending>
    {
        IEnumerable<string> GetAllLendingsRemarksByClientPIN(string PIN);

        IEnumerable<Lending> GetAllLendingsWithRemarks();

        IEnumerable<Lending> GetLendingsByBookISBN(string ISBN);

        IEnumerable<Lending> GetLendingsByClientPIN(string PIN);

        IEnumerable<Lending> GetLendingsOlderThanAMonth();
    }
}