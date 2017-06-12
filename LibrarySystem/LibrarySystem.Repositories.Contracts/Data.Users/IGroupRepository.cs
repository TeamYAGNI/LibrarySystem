// <copyright file = "IGroupRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of IGroupRepository implementators.</summary>

using System.Collections.Generic;
using LibrarySystem.Models.Users;

namespace LibrarySystem.Repositories.Contracts.Data.Users
{
    /// <summary>
    /// Represent a <see cref="IGroupRepository"/> interface. Heir of <see cref="IRepository{Group}"/>
    /// </summary>
    public interface IGroupRepository : IRepository<Group>
    {
        /// <summary>
        /// Provide group by a given name.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        /// <returns>Group with the given name.</returns>
        Group GetGroupByName(string groupName);

        /// <summary>
        /// Provide collection of groups of a specific user by a given username.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <returns>Collection of the groups of the user with the given username.</returns>
        IEnumerable<Group> GetGroupsByUser(string username);

        /// <summary>
        /// Provide collection of groups with master user.
        /// </summary>
        /// <returns>Collection of the groups with master user.</returns>
        IEnumerable<Group> GetGroupsWithMasters();
    }
}