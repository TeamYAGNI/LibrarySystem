// <copyright file="SubjectRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of SubjectRepository class.</summary>

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Repositories.Data
{
    /// <summary>
    /// Represent a <see cref="SubjectRepository"/> class. Heir of <see cref="Repository{Subject}"/>.
    /// Implementator of <see cref="ISubjectRepository"/> interface.
    /// </summary>
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubjectRepository"/> class.
        /// </summary>
        /// <param name="context">Context that provide connection to the database.</param>
        public SubjectRepository(LibrarySystemDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets the context as a <see cref="LibrarySystemDbContext"/>.
        /// </summary>
        private LibrarySystemDbContext LibraryDbContext
        {
            get
            {
                return this.Context as LibrarySystemDbContext;
            }
        }

        /// <summary>
        /// Provides subject by a given name.
        /// </summary>
        /// <param name="subjectName">Name of the subject.</param>
        /// <returns>subject with the given name.</returns>
        public Subject GetSubjectByName(string subjectName)
        {
            return this.LibraryDbContext.Subjects.FirstOrDefault(s => s.Name == subjectName);
        }

        /// <summary>
        /// Provides collection of all the subjects with no parrent subject.
        /// </summary>
        /// <returns>Collection of all the subjects with no parrent subject.</returns>
        public IEnumerable<Subject> GetAllSuperSubjects()
        {
            return this.Find(s => s.SuperSubjectId == null);
        }

        /// <summary>
        /// Provide the five topmost subjects ordered by related journals count.
        /// </summary>
        /// <returns>Collection of at most five subjects ordered by related journals count.</returns>
        public IEnumerable<Subject> GetTop5SubjectsWithMostJournals()
        {
            return this.LibraryDbContext.Subjects
                .Include(s => s.Journals)
                .Where(s => s.Journals != null)
                .OrderByDescending(s => s.Journals.Count)
                .Take(5)
                .ToList();
        }

        /// <summary>
        /// Provide the five topmost subjects ordered by related journals impact factor.
        /// </summary>
        /// <returns>Collection of at most five subjects ordered by related journals impact factor.</returns>
        public IEnumerable<Subject> GetTop5SubjectsOrderedByJournalImpactFactor()
        {
            return this.LibraryDbContext.Subjects
                .Include(s => s.Journals)
                .Where(s => s.Journals != null)
                .OrderByDescending(s => s.Journals.OrderByDescending(j => j.ImpactFactor).Take(5))
                .ToList();
        }

        /// <summary>
        /// Provides collection of all the direct child subjects of a specific subject by a given name.
        /// </summary>
        /// <param name="superSubjectName">Name of the parent subject.</param>
        /// <returns>Collection of all the direct child subjects of the subject with the given name.</returns>
        public IEnumerable<Subject> GetAllSubSubjectsBySuperSubjectName(string superSubjectName)
        {
            var subject = this.LibraryDbContext.Subjects.FirstOrDefault(s => s.Name == superSubjectName);

            return (subject != null) ? subject.SubSubjects : new List<Subject>();
        }

        /// <summary>
        /// Provide a subject by a given name of child subject.
        /// </summary>
        /// <param name="subSubjectName">Name of the child subject.</param>
        /// <returns>Parent subject of the subject with the given name.</returns>
        public Subject GetSuperSubjectBySubSubjectName(string subSubjectName)
        {
            return this.LibraryDbContext.Subjects.FirstOrDefault(s => s.Name == subSubjectName);
        }

        /// <summary>
        /// Provides collection of all the subjects.
        /// </summary>
        /// <returns>Collection of all the subjects.</returns>
        public IEnumerable<Subject> GetAllSubSubjects()
        {
            return this.LibraryDbContext.Subjects
                .Where(s => s.SuperSubjectId != null);
        }
    }
}
