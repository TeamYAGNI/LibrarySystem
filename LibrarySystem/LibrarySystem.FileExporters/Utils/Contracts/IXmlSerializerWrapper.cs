// <copyright file="ITextWriterWrapper.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of text writer wrapper interface.</summary>

using System.Xml.Serialization;

namespace LibrarySystem.FileExporters.Utils.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IXmlSerializerWrapper
    {
        /// <summary>
        /// 
        /// </summary>
        XmlSerializer XmlSerializer { get; }
    }
}
