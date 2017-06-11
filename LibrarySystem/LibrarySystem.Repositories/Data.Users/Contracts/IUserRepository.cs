using System.Collections.Generic;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Models.Users;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories.Data.Users.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetAllUsersWhoAreLoggedIn();

        IEnumerable<User> GetUsersByUserType(UserType userType);

        bool LoginUser(string username, string password);

        bool LogoutUser(string username, string password);

        bool MasterIsLoggedIn();

        bool UserIsLoggedIn(string username);
    }
}