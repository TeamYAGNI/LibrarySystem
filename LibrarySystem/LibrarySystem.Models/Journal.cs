// <copyright file="Journal.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Journal model.</summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Represent a <see cref="Journal"/> entity model.
    /// </summary>
    public class Journal
    {
        /// <summary>
        /// Subjects of the <see cref="Journal"/> entity.
        /// </summary>
        private ICollection<Subject> subjects;

        /// <summary>
        /// Initializes a new instance of the <see cref="Journal"/> class.
        /// </summary>
        public Journal()
        {
            this.subjects = new HashSet<Subject>();
        }

        /// <summary>
        /// Gets or sets the primary key of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>Primary key of the <see cref="Journal"/> entity.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>Title of the <see cref="Journal"/> entity.</value>
        [Required]
        [StringLength(50, ErrorMessage = "Journal Title Invalid Length", MinimumLength = 1)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the impact factor of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>Impact factor of the <see cref="Journal"/> entity.</value>
        [Range(0, float.MaxValue, ErrorMessage = "Journal ImpactFactor cannot be {0}. It must be greater than {1}.")]
        public float? ImpactFactor { get; set; }

        /// <summary>
        /// Gets or sets the ISSN of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>ISSN of the <see cref="Journal"/> entity.</value>
        [Required]
        [RegularExpression(@"^[\S]{4}\-[\S]{4}$", ErrorMessage = "Journal ISSN Invalid Length")]
        public string ISSN { get; set; }

        /// <summary>
        /// Gets or sets the issue number of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>Issue number of the <see cref="Journal"/> entity.</value>
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Journal IssueNumber cannot be {0}. It must be greater than {1}.")]
        public int IssueNumber { get; set; }

        /// <summary>
        /// Gets or sets the year of publishing of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>Year of publishing of the <see cref="Journal"/> entity.</value>
        [Required]
        [Range(392, 4000, ErrorMessage = "Journal YearOfPublishing cannot be {0}. It must be between {1} and {2}.")]
        public int YearOfPublishing { get; set; }

        /// <summary>
        /// Gets or sets foreign key of the publisher of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>Primary key of the publisher of the <see cref="Journal"/> entity.</value>
        [Required]
        public int PublisherId { get; set; }

        /// <summary>
        /// Gets or sets the publisher of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>Publisher of the <see cref="Journal"/> entity.</value>
        public virtual Publisher Publisher { get; set; }

        /// <summary>
        /// Gets or sets foreign key of the client of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>Primary key of the client of the <see cref="Journal"/> entity.</value>
        public int? ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>Client of the <see cref="Journal"/> entity.</value>
        public virtual Client Client { get; set; }

        /// <summary>
        /// Gets or sets the number of copies of the <see cref="Journal"/> entity in the library.
        /// </summary>
        /// <value>Current number of copies of the <see cref="Journal"/> entity in the library.</value>
        [Required]
        [Range(0, 2000, ErrorMessage = "Journal Quantity cannot be {0}. It must be between {1} and {2}.")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the number of available copies of the <see cref="Journal"/> entity in the library.
        /// </summary>
        /// <value>Current number of available copies of the <see cref="Journal"/> entity in the library.</value>
        public int Available { get; set; }

        /// <summary>
        /// Gets or sets the subjects of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>Initial collection of subjects of the <see cref="Journal"/> entity.</value>
        [Required]
        [Range(0, 2000, ErrorMessage = "Journal Available cannot be {0}. It must be between {1} and {2}.")]
        public virtual ICollection<Subject> Subjects
        {
            get
            {
                return this.subjects;
            }

            set
            {
                this.subjects = value;
            }
        }
    }
}