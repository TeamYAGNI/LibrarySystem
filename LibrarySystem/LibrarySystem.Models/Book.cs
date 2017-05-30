using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Book
    {
        private ICollection<Author> authors;
        private ICollection<Genre> genres;
        private ICollection<Client> clients;

        public Book()
        {
            this.authors = new HashSet<Author>();
            this.genres = new HashSet<Genre>();
            this.clients = new HashSet<Client>();
        }

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

        public virtual ICollection<Author> Authors
        {
            get { return this.authors; }
            set { this.authors = value; }
        }

        public virtual ICollection<Genre> Genres
        {
            get { return this.genres; }
            set { this.genres = value; }
        }

        public virtual ICollection<Client> Clients
        {
            get { return this.clients; }
            set { this.clients = value; }
        }
    }
}
