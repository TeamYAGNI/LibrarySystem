// <copyright file="DTOJournal.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Journal DTO.</summary>

using Newtonsoft.Json;

namespace LibrarySystem.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class DTOJournal
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("issn")]
        public string ISSN { get; set; }
    }
}
