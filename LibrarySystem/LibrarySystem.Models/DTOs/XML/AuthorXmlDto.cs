using System.Xml.Serialization;
using LibrarySystem.Models.Enumerations;

namespace LibrarySystem.Models.DTOs.XML
{
    /// <summary>
    /// Represent a <see cref="AuthorXmlDto"/> class.
    /// </summary>
    [XmlType(TypeName = "author")]
    public class AuthorXmlDto
    {
        /// <summary>
        /// Gets or sets the FirstName of the <see cref="AuthorXmlDto"/> entity.
        /// </summary>
        [XmlElement("first-name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName of the <see cref="AuthorXmlDto"/> entity.
        /// </summary>
        [XmlElement("last-name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the GenderType of the <see cref="AuthorXmlDto"/> entity.
        /// </summary>
        [XmlElement("gender")]
        public GenderType GenderType { get; set; }
    }
}
