// <copyright file="Lending.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Lending model.</summary>

using System;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Represent a <see cref="Lending"/> entity model.
    /// </summary>
    public class Lending
    {
        /// <summary>
        /// Gets or sets the primary key of the <see cref="Lending"/> entity.
        /// </summary>
        /// <value>Primary key of the <see cref="Lending"/> entity.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets foreign key for the lended copy of the <see cref="Book"/> entity.
        /// </summary>
        /// <value>Primary key of the lended copy of the <see cref="Book"/> entity.</value>
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets the lended <see cref="Book"/> entity.
        /// </summary>
        /// <value>Lended <see cref="Book"/> entity.</value>
        public Book Book { get; set; }

        /// <summary>
        /// Gets or sets foreign key for the <see cref="Client"/> entity borrowed the copy.
        /// </summary>
        /// <value>Primary key of the lender.</value>
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Client"/> entity borrowed the copy.
        /// </summary>
        /// <value><see cref="Client"/> entity borrowed the copy.</value>
        public Client Client { get; set; }

        /// <summary>
        /// Gets or sets the Date when the copy is borrowed.
        /// </summary>
        /// <value>Date when the copy is borrowed.</value>
        public DateTime BorrоwDate { get; set; }

        /// <summary>
        /// Gets or sets the Date when the copy is returned.
        /// </summary>
        /// <value>Date when the copy is returned.</value>
        public DateTime? ReturnDate { get; set; }

        /// <summary>
        /// Gets or sets remarks of the current lending.
        /// </summary>
        /// <value>Remarks of the current lending.</value>
        public string Remarks { get; set; }
    }
}