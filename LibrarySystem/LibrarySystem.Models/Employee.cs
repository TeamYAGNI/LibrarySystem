// <copyright file="Employee.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Book model.</summary>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using LibrarySystem.Models.Enumerations;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Represent a <see cref="Employee"/> entity model.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the primary key of the <see cref="Employee"/> entity.
        /// </summary>
        /// <value>Primary key of the <see cref="Employee"/> entity.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the <see cref="Employee"/> entity.
        /// </summary>
        /// <value>First name of the <see cref="Employee"/> entity.</value>
        [Required]
        [Column("First Name")]
        [StringLength(20, ErrorMessage = "Employee FirstName Invalid Length", MinimumLength = 1)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the <see cref="Employee"/> entity.
        /// </summary>
        /// <value>Last name of the <see cref="Employee"/> entity.</value>
        [Required]
        [Column("Last Name")]
        [StringLength(20, ErrorMessage = "Employee LastName Invalid Length", MinimumLength = 1)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the full name of the <see cref="Employee"/> entity.
        /// </summary>
        /// <value>Full name of the <see cref="Employee"/> entity.</value>
        [NotMapped]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        /// <summary>
        /// Gets or sets the job title of the <see cref="Employee"/> entity.
        /// </summary>
        /// <value>Job title of the <see cref="Employee"/> entity.</value>
        [Required]
        public virtual JobTitle JobTitle { get; set; }

        /// <summary>
        /// Gets or sets foreign key of the address of the <see cref="Employee"/> entity.
        /// </summary>
        /// <value>Primary key of the address of the <see cref="Employee"/> entity.</value>
        [Required]
        public int AddressId { get; set; }

        /// <summary>
        /// Gets or sets the address of the <see cref="Employee"/> entity.
        /// </summary>
        /// <value>Address of the <see cref="Employee"/> entity.</value>
        public virtual Address Address { get; set; }

        /// <summary>
        /// Gets or sets foreign key of the manager of the <see cref="Employee"/> entity.
        /// </summary>
        /// <value>Primary key of the manager of the <see cref="Employee"/> entity.</value>
        public int? ReportsToId { get; set; }

        /// <summary>
        /// Gets or sets the manager of the <see cref="Employee"/> entity.
        /// </summary>
        /// <value>Manager of the <see cref="Employee"/> entity.</value>
        public virtual Employee ReportsTo { get; set; }
    }
}