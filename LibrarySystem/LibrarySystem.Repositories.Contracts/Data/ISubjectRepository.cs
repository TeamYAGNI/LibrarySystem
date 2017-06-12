// <copyright file = "ISubjectRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of ISubjectRepository implementators.</summary>

using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Contracts.Data
{
    /// <summary>
    /// Represent a <see cref="ISubjectRepository"/> interface. Heir of <see cref="IRepository{Subject}"/>
    /// </summary>
    public interface ISubjectRepository : IRepository<Subject>
    {
        /// <summary>
        /// Provides collection of all the subjects.
        /// </summary>
        /// <returns>Collection of all the subjects.</returns>
        IEnumerable<Subject> GetAllSubSubjects();

        /// <summary>
        /// Provides collection of all the direct child subjects of a specific subject by a given name.
        /// </summary>
        /// <param name="superSubjectName">Name of the parent subject.</param>
        /// <returns>Collection of all the direct child subjects of the subject with the given name.</returns>
        IEnumerable<Subject> GetAllSubSubjectsBySuperSubjectName(string superSubjectName);

        /// <summary>
        /// Provides collection of all the subjects with no parrent subject.
        /// </summary>
        /// <returns>Collection of all the subjects with no parrent subject.</returns>
        IEnumerable<Subject> GetAllSuperSubjects();

        /// <summary>
        /// Provides subject by a given name.
        /// </summary>
        /// <param name="subjectName">Name of the subject.</param>
        /// <returns>subject with the given name.</returns>
        Subject GetSubjectByName(string subjectName);

        /// <summary>
        /// Provide a subject by a given name of child subject.
        /// </summary>
        /// <param name="subSubjectName">Name of the child subject.</param>
        /// <returns>Parent subject of the subject with the given name.</returns>
        Subject GetSuperSubjectBySubSubjectName(string subSubjectName);

        /// <summary>
        /// Provide the five topmost subjects ordered by related journals count.
        /// </summary>
        /// <returns>Collection of at most five subjects ordered by related journals count.</returns>
        IEnumerable<Subject> GetTop5SubjectsWithMostJournals();

        /// <summary>
        /// Provide the five topmost subjects ordered by related journals impact factor.
        /// </summary>
        /// <returns>Collection of at most five subjects ordered by related journals impact factor.</returns>
        IEnumerable<Subject> GetTop5SubjectsOrderedByJournalImpactFactor();
    }
}