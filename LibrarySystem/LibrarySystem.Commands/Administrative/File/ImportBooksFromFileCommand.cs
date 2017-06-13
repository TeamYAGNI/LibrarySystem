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

            foreach (var book in books)
            {
                string bookTitle = book.Title;
                string bookISBN = book.ISBN;
                string pageCount = book.PageCount.ToString();
                string yearOfPublishing = book.YearOfPublishing.ToString();
                string publisherName;
                if (book.Publisher != null)
                {
                    publisherName = book.Publisher.Name;
                }
                else
                {
                    publisherName = "Mark Twain";
                }
                string quantity = book.Quantity.ToString();
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
