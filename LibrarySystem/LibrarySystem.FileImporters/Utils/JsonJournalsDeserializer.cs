// <copyright file="JsonJournalsDeserializer.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of JSON deserializer wrapper.</summary>

using System.Collections.Generic;
using LibrarySystem.Models;
using Newtonsoft.Json;

namespace LibrarySystem.FileImporters.Utils
{
    /// <summary>
    /// Represent a <see cref="JsonJournalsDeserializer"/> class.
    /// </summary>
    public class JsonJournalsDeserializer
    {
        /// <summary>
        /// Deserializes the JSON to the Journal DTO type - wrapper instance method.
        /// </summary>
        /// <param name="jsonText">The JSON to be deserialized.</param>
        /// <returns>Deserialized collection of Journal DTOs.</returns>
        public IEnumerable<DTOJournal> Deserialize(string jsonJournalsText)
        {
            return JsonConvert.DeserializeObject<IEnumerable<DTOJournal>>(jsonJournalsText);
        }
    }
}