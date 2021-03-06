﻿using System.Collections.Generic;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;

using LibrarySystem.Repositories.Contracts.Data.Users;
using LibrarySystem.Repositories.Contracts.Data.Users.UnitOfWork;

namespace LibrarySystem.Commands.Functional
{
    public class UserLoginCommand : Command, ICommand
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
            IUserPassport passport) : base(new List<object>() { usersUnitOfWork, usersRepository, authKeyProvider, hashProvider, passport }, 2)
        {
            this.usersUnitOfWork = usersUnitOfWork;
            this.usersRepository = usersRepository;
            this.authKeyProvider = authKeyProvider;
            this.hashProvider = hashProvider;
            this.passport = passport;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

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
