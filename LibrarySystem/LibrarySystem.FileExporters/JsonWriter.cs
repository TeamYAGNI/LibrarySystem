// <copyright file="JsonWriter.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of JSON file writer.</summary>

using System.Collections.Generic;
using Bytes2you.Validation;
using LibrarySystem.FileExporters.Utils.Contracts;
using LibrarySystem.Models;

namespace LibrarySystem.FileExporters
{
    /// <summary>
    /// Represent a <see cref="JsonWriter"/> class.
    /// </summary>
    public class JsonWriter
    {
        /// <summary>
        /// Text writer wrapper interface handle.
        /// </summary>
        private ITextWriter textWriterWrapper;

        /// <summary>
        /// JSON Journals serializer object handle.
        /// </summary>
        private IJsonSerializer jsonSerializerWrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonWriter"/> class.
        /// </summary>
        /// <param name="textStreamWriter">Stream writer to be used for writing text data.</param>
        /// <param name="jsonJournalsSerializer">JSON serializer to be used for converting object data</param>
        public JsonWriter(ITextWriter textWriterWrapper, IJsonSerializer jsonSerializerWrapper)
        {
            Guard.WhenArgument(textWriterWrapper, "JsonWriter").IsNull().Throw();
            
            Guard.WhenArgument(jsonSerializerWrapper, "JsonWriter").IsNull().Throw();

            this.textWriterWrapper = textWriterWrapper;
            this.jsonSerializerWrapper = jsonSerializerWrapper;
        }

        /// <summary>
        /// Exports the specified collection of Journal DTOs to JSON text file.
        /// </summary>
        /// <param name="journals">Collection of Journal DTOs.</param>
        public void ExportJournals(IEnumerable<JournalDto> journals)
        {
            Guard.WhenArgument(journals, "ExportJournals").IsNull().Throw();

            using (this.textWriterWrapper.GetTextWriter())
            {
                this.textWriterWrapper.GetTextWriter().Write(this.jsonSerializerWrapper.Serialize(journals));
            }
        }
    }
}
