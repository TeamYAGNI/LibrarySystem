// <copyright file="JsonReader.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of JSON file reader.</summary>

using System;
using System.Collections.Generic;
using System.IO;
using LibrarySystem.Models;
using Newtonsoft.Json;

namespace LibrarySystem.FileImporters
{
    /// <summary>
    /// 
    /// </summary>
    public class JsonReader
    {
        /// <summary>
        /// 
        /// </summary>
        private string filePath;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        public JsonReader(string filePath)
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
        public IEnumerable<DTOJournal> ImportJournals()
        {
            using (StreamReader file = File.OpenText(this.filePath))
            {
                return JsonConvert.DeserializeObject<IEnumerable<DTOJournal>>(file.ReadToEnd());
            }
        }
    }
}
