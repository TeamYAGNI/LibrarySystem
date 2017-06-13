using System;
using System.Collections.Generic;
using Bytes2you.Validation;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LibrarySystem.FileExporters.Utils.Contracts;
using LibrarySystem.Models;

namespace LibrarySystem.FileExporters.Utils
{
    public class PdfTableGenerator : IPdfTableGenerator
    {
        private const string ReportTitle = "Lendings Report generated on: ";
        private const string BookName = "Book Name";
        private const string ClientName = "Client Name";
        private const string BorrowDate = "Borrowed on";
        private const string ReturnDate = "Returned on";
        private const string Remarks = "Remarks";
        private const string NullDateString = "Not Returned";
        private const int PdfTableSize = 5;

        public PdfPTable CreateTable(IEnumerable<Lending> report)
        {
            Guard.WhenArgument(report, "CreateTable").IsNull().Throw();

            PdfPTable table = new PdfPTable(PdfTableSize);
            table.WidthPercentage = 100;
            table.LockedWidth = false;
            table.HorizontalAlignment = Element.ALIGN_CENTER;

            var fullTitle = new Phrase(ReportTitle + DateTime.Now.ToString());
            var titleCell = new PdfPCell(fullTitle);
            titleCell.Colspan = PdfTableSize;
            titleCell.HorizontalAlignment = Element.ALIGN_CENTER;
            titleCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(titleCell);

            table.AddCell(SetColorToCell(BookName));
            table.AddCell(SetColorToCell(ClientName));
            table.AddCell(SetColorToCell(BorrowDate));
            table.AddCell(SetColorToCell(ReturnDate));
            table.AddCell(SetColorToCell(Remarks));
            
            foreach (var lending in report)
            {
                table.AddCell(lending.Book.Title);
                table.AddCell(lending.Client.FullName);
                table.AddCell(lending.BorrоwDate.ToString());
                table.AddCell(lending.ReturnDate == null ? NullDateString : lending.ReturnDate.ToString());
                table.AddCell(lending.Remarks);
            }

            return table;
        }

        private PdfPCell SetColorToCell(string cellTitle)
        {
            var phrase = new Phrase(cellTitle);
            var cell = new PdfPCell(phrase);
            cell.BackgroundColor = BaseColor.CYAN;

            return cell;
        }
    }
}
