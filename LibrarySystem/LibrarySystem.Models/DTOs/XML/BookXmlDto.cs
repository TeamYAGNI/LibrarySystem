// <copyright file="BookXmlDto.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Book DTO.</summary>

using System.Collections.Generic;
using System.Xml.Serialization;

namespace LibrarySystem.Models.DTOs.XML
{
    /// <summary>
    /// Represent a <see cref="BookDto"/> class.
    /// </summary>
    [XmlType(TypeName = "book")]
    public class BookXmlDto
    {
        /// <summary>
        /// Gets or sets the Title of the <see cref="BookDto"/> entity.
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the ISBN of the <see cref="BookDto"/> entity.
        /// </summary>
        [XmlElement("isbn")]
        public string ISBN { get; set; }

        /// <summary>
        /// Gets or sets the Authors of the <see cref="BookDto"/> entity.
        /// </summary>
        [XmlArray("authors")]
        [XmlArrayItem("author")]
        public List<AuthorXmlDto> Authors { get; set; }

        /// <summary>
        /// Gets or sets the Genres of the <see cref="BookDto"/> entity.
        /// </summary>
        [XmlArray("genres")]
        [XmlArrayItem("genre")]
        public List<GenreXmlDto> Genres { get; set; }

        /// <summary>
        /// Gets or sets the Description of the <see cref="BookDto"/> entity.
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the PageCount of the <see cref="BookDto"/> entity.
        /// </summary>
        [XmlElement("page-count")]
        public int PageCount { get; set; }

        /// <summary>
        /// Gets or sets the YearOfPublishing of the <see cref="BookDto"/> entity.
        /// </summary>
        [XmlElement("year-of-publishing")]
        public int YearOfPublishing { get; set; }

        /// <summary>
        /// Gets or sets the Publisher of the <see cref="BookDto"/> entity.
        /// </summary>
        [XmlElement("publisher")]
        public PublisherXmlDto Publisher { get; set; }

        /// <summary>
        /// Gets or sets the Quantity of the <see cref="BookDto"/> entity.
        /// </summary>
        [XmlElement("quantity")]
        public int Quantity { get; set; }
    }
}
