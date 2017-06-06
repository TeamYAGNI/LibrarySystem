// <copyright file="ExportJournals_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of JsonWriter object constructor.</summary>

using System;
using System.Collections.Generic;
using LibrarySystem.FileExporters.Utils.Contracts;
using LibrarySystem.Models;
using Moq;
using NUnit.Framework;
using System.IO;

namespace LibrarySystem.FileExporters.UnitTests.XmlWriterTests
{
    [TestFixture]
    public class ExportBooks_Should
    {
        [Test]
        [Category("FileExplorers.XmlWriter.Constructor")]
        public void CallGetTextWriterMethodTwice_WhenAllArgumentsArePassed()
        {
            // Arrange
            var mockTextWriterWrapper = new Mock<ITextWriter>();
            mockTextWriterWrapper.Setup(p => p.GetTextWriter());
            var mockXmlSerializerWrapper = new Mock<IXmlSerializer>();
            var books = new Mock<IEnumerable<DTOBook>>();
            var xmlWriter = new XmlWriter(mockTextWriterWrapper.Object, mockXmlSerializerWrapper.Object);

            // Act
            xmlWriter.ExportBooks(books.Object);

            // Assert
            mockTextWriterWrapper.Verify(x => x.GetTextWriter(), Times.Exactly(2));
        }

        [Test]
        [Category("FileExplorers.XmlWriter.Constructor")]
        public void CallSerializeMethodOnce_WhenAllArgumentsArePassed()
        {
            // Arrange
            var mockTextWriterWrapper = new Mock<ITextWriter>();
            mockTextWriterWrapper.Setup(p => p.GetTextWriter());
            var mockXmlSerializerWrapper = new Mock<IXmlSerializer>();
            var books = new Mock<IEnumerable<DTOBook>>();
            mockXmlSerializerWrapper.Setup(p => p.Serialize(It.IsAny<TextWriter>(), books.Object));
            var xmlWriter = new XmlWriter(mockTextWriterWrapper.Object, mockXmlSerializerWrapper.Object);

            // Act
            xmlWriter.ExportBooks(books.Object);

            // Assert
            mockXmlSerializerWrapper.Verify(x => x.Serialize(It.IsAny<TextWriter>(), books.Object), Times.Once());
        }

        [Test]
        [Category("FileExplorers.XmlWriter.Constructor")]
        public void ThrowArgumentNullException_WhenJournalsArgumentIsNull()
        {
            // Arrange
            var mockTextWriterWrapper = new Mock<ITextWriter>();
            var mockXmlSerializerWrapper = new Mock<IXmlSerializer>();
            var xmlWriter = new XmlWriter(mockTextWriterWrapper.Object, mockXmlSerializerWrapper.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => xmlWriter.ExportBooks(null));
        }
    }
}
