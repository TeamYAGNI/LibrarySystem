// <copyright file="XmlReader.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of XML file reader.</summary>

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using LibrarySystem.Models;

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
        private StreamReader streamReader;

        /// <summary>
        /// XML Books deserializer object handle.
        /// </summary>
        private XmlSerializer xmlBooksSerializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlReader"/> class.
        /// </summary>
        /// <param name="streamReader">Stream reader to be used for reading text data.</param>
        /// <param name="xmlBooksSerializer">XML deserializer to be used for converting XML text.</param>
        public XmlReader(StreamReader streamReader, XmlSerializer xmlBooksSerializer)
        {
            if (streamReader == null)
            {
                throw new ArgumentNullException("Stream reader cannot be null.");
            }

            if (xmlBooksSerializer == null)
            {
                throw new ArgumentNullException("XML Books serializer cannot be null.");
            }

            this.streamReader = streamReader;
            this.xmlBooksSerializer = xmlBooksSerializer;
        }

        /// <summary>
        /// Imports the specified collection of Book DTOs from XML text file.
        /// </summary>
        /// <returns>Collection of Journal DTOs</returns>
        public IEnumerable<DTOBook> ImportBooks()
        {
            using (this.streamReader)
            {
                return (IEnumerable<DTOBook>)this.xmlBooksSerializer.Deserialize(this.streamReader);
            }
        }
    }
}
