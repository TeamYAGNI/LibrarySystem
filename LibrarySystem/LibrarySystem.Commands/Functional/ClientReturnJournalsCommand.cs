using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bytes2you.Validation;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;
using LibrarySystem.Repositories.Contracts.Data.UnitOfWork;

namespace LibrarySystem.Commands.Functional
{
    public class ClientReturnJournalsCommand : Command, ICommand
    {
        private readonly ILibraryUnitOfWork libraryUnitOfWork;
        private readonly IJournalRepository journalRepository;

        public ClientReturnJournalsCommand(ILibraryUnitOfWork libraryUnitOfWork, IJournalRepository journalRepository) : base(new List<object>() { libraryUnitOfWork, journalRepository }, 1)
        {
            this.libraryUnitOfWork = libraryUnitOfWork;
            this.journalRepository = journalRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

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

            this.libraryUnitOfWork.Commit();
            return sb.ToString();
        }
    }
}
