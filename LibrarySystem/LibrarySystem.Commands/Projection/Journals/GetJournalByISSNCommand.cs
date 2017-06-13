using System.Collections.Generic;
using System.Text;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Projection.Journals
{
    public class GetJournalByISSNCommand : Command, ICommand
    {
        private readonly IJournalRepository journalRepository;

        public GetJournalByISSNCommand(IJournalRepository journalRepository) : base(new List<object>() { journalRepository }, 1)
        {
            this.journalRepository = journalRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

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
