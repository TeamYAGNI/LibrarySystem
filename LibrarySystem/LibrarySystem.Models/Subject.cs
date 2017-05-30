using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}