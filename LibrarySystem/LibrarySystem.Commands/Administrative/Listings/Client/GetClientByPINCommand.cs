using System.Collections.Generic;
using System.Text;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Administrative.Listings.Client
{
    public class GetClientByPINCommand : Command, ICommand
    {
        private readonly IClientRepository clientRepository;

        public GetClientByPINCommand(IClientRepository clientRepository) : base(new List<object>() { clientRepository }, 1)
        {
            this.clientRepository = clientRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

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
