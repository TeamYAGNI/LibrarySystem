using System.Linq;
using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Abstractions;
using LibrarySystem.Repositories.Data.Contracts;

namespace LibrarySystem.Repositories.Data
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(LibrarySystemDbContext context) : base(context)
        {
        }

        private LibrarySystemDbContext LibraryDbContext
        {
            get
            {
                return this.Context as LibrarySystemDbContext;
            }
        }

        public Publisher GetPublisherByName(string publisherName)
        {
            return this.LibraryDbContext.Publishers.FirstOrDefault(p => p.Name == publisherName);
        }

        public int GetBookCountByPublisherName(string publisherName)
        {
            return this.LibraryDbContext.Publishers
                .Where(p => p.Name == publisherName)
                .Select(p => p.Books)
                .Count();
        }

        public int GetJournalCountByPublisherName(string publisherName)
        {
            return this.LibraryDbContext.Publishers
                .Where(p => p.Name == publisherName)
                .Select(p => p.Journals)
                .Count();
        }

        public Publisher GetPublisherByBookTitle(string bookTitle)
        {
            return this.Find(a => a.Books.Any(b => b.Title == bookTitle)).FirstOrDefault();
        }

        public Publisher GetPublisherByJournalTitle(string journalTitle)
        {
            return this.Find(a => a.Books.Any(b => b.Title == journalTitle)).FirstOrDefault();
        }
    }
}
