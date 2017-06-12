using System.Collections.Generic;
using System.Linq;
using System.Text;

using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Projection.Journals
{
    public class GetJournalsByPublisherNameCommand : ICommand
    {
        private readonly IJournalRepository journalRepository;

        public GetJournalsByPublisherNameCommand(IJournalRepository journalRepository)
        {
            this.journalRepository = journalRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var publisherName = parameters[0];

            var journals = this.journalRepository.GetJournalsByPublisherName(publisherName);

            if (journals.Count() == 0)
            {
                return $"There are no journals with Publisher {publisherName} in our Library.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Journals with Publisher {publisherName}:");
            foreach (var journal in journals)
            {
                sb.AppendLine($"* Journal Title: {journal.Title}");
                sb.AppendLine($"* Journal ISSN: {journal.ISSN}");
                sb.AppendLine($"* Journal Available Quantity: {journal.Available}");
            }

            return sb.ToString();
        }
    }
}
