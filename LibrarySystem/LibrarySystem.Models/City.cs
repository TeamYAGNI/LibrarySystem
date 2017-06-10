// <copyright file="City.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of City model.</summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Represent a <see cref="City"/> entity model.
    /// </summary>
    public class City
    {
        /// <summary>
        /// Addresses related to the <see cref="City"/> entity.
        /// </summary>
        private ICollection<Address> addresses;

        /// <summary>
        /// Initializes a new instance of the <see cref="City"/> class.
        /// </summary>
        public City()
        {
            this.addresses = new HashSet<Address>();
        }

        /// <summary>
        /// Gets or sets the primary key of the <see cref="City"/> entity.
        /// </summary>
        /// <value>Primary key of the <see cref="City"/> entity.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the <see cref="City"/> entity.
        /// </summary>
        /// <value>Name of the <see cref="City"/> entity.</value>
        [Required]
        [StringLength(50, ErrorMessage = "City Name Invalid Length", MinimumLength = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the addresses related to the <see cref="City"/> entity.
        /// </summary>
        /// <value>Collection of addresses related to the <see cref="City"/> entity.</value>
        public virtual ICollection<Address> Addresses
        {
            get
            {
                return this.addresses;
            }

            set
            {
                this.addresses = value;
            }
        }
    }
}