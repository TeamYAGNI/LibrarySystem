// <copyright file="Address.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Address model.</summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Represent a <see cref="Address"/> entity model.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Clients of the <see cref="Address"/> entity.
        /// </summary>
        private ICollection<Client> clients;

        /// <summary>
        /// Employees of the <see cref="Address"/> entity.
        /// </summary>
        private ICollection<Employee> employees;

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        public Address()
        {
            this.clients = new HashSet<Client>();
            this.employees = new HashSet<Employee>();
        }

        /// <summary>
        /// Gets or sets the primary key of the <see cref="Address"/> entity.
        /// </summary>
        /// <value>Primary key of the <see cref="Address"/> entity.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the street of the <see cref="Address"/> entity.
        /// </summary>
        /// <value>Street of the <see cref="Address"/> entity.</value>
        [Required]
        [StringLength(100, ErrorMessage = "Address Street Invalid Length", MinimumLength = 1)]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the street number of the <see cref="Address"/> entity.
        /// </summary>
        /// <value>Street number of the <see cref="Address"/> entity.</value>
        [Range(1, 2000, ErrorMessage = "Address StreetNumber cannot be {0}. It must be between {1} and {2}.")]
        public int? StreetNumber { get; set; }

        /// <summary>
        /// Gets or sets foreign key of the City of the <see cref="Address"/> entity.
        /// </summary>
        /// <value>Primary key of the City of the <see cref="Address"/> entity.</value>
        [Required]
        public int CityId { get; set; }

        /// <summary>
        /// Gets or sets the City of the <see cref="Address"/> entity.
        /// </summary>
        /// <value>City of the <see cref="Address"/> entity.</value>
        public virtual City City { get; set; }

        /// <summary>
        /// Gets or sets the clients of the <see cref="Address"/> entity.
        /// </summary>
        /// <value>Initial collection of clients of the <see cref="Address"/> entity.</value>
        public virtual ICollection<Client> Clients
        {
            get
            {
                return this.clients;
            }

            set
            {
                this.clients = value;
            }
        }

        /// <summary>
        /// Gets or sets the employees of the <see cref="Address"/> entity.
        /// </summary>
        /// <value>Initial collection of employees of the <see cref="Address"/> entity.</value>
        public virtual ICollection<Employee> Employees
        {
            get
            {
                return this.employees;
            }

            set
            {
                this.employees = value;
            }
        }
    }
}