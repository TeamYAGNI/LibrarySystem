// <copyright file = "IUsersUnitOfWork.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of IUsersUnitOfWork implementators.</summary>

namespace LibrarySystem.Repositories.Contracts.Data.Users.UnitOfWork
{
    /// <summary>
    /// Represent a <see cref="IUsersUnitOfWork"/> interface. Heir of <see cref="IUnitOfWork"/>
    /// </summary>
    public interface IUsersUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets or sets <see cref="IGroupRepository"/> implementator instance.
        /// </summary>
        IGroupRepository Groups { get; set; }

        /// <summary>
        /// Gets or sets <see cref="IUserRepository"/> implementator instance.
        /// </summary>
        IUserRepository Users { get; set; }
    }
}