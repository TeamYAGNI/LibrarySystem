using System.Collections.Generic;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories.Data.Contracts
{
    public interface ILendingRepository : IRepository<Lending>
    {
        IEnumerable<string> GetAllLendingsRemarksByClientPIN(string PIN);

        IEnumerable<Lending> GetAllLendingsWithRemarks();

        IEnumerable<Lending> GetLendingsByBookISBN(string ISBN);

        IEnumerable<Lending> GetLendingsByClientPIN(string PIN);

        IEnumerable<Lending> GetLendingsHistoryByClientPIN(string PIN);

        IEnumerable<Lending> GetLendingsOlderThanAMonth();
    }
}