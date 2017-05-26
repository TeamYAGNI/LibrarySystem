// <copyright file="Genre.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Genre model.</summary>

using System.Collections.Generic;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Represent a <see cref="Genre"/> entity model.
    /// </summary>
    public class Genre
    {
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
        }

        /// <summary>
        /// Gets or sets the primary key of the <see cref="Genre"/> entity.
        /// </summary>
        /// <value>Primary key of the <see cref="Genre"/> entity.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the <see cref="Genre"/> entity.
        /// </summary>
        /// <value>Name of the <see cref="Genre"/> entity.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets foreign key of the Genre to witch the <see cref="Genre"/> entity is sub-category.
        /// </summary>
        /// <value>Primary key of the sup-genre of the <see cref="Book"/> entity.</value>
        public int SuperGenreId { get; set; }

        /// <summary>
        /// Gets or sets the Genre to witch the <see cref="Genre"/> entity is sub-category.
        /// </summary>
        /// <value>Sup-genre of the <see cref="Book"/> entity.</value>
        public Genre SuperGenre { get; set; }

        /// <summary>
        /// Gets or sets the initial collection of books from the <see cref="Genre"/> entity.
        /// </summary>
        /// <value>Collection of books from the <see cref="Genre"/> entity.</value>
        public ICollection<Book> Books
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