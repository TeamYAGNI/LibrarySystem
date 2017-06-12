using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Data.Contracts;

namespace LibrarySystem.Commands.Projection.Publishers
{
    public class GetPublisherByJournalTitleCommand : ICommand
    {
        private readonly IPublisherRepository publishersRepository;

        public GetPublisherByJournalTitleCommand(IPublisherRepository publishersRepository)
        {
            this.publishersRepository = publishersRepository;
        }

        public string Execute(IList<string> parameters)
        {
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
