// <copyright file="Group.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Group model.</summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models.Users
{
    /// <summary>
    /// Represent a <see cref="Group"/> entity model.
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Users of the <see cref="Group"/> entity.
        /// </summary>
        private ICollection<User> users;

        /// <summary>
        /// Initializes a new instance of the <see cref="Group"/> class.
        /// </summary>
        public Group()
        {
            this.users = new HashSet<User>();
        }

        /// <summary>
        /// Gets or sets the primary key of the <see cref="Group"/> entity.
        /// </summary>
        /// <value>Primary key of the <see cref="Group"/> entity.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the <see cref="Group"/> entity.
        /// </summary>
        /// <value>Name of the <see cref="Group"/> entity.</value>
        [Required]
        [StringLength(50, ErrorMessage = "Group Name Invalid Length", MinimumLength = 5)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the groups related to the <see cref="User"/> entity.
        /// </summary>
        /// <value>Collection of groups related to the <see cref="User"/> entity.</value>
        public virtual ICollection<User> Users
        {
            get
            {
                return this.users;
            }

            set
            {
                this.users = value;
            }
        }
    }
}
