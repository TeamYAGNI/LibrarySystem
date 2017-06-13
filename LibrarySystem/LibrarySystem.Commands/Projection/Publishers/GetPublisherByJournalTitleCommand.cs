using System.Collections.Generic;
using System.Text;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Projection.Publishers
{
    public class GetPublisherByJournalTitleCommand : Command, ICommand
    {
        private readonly IPublisherRepository publishersRepository;

        public GetPublisherByJournalTitleCommand(IPublisherRepository publishersRepository) : base(new List<object>() { publishersRepository }, 1)
        {
            this.publishersRepository = publishersRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var journalTitle = parameters[0];

            var publisher = this.publishersRepository.GetPublisherByJournalTitle(journalTitle);

            if (publisher == null)
            {
                return $"There is no data for publisher of Journal {journalTitle}";
            }

            var sb = new StringBuilder();

            sb.AppendLine($"* Publisher of Journal {journalTitle}:");
            sb.AppendLine($"* {publisher.Name}");

            return sb.ToString();
        }
    }
}
