using System.Collections.Generic;
using LibrarySystem.Models;

namespace LibrarySystem.Repositories.Contracts
{
    public interface IJournalRepository : IRepository<Journal>
    {
        Journal FindJournalByISSN(string ISSN);

        IEnumerable<Journal> FindJournalsByTitle(string title);

        IEnumerable<Journal> GetAllJournalsByPublisherAndYearOfPublishing(string publisherName, int yearOfPublishing);

        IEnumerable<Journal> GetAllJournalsByYearOfPublishing(int yearOfPublishing);

        IEnumerable<Journal> GetAllJournalsThatAreInUse();

        int GetAvailableQuantityByISSN(string ISSN);

        int GetInitialQuantityByISSN(string ISSN);

        int GetIssueNumberByISSN(string ISSN);

        IEnumerable<Journal> GetJournalsByPublisherName(string publisherName);

        IEnumerable<Journal> GetJournalsBySubject(string subject);

        IEnumerable<Journal> GetTop5JournalsOrderedByImpactFactor();

        IEnumerable<Journal> GetAllClientJournals(string PIN);
    }
}