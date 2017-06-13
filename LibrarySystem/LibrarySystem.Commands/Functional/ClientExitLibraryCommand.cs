using System.Collections.Generic;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Functional
{
    public class ClientExitLibraryCommand : Command, ICommand
    {
        private readonly IClientRepository clientRepository;

        public ClientExitLibraryCommand(IClientRepository clientRepository) : base(new List<object>() { clientRepository }, 1)
        {
            this.clientRepository = clientRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            string PIN = parameters[0];

            var hasJournals = this.clientRepository.ClientHasJournal(PIN);

            if (hasJournals)
            {
                return $"Client with PIN {PIN} can not leave the library before he returns all journals.";
            }

            return $"Client with PIN {PIN} exit successful.";
        }
    }
}
