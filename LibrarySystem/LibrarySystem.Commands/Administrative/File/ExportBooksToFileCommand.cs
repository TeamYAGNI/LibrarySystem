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
                var dtoBook = new BookXmlDto();
                dtoBook.ISBN = book.ISBN;
                dtoBook.PageCount = book.PageCount;
                dtoBook.Quantity = book.Quantity;
                dtoBook.Title = book.Title;
                dtoBook.YearOfPublishing = book.YearOfPublishing;
                dtoBook.Description = book.Description;

                if (book.Publisher != null)
                {
                    dtoBook.Publisher.Name = book.Publisher.Name;
                }

                if (book.Authors.Count != 0)
                {
                    var dtoAuthors = new List<AuthorXmlDto>();

                    foreach (var author in book.Authors)
                    {
                        var dtoAuthor = new AuthorXmlDto();
                        dtoAuthor.FirstName = author.FirstName;
                        dtoAuthor.LastName = author.LastName;
                        dtoAuthor.GenderType = author.GenderType;
                        dtoAuthors.Add(dtoAuthor);
                    }

                    dtoBook.Authors = dtoAuthors;
                }

                if (book.Genres.Count() != 0)
                {
                    var dtoGenres = new List<GenreXmlDto>();

                    foreach (var genre in book.Genres)
                    {
                        var dtoGenre = new GenreXmlDto();
                        dtoGenre.Name = genre.Name;
                        dtoGenres.Add(dtoGenre);
                    }

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
                return $"Books could not export due to technical reasons";
            }

            return $"Books successfully exported";
        }
    }
}
