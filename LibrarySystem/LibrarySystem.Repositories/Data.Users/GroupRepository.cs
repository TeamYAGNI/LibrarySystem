// <copyright file="GroupRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of GroupRepository class.</summary>

using System.Collections.Generic;
using System.Linq;

using LibrarySystem.Data.Users;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Models.Users;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data.Users;

namespace LibrarySystem.Repositories.Data.Users
{
    /// <summary>
    /// Represent a <see cref="GroupRepository"/> class. Heir of <see cref="Repository{Group}"/>.
    /// Implementator of <see cref="IGroupRepository"/> interface.
    /// </summary>
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupRepository"/> class.
        /// </summary>
        /// <param name="context">Context that provide connection to the database.</param>
        public GroupRepository(LibrarySystemUsersDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets the context as a <see cref="LibrarySystemDbContext"/>.
        /// </summary>
        private LibrarySystemUsersDbContext UsersDbContext
        {
            get
            {
                return this.Context as LibrarySystemUsersDbContext;
            }
        }

        /// <summary>
        /// Provide collection of groups of a specific user by a given username.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <returns>Collection of the groups of the user with the given username.</returns>
        public IEnumerable<Group> GetGroupsByUser(string username)
        {
            return this.UsersDbContext.Groups.Where(g => g.Users.Any(u => u.Username == username)).ToList();
        }

        /// <summary>
        /// Provide collection of groups with master user.
        /// </summary>
        /// <returns>Collection of the groups with master user.</returns>
        public IEnumerable<Group> GetGroupsWithMasters()
        {
            return this.UsersDbContext.Groups.Where(g => g.Users.Any(u => u.Type == UserType.Master)).ToList();
        }

        /// <summary>
        /// Provide group by a given name.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        /// <returns>Group with the given name.</returns>
        public Group GetGroupByName(string groupName)
        {
            return this.UsersDbContext.Groups.FirstOrDefault(g => g.Name == groupName);
        }
    }
}
