using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using LibrarySystem.Data;
using LibrarySystem.Framework.Providers;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Repositories.Data
{
    public class LendingRepository : Repository<Lending>, ILendingRepository
    {
        public LendingRepository(LibrarySystemDbContext context) : base(context)
        {
        }

        private LibrarySystemDbContext LibraryDbContext
        {
            get
            {
                return this.Context as LibrarySystemDbContext;
            }
        }

        public IEnumerable<Lending> GetLendingsOlderThanAMonth()
        {
            return this.Find(l => l.BorrоwDate.AddMonths(1) < TimeProvider.Current.Today);
        }

        public IEnumerable<Lending> GetLendingsByClientPIN(string PIN)
        {
            return this.LibraryDbContext.Lendings.Include(l => l.Book)
                .Where(l => l.Client.PIN == PIN && l.ReturnDate == null).ToList();
        }

        public IEnumerable<Lending> GetLendingsHistoryByClientPIN(string PIN)
        {
            return this.LibraryDbContext.Lendings.Where(l => l.Client.PIN == PIN && l.ReturnDate != null).ToList();
        }

        public IEnumerable<Lending> GetLendingsByBookISBN(string ISBN)
        {
            return this.LibraryDbContext.Lendings.Where(l => l.Book.ISBN == ISBN).ToList();
        }

        public IEnumerable<Lending> GetAllLendingsWithRemarks()
        {
            return this.Find(l => l.Remarks != null);
        }

        public IEnumerable<string> GetAllLendingsRemarksByClientPIN(string PIN)
        {
            return this.LibraryDbContext.Lendings.Include(l => l.Book).Where(l => l.Client.PIN == PIN)
                .Select(l => l.Remarks).ToList();
        }
    }
}
