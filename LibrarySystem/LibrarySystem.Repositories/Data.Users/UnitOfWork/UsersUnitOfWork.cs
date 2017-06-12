// <copyright file="UsersUnitOfWork.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of UsersUnitOfWork class.</summary>

using Bytes2you.Validation;

using LibrarySystem.Data.Users;
using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Repositories.Contracts.Data.Users;
using LibrarySystem.Repositories.Contracts.Data.Users.UnitOfWork;

namespace LibrarySystem.Repositories.Data.Users.UnitOfWork
{
    /// <summary>
    /// Represent a <see cref="UsersUnitOfWork"/> class.
    /// Implementator of <see cref="IUnitOfWork"/> and <see cref="IUsersUnitOfWork"/> interfaces.
    /// </summary>
    public class UsersUnitOfWork : IUnitOfWork, IUsersUnitOfWork
    {
        /// <summary>Context that provide connection to the database.</summary>
        private readonly LibrarySystemUsersDbContext usersContext;

        public UsersUnitOfWork(LibrarySystemUsersDbContext usersContext)
        {
            Guard.WhenArgument(usersContext, "usersContext").IsNull().Throw();
            this.usersContext = usersContext;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.usersContext.Dispose();
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
            return this.usersContext.SaveChanges();
        }
    }
}
