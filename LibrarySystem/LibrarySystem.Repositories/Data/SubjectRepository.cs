using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Data.Contracts;

namespace LibrarySystem.Repositories.Data
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(LibrarySystemDbContext context) : base(context)
        {
        }

        private LibrarySystemDbContext LibraryDbContext
        {
            get
            {
                return this.Context as LibrarySystemDbContext;
            }
        }

        public Subject GetSubjectByName(string subjectName)
        {
            return this.LibraryDbContext.Subjects.FirstOrDefault(s => s.Name == subjectName);
        }

        public IEnumerable<Subject> GetAllSuperSubjects()
        {
            return this.Find(s => s.SuperSubjectId == null);
        }

        public IEnumerable<Subject> GetTop5SubjectsWithMostJournals()
        {
            return this.LibraryDbContext.Subjects
                .Include(s => s.Journals)
                .Where(s => s.Journals != null)
                .OrderByDescending(s => s.Journals.Count)
                .Take(5)
                .ToList();
        }

        public IEnumerable<Subject> GetTop5SubjectsOrderedByJournalImpactFactor()
        {
            return this.LibraryDbContext.Subjects
                .Include(s => s.Journals)
                .Where(s => s.Journals != null)
                .OrderByDescending(s => s.Journals.OrderByDescending(j => j.ImpactFactor).Take(5))
                .ToList();
        }

        public IEnumerable<Subject> GetAllSubSubjectsBySuperSubjectName(string superSubjectName)
        {
            var subject = this.LibraryDbContext.Subjects.FirstOrDefault(s => s.Name == superSubjectName);

            return (subject != null) ? subject.SubSubjects : new List<Subject>();
        }

        public Subject GetSuperSubjectBySubSubjectName(string subSubjectName)
        {
            return this.LibraryDbContext.Subjects.FirstOrDefault(s => s.Name == subSubjectName);
        }

        public IEnumerable<Subject> GetAllSubSubjects()
        {
            return this.LibraryDbContext.Subjects
                .Where(s => s.SuperSubjectId != null);
        }
    }
}
