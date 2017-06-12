// <copyright file = "IUserRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of IUserRepository implementators.</summary>

using System.Collections.Generic;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Models.Users;

namespace LibrarySystem.Repositories.Contracts.Data.Users
{
    /// <summary>
    /// Represent a <see cref="IUserRepository"/> interface. Heir of <see cref="IRepository{User}"/>
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Provide collection of all logged users.
        /// </summary>
        /// <returns>Collection of all the logged users.</returns>
        IEnumerable<User> GetAllUsersWhoAreLoggedIn();

        /// <summary>
        /// Provide collection of users by a given UserType.
        /// </summary>
        /// <param name="userType">UserType of the users.</param>
        /// <returns>Collection of the users with the given UserType.</returns>
        IEnumerable<User> GetUsersByUserType(UserType userType);

        /// <summary>
        /// Provide ability a specific user to logged in by given username and password.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <returns>Wether the user is logged in.</returns>
        bool LoginUser(string username, string password);

        /// <summary>
        /// Provide ability a specific user to logged out by given username and password.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <returns>Wether the user is logged out.</returns>
        bool LogoutUser(string username, string password);

        /// <summary>
        /// Provide wether the master user is logged in.
        /// </summary>
        /// <returns>Wether the master user is logged in.</returns>
        bool MasterIsLoggedIn();

        /// <summary>
        /// Provide wether a specific user is logged in by a given username.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <returns>Wether the user with the given username is logged in.</returns>
        bool UserIsLoggedIn(string username);
    }
}