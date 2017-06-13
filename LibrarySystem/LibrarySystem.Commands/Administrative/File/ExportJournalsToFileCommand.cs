using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.FileExporters;
using LibrarySystem.FileExporters.Contracts;
using LibrarySystem.Models.DTOs.JSON;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Administrative.File
{
    public class ExportJournalsToFileCommand : Command, ICommand
    {
        private readonly JsonWriter jsonWriter;
        private readonly IJournalRepository journalRepository;

        public ExportJournalsToFileCommand(JsonWriter jsonWriter, IJournalRepository journalRepository) : base(new List<object>() { jsonWriter, journalRepository }, 0)
        {
            this.jsonWriter = jsonWriter;
            this.journalRepository = journalRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var journals = this.journalRepository.GetAll();

            if (journals.Count() == 0)
            {
                return $"There are no journals in the base";
            }

            var dtoJournals = new List<JournalJsonDto>();

            foreach (var journal in journals)
            {
                var dtoJournal = new JournalJsonDto();

                dtoJournal.Title = journal.Title;
                dtoJournal.ISSN = journal.ISSN;
                dtoJournal.IssueNumber = journal.IssueNumber;
                dtoJournal.Quantity = journal.Quantity;
                dtoJournal.YearOfPublishing = journal.YearOfPublishing;

                if (journal.ImpactFactor != null)
                {
                    dtoJournal.ImpactFactor = journal.ImpactFactor;
                }

                if (journal.Publisher != null)
                {
                    var dtoPublisher = new PublisherJsonDto();
                    dtoPublisher.Name = journal.Publisher.Name;
                    dtoJournal.Publisher = dtoPublisher;
                }

                if (journal.Subjects.Count() != 0)
                {
                    var dtoSubjects = new List<SubjectJsonDto>();

                    foreach (var subject in journal.Subjects)
                    {
                        var dtoSubject = new SubjectJsonDto();
                        dtoSubject.Name = subject.Name;
                        dtoSubjects.Add(dtoSubject);
                    }

                    dtoJournal.Subjects = dtoSubjects;
                }

                dtoJournals.Add(dtoJournal);
            }

            try
            {
                this.jsonWriter.ExportJournals(dtoJournals);
            }
            catch (Exception)
            {
                return $"Journals could not export due to technical issues.";
            }

            return $"Journals successfully exported";
        }
    }
}
