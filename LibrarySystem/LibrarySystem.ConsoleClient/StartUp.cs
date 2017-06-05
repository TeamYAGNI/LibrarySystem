// <copyright file="StartUP.cs" company="YAGNI">
// All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using LibrarySystem.FileExporters;
using LibrarySystem.FileExporters.Utils;
using LibrarySystem.FileImporters;
using LibrarySystem.FileImporters.Utils;
using LibrarySystem.Models;

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
            // Read XML Books
            var xmlFileReader = new XmlReader(
                new StreamReader("./../../../books.xml"),
                new XmlSerializer(typeof(List<DTOBook>)));
            var xmlBooks = xmlFileReader.ImportBooks();
            foreach (var xmlBook in xmlBooks)
            {
                Console.WriteLine($"BookId: {xmlBook.Id}");
                Console.WriteLine($"---- Author: {xmlBook.Author}");
                Console.WriteLine($"---- Title: {xmlBook.Title}");
                Console.WriteLine($"---- ISBN: {xmlBook.ISBN}\n");
            }

            // Write XML Books
            var xmlFileWriter = new XmlWriter(
                new TextWriterWrapper("./../../../", "books-inventory.xml"),
                new XmlSerializerWrapper(
                    new XmlSerializer(typeof(List<DTOBook>))));
            xmlFileWriter.ExportBooks(xmlBooks);

            // Read JSON Journals
            var jsonImporter = new JsonReader(
                new StreamReader("./../../../journals.json"),
                new JsonJournalsDeserializer());
            var journals = jsonImporter.ImportJournals();
            foreach (var journal in journals)
            {
                Console.WriteLine($"Journal Id: {journal.Id}");
                Console.WriteLine($"---- Title: {journal.Title}");
                Console.WriteLine($"---- ISSN: {journal.ISSN}\n");
            }

            // Write JSON Journals
            var jsonExporter = new JsonWriter(
                new TextWriterWrapper("./../../../", "journals-inventory.json"),
                new JsonSerializerWrapper());
            jsonExporter.ExportJournals(journals);
        }
    }
}
