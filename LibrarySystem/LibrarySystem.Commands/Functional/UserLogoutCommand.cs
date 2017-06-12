using System.Collections.Generic;

using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data.Users;

namespace LibrarySystem.Commands.Functional
{
    public class UserLogoutCommand : ICommand
    {
        private readonly IUserRepository usersRepository;
        private readonly IUserPassport passport;

        public UserLogoutCommand(IUserRepository usersRepository, IUserPassport passport)
        {
            this.usersRepository = usersRepository;
            this.passport = passport;
        }

        public string Execute(IList<string> parameters)
        {
            var username = parameters[0];
            var authKey = passport.AuthKey;

            var hasLoggedOut = this.usersRepository.LogoutUser(username, authKey);

            if (!hasLoggedOut)
            {
                return $"User {username} authentication failed.";
            }

            return $"User {username} successfully logged out.";
        }
    }
}
