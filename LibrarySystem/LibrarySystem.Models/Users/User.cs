// <copyright file="User.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of User model.</summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using LibrarySystem.Models.Enumerations;

namespace LibrarySystem.Models.Users
{
    /// <summary>
    /// Represent a <see cref="User"/> entity model.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Groups related to the <see cref="User"/> entity.
        /// </summary>
        private ICollection<Group> groups;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            this.groups = new HashSet<Group>();
        }

        /// <summary>
        /// Gets or sets the primary key of the <see cref="User"/> entity.
        /// </summary>
        /// <value>Primary key of the <see cref="User"/> entity.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Username of the <see cref="User"/> entity.
        /// </summary>
        /// <value>Username of the <see cref="User"/> entity.</value>
        [Required]
        [StringLength(50, ErrorMessage = "User Username Invalid Length", MinimumLength = 5)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the PassHash of the <see cref="User"/> entity.
        /// </summary>
        /// <value>PassHash of the <see cref="User"/> entity.</value>
        [Required]
        [StringLength(50, ErrorMessage = "User PassHash Invalid Length", MinimumLength = 16)]
        public string PassHash { get; set; }

        /// <summary>
        /// Gets or sets the AuthKey of the <see cref="User"/> entity.
        /// </summary>
        /// <value>AuthKey of the <see cref="User"/> entity.</value>
        [Required]
        [StringLength(50, ErrorMessage = "User AuthKey Invalid Length", MinimumLength = 16)]
        public string AuthKey { get; set; }

        /// <summary>
        /// Gets or sets the Type of the <see cref="User"/> entity.
        /// </summary>
        /// <value>Type of the <see cref="User"/> entity.</value>
        public UserType Type { get; set; }

        /// <summary>
        /// Gets or sets the groups related to the <see cref="User"/> entity.
        /// </summary>
        /// <value>Collection of groups related to the <see cref="User"/> entity.</value>
        public virtual ICollection<Group> Groups
        {
            get
            {
                return this.groups;
            }

            set
            {
                this.groups = value;
            }
        }
    }
}
