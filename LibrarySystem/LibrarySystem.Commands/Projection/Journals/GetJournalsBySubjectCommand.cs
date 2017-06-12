using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bytes2you.Validation;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Projection.Journals
{
    public class GetJournalsBySubjectCommand : ICommand
    {
        private readonly IJournalRepository journalRepository;

        public GetJournalsBySubjectCommand(IJournalRepository journalRepository)
        {
            Guard.WhenArgument(journalRepository, "journalRepository").IsNull().Throw();

            this.journalRepository = journalRepository;
        }

        public string Execute(IList<string> parameters)
        {
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
