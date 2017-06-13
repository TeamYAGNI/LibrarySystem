using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.FileExporters;
using LibrarySystem.Models.DTOs.XML;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Administrative.File
{
    public class ExportBooksToFileCommand : Command, ICommand
    {
        private readonly XmlWriter xmlWriter;
        private readonly IBookRepository bookRepository;

        public ExportBooksToFileCommand(XmlWriter xmlWriter, IBookRepository bookRepository) : base(new List<object>()
        {
            xmlWriter, bookRepository
        }, 0)
        {
            this.xmlWriter = xmlWriter;
            this.bookRepository = bookRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);
            var books = this.bookRepository.GetAll();

            if (books.Count() == 0)
            {
                return $"There are no books in the base";
            }

            var dtoBooks = new List<BookXmlDto>();

            foreach (var book in books)
            {
                var dtoBook = new BookXmlDto
                {
                    ISBN = book.ISBN,
                    PageCount = book.PageCount,
                    Quantity = book.Quantity,
                    Title = book.Title,
                    YearOfPublishing = book.YearOfPublishing,
                    Description = book.Description
                };

                if (book.Publisher != null)
                {
                    var dtoPublisher = new PublisherXmlDto();
                    dtoPublisher.Name = book.Publisher.Name;
                    dtoBook.Publisher = dtoPublisher;
                }

                if (book.Authors.Count != 0)
                {
                    var dtoAuthors = book.Authors.Select(author => new AuthorXmlDto
                    {
                        FirstName = author.FirstName,
                        LastName = author.LastName,
                        GenderType = author.GenderType
                    })
                        .ToList();

                    dtoBook.Authors = dtoAuthors;
                }

                if (book.Genres.Count() != 0)
                {
                    var dtoGenres = book.Genres.Select(genre => new GenreXmlDto { Name = genre.Name }).ToList();

                    dtoBook.Genres = dtoGenres;
                }

                dtoBooks.Add(dtoBook);
            }

            try
            {
                xmlWriter.ExportBooks(dtoBooks);
            }
            catch (Exception)
            {
                return $"Books could not export due to technical issues.";
            }

            return $"Books successfully exported";
        }
    }
}
