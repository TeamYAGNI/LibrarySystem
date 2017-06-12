// <copyright file="LibraryUnitOfWork.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of LibraryUnitOfWork class.</summary>

using Bytes2you.Validation;

using LibrarySystem.Data;
using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Repositories.Contracts.Data;
using LibrarySystem.Repositories.Contracts.Data.UnitOfWork;

namespace LibrarySystem.Repositories.Data.UnitOfWork
{
    /// <summary>
    /// Represent a <see cref="LibraryUnitOfWork"/> class.
    /// Implementator of <see cref="IUnitOfWork"/> and <see cref="ILibraryUnitOfWork"/> interfaces.
    /// </summary>
    public class LibraryUnitOfWork : IUnitOfWork, ILibraryUnitOfWork
    {
        /// <summary>Context that provide connection to the database.</summary>
        private readonly LibrarySystemDbContext libraryContext;

        /// <summary>Books repository.</summary>
        private IBookRepository books;

        /// <summary>Journals repository.</summary>
        private IJournalRepository journals;

        /// <summary>Genres repository.</summary>
        private IGenreRepository genres;

        /// <summary>Authors repository.</summary>
        private IAuthorRepository authors;

        /// <summary>Publishers repository.</summary>
        private IPublisherRepository publishers;

        /// <summary>Subjects repository.</summary>
        private ISubjectRepository subjects;

        /// <summary>Clients repository.</summary>
        private IClientRepository clients;

        /// <summary>Employees repository.</summary>
        private IEmployeeRepository employees;

        /// <summary>Addresses repository.</summary>
        private IAddressRepository addresses;

        /// <summary>Cities repository.</summary>
        private ICityRepository cities;

        /// <summary>Lendings repository.</summary>
        private ILendingRepository lendings;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryUnitOfWork"/> class.
        /// </summary>
        /// <param name="libraryContext">Context that provide connection to the database.</param>
        /// <param name="books">Books repository.</param>
        /// <param name="journals">Journals repository.</param>
        /// <param name="genres">Genres repository.</param>
        /// <param name="authors">Authors repository.</param>
        /// <param name="publishers">Publishers repository.</param>
        /// <param name="subjects">Subjects repository.</param>
        /// <param name="clients">Clients repository.</param>
        /// <param name="employees">Employees repository.</param>
        /// <param name="addresses">Addresses repository.</param>
        /// <param name="cities">Cities repository.</param>
        /// <param name="lendings">Lendings repository.</param>
        public LibraryUnitOfWork(
            LibrarySystemDbContext libraryContext,
            IBookRepository books,
            IJournalRepository journals,
            IGenreRepository genres,
            IAuthorRepository authors,
            IPublisherRepository publishers,
            ISubjectRepository subjects,
            IClientRepository clients,
            IEmployeeRepository employees,
            IAddressRepository addresses,
            ICityRepository cities,
            ILendingRepository lendings)
        {
            Guard.WhenArgument(libraryContext, "libraryContext").IsNull().Throw();
            this.libraryContext = libraryContext;

            this.Books = books;
            this.Journals = journals;
            this.Genres = genres;
            this.Authors = authors;
            this.Publishers = publishers;
            this.Subjects = subjects;
            this.Clients = clients;
            this.Employees = employees;
            this.Addresses = addresses;
            this.Cities = cities;
            this.Lendings = lendings;
        }

        /// <summary>
        /// Gets <see cref="ILendingRepository"/> instance.
        /// </summary>
        public ILendingRepository Lendings
        {
            get
            {
                return this.lendings;
            }

            private set
            {
                Guard.WhenArgument(value, "Lendings").IsNull().Throw();

                this.lendings = value;
            }
        }

        /// <summary>
        /// Gets <see cref="ICityRepository"/> instance.
        /// </summary>
        public ICityRepository Cities
        {
            get
            {
                return this.cities;
            }

            private set
            {
                Guard.WhenArgument(value, "Cities").IsNull().Throw();

                this.cities = value;
            }
        }

        /// <summary>
        /// Gets <see cref="IAuthorRepository"/> instance.
        /// </summary>
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

        /// <summary>
        /// Gets <see cref="IClientRepository"/> instance.
        /// </summary>
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

        /// <summary>
        /// Gets <see cref="IEmployeeRepository"/> instance.
        /// </summary>
        public IEmployeeRepository Employees
        {
            get
            {
                return this.employees;
            }

            private set
            {
                Guard.WhenArgument(value, "Employees").IsNull().Throw();

                this.employees = value;
            }
        }

        /// <summary>
        /// Gets <see cref="IAddressRepository"/> instance.
        /// </summary>
        public IAddressRepository Addresses
        {
            get
            {
                return this.addresses;
            }

            private set
            {
                Guard.WhenArgument(value, "Addresses").IsNull().Throw();

                this.addresses = value;
            }
        }

        /// <summary>
        /// Gets <see cref="ISubjectRepository"/> instance.
        /// </summary>
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

        /// <summary>
        /// Gets <see cref="IPublisherRepository"/> instance.
        /// </summary>
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

        /// <summary>
        /// Gets <see cref="IBookRepository"/> instance.
        /// </summary>
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

        /// <summary>
        /// Gets <see cref="IJournalRepository"/> instance.
        /// </summary>
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

        /// <summary>
        /// Gets <see cref="IGenreRepository"/> instance.
        /// </summary>
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

        /// <summary>
        /// Make a transaction to save the changes of the entities tracked by the context.
        /// </summary>
        /// <returns>
        /// The number of state entries written to the underlying database. This can include
        /// state entries for entities and/or relationships. Relationship state entries are
        /// created for many-to-many relationships and relationships where there is no foreign
        /// key property included in the entity class (often referred to as independent associations).
        /// </returns>
        public int Commit()
        {
            return this.libraryContext.SaveChanges();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.libraryContext.Dispose();
        }
    }
}
