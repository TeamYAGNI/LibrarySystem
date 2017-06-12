using System.Linq;
using Bytes2you.Validation;
using LibrarySystem.FileExporters.Contracts;
using LibrarySystem.Models.DTOs.JSON;
using LibrarySystem.Repositories.Contracts;

namespace LibrarySystem.Repositories.FileExport.UnitOfWork
{
    public class JsonUnitOfWork : IUnitOfWork
    {
        private IJsonWriter jsonFileContext;
        private IRepository<JournalJsonDto> journals;

        public JsonUnitOfWork(IJsonWriter jsonFileContext, IRepository<JournalJsonDto> journals)
        {
            Guard.WhenArgument(jsonFileContext, "JsonUnitOfWork").IsNull().Throw();
            Guard.WhenArgument(journals, "JsonUnitOfWork").IsNull().Throw();

            this.jsonFileContext = jsonFileContext;
            this.journals = journals;
        }

        public int Commit()
        {
            jsonFileContext.ExportJournals(this.journals.GetAll());
            return this.journals.GetAll().Count();
        }

        public void Dispose()
        {
        }
    }
}
