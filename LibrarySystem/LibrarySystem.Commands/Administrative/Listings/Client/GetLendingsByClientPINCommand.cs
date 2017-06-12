using System.Collections.Generic;
using System.Linq;
using System.Text;

using LibrarySystem.Commands.Administrative.Listings.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Administrative.Listings.Client
{
    public class GetLendingsByClientPINCommand : IAdministratorCommand
    {
        private readonly ILendingRepository lendingRepository;

        public GetLendingsByClientPINCommand(ILendingRepository lendingRepository)
        {
            this.lendingRepository = lendingRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var PIN = parameters[0];

            var lendings = this.lendingRepository.GetLendingsByClientPIN(PIN);

            if (lendings.Count() == 0)
            {
                return $"Client with PIN {PIN} has no lendings at the exact moment.";
            }

            var sb = new StringBuilder();

            foreach (var lending in lendings)
            {
                sb.AppendLine($"* Book Title: {lending.Book.Title}");
                sb.AppendLine($"* Borrow Date: {lending.BorrоwDate}");
            }

            return sb.ToString();
        }
    }
}
