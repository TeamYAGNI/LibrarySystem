// <copyright file="JsonJournalsDeserializer.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of JSON deserializer wrapper.</summary>

using System.Collections.Generic;
using Bytes2you.Validation;
using LibrarySystem.FileImporters.Utils.Contracts;
using LibrarySystem.Models;
using Newtonsoft.Json;

namespace LibrarySystem.FileImporters.Utils
{
    /// <summary>
    /// Represent a <see cref="JsonJournalsDeserializer"/> class.
    /// </summary>
    public class JsonDeserializerWrapper : IJsonDeserializer
    {
        /// <summary>
        /// Deserializes the JSON to the Journal DTO type - wrapper instance method.
        /// </summary>
        /// <param name="jsonText">The JSON to be deserialized.</param>
        /// <returns>Deserialized collection of Journal DTOs.</returns>
        public IEnumerable<JournalDto> Deserialize(string jsonJournalsText)
        {
            Guard.WhenArgument(jsonJournalsText, "Deserialize").IsNullOrEmpty().Throw();

            return JsonConvert.DeserializeObject<IEnumerable<JournalDto>>(jsonJournalsText);
        }
    }
}