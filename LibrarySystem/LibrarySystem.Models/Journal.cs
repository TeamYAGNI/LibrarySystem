// <copyright file="Journal.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Journal model.</summary>

using System.Collections.Generic;

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
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>Title of the <see cref="Journal"/> entity.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the impact factor of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>Impact factor of the <see cref="Journal"/> entity.</value>
        public float ImpactFactor { get; set; }

        /// <summary>
        /// Gets or sets the ISSN of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>ISSN of the <see cref="Journal"/> entity.</value>
        public string ISSN { get; set; }

        /// <summary>
        /// Gets or sets the issue number of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>Issue number of the <see cref="Journal"/> entity.</value>
        public int IssueNumber { get; set; }

        /// <summary>
        /// Gets or sets the year of publishing of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>Year of publishing of the <see cref="Journal"/> entity.</value>
        public int YearOfPublishing { get; set; }

        /// <summary>
        /// Gets or sets foreign key of the publisher of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>Primary key of the publisher of the <see cref="Journal"/> entity.</value>
        public int PublisherId { get; set; }

        /// <summary>
        /// Gets or sets the publisher of the <see cref="Journal"/> entity.
        /// </summary>
        /// <value>Publisher of the <see cref="Journal"/> entity.</value>
        public Publisher Publisher { get; set; }

        /// <summary>
        /// Gets or sets the number of copies of the <see cref="Journal"/> entity in the library.
        /// </summary>
        /// <value>Current number of copies of the <see cref="Journal"/> entity in the library.</value>
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
        public ICollection<Subject> Subjects
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