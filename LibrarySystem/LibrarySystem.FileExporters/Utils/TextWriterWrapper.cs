// <copyright file="TextWriterWrapper.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of TextWriter wrapper.</summary>

using System.IO;
using Bytes2you.Validation;
using LibrarySystem.FileExporters.Utils.Contracts;

namespace LibrarySystem.FileExporters.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class TextWriterWrapper : ITextWriter
    {
        /// <summary>
        /// 
        /// </summary>
        private StreamWriter textWriter;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="fileName"></param>
        public TextWriterWrapper(string directory, string fileName)
        {
            Guard.WhenArgument(directory, "TextWriterWrapper").IsNullOrEmpty().Throw();

            Guard.WhenArgument(fileName, "TextWriterWrapper").IsNullOrEmpty().Throw();

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            this.textWriter = new StreamWriter(directory + "\\" + fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        public TextWriter GetTextWriter()
        {
            return this.textWriter;
        }
    }
}
