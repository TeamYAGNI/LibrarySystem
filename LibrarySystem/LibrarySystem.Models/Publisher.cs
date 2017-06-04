// <copyright file="Publisher.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Publisher model.</summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Represent a <see cref="Publisher"/> entity model.
    /// </summary>
    public class Publisher
    {
        /// <summary>
        /// Books of the <see cref="Publisher"/> entity.
        /// </summary>
        private ICollection<Book> books;

        /// <summary>
        /// Journals of the <see cref="Publisher"/> entity.
        /// </summary>
        private ICollection<Journal> journals;

        /// <summary>
        /// Initializes a new instance of the <see cref="Publisher"/> class.
        /// </summary>
        public Publisher()
        {
            this.books = new HashSet<Book>();

            this.journals = new HashSet<Journal>();
        }

        /// <summary>
        /// Gets or sets the primary key of the <see cref="Publisher"/> entity.
        /// </summary>
        /// <value>Primary key of the <see cref="Publisher"/> entity.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the <see cref="Publisher"/> entity.
        /// </summary>
        /// <value>Name of the <see cref="Publisher"/> entity.</value>
        [Required]
        [StringLength(50, ErrorMessage = "Publisher Name Invalid Length", MinimumLength = 3)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the books of the <see cref="Publisher"/> entity.
        /// </summary>
        /// <value>Collection of books of the <see cref="Publisher"/> entity.</value>
        public virtual ICollection<Book> Books
        {
            get
            {
                return this.books;
            }

            set
            {
                this.books = value;
            }
        }

        /// <summary>
        /// Gets or sets the journals of the <see cref="Publisher"/> entity.
        /// </summary>
        /// <value>Collection of journals of the <see cref="Publisher"/> entity.</value>
        public virtual ICollection<Journal> Journals
        {
            get
            {
                return this.journals;
            }

            set
            {
                this.journals = value;
            }
        }
    }
}