using System.Collections.Generic;
using System.Text;
using Bytes2you.Validation;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Framework.Providers;
using LibrarySystem.Models;
using LibrarySystem.Models.Factory;
using LibrarySystem.Repositories.Contracts.Data;
using LibrarySystem.Repositories.Contracts.Data.UnitOfWork;

namespace LibrarySystem.Commands.Functional
{
    public class ClientGetBookCommand : Command, ICommand
    {
        private readonly ILibraryUnitOfWork libraryUnitOfWork;
        private readonly IModelsFactory modelsFactory;
        private readonly IClientRepository clientRepository;
        private readonly IBookRepository bookRepository;
        private readonly ILendingRepository lendingRepository;

        public ClientGetBookCommand(ILibraryUnitOfWork libraryUnitOfWork, IModelsFactory modelsFactory, IClientRepository clientRepository, IBookRepository bookRepository, ILendingRepository lendingRepository) : base(new List<object>() { libraryUnitOfWork, modelsFactory, clientRepository, bookRepository, lendingRepository }, 2)
        {
            this.libraryUnitOfWork = libraryUnitOfWork;
            this.modelsFactory = modelsFactory;
            this.clientRepository = clientRepository;
            this.bookRepository = bookRepository;
            this.lendingRepository = lendingRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var sb = new StringBuilder();
            string PIN = parameters[0];
            string ISBN = parameters[1];

            Client client = this.clientRepository.GetClientByPin(PIN);
            Book book = this.bookRepository.GetBookByISBN(ISBN);

            if (client == null)
            {
                sb.AppendLine($"Client with PIN {PIN} not found");
                return sb.ToString();
            }

            if (book == null)
            {
                sb.AppendLine($"Book with ISBN {ISBN} not found");
                return sb.ToString();
            }

            if (book.Available <= 0)
            {
                sb.AppendLine($"Book {book.Title} is not available right now");
                book.Available = 0;
                return sb.ToString();
            }

            book.Available--;
            var lending = modelsFactory.CreateLending(book, client, TimeProvider.Current.Today, null, null);
            lendingRepository.Add(lending);

            sb.AppendLine($"{client.FullName} got {book.Title}");
            sb.AppendLine($"Should return it by {TimeProvider.Current.Today.AddMonths(1).Date:D}");

            this.libraryUnitOfWork.Commit();
            return sb.ToString();
        }
    }
}
