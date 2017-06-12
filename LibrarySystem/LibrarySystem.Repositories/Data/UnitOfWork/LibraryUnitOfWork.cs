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

        public LibraryUnitOfWork(LibrarySystemDbContext libraryContext)
        {
            Guard.WhenArgument(libraryContext, "libraryContext").IsNull().Throw();
            this.libraryContext = libraryContext;
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
