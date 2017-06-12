using System.Collections.Generic;
using LibrarySystem.Models.DTOs.JSON;

namespace LibrarySystem.FileImporters.Utils.Contracts
{
    public interface IJsonDeserializer
    {
        IEnumerable<JournalJsonDto> Deserialize(string jsonJournalsText);
    }
}
