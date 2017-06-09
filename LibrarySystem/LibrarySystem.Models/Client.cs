// <copyright file="Client.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Book model.</summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibrarySystem.Models.Enumerations;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Represent a <see cref="Client"/> entity model.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Pattern for validation of the PIN of the <see cref="Client"/> entity.
        /// </summary>
        private const string PINPattern = @"^[0-9]{10}$";

        /// <summary>
        /// Pattern for validation of the phone number of the <see cref="Client"/> entity.
        /// </summary>
        private const string PhonePattern = @"^[0-9]{3, 14}$";

        /// <summary>
        /// Pattern for validation of the email address of the <see cref="Client"/> entity.
        /// </summary>
        private const string EmailPattern = @"^(?(\"")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        /// <summary>
        /// Lendings of the <see cref="Client"/> entity.
        /// </summary>
        private ICollection<Lending> lendings;

        /// <summary>
        /// Journals of the <see cref="Client"/> entity.
        /// </summary>
        private ICollection<Journal> journals;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        public Client()
        {
            this.lendings = new HashSet<Lending>();

            this.journals = new HashSet<Journal>();
        }

        /// <summary>
        /// Gets or sets the primary key of the <see cref="Client"/> entity.
        /// </summary>
        /// <value>Primary key of the <see cref="Client"/> entity.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the <see cref="Client"/> entity.
        /// </summary>
        /// <value>First name of the <see cref="Client"/> entity.</value>
        [Required]
        [StringLength(20, ErrorMessage = "Client FirstName Invalid Length", MinimumLength = 1)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the <see cref="Client"/> entity.
        /// </summary>
        /// <value>Last name of the <see cref="Client"/> entity.</value>
        [Required]
        [StringLength(20, ErrorMessage = "Client LastName Invalid Length", MinimumLength = 1)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets the full name of the <see cref="Client"/> entity.
        /// </summary>
        /// <value>Full name of the <see cref="Client"/> entity.</value>
        [NotMapped]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        /// <summary>
        /// Gets or sets the gender type of the <see cref="Client"/> entity.
        /// </summary>
        /// <value>Gender type of the <see cref="Client"/> entity.</value>
        public GenderType GenderType { get; set; }

        /// <summary>
        /// Gets or sets the Personal Identification Number of the <see cref="Client"/> entity.
        /// </summary>
        /// <value>Personal Identification Number of the <see cref="Client"/> entity.</value>
        [Required]
        [RegularExpression(PINPattern, ErrorMessage = "Client PIN Invalid Length")]
        public string PIN { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the <see cref="Client"/> entity.
        /// </summary>
        /// <value>Phone number of the <see cref="Client"/> entity.</value>
        [RegularExpression(PhonePattern, ErrorMessage = "Client Phone Invalid Length")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the email address of the <see cref="Client"/> entity.
        /// </summary>
        /// <value>Email address of the <see cref="Client"/> entity.</value>
        [RegularExpression(EmailPattern, ErrorMessage = "Client Phone Invalid Length")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets foreign key of the address of the <see cref="Client"/> entity.
        /// </summary>
        /// <value>Primary key of the address of the <see cref="Client"/> entity.</value>
        [Required]
        public int AddressId { get; set; }

        /// <summary>
        /// Gets or sets the the address of the <see cref="Client"/> entity.
        /// </summary>
        /// <value>Address of the <see cref="Client"/> entity.</value>
        public virtual Address Address { get; set; }

        /// <summary>
        /// Gets or sets the landings of the <see cref="Client"/> entity.
        /// </summary>
        /// <value>Initial collection of landings of the <see cref="Client"/> entity.</value>
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

        /// <summary>
        /// Gets or sets the journals of the <see cref="Client"/> entity.
        /// </summary>
        /// <value>Initial collection of journals of the <see cref="Client"/> entity.</value>
        public virtual ICollection<Journal> Journals
        {
            get
            {
                return this.journals;
            }

            set
            {
                this.journals = value;
            }
        }
    }
}