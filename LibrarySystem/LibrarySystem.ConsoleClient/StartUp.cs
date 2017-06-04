// <copyright file="StartUP.cs" company="YAGNI">
// All rights reserved.
// </copyright>

using System;
using LibrarySystem.FileExporters;
using LibrarySystem.FileImporters;

namespace LibrarySystem.ConsoleClient
{
    /// <summary>
    /// Represent the Console Client of the Library System application starting point.
    /// </summary>
    public class StartUp
    {
        /// <summary>
        /// Represent the main method called in the application live.
        /// </summary>
        public static void Main()
        {
            var xmlImportFilePath = "./../../../books.xml";
            var xmlFileReader = new XmlReader(xmlImportFilePath);
            var xmlBooks = xmlFileReader.ImportBooks();
            foreach (var xmlBook in xmlBooks)
            {
                Console.WriteLine($"BookId: {xmlBook.Id}");
                Console.WriteLine($"---- Author: {xmlBook.Author}");
                Console.WriteLine($"---- Title: {xmlBook.Title}");
                Console.WriteLine($"---- ISBN: {xmlBook.ISBN}\n");
            }

            var xmlExportFileDirectory = "./../../../";
            var xmlExportFileName = "books-inventory.xml";
            var xmlFileWriter = new XmlWriter(xmlExportFileDirectory, xmlExportFileName);
            xmlFileWriter.ExportBooks(xmlBooks);
            
            JsonReader jsonImporter = new JsonReader("./../../../journals.json");
            var journals = jsonImporter.ImportJournals();
            foreach (var journal in journals)
            {
                Console.WriteLine($"Journal Id: {journal.Id}");
                Console.WriteLine($"---- Title: {journal.Title}");
                Console.WriteLine($"---- ISSN: {journal.ISSN}\n");
            }

            var jsonExportFileDirectory = "./../../../";
            var jsonExportFileName = "journals-inventory.json";
            JsonWriter jsonExporter = new JsonWriter(jsonExportFileDirectory, jsonExportFileName);
            jsonExporter.ExportJournals(journals);
        }
    }
}
