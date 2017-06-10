// <copyright file="LogType.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of LogType model.</summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models.Logs
{
    /// <summary>
    /// Represent a <see cref="LogType"/> entity model.
    /// </summary>
    public class LogType
    {
        /// <summary>
        /// Addresses related to the <see cref="LogType"/> entity.
        /// </summary>
        private ICollection<Log> logs;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogType"/> class.
        /// </summary>
        public LogType()
        {
            this.logs = new HashSet<Log>();
        }

        /// <summary>
        /// Gets or sets the primary key of the <see cref="LogType"/> entity.
        /// </summary>
        /// <value>Primary key of the <see cref="LogType"/> entity.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the <see cref="LogType"/> entity.
        /// </summary>
        /// <value>Name of the <see cref="LogType"/> entity.</value>
        [Required]
        [StringLength(256, ErrorMessage = "LogType Name Invalid Length", MinimumLength = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the logs related to the <see cref="LogType"/> entity.
        /// </summary>
        /// <value>Collection of logs related to the <see cref="LogType"/> entity.</value>
        public virtual ICollection<Log> Logs
        {
            get
            {
                return this.logs;
            }

            set
            {
                this.logs = value;
            }
        }
    }
}