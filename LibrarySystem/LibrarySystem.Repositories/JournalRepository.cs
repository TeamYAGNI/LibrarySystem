using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories
{
    public class JournalRepository : Repository<Journal>, IJournalRepository
    {
        public JournalRepository(LibrarySystemDbContext context) : base(context)
        {
        }

        private LibrarySystemDbContext LibraryDbContext
        {
            get
            {
                return this.Context as LibrarySystemDbContext;
            }
        }

        public Journal FindJournalByISSN(string ISSN)
        {
            return this.LibraryDbContext.Journals
                .FirstOrDefault(j => j.ISSN == ISSN);
        }

        public IEnumerable<Journal> FindJournalsByTitle(string title)
        {
            return this.Find(j => j.Title == title);
        }

        public int GetIssueNumberByISSN(string ISSN)
        {
            return this.LibraryDbContext.Journals
                .Where(j => j.ISSN == ISSN)
                .Select(j => j.IssueNumber)
                .FirstOrDefault();
        }

        public int GetInitialQuantityByISSN(string ISSN)
        {
            return this.LibraryDbContext.Journals
                .Where(j => j.ISSN == ISSN)
                .Select(j => j.Quantity)
                .FirstOrDefault();
        }

        public int GetAvailableQuantityByISSN(string ISSN)
        {
            return this.LibraryDbContext.Journals
                .Where(j => j.ISSN == ISSN)
                .Select(j => j.Available)
                .FirstOrDefault();
        }

        public IEnumerable<Journal> GetJournalsBySubject(string subject)
        {
            return this.LibraryDbContext.Journals.Where(j => j.Subjects.Any(s => s.Name == subject)).AsEnumerable();
        }

        public IEnumerable<Journal> GetJournalsByPublisherName(string publisherName)
        {
            return this.Find(j => j.Publisher.Name == publisherName);
        }

        public IEnumerable<Journal> GetAllJournalsByYearOfPublishing(int yearOfPublishing)
        {
            return this.Find(j => j.YearOfPublishing == yearOfPublishing);
        }

        public IEnumerable<Journal> GetAllJournalsByPublisherAndYearOfPublishing(string publisherName, int yearOfPublishing)
        {
            return this.Find(j => j.Publisher.Name == publisherName && j.YearOfPublishing == yearOfPublishing);
        }

        public IEnumerable<Journal> GetTop5JournalsOrderedByImpactFactor()
        {
            return this.LibraryDbContext.Journals
                .Where(j => j.ImpactFactor != null)
                .OrderByDescending(j => j.ImpactFactor)
                .Take(5)
                .AsEnumerable();
        }

        public IEnumerable<Journal> GetAllJournalsThatAreInUse()
        {
            return this.Find(j => j.Quantity != j.Available);
        }
    }
}
