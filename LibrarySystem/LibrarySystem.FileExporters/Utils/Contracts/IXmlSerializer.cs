// <copyright file="ITextWriterWrapper.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of text writer wrapper interface.</summary>

using System.Collections.Generic;
using LibrarySystem.Models.DTOs.XML;

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
        void Serialize(ITextWriter textWriter, IEnumerable<BookXmlDto> books);
    }
}
