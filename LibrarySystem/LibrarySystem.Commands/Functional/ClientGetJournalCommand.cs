﻿using System.Collections.Generic;
using System.Text;
using Bytes2you.Validation;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Contracts.Data;
using LibrarySystem.Repositories.Contracts.Data.UnitOfWork;

namespace LibrarySystem.Commands.Functional
{
    public class ClientGetJournalCommand : ICommand
    {
        private readonly ILibraryUnitOfWork libraryUnitOfWork;
        private readonly IClientRepository clientRepository;
        private readonly IJournalRepository journalRepository;

        public ClientGetJournalCommand(ILibraryUnitOfWork libraryUnitOfWork, IClientRepository clientRepository, IJournalRepository journalRepository)
        {
            Guard.WhenArgument(libraryUnitOfWork, "libraryUnitOfWork").IsNull().Throw();
            Guard.WhenArgument(clientRepository, "clientRepository").IsNull().Throw();
            Guard.WhenArgument(journalRepository, "journalRepository").IsNull().Throw();

            this.libraryUnitOfWork = libraryUnitOfWork;
            this.clientRepository = clientRepository;
            this.journalRepository = journalRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var sb = new StringBuilder();
            string PIN = parameters[0];
            string ISSN = parameters[1];

            Client client = this.clientRepository.GetClientByPin(PIN);
            Journal journal = this.journalRepository.FindJournalByISSN(ISSN);

            if (client == null)
            {
                sb.AppendLine($"Client with PIN {PIN} not found");
                return sb.ToString();
            }

            if (journal == null)
            {
                sb.AppendLine($"Journal with ISSN {ISSN} not found");
                return sb.ToString();
            }

            if (journal.Available <= 0)
            {
                sb.AppendLine($"Journal {journal.Title} is not available right now");
                journal.Available = 0;
                return sb.ToString();
            }

            journal.Available--;
            client.Journals.Add(journal);

            sb.AppendLine($"{client.FullName} got {journal.Title}");
            sb.AppendLine($"This item can not be lended");

            this.libraryUnitOfWork.Commit();
            return sb.ToString();
        }
    }
}
