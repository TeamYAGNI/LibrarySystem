// <copyright file="ExportJournals_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of JsonWriter object constructor.</summary>

using System;
using System.Collections.Generic;
using LibrarySystem.FileImporters.Utils.Contracts;
using Moq;
using NUnit.Framework;
using LibrarySystem.Models.DTOs.XML;

namespace LibrarySystem.FileImporters.UnitTests.XmlWriterTests
{
    [TestFixture]
    public class ImportBooks_Should
    {
        [Test]
        [Category("FileImporters.XmlReader.ImportBooks")]
        public void CallGetStreamReaderMethodOnce_WhenAllArgumentsArePassed()
        {
            // Arrange
            var mockStreamReaderWrapper = new Mock<IStreamReader>();
            mockStreamReaderWrapper.Setup(p => p.GetStreamReader());
            var mockXmlDeserializerWrapper = new Mock<IXmlDeserializer>();
            var xmlReader = new XmlReader(mockStreamReaderWrapper.Object, mockXmlDeserializerWrapper.Object);

            // Act
            xmlReader.ImportBooks();

            // Assert
            mockStreamReaderWrapper.Verify(x => x.GetStreamReader(), Times.Once);
        }

        [Test]
        [Category("FileImporters.XmlReader.ImportBooks")]
        public void CallDeserializeMethodOnce_WhenAllArgumentsArePassed()
        {
            // Arrange
            var mockStreamReaderWrapper = new Mock<IStreamReader>();
            var mockXmlDeserializerWrapper = new Mock<IXmlDeserializer>();
            mockXmlDeserializerWrapper.Setup(p => p.Deserialize(It.IsAny<IStreamReader>()));
            var xmlReader = new XmlReader(mockStreamReaderWrapper.Object, mockXmlDeserializerWrapper.Object);

            // Act
            xmlReader.ImportBooks();

            // Assert
            mockXmlDeserializerWrapper.Verify(x => x.Deserialize(It.IsAny<IStreamReader>()), Times.Once());
        }
    }
}
