// <copyright file="XmlWriter.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of XML file writer.</summary>

using System;
using System.Collections.Generic;
using LibrarySystem.FileExporters.Utils.Contracts;
using LibrarySystem.Models.DTOs.XML;
using Bytes2you.Validation;

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
        private ITextWriter textWriterWrapper;

        /// <summary>
        /// XML Books serializer wrapper interface handle.
        /// </summary>
        private IXmlSerializer xmlSerializerWrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlWriter"/> class.
        /// </summary>
        /// <param name="ITextWriterWrapper">Stream writer to be used for writing text data.</param>
        /// <param name="xmlSerializerWrapper">XML serializer to be used for converting object data</param>
        public XmlWriter(ITextWriter textWriterWrapper, IXmlSerializer xmlSerializerWrapper)
        {
            Guard.WhenArgument(textWriterWrapper, "PdfStreamWrapper").IsNull().Throw();
            Guard.WhenArgument(xmlSerializerWrapper, "PdfStreamWrapper").IsNull().Throw();

            this.textWriterWrapper = textWriterWrapper;
            this.xmlSerializerWrapper = xmlSerializerWrapper;
        }

        /// <summary>
        /// Exports the specified collection of Book DTOs to XML text file.
        /// </summary>
        /// <param name="books">Collection of Book DTOs.</param>
        public void ExportBooks(IEnumerable<BookXmlDto> books)
        {
            Guard.WhenArgument(books, "ExportBooks").IsNull().Throw();

            using (this.textWriterWrapper.GetTextWriter())
            {
                this.xmlSerializerWrapper.Serialize(this.textWriterWrapper, books);
            }
        }
    }
}
