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

        /// <summary>Users repository.</summary>
        private IUserRepository users;

        /// <summary>Groups repository.</summary>
        private IGroupRepository groups;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersUnitOfWork"/> class.
        /// </summary>
        /// <param name="usersContext">Context that provide connection to the database.</param>
        /// <param name="users">Users repository.</param>
        /// <param name="groups">Groups repository.</param>
        public UsersUnitOfWork(LibrarySystemUsersDbContext usersContext, IUserRepository users, IGroupRepository groups)
        {
            Guard.WhenArgument(usersContext, "usersContext").IsNull().Throw();
            this.usersContext = usersContext;

            this.Users = users;
            this.Groups = groups;
        }

        /// <summary>
        /// Gets or sets <see cref="IUserRepository"/> instance.
        /// </summary>
        public IUserRepository Users
        {
            get
            {
                return this.users;
            }

            set
            {
                Guard.WhenArgument(value, "Users").IsNull().Throw();

                this.users = value;
            }
        }

        /// <summary>
        /// Gets or sets <see cref="IGroupRepository"/> instance.
        /// </summary>
        public IGroupRepository Groups
        {
            get
            {
                return this.groups;
            }

            set
            {
                Guard.WhenArgument(value, "Groups").IsNull().Throw();

                this.groups = value;
            }
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
