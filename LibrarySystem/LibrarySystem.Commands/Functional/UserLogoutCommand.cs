using System.Collections.Generic;
using Bytes2you.Validation;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data.Users;
using LibrarySystem.Repositories.Contracts.Data.Users.UnitOfWork;

namespace LibrarySystem.Commands.Functional
{
    public class UserLogoutCommand : Command, ICommand
    {
        private readonly IUsersUnitOfWork usersUnitOfWork;
        private readonly IUserRepository usersRepository;
        private readonly IUserPassport passport;

        public UserLogoutCommand(IUsersUnitOfWork usersUnitOfWork, IUserRepository usersRepository, IUserPassport passport) : base(new List<object>() { usersUnitOfWork, usersRepository, passport }, 1)
        {
            this.usersUnitOfWork = usersUnitOfWork;
            this.usersRepository = usersRepository;
            this.passport = passport;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

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
