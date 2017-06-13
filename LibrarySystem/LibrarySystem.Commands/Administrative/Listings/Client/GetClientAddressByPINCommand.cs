using System.Collections.Generic;
using System.Text;
using Bytes2you.Validation;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Administrative.Listings.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Administrative.Listings.Client
{
    public class GetClientAddressByPINCommand : Command, IAdministratorCommand
    {
        private readonly IAddressRepository addressRepository;

        public GetClientAddressByPINCommand(IAddressRepository addressRepository) : base(new List<object>() { addressRepository }, 1)
        {
            this.addressRepository = addressRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var PIN = parameters[0];

            var address = this.addressRepository.GetAddressByClientPIN(PIN);

            if (address == null)
            {
                return $"There is no such address.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"* Address Street #: {address.Street} {address.StreetNumber}");

            return sb.ToString();
        }
    }
}
