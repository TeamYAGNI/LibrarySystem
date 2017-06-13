using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Administrative.Listings.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Administrative.Listings.Client
{
    public class GetAllClientsWithJournalsCommand : Command, IAdministratorCommand
    {
        private readonly IClientRepository clientRepository;

        public GetAllClientsWithJournalsCommand(IClientRepository clientRepository) : base(new List<object>() { clientRepository }, 0)
        {
            this.clientRepository = clientRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var clients = this.clientRepository.GetAllClientsWithJournals();

            if (clients.Count() == 0)
            {
                return $"All clients have returned their journals";
            }

            var sb = new StringBuilder();
            sb.AppendLine("* Clients with Journals: ");
            foreach (var client in clients)
            {
                sb.AppendLine($"* Client Full Name: {client.FullName}");
                sb.AppendLine($"* Client PIN: {client.PIN}");
            }

            return sb.ToString();
        }
    }
}
