using System.Collections.Generic;

using Bytes2you.Validation;

using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;
using LibrarySystem.Repositories.Contracts.Data.UnitOfWork;
using LibrarySystem.Models;
using LibrarySystem.Models.Factory;

namespace LibrarySystem.Commands.Administrative.Creational
{
    public class CreateJournalCommand : ICommand
    {
        private const string SuccessMessage = "Journal {0} was created succesfully!";
        private const string ErrorMessage = "There is already a journal with ISSN {0} and issue number {1} in the library.";
        private const string InvalidIssueNumberMessage = "Issue number of the journal cannot be {0}!";
        private const string InvalidYearOfPublishingMessage = "Year of publishing of the journal cannot be {0}!";
        private const string InvalidQuantityMessage = "Initial quantity of the journal cannot be {0}!";

        private readonly IPublisherRepository publishers;
        private readonly IJournalRepository journals;
        private readonly ILibraryUnitOfWork unitOfWork;
        private readonly IModelsFactory factory;

        public CreateJournalCommand(
            IPublisherRepository publishers,
            IJournalRepository journals,
            ILibraryUnitOfWork unitOfWork,
            IModelsFactory factory)
        {
            Guard.WhenArgument(publishers, "CreateBookCommand publishers").IsNull().Throw();
            Guard.WhenArgument(journals, "CreateBookCommand journals").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "CreateBookCommand unitOfWork").IsNull().Throw();
            Guard.WhenArgument(factory, "CreateBookCommand factory").IsNull().Throw();

            this.publishers = publishers;
            this.journals = journals;
            this.unitOfWork = unitOfWork;
            this.factory = factory;
        }

        public string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, "CreateJournalCommand parameters").IsNull().Throw();
            Guard.WhenArgument(parameters.Count, "CreateJournalCommand parameters count").IsNotEqual(6).Throw();

            string journalTitle = parameters[0];
            string journalISSN = parameters[1];
            string publisherName = parameters[4];


            int issueNumber;
            if (!int.TryParse(parameters[2], out issueNumber))
            {
                return string.Format(InvalidIssueNumberMessage, parameters[2]);
            }

            int yearOfPublishing;
            if (!int.TryParse(parameters[3], out yearOfPublishing))
            {
                return string.Format(InvalidYearOfPublishingMessage, parameters[3]);
            }

            int quantity;
            if (!int.TryParse(parameters[5], out quantity))
            {
                return string.Format(InvalidQuantityMessage, parameters[5]);
            }

            int available = quantity;

            Publisher publisher = publishers.GetPublisherByName(publisherName) ?? this.factory.CreatePublisher(publisherName, null, null);
            Journal journal = this.journals.FindJournalByISSN(journalISSN);

            if (journal != null)
            {
                return string.Format(ErrorMessage, journalISSN, issueNumber);
            }

            journal = this.factory.CreateJournal(journalTitle, null, journalISSN, issueNumber, yearOfPublishing, publisher, quantity, available, null);

            this.journals.Add(journal);
            this.unitOfWork.Commit();

            return string.Format(SuccessMessage, journalTitle);
        }
    }
}
