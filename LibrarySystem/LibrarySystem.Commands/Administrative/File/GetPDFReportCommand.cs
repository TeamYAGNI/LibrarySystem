using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Commands.Abstractions;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.FileExporters;
using LibrarySystem.Repositories.Contracts.Data;

namespace LibrarySystem.Commands.Administrative.File
{
    public class GetPDFReportCommand : Command, ICommand
    {
        private readonly PdfWriterProvider pdfWriter;
        private readonly ILendingRepository lendingRepository;
        public GetPDFReportCommand(PdfWriterProvider pdfWriter, ILendingRepository lendingRepository) : base(new List<object>() { pdfWriter, lendingRepository }, 0)
        {
            this.pdfWriter = pdfWriter;
            this.lendingRepository = lendingRepository;
        }

        public override string Execute(IList<string> parameters)
        {
            this.ValidateParameters(parameters);

            var lendigs = this.lendingRepository.GetAll();

            if (lendigs.Count() == 0)
            {
                return $"There are no lendings in the base.";
            }

            this.pdfWriter.ExportPdfReport(lendigs);

            return $"Successfully created pdf report.";
        }
    }
}
