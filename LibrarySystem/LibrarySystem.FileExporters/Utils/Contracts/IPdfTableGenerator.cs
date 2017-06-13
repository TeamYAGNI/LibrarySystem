using System.Collections.Generic;
using iTextSharp.text.pdf;
using LibrarySystem.Models;

namespace LibrarySystem.FileExporters.Utils.Contracts
{
    public interface IPdfTableGenerator
    {
        PdfPTable CreateTable(IEnumerable<Lending> report);
    }
}
