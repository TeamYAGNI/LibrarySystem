using Bytes2you.Validation;

using LibrarySystem.Data;
using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Repositories.Contracts.Data;
using LibrarySystem.Repositories.Contracts.Data.UnitOfWork;

namespace LibrarySystem.Repositories.Data.UnitOfWork
{
    public class LibraryUnitOfWork : IUnitOfWork, ILibraryUnitOfWork
    {
        private readonly LibrarySystemDbContext libraryContext;

        public LibraryUnitOfWork(LibrarySystemDbContext libraryContext)
        {
            Guard.WhenArgument(libraryContext, "libraryContext").IsNull().Throw();
            this.libraryContext = libraryContext;
        }

        public int Commit()
        {
            return this.libraryContext.SaveChanges();
        }

        public void Dispose()
        {
            this.libraryContext.Dispose();
        }
    }
}
