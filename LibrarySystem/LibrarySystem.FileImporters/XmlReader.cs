// <copyright file="XmlReader.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of XML file reader.</summary>

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using LibrarySystem.Models;

namespace LibrarySystem.FileImporters
{
    /// <summary>
    /// 
    /// </summary>
    public class XmlReader
    {
        /// <summary>
        /// 
        /// </summary>
        private const string DescendantName = "book";

        /// <summary>
        /// 
        /// </summary>
        private string filePath;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        public XmlReader(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty string!");
            }

            this.filePath = filePath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DTOBook> ImportBooks()
        {
            var xmlDocument = XDocument.Load(this.filePath);
            var xmlFormatBooks = xmlDocument.Descendants(DescendantName);
            var pocoBooks = new List<DTOBook>();

            foreach (var book in xmlFormatBooks)
            {
                var stringReader = new StringReader(book.ToString());
                var xmlSerializer = new XmlSerializer(typeof(DTOBook));
                var current = (DTOBook)xmlSerializer.Deserialize(stringReader);

                pocoBooks.Add(current);
            }

            return pocoBooks;
        }
    }
}
