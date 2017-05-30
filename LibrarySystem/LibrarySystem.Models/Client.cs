using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Client
    {
        private ICollection<Book> books;
        private ICollection<Journal> journals;

        public Client()
        {
            this.books = new HashSet<Book>();
            this.journals = new HashSet<Journal>();
        }

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

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }

        public virtual ICollection<Journal> Journals
        {
            get { return this.journals; }
            set { this.journals = value; }
        }
    }
}