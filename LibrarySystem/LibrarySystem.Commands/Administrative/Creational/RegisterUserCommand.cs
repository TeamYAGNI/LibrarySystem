using System;
using System.Collections.Generic;

using Bytes2you.Validation;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data.Users;
using LibrarySystem.Repositories.Contracts.Data.Users.UnitOfWork;
using LibrarySystem.Models.Factory;
using LibrarySystem.Models.Users;
using LibrarySystem.Models.Enumerations;

namespace LibrarySystem.Commands.Administrative.Creational
{
    public class RegisterUserCommand : Command, ICommand
    {
        private const string SuccessMessage = "User {0} was registered succesfully!";
        private const string ErrorMessage = "There is already a user with username {0}.";
        private const string InvalidUserTypeMessage = "User type of the user cannot be {0}!";

        private readonly IUserRepository users;
        private readonly IUsersUnitOfWork unitOfWork;
        private readonly IModelsFactory factory;
        private readonly IHashProvider hashProvider;
        private readonly IAuthKeyProvider authKeyProvider;

        public RegisterUserCommand(
            IUserRepository users,
            IUsersUnitOfWork unitOfWork,
            IModelsFactory factory,
            IHashProvider hashProvider,
            IAuthKeyProvider authKeyProvider) : base(new List<object>() { users, unitOfWork, factory, hashProvider, authKeyProvider }, 3)
        {
            this.users = users;
            this.unitOfWork = unitOfWork;
            this.factory = factory;
            this.hashProvider = hashProvider;
            this.authKeyProvider = authKeyProvider;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            string username = parameters[0];
            string password = parameters[1];
            string passHash = this.hashProvider.Hash(password);
            string authKey = this.authKeyProvider.GenerateAuthKey(password);

            DateTime authKeyExpirationDate = default(DateTime);

            UserType type;
            if (!Enum.TryParse(parameters[2], true, out type))
            {
                return string.Format(InvalidUserTypeMessage, parameters[2]);
            }

            User user = this.users.GetUserByUsername(username);

            if (user != null)
            {
                return string.Format(ErrorMessage, parameters[0]);
            }

            user = this.factory.CreateUser(username, passHash, authKey, authKeyExpirationDate, type, null);

            this.users.Add(user);
            this.unitOfWork.Commit();

            return string.Format(SuccessMessage, username);
        }
    }
}
