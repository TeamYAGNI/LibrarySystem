// <copyright file="Genre.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Genre model.</summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Represent a <see cref="Genre"/> entity model.
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// ChildNodes of the <see cref="Genre"/> entity.
        /// </summary>
        private ICollection<Genre> subGenres;

        /// <summary>
        /// Books from the <see cref="Genre"/> entity.
        /// </summary>
        private ICollection<Book> books;

        /// <summary>
        /// Initializes a new instance of the <see cref="Genre"/> class.
        /// </summary>
        public Genre()
        {
            this.books = new HashSet<Book>();
            this.subGenres = new HashSet<Genre>();
        }

        /// <summary>
        /// Gets or sets the primary key of the <see cref="Genre"/> entity.
        /// </summary>
        /// <value>Primary key of the <see cref="Genre"/> entity.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the <see cref="Genre"/> entity.
        /// </summary>
        /// <value>Name of the <see cref="Genre"/> entity.</value>
        [Required]
        [StringLength(50, ErrorMessage = "Genre Name Invalid Length", MinimumLength = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets foreign key of the Genre to witch the <see cref="Genre"/> entity is sub-category.
        /// </summary>
        /// <value>Primary key of the sup-genre of the <see cref="Book"/> entity.</value>
        public int? SuperGenreId { get; set; }

        /// <summary>
        /// Gets or sets the Genre to witch the <see cref="Genre"/> entity is sub-category.
        /// </summary>
        /// <value>Sup-genre of the <see cref="Book"/> entity.</value>
        public virtual Genre SuperGenre { get; set; }

        /// <summary>
        /// Gets or sets the initial collection of child genres of the <see cref="Genre"/> entity.
        /// </summary>
        /// <value>Collection of child genres of the <see cref="Genre"/> entity.</value>
        public virtual ICollection<Genre> SubGenres
        {
            get
            {
                return this.subGenres;
            }

            set
            {
                this.subGenres = value;
            }
        }

        /// <summary>
        /// Gets or sets the initial collection of books from the <see cref="Genre"/> entity.
        /// </summary>
        /// <value>Collection of books from the <see cref="Genre"/> entity.</value>
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