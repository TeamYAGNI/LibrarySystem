// <copyright file="Subject.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Book model.</summary>

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    /// <summary>
    /// Represent a <see cref="Subject"/> entity model.
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// Child nodes of the <see cref="Subject"/> entity.
        /// </summary>
        private ICollection<Subject> subSubjects;

        /// <summary>
        /// Journal of the <see cref="Subject"/> entity.
        /// </summary>
        private ICollection<Journal> journals;

        /// <summary>
        /// Initializes a new instance of the <see cref="Subject"/> class.
        /// </summary>
        public Subject()
        {
            this.subSubjects = new HashSet<Subject>();
            this.journals = new HashSet<Journal>();
        }

        /// <summary>
        /// Gets or sets the primary key of the <see cref="Subject"/> entity.
        /// </summary>
        /// <value>Primary key of the <see cref="Subject"/> entity.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the <see cref="Subject"/> entity.
        /// </summary>
        /// <value>Name of the <see cref="Subject"/> entity.</value>
        [Required]
        [StringLength(50, ErrorMessage = "Subject Name Invalid Length", MinimumLength = 1)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets foreign key of the parent node of the <see cref="Subject"/> entity.
        /// </summary>
        /// <value>Primary key of the parent node of the <see cref="Subject"/> entity.</value>
        public int? SuperSubjectId { get; set; }

        /// <summary>
        /// Gets or sets the parent node of the <see cref="Subject"/> entity.
        /// </summary>
        /// <value>Parent node of the <see cref="Subject"/> entity.</value>
        public virtual Subject SuperSubject { get; set; }

        /// <summary>
        /// Gets or sets the child nodes of the <see cref="Subject"/> entity.
        /// </summary>
        /// <value>Initial collection of child nodes of the <see cref="Subject"/> entity.</value>
        public virtual ICollection<Subject> SubSubjects
        {
            get
            {
                return this.subSubjects;
            }

            set
            {
                this.subSubjects = value;
            }
        }

        /// <summary>
        /// Gets or sets the journals related to the <see cref="Subject"/> entity.
        /// </summary>
        /// <value>Initial collection of journals related to the <see cref="Subject"/> entity.</value>
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