using System.Collections.Generic;
using Bytes2you.Validation;
using LibrarySystem.FileExporters.Utils.Contracts;
using LibrarySystem.Models;

namespace LibrarySystem.FileExporters
{
    public class PdfWriterProvider
    {
        private IPdfStream pdfStream;
        private IPdfTableGenerator pdfTableGenerator;

        public PdfWriterProvider(IPdfStream pdfStream, IPdfTableGenerator pdfTableGenerator)
        {
            Guard.WhenArgument(pdfStream, "PdfStreamWrapper").IsNull().Throw();
            Guard.WhenArgument(pdfTableGenerator, "PdfStreamWrapper").IsNull().Throw();

            this.pdfStream = pdfStream;
            this.pdfTableGenerator = pdfTableGenerator;
        }

        public void ExportPdfReport(IEnumerable<Lending> report)
        {
            Guard.WhenArgument(report, "CreateTable").IsNull().Throw();

            this.pdfStream.Document.Open();
            this.pdfStream.Document.Add(this.pdfTableGenerator.CreateTable(report));
            this.pdfStream.Document.Close();
        }
    }
}
