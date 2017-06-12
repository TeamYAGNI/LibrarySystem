using System.Xml.Serialization;

namespace LibrarySystem.Models.DTOs.XML
{
    /// <summary>
    /// Represent a <see cref="PublisherXmlDto"/> class.
    /// </summary>
    [XmlType(TypeName = "publisher")]
    public class PublisherXmlDto
    {
        /// <summary>
        /// Gets or sets the Name of the <see cref="PublisherXmlDto"/> entity.
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
