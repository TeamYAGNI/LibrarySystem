using System.Collections.Generic;
using LibrarySystem.Models.DTOs.JSON;

namespace LibrarySystem.FileExporters.Contracts
{
    public interface IJsonWriter
    {
        void ExportJournals(IEnumerable<JournalJsonDto> journals);
    }
}
