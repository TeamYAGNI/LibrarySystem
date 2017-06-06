// <copyright file="ITextWriterWrapper.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of text writer wrapper interface.</summary>

using System.Collections.Generic;
using System.IO;
using LibrarySystem.Models;

namespace LibrarySystem.FileExporters.Utils.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IXmlSerializer
    {
        /// <summary>
        /// 
        /// </summary>
        void Serialize(TextWriter textWriter, IEnumerable<DTOBook> books);
    }
}
