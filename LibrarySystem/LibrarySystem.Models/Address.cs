using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int StreetNumber { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}