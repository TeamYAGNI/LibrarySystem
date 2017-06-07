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
        private IGenreRepository genres;

        public LibraryUnitOfWork(LibrarySystemDbContext context, IBookRepository books, IJournalRepository journals, IGenreRepository genres)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;

            this.Books = books;
            this.Journals = journals;
            this.Genres = genres;
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

            private set
            {
                Guard.WhenArgument(value, "Journals").IsNull().Throw();

                this.journals = value;
            }
        }

        public IGenreRepository Genres
        {
            get
            {
                return this.genres;
            }

            private set
            {
                Guard.WhenArgument(value, "Genres").IsNull().Throw();

                this.genres = value;
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
