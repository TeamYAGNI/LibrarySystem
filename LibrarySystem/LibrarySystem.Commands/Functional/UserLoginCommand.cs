using System.Collections.Generic;
using Bytes2you.Validation;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data.Users;
using LibrarySystem.Repositories.Contracts.Data.Users.UnitOfWork;

namespace LibrarySystem.Commands.Functional
{
    public class UserLoginCommand : ICommand
    {
        private readonly IUsersUnitOfWork usersUnitOfWork;
        private readonly IUserRepository usersRepository;

        public UserLoginCommand(IUsersUnitOfWork usersUnitOfWork ,IUserRepository usersRepository)
        {
            Guard.WhenArgument(usersUnitOfWork, "usersUnitOfWork").IsNull().Throw();
            Guard.WhenArgument(usersRepository, "usersRepository").IsNull().Throw();

            this.usersUnitOfWork = usersUnitOfWork;
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

            this.usersUnitOfWork.Commit();
            return $"User {username} has successfully been logged in.";
        }
    }
}
