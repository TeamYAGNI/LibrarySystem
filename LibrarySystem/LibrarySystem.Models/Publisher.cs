// <copyright file="Publisher.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Publisher model.</summary>

using System.Collections.Generic;

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
        /// Initializes a new instance of the <see cref="Publisher"/> class.
        /// </summary>
        public Publisher()
        {
            this.books = new HashSet<Book>();
        }

        /// <summary>
        /// Gets or sets the primary key of the <see cref="Publisher"/> entity.
        /// </summary>
        /// <value>Primary key of the <see cref="Publisher"/> entity.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the <see cref="Publisher"/> entity.
        /// </summary>
        /// <value>Name of the <see cref="Publisher"/> entity.</value>
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
    }
}