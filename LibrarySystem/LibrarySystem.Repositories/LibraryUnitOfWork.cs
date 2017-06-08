using Bytes2you.Validation;
using LibrarySystem.Data;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories
{
    public class LibraryUnitOfWork : IUnitOfWork, ILibraryUnitOfWork
    {
        private readonly LibrarySystemDbContext context;

        private IBookRepository books;
        private IJournalRepository journals;
        private IGenreRepository genres;
        private IAuthorRepository authors;
        private IPublisherRepository publishers;
        private ISubjectRepository subjects;
        private IClientRepository clients;

        public LibraryUnitOfWork(LibrarySystemDbContext context, IBookRepository books, IJournalRepository journals, IGenreRepository genres, IAuthorRepository authors, IPublisherRepository publishers, ISubjectRepository subjects, IClientRepository clients)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;

            this.Books = books;
            this.Journals = journals;
            this.Genres = genres;
            this.Authors = authors;
            this.Publishers = publishers;
            this.Subjects = subjects;
            this.Clients = clients;
        }

        public IAuthorRepository Authors
        {
            get
            {
                return this.authors;
            }

            private set
            {
                Guard.WhenArgument(value, "Authors").IsNull().Throw();

                this.authors = value;
            }
        }

        public IClientRepository Clients
        {
            get
            {
                return this.clients;
            }

            private set
            {
                Guard.WhenArgument(value, "Clients").IsNull().Throw();

                this.clients = value;
            }
        }

        public ISubjectRepository Subjects
        {
            get
            {
                return this.subjects;
            }

            private set
            {
                Guard.WhenArgument(value, "Subjects").IsNull().Throw();

                this.subjects = value;
            }
        }

        public IPublisherRepository Publishers
        {
            get
            {
                return this.publishers;
            }

            private set
            {
                Guard.WhenArgument(value, "Publishers").IsNull().Throw();

                this.publishers = value;
            }
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
