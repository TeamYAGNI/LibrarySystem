using System.Collections.Generic;
using System.Xml.Serialization;

namespace LibrarySystem.Models.DTOs.XML
{
    /// <summary>
    /// Represent a <see cref="GenreXmlDto"/> class.
    /// </summary>
    [XmlType(TypeName = "genre")]
    public class GenreXmlDto
    {
        /// <summary>
        /// Gets or sets the Name of the <see cref="GenreXmlDto"/> entity.
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Genre to which the <see cref="Genre"/> entity is sub-category.
        /// </summary>
        /// <value>Sup-genre of the <see cref="BookDto"/> entity.</value>
        public GenreXmlDto SuperGenre { get; set; }

        /// <summary>
        /// Gets or sets the Authors of the <see cref="GenreXmlDto"/> entity.
        /// </summary>
        [XmlArray("sub-genres")]
        [XmlArrayItem("genre")]
        public List<GenreXmlDto> SubGenres { get; set; }
    }
}
