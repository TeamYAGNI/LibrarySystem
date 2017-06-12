using System.Collections.Generic;
using LibrarySystem.Models.DTOs.XML;

namespace LibrarySystem.FileImporters.Utils.Contracts
{
    public interface IXmlDeserializer
    {
        IEnumerable<BookXmlDto> Deserialize(IStreamReader streamReader);
    }
}
