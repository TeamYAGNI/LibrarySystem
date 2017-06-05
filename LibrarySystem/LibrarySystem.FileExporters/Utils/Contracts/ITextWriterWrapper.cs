// <copyright file="ITextWriterWrapper.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of text writer wrapper interface.</summary>

using System.IO;

namespace LibrarySystem.FileExporters.Utils.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITextWriterWrapper
    {
        TextWriter TextWriter { get; set; }
    }
}
