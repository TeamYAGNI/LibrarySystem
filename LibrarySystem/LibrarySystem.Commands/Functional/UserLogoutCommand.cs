using System.Collections.Generic;
using Bytes2you.Validation;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data.Users;
using LibrarySystem.Repositories.Contracts.Data.Users.UnitOfWork;

namespace LibrarySystem.Commands.Functional
{
    public class UserLogoutCommand : ICommand
    {
        private readonly IUsersUnitOfWork usersUnitOfWork;
        private readonly IUserRepository usersRepository;
        private readonly IUserPassport passport;

        public UserLogoutCommand(IUsersUnitOfWork usersUnitOfWork, IUserRepository usersRepository, IUserPassport passport)
        {
            Guard.WhenArgument(usersUnitOfWork, "UserLogoutCommand usersUnitOfWork").IsNull().Throw();
            Guard.WhenArgument(usersRepository, "UserLogoutCommand usersRepository").IsNull().Throw();
            Guard.WhenArgument(passport, "UserLogoutCommand passport").IsNull().Throw();

            this.usersUnitOfWork = usersUnitOfWork;
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

            this.usersUnitOfWork.Commit();
            return $"User {username} successfully logged out.";
        }
    }
}
