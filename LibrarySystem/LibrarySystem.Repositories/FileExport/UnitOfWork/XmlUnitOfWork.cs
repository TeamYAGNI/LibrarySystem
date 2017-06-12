using System;
using Bytes2you.Validation;
using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Models.DTOs.XML;
using LibrarySystem.FileExporters.Contracts;
using System.Linq;

namespace LibrarySystem.Repositories.FileExport.UnitOfWork
{
    public class XmlUnitOfWork : IUnitOfWork
    {
        private IXmlWriter xmlFileContext;
        private IRepository<BookXmlDto> books;

        public XmlUnitOfWork(IXmlWriter xmlFileContext, IRepository<BookXmlDto> books)
        {
            Guard.WhenArgument(xmlFileContext, "XmlUnitOfWork").IsNull().Throw();
            Guard.WhenArgument(books, "XmlUnitOfWork").IsNull().Throw();

            this.xmlFileContext = xmlFileContext;
            this.books = books;
        }

        public int Commit()
        {
            xmlFileContext.ExportBooks(this.books.GetAll());
            return this.books.GetAll().Count();
        }

        public void Dispose()
        {
        }
    }
}
