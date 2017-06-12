using System.Collections.Generic;

using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data.Users;

namespace LibrarySystem.Commands.Functional
{
    public class UserLogoutCommand : ICommand
    {
        private readonly IUserRepository usersRepository;

        public UserLogoutCommand(IUserRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var username = parameters[0];
            var password = parameters[1];

            var hasLoggedOut = this.usersRepository.LogoutUser(username, password);

            if (!hasLoggedOut)
            {
                return $"User {username} authentication failed.";
            }

            return $"User {username} successfully logged out.";
        }
    }
}
