// <copyright file="Author.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Author model.</summary>

using System.Collections.Generic;

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
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the <see cref="Author"/> entity.
        /// </summary>
        /// <value>Name of the <see cref="Author"/> entity.</value>
        public string Name { get; set; }

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