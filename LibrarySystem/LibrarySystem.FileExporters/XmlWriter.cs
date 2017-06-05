// <copyright file="XmlWriter.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of XML file writer.</summary>

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using LibrarySystem.FileExporters.Utils.Contracts;
using LibrarySystem.Models;

namespace LibrarySystem.FileExporters
{
    /// <summary>
    /// Represent a <see cref="XmlWriter"/> class.
    /// </summary>
    public class XmlWriter
    {
        /// <summary>
        /// Text writer wrapper interface handle.
        /// </summary>
        private ITextWriterWrapper textWriterWrapper;

        /// <summary>
        /// XML Books serializer wrapper interface handle.
        /// </summary>
        private IXmlSerializerWrapper xmlSerializerWrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlWriter"/> class.
        /// </summary>
        /// <param name="ITextWriterWrapper">Stream writer to be used for writing text data.</param>
        /// <param name="xmlSerializerWrapper">XML serializer to be used for converting object data</param>
        public XmlWriter(ITextWriterWrapper textWriterWrapper, IXmlSerializerWrapper xmlSerializerWrapper)
        {
            if (textWriterWrapper == null)
            {
                throw new ArgumentNullException("Text stream wrapper cannot be null.");
            }

            if (xmlSerializerWrapper == null)
            {
                throw new ArgumentNullException("XML Books serializer cannot be null.");
            }

            this.textWriterWrapper = textWriterWrapper;
            this.xmlSerializerWrapper = xmlSerializerWrapper;
        }

        /// <summary>
        /// Exports the specified collection of Book DTOs to XML text file.
        /// </summary>
        /// <param name="books">Collection of Book DTOs.</param>
        public void ExportBooks(IEnumerable<DTOBook> books)
        {
            using (this.textWriterWrapper.TextWriter)
            {
                this.xmlSerializerWrapper.XmlSerializer.Serialize(this.textWriterWrapper.TextWriter, books);
            }
        }
    }
}
