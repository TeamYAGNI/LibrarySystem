using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Repositories.Data.Contracts;

namespace LibrarySystem.Commands.Functional
{
    public class ClientExitLibraryCommand : ICommand
    {
        private readonly IClientRepository clientRepository;

        public ClientExitLibraryCommand(IClientRepository clientRepository)
        {
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
