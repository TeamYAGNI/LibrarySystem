using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Models;
using LibrarySystem.Models.Factory;
using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Repositories.Data.Contracts;

namespace LibrarySystem.Commands.Functional
{
    public class ClientGetJournalCommand : ICommand
    {
        private readonly IClientRepository clientRepository;
        private readonly IJournalRepository journalRepository;

        public ClientGetJournalCommand(IClientRepository clientRepository, IJournalRepository journalRepository)
        {
            this.clientRepository = clientRepository;
            this.journalRepository = journalRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var sb = new StringBuilder();
            string PIN = parameters[0];
            string ISSN = parameters[1];

            Client client = this.clientRepository.GetClientByPin(PIN);
            Journal journal = this.journalRepository.FindJournalByISSN(ISSN);

            if (client == null)
            {
                sb.AppendLine($"Client with PIN {PIN} not found");
                return sb.ToString();
            }

            if (journal == null)
            {
                sb.AppendLine($"Journal with ISSN {ISSN} not found");
                return sb.ToString();
            }

            if (journal.Available <= 0)
            {
                sb.AppendLine($"Journal {journal.Title} is not available right now");
                journal.Available = 0;
                return sb.ToString();
            }

            journal.Available--;
            client.Journals.Add(journal);

            sb.AppendLine($"{client.FullName} got {journal.Title}");
            sb.AppendLine($"This item can not be lended");
            return sb.ToString();
        }
    }
}
