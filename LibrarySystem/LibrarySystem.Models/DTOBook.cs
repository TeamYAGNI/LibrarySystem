// <copyright file="DTOBook.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Book DTO.</summary>

using System.Xml.Serialization;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Represent a <see cref="DTOBook"/> class.
    /// </summary>
    [XmlType(TypeName = "book")]
    public class DTOBook
    {
        /// <summary>
        /// Gets or sets the Id of the <see cref="DTOBook"/> entity.
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Author of the <see cref="DTOBook"/> entity.
        /// </summary>
        [XmlElement("author")]
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the Title of the <see cref="DTOBook"/> entity.
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the ISBN of the <see cref="DTOBook"/> entity.
        /// </summary>
        [XmlElement("isbn")]
        public string ISBN { get; set; }
    }
}
