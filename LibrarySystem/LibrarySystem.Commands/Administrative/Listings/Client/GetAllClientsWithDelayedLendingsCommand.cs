using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bytes2you.Validation;
using LibrarySystem.Commands.Administrative.Listings.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Administrative.Listings.Client
{
    public class GetAllClientsWithDelayedLendingsCommand : IAdministratorCommand
    {
        private readonly IClientRepository clientRepository;

        public GetAllClientsWithDelayedLendingsCommand(IClientRepository clientRepository)
        {
            Guard.WhenArgument(clientRepository, "clientRepository").IsNull().Throw();

            this.clientRepository = clientRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var clients = this.clientRepository.GetAllClientsWithLendingsOlderThanAMonth();

            if (clients.Count() == 0)
            {
                return $"There are no clients who are in delay returning a book.";
            }

            var sb = new StringBuilder();
            sb.AppendLine("* Delayed Clients: ");
            foreach (var client in clients)
            {
                sb.AppendLine($"* Client Full Name: {client.FullName}");
                sb.AppendLine($"* Client PIN: {client.PIN}");
            }

            return sb.ToString();
        }
    }
}
