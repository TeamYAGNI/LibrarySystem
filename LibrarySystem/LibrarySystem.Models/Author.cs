// <copyright file="Author.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Author model.</summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibrarySystem.Models.Enumerations;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Represent a <see cref="Author"/> entity model.
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Books of the <see cref="Author"/> entity.
        /// </summary>
        private ICollection<Book> books;

        /// <summary>
        /// Initializes a new instance of the <see cref="Author"/> class.
        /// </summary>
        public Author()
        {
            this.books = new HashSet<Book>();
        }

        /// <summary>
        /// Gets or sets the primary key of the <see cref="Author"/> entity.
        /// </summary>
        /// <value>Primary key of the <see cref="Author"/> entity.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the <see cref="Author"/> entity.
        /// </summary>
        /// <value>First name of the <see cref="Author"/> entity.</value>
        [Required]
        [StringLength(20, ErrorMessage = "Author FirstName Invalid Length", MinimumLength = 1)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the <see cref="Author"/> entity.
        /// </summary>
        /// <value>Last name of the <see cref="Author"/> entity.</value>
        [Required]
        [StringLength(20, ErrorMessage = "Author LastName Invalid Length", MinimumLength = 1)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets the full name of the <see cref="Author"/> entity.
        /// </summary>
        /// <value>Full name of the <see cref="Author"/> entity.</value>
        [NotMapped]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        /// <summary>
        /// Gets or sets the gender type of the <see cref="Author"/> entity.
        /// </summary>
        /// <value>Gender type of the <see cref="Author"/> entity.</value>
        public GenderType GenderType { get; set; }

        /// <summary>
        /// Gets or sets the books of the <see cref="Author"/> entity.
        /// </summary>
        /// <value>Collection of books of the <see cref="Author"/> entity.</value>
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
    }
}
