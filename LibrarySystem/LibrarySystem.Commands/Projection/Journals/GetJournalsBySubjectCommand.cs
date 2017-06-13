using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bytes2you.Validation;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Projection.Journals
{
    public class GetJournalsBySubjectCommand : Command, ICommand
    {
        private readonly IJournalRepository journalRepository;

        public GetJournalsBySubjectCommand(IJournalRepository journalRepository) : base(new List<object>() { journalRepository }, 1)
        {
            this.journalRepository = journalRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var subject = parameters[0];

            var journals = this.journalRepository.GetJournalsBySubject(subject);

            if (journals.Count() == 0)
            {
                return $"There are no journals on Subject {subject} in our Library.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Journals on Subject {subject}:");
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
