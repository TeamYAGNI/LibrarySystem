using System.Collections.Generic;
using Bytes2you.Validation;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Functional
{
    public class ClientExitLibraryCommand : ICommand
    {
        private readonly IClientRepository clientRepository;

        public ClientExitLibraryCommand(IClientRepository clientRepository)
        {
            Guard.WhenArgument(clientRepository, "clientRepository").IsNull().Throw();

            this.clientRepository = clientRepository;
        }

        public string Execute(IList<string> parameters)
        {
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
