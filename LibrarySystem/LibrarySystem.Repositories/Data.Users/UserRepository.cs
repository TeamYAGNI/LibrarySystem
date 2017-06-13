// <copyright file="UserRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of UserRepository class.</summary>

using System;
using System.Collections.Generic;
using System.Linq;

using LibrarySystem.Data.Users;
using LibrarySystem.Framework.Providers;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Models.Users;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data.Users;

namespace LibrarySystem.Repositories.Data.Users
{
    /// <summary>
    /// Represent a <see cref="UserRepository"/> class. Heir of <see cref="Repository{User}"/>.
    /// Implementator of <see cref="IUserRepository"/> interface.
    /// </summary>
    public class UserRepository : Repository<User>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">Context that provide connection to the database.</param>
        public UserRepository(LibrarySystemUsersDbContext context) : base(context)
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
        /// Provide collection of users by a given UserType.
        /// </summary>
        /// <param name="userType">UserType of the users.</param>
        /// <returns>Collection of the users with the given UserType.</returns>
        public IEnumerable<User> GetUsersByUserType(UserType userType)
        {
            return this.UsersDbContext.Users.Where(u => u.Type == userType).ToList();
        }

        /// <summary>
        /// Provide ability a specific user to logged in by given username and passHash.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <param name="passHash">Password of the user.</param>
        /// <param name="authKey">AuthKey of the user.</param>
        /// <returns>Wether the user is logged in.</returns>
        public bool LoginUser(string username, string passHash, string authKey)
        {
            var user = this.UsersDbContext.Users
                .SingleOrDefault(u => u.Username == username && u.PassHash == passHash);

            if (user == null)
            {
                return false;
            }

            user.AuthKey = authKey;
            user.AuthKeyExpirationDate = TimeProvider.Current.Now.AddHours(8);
            return true;
        }

        /// <summary>
        /// Provide ability a specific user to logged out by given username.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <param name="authKey">AuthKey of the user.</param>
        /// <returns>Wether the user is logged out.</returns>
        public bool LogoutUser(string username, string authKey)
        {
            var user = this.UsersDbContext.Users
                .SingleOrDefault(u => u.Username == username && u.AuthKey == authKey);

            if (user == null)
            {
                return false;
            }

            user.AuthKeyExpirationDate = default(DateTime);
            return true;
        }

        /// <summary>
        /// Provide wether the master user is logged in.
        /// </summary>
        /// <returns>Wether the master user is logged in.</returns>
        public bool MasterIsLoggedIn()
        {
            return this.UsersDbContext.Users.Any(u => u.AuthKeyExpirationDate < TimeProvider.Current.Now && u.Type == UserType.Master);
        }

        /// <summary>
        /// Provide wether a specific user is logged in by a given username and authentication key.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <param name="authKey">AuthKey of the user.</param>
        /// <returns>Wether the user with the given username is logged in.</returns>
        public bool UserIsLoggedIn(string username, string authKey)
        {
            return this.UsersDbContext.Users
                .Any(u => 
                u.Username == username &&
                u.AuthKey == authKey &&
                u.AuthKeyExpirationDate < TimeProvider.Current.Now);
        }

        /// <summary>
        /// Provide collection of all logged users.
        /// </summary>
        /// <returns>Collection of all the logged users.</returns>
        public IEnumerable<User> GetAllUsersWhoAreLoggedIn()
        {
            return this.UsersDbContext.Users.Where(u => u.AuthKeyExpirationDate < TimeProvider.Current.Now).ToList();
        }

        /// <summary>
        /// Provide user by a given username.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <returns>User with the given username.</returns>
        public User GetUserByUsername(string username)
        {
            return this.UsersDbContext.Users.Where(u => u.Username == username).SingleOrDefault();
        }
    }
}
