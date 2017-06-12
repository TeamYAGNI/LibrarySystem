// <copyright file="JsonBooksSerializer.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of JSON serializer wrapper.</summary>

using System.Collections.Generic;
using System.Xml.Serialization;
using Bytes2you.Validation;
using LibrarySystem.FileExporters.Utils.Contracts;
using LibrarySystem.Models;
using LibrarySystem.Models.DTOs.XML;

namespace LibrarySystem.FileExporters.Utils
{
    /// <summary>
    /// Represent a <see cref="XmlSerializerWrapper"/> class.
    /// </summary>
    public class XmlSerializerWrapper : IXmlSerializer
    {
        /// <summary>
        /// 
        /// </summary>
        private XmlSerializer xmlSerializer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlSerializer"></param>
        public XmlSerializerWrapper(XmlSerializer xmlSerializer)
        {
            Guard.WhenArgument(xmlSerializer, "XmlSerializerWrapper").IsNull().Throw();
        
            this.xmlSerializer = xmlSerializer;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Serialize(ITextWriter textWriter, IEnumerable<BookXmlDto> books)
        {
            Guard.WhenArgument(books, "Serialize").IsNull().Throw();

            this.xmlSerializer.Serialize(textWriter.GetTextWriter(), books);
        }
    }
}
