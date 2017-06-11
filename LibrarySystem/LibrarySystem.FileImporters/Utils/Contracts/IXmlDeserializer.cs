using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.FileImporters.Utils.Contracts
{
    public interface IXmlDeserializer
    {
        IEnumerable<BookDto> Deserialize(IStreamReader streamReader);
    }
}
