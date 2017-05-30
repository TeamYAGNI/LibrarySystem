using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        public int PageCount { get; set; }

        public int YearOfPublishing { get; set; }

        public int PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }
    }
}
