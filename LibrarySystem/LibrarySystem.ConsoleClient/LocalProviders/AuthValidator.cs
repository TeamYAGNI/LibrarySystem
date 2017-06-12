using Bytes2you.Validation;

using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data.Users;

namespace LibrarySystem.ConsoleClient.LocalProviders
{
    public class AuthValidator : IAuthValidator
    {
        private readonly IUserRepository userRepository;

        public AuthValidator(IUserRepository userRepository)
        {
            Guard.WhenArgument(userRepository, "AuthValidator userRepository").IsNull().Throw();

            this.userRepository = userRepository;
        }
        public bool isAuth(IUserPassport passport)
        {
            var username = passport.Username;
            var authKey = passport.AuthKey;

            return this.userRepository.UserIsLoggedIn(username, authKey);
        }
    }
}
