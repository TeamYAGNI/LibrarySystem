// <copyright file="JsonWriter.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of JSON file writer.</summary>

using System;
using System.Collections.Generic;
using System.IO;
using LibrarySystem.Models;
using Newtonsoft.Json;

namespace LibrarySystem.FileExporters
{
    /// <summary>
    /// 
    /// </summary>
    public class JsonWriter
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
        /// <param name="directory"></param>
        /// <param name="fileName"></param>
        public JsonWriter(string directory, string fileName)
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
        /// <param name="journals"></param>
        public void ExportJournals(IEnumerable<DTOJournal> journals)
        {
            if (!Directory.Exists(this.directory))
            {
                Directory.CreateDirectory(this.directory);
            }

            string journalsJson = JsonConvert.SerializeObject(journals, Formatting.Indented);
            File.WriteAllText(this.directory + "\\" + this.fileName, journalsJson);
        }
    }
}
