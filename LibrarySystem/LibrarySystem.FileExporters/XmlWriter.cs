// <copyright file="XmlWriter.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of XML file writer.</summary>
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using LibrarySystem.Models;

namespace LibrarySystem.FileExporters
{
    /// <summary>
    /// 
    /// </summary>
    public class XmlWriter
    {
        /// <summary>
        /// 
        /// </summary>
        private string directory;

        /// <summary>
        /// 
        /// </summary>
        private string fileName;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        public XmlWriter(string directory, string fileName)
        {
            if (string.IsNullOrEmpty(directory))
            {
                throw new ArgumentException("Direcotry path cannot be null or empty string!");
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("File name cannot be null or empty string!");
            }

            this.directory = directory;
            this.fileName = fileName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void ExportBooks(IEnumerable<DTOBook> books)
        {
            if (!Directory.Exists(this.directory))
            {
                Directory.CreateDirectory(this.directory);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<DTOBook>));
            using (TextWriter writer = new StreamWriter(this.directory + "\\" + this.fileName))
            {
                serializer.Serialize(writer, books);
            }
        }
    }
}
