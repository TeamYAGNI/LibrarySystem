﻿using System.Collections.Generic;
using System.Text;
using Bytes2you.Validation;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Projection.Publishers
{
    public class GetPublisherByBookTitleCommand : ICommand
    {
        private readonly IPublisherRepository publishersRepository;

        public GetPublisherByBookTitleCommand(IPublisherRepository publishersRepository)
        {
            Guard.WhenArgument(publishersRepository, "publishersRepository").IsNull().Throw();

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