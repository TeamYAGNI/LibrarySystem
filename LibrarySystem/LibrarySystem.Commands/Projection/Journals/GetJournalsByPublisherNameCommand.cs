using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Projection.Journals
{
    public class GetJournalsByPublisherNameCommand : Command, ICommand
    {
        private readonly IJournalRepository journalRepository;

        public GetJournalsByPublisherNameCommand(IJournalRepository journalRepository) : base(new List<object>() { journalRepository }, 1)
        {
            this.journalRepository = journalRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

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
