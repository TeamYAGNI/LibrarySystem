using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Journal
    {
        private ICollection<Subject> subjects;
        private ICollection<Client> clients;

        public Journal()
        {
            this.subjects = new HashSet<Subject>();
            this.clients = new HashSet<Client>();
        }
        
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

        public virtual ICollection<Subject> Subjects
        {
            get { return this.subjects; }
            set { this.subjects = value; }
        }

        public virtual ICollection<Client> Clients
        {
            get { return this.clients; }
            set { this.clients = value; }
        }
    }
}