using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.FileImporters;
using LibrarySystem.FileImporters.Utils;
using LibrarySystem.Models.DTOs.XML;
using LibrarySystem.Repositories.Contracts.Data;
using LibrarySystem.Repositories.Contracts.Data.UnitOfWork;

namespace LibrarySystem.Commands.Administrative.File
{
    public class ImportBooksFromFileCommand : Command, ICommand
    {
        private readonly XmlReader xmlFileReader;
        private readonly ICommand createBookCommand;

        public ImportBooksFromFileCommand(XmlReader xmlFileReader, ICommand createBookCommand) : base(new List<object>() { xmlFileReader, createBookCommand }, 0)
        {
            this.xmlFileReader = xmlFileReader;
            this.createBookCommand = createBookCommand;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var books = xmlFileReader.ImportBooks();

            if (books.Count() == 0)
            {
                return $"Sorry, there are no books in the file.";
            }

            string bookTitle;
            string bookISBN;
            string pageCount;
            string yearOfPublishing;
            string publisherName;
            string quantity;

            foreach (var book in books)
            {
                bookTitle = book.Title;
                bookISBN = book.ISBN;
                pageCount = book.PageCount.ToString();
                yearOfPublishing = book.YearOfPublishing.ToString();
                publisherName = book.Publisher.Name;
                quantity = book.Quantity.ToString();
                this.createBookCommand.Execute(new List<string>()
                {
                    bookTitle,
                    bookISBN,
                    pageCount,
                    yearOfPublishing,
                    publisherName,
                    quantity
                });
            }

            return $"Books successfully imported.";
        }
    }
}
