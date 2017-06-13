using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data.Users;

namespace LibrarySystem.Commands.Administrative.Listings.User
{
    public class GetLoggedInUsersCommand : Command ,ICommand
    {
        private readonly IUserRepository usersRepository;

        public GetLoggedInUsersCommand(IUserRepository usersRepository) : base(new List<object>() { usersRepository }, 0)
        {
            this.usersRepository = usersRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

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
