using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Repositories.Data.Contracts;

namespace LibrarySystem.Commands.Functional
{
    public class ClientReturnJournalsCommand : ICommand
    {
        private readonly IJournalRepository journalRepository;

        public ClientReturnJournalsCommand(IJournalRepository journalRepository)
        {
            this.journalRepository = journalRepository;
        }
        public string Execute(IList<string> parameters)
        {
            var sb = new StringBuilder();
            var PIN = parameters[0];

            var journals = journalRepository.GetAllClientJournals(PIN);

            if (journals.Count() == 0)
            {
                sb.AppendLine($"Client with PIN {PIN} has no Journals");
                return sb.ToString();
            }

            var client = journals.First().Client;

            sb.AppendLine($"Client {client.FullName} returned:");
            foreach (var journal in journals)
            {
                journal.Available++;
                if (journal.Available > journal.Quantity)
                {
                    journal.Available = journal.Quantity;
                }
                sb.AppendLine($"- {journal.Title}");
            }

            client.Journals.Clear();

            return sb.ToString();
        }
    }
}
