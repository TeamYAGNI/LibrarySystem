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
using LibrarySystem.Models.DTOs.JSON;
using LibrarySystem.Models.DTOs.XML;

using LibrarySystem.ConsoleClient.ContainerConfiguration;
using LibrarySystem.Framework.Contracts;
using Ninject;

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
            //IEngine engine = new StandardKernel(new LibrarySystemNinjectModule()).Get<IEngine>();
            //engine.Start();
            // Read XML Books
            var xmlFileReader = new XmlReader(
                new StreamReaderWrapper("./../../../books.xml"),
                new XmlDeserializerWrapper(
                    new XmlSerializer(typeof(List<BookXmlDto>))));
            var xmlBooks = xmlFileReader.ImportBooks();
            foreach (var xmlBook in xmlBooks)
            {
                Console.WriteLine($"---- Title: {xmlBook.Title}");
                Console.WriteLine($"---- ISBN: {xmlBook.ISBN}");
                foreach (var author in xmlBook.Authors)
                {
                    Console.WriteLine($"---- Author: {author.FirstName} {author.LastName}");
                }
                Console.WriteLine();
            }

            // Write XML Books
            var xmlFileWriter = new XmlWriter(
                new TextWriterWrapper("./../../../", "books-inventory.xml"),
                new XmlSerializerWrapper(
                    new XmlSerializer(typeof(List<BookXmlDto>))));
            xmlFileWriter.ExportBooks(xmlBooks);

            // Read JSON Journals
            var jsonImporter = new JsonReader(
                new StreamReaderWrapper("./../../../journals.json"),
                new JsonDeserializerWrapper());
            var journals = jsonImporter.ImportJournals();
            foreach (var journal in journals)
            {
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
