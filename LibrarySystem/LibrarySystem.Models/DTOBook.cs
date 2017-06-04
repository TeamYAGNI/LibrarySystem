// <copyright file="DTOBook.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Book DTO.</summary>

using System.Xml.Serialization;

namespace LibrarySystem.Models
{
    /// <summary>
    /// 
    /// </summary>
    [XmlType(TypeName = "book")]
    public class DTOBook
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute("id")]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("author")]
        public string Author { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("isbn")]
        public string ISBN { get; set; }
    }
}
