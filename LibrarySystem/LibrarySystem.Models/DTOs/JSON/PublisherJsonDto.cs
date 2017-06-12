using Newtonsoft.Json;

namespace LibrarySystem.Models.DTOs.JSON
{
    public class PublisherJsonDto
    {
        /// <summary>
        /// Gets or sets the Name of the <see cref="PublisherJsonDto"/> entity.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
