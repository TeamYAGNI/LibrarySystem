// <copyright file="JsonBooksSerializer.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of JSON serializer wrapper.</summary>

using System;
using System.Xml.Serialization;
using LibrarySystem.FileExporters.Utils.Contracts;

namespace LibrarySystem.FileExporters.Utils
{
    /// <summary>
    /// Represent a <see cref="XmlSerializerWrapper"/> class.
    /// </summary>
    public class XmlSerializerWrapper : IXmlSerializerWrapper
    {
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

            this.XmlSerializer = xmlSerializer;
        }

        /// <summary>
        /// 
        /// </summary>
        public XmlSerializer XmlSerializer { get; private set; }
    }
}
