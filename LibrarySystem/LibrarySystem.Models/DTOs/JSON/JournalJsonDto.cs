// <copyright file="JournalJsonDto.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Journal DTO.</summary>

using System.Collections.Generic;
using Newtonsoft.Json;

namespace LibrarySystem.Models.DTOs.JSON
{
    /// <summary>
    /// Represent a <see cref="JournalJsonDto"/> class.
    /// </summary>
    public class JournalJsonDto
    {
        /// <summary>
        /// Gets or sets the Title of the <see cref="JournalJsonDto"/> entity.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the ImpactFactor of the <see cref="JournalJsonDto"/> entity.
        /// </summary>
        [JsonProperty("impactFactor")]
        public float? ImpactFactor { get; set; }

        /// <summary>
        /// Gets or sets the ISSN of the <see cref="JournalJsonDto"/> entity.
        /// </summary>
        [JsonProperty("issn")]
        public string ISSN { get; set; }

        /// <summary>
        /// Gets or sets the IssueNumber of the <see cref="JournalJsonDto"/> entity.
        /// </summary>
        [JsonProperty("issueNumber")]
        public int IssueNumber { get; set; }

        /// <summary>
        /// Gets or sets the YearOfPublishing of the <see cref="JournalJsonDto"/> entity.
        /// </summary>
        [JsonProperty("yearOfPublishing")]
        public int YearOfPublishing { get; set; }

        /// <summary>
        /// Gets or sets the Publisher of the <see cref="JournalJsonDto"/> entity.
        /// </summary>
        [JsonProperty("publisher")]
        public PublisherJsonDto Publisher { get; set; }

        /// <summary>
        /// Gets or sets the Quantity of the <see cref="JournalJsonDto"/> entity.
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the Subjects of the <see cref="JournalJsonDto"/> entity.
        /// </summary>
        [JsonProperty("subjects")]
        public List<SubjectJsonDto> Subjects { get; set; }
    }
}
