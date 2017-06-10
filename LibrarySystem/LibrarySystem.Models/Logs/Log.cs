// <copyright file="Log.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Log model.</summary>

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models.Logs
{
    /// <summary>
    /// Represent a <see cref="Log"/> entity model.
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Gets or sets the primary key of the <see cref="Log"/> entity.
        /// </summary>
        /// <value>Primary key of the <see cref="Log"/> entity.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the message of the <see cref="Log"/> entity.
        /// </summary>
        /// <value>Message of the <see cref="Log"/> entity.</value>
        [Required]
        [Column(TypeName = "ntext")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the DateTime when the log is logged.
        /// </summary>
        /// <value>DateTime when the log is logged.</value>
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd hh:mm:ss.fff}")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Gets or sets foreign key of the LogType of the <see cref="Log"/> entity.
        /// </summary>
        /// <value>Primary key of the LogType of the <see cref="Log"/> entity.</value>
        [Required]
        public int LogTypeId { get; set; }

        /// <summary>
        /// Gets or sets the LogType of the <see cref="Log"/> entity.
        /// </summary>
        /// <value>LogType of the <see cref="Log"/> entity.</value>
        public virtual LogType LogType { get; set; }
    }
}