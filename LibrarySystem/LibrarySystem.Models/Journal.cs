using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Journal
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(8)]
        public string ISSN { get; set; }

        public int IssueNumber { get; set; }

        public int YearOfPublishing { get; set; }

        public int ImpactFactor { get; set; }

        public int PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }
    }
}