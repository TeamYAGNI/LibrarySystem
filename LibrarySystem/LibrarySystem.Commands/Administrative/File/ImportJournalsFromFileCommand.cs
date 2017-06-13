using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.FileImporters;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Administrative.File
{
    public class ImportJournalsFromFileCommand : Command, ICommand
    {
        private readonly JsonReader jsonReader;
        private readonly ICommand createJournalCommand;

        public ImportJournalsFromFileCommand(JsonReader jsonReader, ICommand createJournalCommand) : base(new List<object>() { jsonReader, createJournalCommand }, 0)
        {
            this.jsonReader = jsonReader;
            this.createJournalCommand = createJournalCommand;
        }

        public override string Execute(IList<string> parameters)
        {
            var journals = jsonReader.ImportJournals();

            if (journals.Count() == 0)
            {
                return $"Sorry, there are no journals in the file.";
            }

            foreach (var journal in journals)
            {
                string journalTitle = journal.Title;
                string journalISSN = journal.ISSN;
                string issueNumber = journal.IssueNumber.ToString();
                string yearOfPublishing = journal.YearOfPublishing.ToString();
                string publisherName;
                if (journal.Publisher != null)
                {
                    publisherName = journal.Publisher.Name;
                }
                else
                {
                    publisherName = "Unknown Publisher";
                }
                string quantity = journal.Quantity.ToString();
                this.createJournalCommand.Execute(new List<string>()
                {
                    journalTitle,
                    journalISSN,
                    issueNumber,
                    yearOfPublishing,
                    publisherName,
                    quantity
                });

            }

            return $"Journals successfully imported";
        }
    }
}
