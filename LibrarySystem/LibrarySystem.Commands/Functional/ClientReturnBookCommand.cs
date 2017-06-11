using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Framework.Providers;
using LibrarySystem.Models;
using LibrarySystem.Models.Factory;
using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Repositories.Data.Contracts;

namespace LibrarySystem.Commands.Functional
{
    public class ClientReturnBookCommand : ICommand
    {
        private readonly ILendingRepository lendingRepository;

        public ClientReturnBookCommand(ILendingRepository lendingRepository)
        {
            this.lendingRepository = lendingRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var sb = new StringBuilder();
            var PIN = parameters[0];
            var ISBN = parameters[1];
            var remarks = parameters[2];

            var lending = this.lendingRepository.GetLendingsByClientPIN(PIN).FirstOrDefault(l => l.Book.ISBN == ISBN);

            if (lending == null)
            {
                sb.AppendLine($"Book with ISBN {ISBN} was not found in Client's collection.");
                return sb.ToString();
            }

            var book = lending.Book;

            book.Available++;
            if (book.Available > book.Quantity)
            {
                book.Available = book.Quantity;
            }

            var delay = lending.BorrоwDate.AddMonths(1) - TimeProvider.Current.Today;
            var delayedMessage = $"Delayed by {delay.Days} days.{Environment.NewLine}";
            remarks = (delay.Days > 0) ? delayedMessage + remarks : remarks;

            lending.Remarks = remarks;
            lending.ReturnDate = TimeProvider.Current.Today;

            sb.AppendLine($"{book.Title} was successfully returned.");
            return sb.ToString();
        }
    }
}

