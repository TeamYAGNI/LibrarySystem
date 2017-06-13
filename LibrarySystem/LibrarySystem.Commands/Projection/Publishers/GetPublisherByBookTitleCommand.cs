using System.Collections.Generic;
using System.Text;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Projection.Publishers
{
    public class GetPublisherByBookTitleCommand : Command, ICommand
    {
        private readonly IPublisherRepository publishersRepository;

        public GetPublisherByBookTitleCommand(IPublisherRepository publishersRepository) : base(new List<object>() { publishersRepository }, 1)
        {
            this.publishersRepository = publishersRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

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
