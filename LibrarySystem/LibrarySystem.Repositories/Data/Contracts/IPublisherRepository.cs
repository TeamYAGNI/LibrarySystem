using LibrarySystem.Models;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories.Data.Contracts
{
    public interface IPublisherRepository : IRepository<Publisher>
    {
        int GetBookCountByPublisherName(string publisherName);

        int GetJournalCountByPublisherName(string publisherName);

        Publisher GetPublisherByBookTitle(string bookTitle);

        Publisher GetPublisherByJournalTitle(string journalTitle);

        Publisher GetPublisherByName(string publisherName);
    }
}