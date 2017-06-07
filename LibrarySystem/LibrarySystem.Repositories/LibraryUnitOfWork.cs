using Bytes2you.Validation;
using LibrarySystem.Data;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories
{
    public class LibraryUnitOfWork : ILibraryUnitOfWork
    {
        private readonly LibrarySystemDbContext context;

        private IBookRepository books;

        public LibraryUnitOfWork(LibrarySystemDbContext context, IBookRepository books)
        {
            this.context = context;

            this.Books = books;
        }

        public IBookRepository Books
        {
            get
            {
                return this.books;
            }

            private set
            {
                Guard.WhenArgument(value, "Books").IsNull().Throw();

                this.books = value;
            }
        }

        public int Commit()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}
