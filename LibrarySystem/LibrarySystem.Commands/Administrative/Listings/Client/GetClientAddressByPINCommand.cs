using LibrarySystem.Commands.Administrative.Listings.Contracts;
using LibrarySystem.Repositories.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Commands.Administrative.Listings.Client
{
    public class GetClientAddressByPINCommand : IAdministratorCommand
    {
        private readonly IAddressRepository addressRepository;

        public GetClientAddressByPINCommand(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public string Execute(IList<string> parameters)
        {
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
