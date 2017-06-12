using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Data.Contracts;

namespace LibrarySystem.Commands.Projection.Publishers
{
    public class GetPublisherByBookTitleCommand : ICommand
    {
        private readonly IPublisherRepository publishersRepository;

        public GetPublisherByBookTitleCommand(IPublisherRepository publishersRepository)
        {
            this.publishersRepository = publishersRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var bookTitle = parameters[0];

            var publisher = this.publishersRepository.GetPublisherByBookTitle(bookTitle);

            if (publisher == null)
            {
                return $"There is no data for publisher of Book {bookTitle}";
            }

            var sb = new StringBuilder();

            sb.AppendLine($"* Publisher of Book {bookTitle}:");
            sb.AppendLine($"* {publisher.Name}");

            return sb.ToString();
        }
    }
}
