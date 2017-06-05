// <copyright file="JsonReader.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of JSON file reader.</summary>

using System;
using System.Collections.Generic;
using System.IO;
using LibrarySystem.FileImporters.Utils;
using LibrarySystem.Models;

namespace LibrarySystem.FileImporters
{
    /// <summary>
    /// Represent a <see cref="JsonReader"/> class.
    /// </summary>
    public class JsonReader
    {
        /// <summary>
        /// Stream reader object handle.
        /// </summary>
        private StreamReader streamReader;

        /// <summary>
        /// JSON Journals deserializer object handle.
        /// </summary>
        private JsonJournalsDeserializer jsonJournalsDeserializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonReader"/> class.
        /// </summary>
        /// <param name="streamReader">Stream reader to be used for reading text data.</param>
        /// <param name="jsonJournalsDeserializer">JSON deserializer to be used for converting JSON text.</param>
        public JsonReader(StreamReader streamReader, JsonJournalsDeserializer jsonJournalsDeserializer)
        {
            if (streamReader == null)
            {
                throw new ArgumentNullException("Stream reader cannot be null.");
            }

            if (jsonJournalsDeserializer == null)
            {
                throw new ArgumentNullException("JSON Journals deserializer cannot be null.");
            }

            this.streamReader = streamReader;
            this.jsonJournalsDeserializer = jsonJournalsDeserializer;
        }

        /// <summary>
        /// Imports the specified collection of Journal DTOs from JSON text file.
        /// </summary>
        /// <returns>Collection of Journal DTOs.</returns>
        public IEnumerable<DTOJournal> ImportJournals()
        {
            using (this.streamReader)
            {
                return this.jsonJournalsDeserializer.Deserialize(this.streamReader.ReadToEnd());
            }
        }
    }
}
