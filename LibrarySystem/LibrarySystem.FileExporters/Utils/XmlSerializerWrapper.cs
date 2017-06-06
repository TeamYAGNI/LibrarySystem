// <copyright file="JsonBooksSerializer.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of JSON serializer wrapper.</summary>

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using LibrarySystem.FileExporters.Utils.Contracts;
using LibrarySystem.Models;

namespace LibrarySystem.FileExporters.Utils
{
    /// <summary>
    /// Represent a <see cref="XmlSerializerWrapper"/> class.
    /// </summary>
    public class XmlSerializerWrapper : IXmlSerializer
    {
        /// <summary>
        /// 
        /// </summary>
        private XmlSerializer xmlSerializer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlSerializer"></param>
        public XmlSerializerWrapper(XmlSerializer xmlSerializer)
        {
            if (xmlSerializer == null)
            {
                throw new ArgumentNullException("Text stream wrapper cannot be null.");
            }
        
            this.xmlSerializer = xmlSerializer;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Serialize(TextWriter textWriter, IEnumerable<DTOBook> books)
        {

        }
    }
}
