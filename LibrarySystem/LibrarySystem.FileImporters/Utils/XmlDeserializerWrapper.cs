using System.Collections.Generic;
using System.Xml.Serialization;
using Bytes2you.Validation;
using LibrarySystem.FileImporters.Utils.Contracts;
using LibrarySystem.Models.DTOs.XML;

namespace LibrarySystem.FileImporters.Utils
{
    public class XmlDeserializerWrapper : IXmlDeserializer
    {
        private XmlSerializer xmlSerializer;

        public XmlDeserializerWrapper(XmlSerializer xmlSerializer)
        {
            Guard.WhenArgument(xmlSerializer, "XmlDeserializerWrapper").IsNull().Throw();

            this.xmlSerializer = xmlSerializer;
        }
        
        public IEnumerable<BookXmlDto> Deserialize(IStreamReader streamReader)
        {
            Guard.WhenArgument(streamReader, "Deseralize").IsNull().Throw();

            return (IEnumerable<BookXmlDto>)this.xmlSerializer.Deserialize(streamReader.GetStreamReader());
        }
    }
}
