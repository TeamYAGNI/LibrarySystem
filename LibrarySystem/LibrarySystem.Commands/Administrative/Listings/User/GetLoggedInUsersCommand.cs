using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bytes2you.Validation;
using LibrarySystem.Commands.Administrative.Listings.Contracts;
using LibrarySystem.Repositories.Contracts.Data.Users;

namespace LibrarySystem.Commands.Administrative.Listings.User
{
    public class GetLoggedInUsersCommand : IAdministratorCommand
    {
        private readonly IUserRepository usersRepository;

        public GetLoggedInUsersCommand(IUserRepository usersRepository)
        {
            Guard.WhenArgument(usersRepository, "usersRepository").IsNull().Throw();

            this.usersRepository = usersRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var users = this.usersRepository.GetAllUsersWhoAreLoggedIn();

            if (users.Count() == 0)
            {
                return $"No logged in users";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"* List of all Logged In Users:");

            foreach (var user in users)
            {
                sb.AppendLine($"* Username: {user.Username}");
                sb.AppendLine($"* Key Expires: {user.AuthKeyExpirationDate}");
            }

            return sb.ToString();
        }
    }
}
