using Newtonsoft.Json;

namespace LibrarySystem.Models.DTOs.JSON
{
    public class SubjectJsonDto
    {
        /// <summary>
        /// Gets or sets the Name of the <see cref="SubjectJsonDto"/> entity.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
