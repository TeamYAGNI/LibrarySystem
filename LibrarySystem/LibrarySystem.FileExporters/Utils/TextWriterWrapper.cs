// <copyright file="TextWriterWrapper.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of TextWriter wrapper.</summary>

using System;
using System.IO;
using LibrarySystem.FileExporters.Utils.Contracts;

namespace LibrarySystem.FileExporters.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class TextWriterWrapper : ITextWriterWrapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="fileName"></param>
        public TextWriterWrapper(string directory, string fileName)
        {
            if (string.IsNullOrEmpty(directory))
            {
                throw new ArgumentException("Direcotry path cannot be null or empty string!");
            }

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("File name cannot be null or empty string!");
            }

            this.TextWriter = new StreamWriter(directory + "\\" + fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        public TextWriter TextWriter { get; set; }
    }
}
