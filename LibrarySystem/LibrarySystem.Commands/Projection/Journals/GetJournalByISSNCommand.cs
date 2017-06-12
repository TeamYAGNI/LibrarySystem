using System.Collections.Generic;
using System.Text;

using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Projection.Journals
{
    public class GetJournalByISSNCommand : ICommand
    {
        private readonly IJournalRepository journalRepository;

        public GetJournalByISSNCommand(IJournalRepository journalRepository)
        {
            this.journalRepository = journalRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var ISSN = parameters[0];

            var journal = this.journalRepository.FindJournalByISSN(ISSN);

            if (journal == null)
            {
                return $"There is no journal with ISSN {ISSN} in our Library.";
            }

            var sb = new StringBuilder();

            sb.AppendLine($"* Journal Title: {journal.Title}");
            sb.AppendLine($"* Journal Year Of Publishing: {journal.YearOfPublishing}");
            sb.AppendLine($"* Journal Issue Number: {journal.IssueNumber}");
            sb.AppendLine($"* Journal Available Quantity: {journal.Available}");

            return sb.ToString();
        }
    }
}
