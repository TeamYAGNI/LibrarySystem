// <copyright file="DTOJournal.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Journal DTO.</summary>

using Newtonsoft.Json;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Represent a <see cref="DTOJournal"/> class.
    /// </summary>
    public class DTOJournal
    {
        /// <summary>
        /// Gets or sets the Id of the <see cref="DTOJournal"/> entity.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Title of the <see cref="DTOJournal"/> entity.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the ISSN of the <see cref="DTOJournal"/> entity.
        /// </summary>
        [JsonProperty("issn")]
        public string ISSN { get; set; }
    }
}
