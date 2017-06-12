using System.Collections.Generic;

using Bytes2you.Validation;

using LibrarySystem.Commands.Contracts;

using LibrarySystem.Repositories.Contracts.Data.Users;
using LibrarySystem.Repositories.Contracts.Data.Users.UnitOfWork;

namespace LibrarySystem.Commands.Functional
{
    public class UserLoginCommand : ICommand
    {
        /// <summary>User repository.</summary>
        private readonly IUsersUnitOfWork usersUnitOfWork;

        private readonly IUserRepository usersRepository;

        /// <summary>AuthKey provider for generating an authKey from passwords.</summary>
        private readonly IAuthKeyProvider authKeyProvider;

        /// <summary>Hash provider for hashing passwords.</summary>
        private readonly IHashProvider hashProvider;

        /// <summary>Passport for providing authentication key of the user.</summary>
        private readonly IUserPassport passport;

        public UserLoginCommand(
            IUsersUnitOfWork usersUnitOfWork,
            IUserRepository usersRepository,
            IAuthKeyProvider authKeyProvider,
            IHashProvider hashProvider,
            IUserPassport passport)
        {
            Guard.WhenArgument(usersUnitOfWork, "UserLoginCommand usersUnitOfWork").IsNull().Throw();
            Guard.WhenArgument(usersRepository, "UserLoginCommand usersRepository").IsNull().Throw();
            Guard.WhenArgument(authKeyProvider, "UserLoginCommand authKeyProvider").IsNull().Throw();
            Guard.WhenArgument(hashProvider, "UserLoginCommand hashProvider").IsNull().Throw();
            Guard.WhenArgument(passport, "UserLoginCommand passport").IsNull().Throw();

            this.usersUnitOfWork = usersUnitOfWork;
            this.usersRepository = usersRepository;
            this.authKeyProvider = authKeyProvider;
            this.hashProvider = hashProvider;
            this.passport = passport;
        }

        public string Execute(IList<string> parameters)
        {
            var username = parameters[0];
            var password = parameters[1];
            var passHash = this.hashProvider.Hash(password);
            var authKey = this.authKeyProvider.GenerateAuthKey(password);

            var hasLogged = this.usersRepository.LoginUser(username, passHash, authKey);

            if (!hasLogged)
            {
                return $"Invalid username or password.";
            }

            this.usersUnitOfWork.Commit();

            return $"User {username} has successfully been logged in.";
        }
    }
}
