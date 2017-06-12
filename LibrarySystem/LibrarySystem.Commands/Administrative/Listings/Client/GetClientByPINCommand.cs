using System.Collections.Generic;
using System.Text;
using Bytes2you.Validation;
using LibrarySystem.Commands.Administrative.Listings.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Administrative.Listings.Client
{
    public class GetClientByPINCommand : IAdministratorCommand
    {
        private readonly IClientRepository clientRepository;

        public GetClientByPINCommand(IClientRepository clientRepository)
        {
            Guard.WhenArgument(clientRepository, "clientRepository").IsNull().Throw();

            this.clientRepository = clientRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var PIN = parameters[0];

            var client = this.clientRepository.GetClientByPin(PIN);

            if (client == null)
            {
                return $"There is no Client with pin {PIN}";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"* Client Full Name: {client.FullName}");
            sb.AppendLine($"* Client Gender Type: {client.GenderType}");
            sb.AppendLine($"* Client Email: {client.Email}");
            sb.AppendLine($"* Client Phone: {client.Phone}");

            return sb.ToString();
        }
    }
}
