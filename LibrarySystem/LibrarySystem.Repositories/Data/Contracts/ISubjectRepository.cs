using System.Collections.Generic;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories.Data.Contracts
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        IEnumerable<Subject> GetAllSubSubjects();

        IEnumerable<Subject> GetAllSubSubjectsBySuperSubjectName(string superSubjectName);

        IEnumerable<Subject> GetAllSuperSubjects();

        Subject GetSubjectByName(string subjectName);

        Subject GetSuperSubjectBySubSubjectName(string subSubjectName);

        IEnumerable<Subject> GetTop5SubjectsOrderedByJournalImpactFactor();

        IEnumerable<Subject> GetTop5SubjectsWithMostJournals();
    }
}