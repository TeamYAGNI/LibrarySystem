using System.ComponentModel.DataAnnotations;
using LibrarySystem.Models.Enumerations;

namespace LibrarySystem.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int JobTitleId { get; set; }

        public virtual JobTitle JobTitle { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public int ReportsToId { get; set; }

        public virtual Employee ReportsTo { get; set; }
    }
}