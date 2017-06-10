using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Contracts
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