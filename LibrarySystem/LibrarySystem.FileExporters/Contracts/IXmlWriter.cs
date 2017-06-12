using System.Collections.Generic;
using LibrarySystem.Models.DTOs.XML;

namespace LibrarySystem.FileExporters.Contracts
{
    public interface IXmlWriter
    {
        void ExportBooks(IEnumerable<BookXmlDto> books);
    }
}
