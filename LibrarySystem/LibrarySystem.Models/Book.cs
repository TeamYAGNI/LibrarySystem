// <copyright file="Book.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Book model.</summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Represent a <see cref="Book"/> entity model.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Authors of the <see cref="Book"/> entity.
        /// </summary>
        private ICollection<Author> authors;

        /// <summary>
        /// Genres of the <see cref="Book"/> entity.
        /// </summary>
        private ICollection<Genre> genres;

        /// <summary>
        /// Lendings of the <see cref="Book"/> entity.
        /// </summary>
        private ICollection<Lending> lendings;

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        public Book()
        {
            this.authors = new HashSet<Author>();
            this.genres = new HashSet<Genre>();
            this.lendings = new HashSet<Lending>();
        }

        /// <summary>
        /// Gets or sets the primary key of the <see cref="Book"/> entity.
        /// </summary>
        /// <value>Primary key of the <see cref="Book"/> entity.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the <see cref="Book"/> entity.
        /// </summary>
        /// <value>Title of the <see cref="Book"/> entity.</value>
        [Required]
        [StringLength(100, ErrorMessage = "Book Title Invalid Length", MinimumLength = 1)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the ISBN of the <see cref="Book"/> entity.
        /// </summary>
        /// <value>ISBN of the <see cref="Book"/> entity.</value>
        [Required]
        [RegularExpression(@"^(97(8|9))?\d{9}(\d|X)$", ErrorMessage = "Book ISBN Invalid Length")]
        public string ISBN { get; set; }

        /// <summary>
        /// Gets or sets the authors of the <see cref="Book"/> entity.
        /// </summary>
        /// <value>Collection of authors of the <see cref="Book"/> entity.</value>
        public virtual ICollection<Author> Authors
        {
            get
            {
                return this.authors;
            }

            set
            {
                this.authors = value;
            }
        }

        /// <summary>
        /// Gets or sets the genres of the <see cref="Book"/> entity.
        /// </summary>
        /// <value>Initial collection of genres of the <see cref="Book"/> entity.</value>
        public virtual ICollection<Genre> Genres
        {
            get
            {
                return this.genres;
            }

            set
            {
                this.genres = value;
            }
        }

        /// <summary>
        /// Gets or sets the description of the <see cref="Book"/> entity.
        /// </summary>
        /// <value>Description of the <see cref="Book"/> entity.</value>
        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the number of pages of the <see cref="Book"/> entity.
        /// </summary>
        /// <value>Number of pages of the <see cref="Book"/> entity.</value>
        [Required]
        [Range(5, 4000, ErrorMessage = "Book PageCount cannot be {0}. It must be between {1} and {2}.")]
        public int PageCount { get; set; }

        /// <summary>
        /// Gets or sets the year of publishing of the <see cref="Book"/> entity.
        /// </summary>
        /// <value>Year of publishing of the <see cref="Book"/> entity.</value>
        [Required]
        [Range(392, 4000, ErrorMessage = "Book YearOfPublishing cannot be {0}. It must be between {1} and {2}.")]
        public int YearOfPublishing { get; set; }

        /// <summary>
        /// Gets or sets foreign key of the publisher of the <see cref="Book"/> entity.
        /// </summary>
        /// <value>Primary key of the publisher of the <see cref="Book"/> entity.</value>
        [Required]
        public int PublisherId { get; set; }

        /// <summary>
        /// Gets or sets the publisher of the <see cref="Book"/> entity.
        /// </summary>
        /// <value>Publisher of the <see cref="Book"/> entity.</value>
        public virtual Publisher Publisher { get; set; }

        /// <summary>
        /// Gets or sets the number of copies of the <see cref="Book"/> entity in the library.
        /// </summary>
        /// <value>Current number of copies of the <see cref="Book"/> entity in the library.</value>
        [Required]
        [Range(0, 2000, ErrorMessage = "Book Quantity cannot be {0}. It must be between {1} and {2}.")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the number of available copies of the <see cref="Book"/> entity in the library.
        /// </summary>
        /// <value>Current number of available copies of the <see cref="Book"/> entity in the library.</value>
        [Required]
        [Range(0, 2000, ErrorMessage = "Book Available cannot be {0}. It must be between {1} and {2}.")]
        public int Available { get; set; }

        /// <summary>
        /// Gets or sets the landings of the <see cref="Book"/> entity.
        /// </summary>
        /// <value>Initial collection of landings of the <see cref="Book"/> entity.</value>
        public virtual ICollection<Lending> Lendings
        {
            get
            {
                return this.lendings;
            }

            set
            {
                this.lendings = value;
            }
        }
    }
}
