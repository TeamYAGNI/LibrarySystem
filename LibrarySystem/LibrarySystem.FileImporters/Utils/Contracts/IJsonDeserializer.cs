using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.FileImporters.Utils.Contracts
{
    public interface IJsonDeserializer
    {
        IEnumerable<JournalDto> Deserialize(string jsonJournalsText);
    }
}
