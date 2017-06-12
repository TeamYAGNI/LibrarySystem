using System;
using System.Collections.Generic;
using System.Linq;

using LibrarySystem.Data.Users;
using LibrarySystem.Framework.Providers;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Models.Users;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data.Users;
using LibrarySystem.Repositories.Data.Users.Utils.Contracts;

namespace LibrarySystem.Repositories.Data.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IHashProvider hashProvider;

        public UserRepository(LibrarySystemUsersDbContext context, IHashProvider hashProvider) : base(context)
        {
            this.hashProvider = hashProvider;
        }

        private LibrarySystemUsersDbContext UsersDbContext
        {
            get
            {
                return this.Context as LibrarySystemUsersDbContext;
            }
        }

        public IEnumerable<User> GetUsersByUserType(UserType userType)
        {
            return this.UsersDbContext.Users.Where(u => u.Type == userType).ToList();
        }

        public bool LoginUser(string username, string password)
        {
            var user = this.UsersDbContext.Users.FirstOrDefault(u => u.Username == username &&
                                                                     this.hashProvider.Verify(password, u.PassHash) &&
                                                                     this.hashProvider.Verify((username + password),
                                                                         u.AuthKey));
            if (user == null)
            {
                return false;
            }

            user.AuthKeyExpirationDate = TimeProvider.Current.Now.AddMinutes(15);
            return true;
        }

        public bool LogoutUser(string username, string password)
        {
            var user = this.UsersDbContext.Users.FirstOrDefault(u => u.Username == username &&
                                                                     this.hashProvider.Verify(password, u.PassHash) &&
                                                                     this.hashProvider.Verify((username + password),
                                                                         u.AuthKey));
            if (user == null)
            {
                return false;
            }

            user.AuthKeyExpirationDate = default(DateTime);
            return true;
        }

        public bool MasterIsLoggedIn()
        {
            return this.UsersDbContext.Users.Any(u => u.AuthKeyExpirationDate < TimeProvider.Current.Now && u.Type == UserType.Master);
        }

        public bool UserIsLoggedIn(string username)
        {
            return this.UsersDbContext.Users.Any(u => u.Username == username &&
                                                      u.AuthKeyExpirationDate < TimeProvider.Current.Now);
        }

        public IEnumerable<User> GetAllUsersWhoAreLoggedIn()
        {
            return this.UsersDbContext.Users.Where(u => u.AuthKeyExpirationDate < TimeProvider.Current.Now).ToList();
        }
    }
}
