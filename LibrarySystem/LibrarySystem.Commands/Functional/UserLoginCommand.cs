using System.Collections.Generic;

using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data.Users;

namespace LibrarySystem.Commands.Functional
{
    public class UserLoginCommand : ICommand
    {
        private readonly IUserRepository usersRepository;

        public UserLoginCommand(IUserRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var username = parameters[0];
            var password = parameters[1];

            var hasLogged = this.usersRepository.LoginUser(username, password);

            if (!hasLogged)
            {
                return $"User {username} authentication failed.";
            }

            return $"User {username} has been logged in.";
        }
    }
}
