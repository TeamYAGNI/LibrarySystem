using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int PIN { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}