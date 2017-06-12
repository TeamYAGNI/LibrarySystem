// <copyright file="XmlReader.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of XML file reader.</summary>

using System.Collections.Generic;
using Bytes2you.Validation;
using LibrarySystem.FileImporters.Utils.Contracts;
using LibrarySystem.Models;
using LibrarySystem.Models.DTOs.XML;

namespace LibrarySystem.FileImporters
{
    /// <summary>
    /// Represent a <see cref="XmlReader"/> class.
    /// </summary>
    public class XmlReader
    {
        /// <summary>
        /// Stream reader object handle.
        /// </summary>
        private IStreamReader streamReaderWrapper;

        /// <summary>
        /// XML Books deserializer object handle.
        /// </summary>
        private IXmlDeserializer xmlDeserializerWrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlReader"/> class.
        /// </summary>
        /// <param name="streamReaderWrapper">Stream reader to be used for reading text data.</param>
        /// <param name="xmlBooksSerializer">XML deserializer to be used for converting XML text.</param>
        public XmlReader(IStreamReader streamReaderWrapper, IXmlDeserializer xmlDeserializerWrapper)
        {
            Guard.WhenArgument(streamReaderWrapper, "JsonReader").IsNull().Throw();

            Guard.WhenArgument(xmlDeserializerWrapper, "JsonReader").IsNull().Throw();

            this.streamReaderWrapper = streamReaderWrapper;
            this.xmlDeserializerWrapper = xmlDeserializerWrapper;
        }

        /// <summary>
        /// Imports the specified collection of Book DTOs from XML text file.
        /// </summary>
        /// <returns>Collection of Journal DTOs</returns>
        public IEnumerable<BookXmlDto> ImportBooks()
        {
            using (this.streamReaderWrapper.GetStreamReader())
            {
                return this.xmlDeserializerWrapper.Deserialize(this.streamReaderWrapper);
            }
        }
    }
}
