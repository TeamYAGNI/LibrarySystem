// <copyright file="JsonBooksSerializer.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of JSON serializer wrapper.</summary>

using System.Collections.Generic;
using Bytes2you.Validation;
using LibrarySystem.FileExporters.Utils.Contracts;
using LibrarySystem.Models;
using Newtonsoft.Json;

namespace LibrarySystem.FileExporters.Utils
{
    /// <summary>
    /// Represent a <see cref="JsonSerializerWrapper"/> class.
    /// </summary>
    public class JsonSerializerWrapper : IJsonSerializer
    {
        /// <summary>
        /// Serializes the specified object to a JSON string - wrapper instance method.
        /// </summary>
        /// <param name="journals">Collection of Journal DTOs.</param>
        /// <returns>A JSON string of the specified object.</returns>
        public string Serialize(IEnumerable<JournalDto> journals)
        {
            Guard.WhenArgument(journals, "Serialize").IsNull().Throw();

            return JsonConvert.SerializeObject(journals, Formatting.Indented);
        }
    }
}
