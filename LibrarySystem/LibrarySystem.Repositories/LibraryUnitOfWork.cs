using Bytes2you.Validation;
using LibrarySystem.Data;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories
{
    public class LibraryUnitOfWork : ILibraryUnitOfWork
    {
        private readonly LibrarySystemDbContext context;

        private IBookRepository books;
        private IJournalRepository journals;

        public LibraryUnitOfWork(LibrarySystemDbContext context, IBookRepository books, IJournalRepository journals)
        {
            this.context = context;

            this.Books = books;
            this.Journals = journals;
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

        public IJournalRepository Journals
        {
            get
            {
                return this.journals;
            }

            set
            {
                Guard.WhenArgument(value, "Journals").IsNull().Throw();

                this.journals = value;
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
