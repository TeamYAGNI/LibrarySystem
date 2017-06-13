// <copyright file="ExportJournals_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of JsonWriter object constructor.</summary>

using System;
using System.Collections.Generic;
using LibrarySystem.FileImporters;
using LibrarySystem.FileImporters.Utils.Contracts;
using LibrarySystem.Models.DTOs.JSON;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.FileImporters.UnitTests.JsonReaderTests
{
    [TestFixture]
    public class ImportJournals_Should
    {
        [Test]
        [Category("FileImporters.JsonReader.ImportJournals")]
        public void CallGetStreamReaderMethodTwice_WhenAllArgumentsArePassed()
        {
            // Arrange
            var mockStreamReaderWrapper = new Mock<IStreamReader>();
            mockStreamReaderWrapper.Setup(p => p.GetStreamReader());
            var mockJsonDeserializerWrapper = new Mock<IJsonDeserializer>();
            var journals = new Mock<IEnumerable<JournalJsonDto>>();
            var jsonReader = new JsonReader(mockStreamReaderWrapper.Object, mockJsonDeserializerWrapper.Object);

            // Act
            jsonReader.ImportJournals();

            // Assert
            mockStreamReaderWrapper.Verify(x => x.GetStreamReader(), Times.Exactly(2));
        }

        [Test]
        [Category("FileImporters.JsonReader.ImportJournals")]
        public void CallSerializeMethodOnce_WhenAllArgumentsArePassed()
        {
            // Arrange
            var mockStreamReaderWrapper = new Mock<IStreamReader>();
            mockStreamReaderWrapper.Setup(p => p.GetStreamReader());
            var mockJsonDeserializerWrapper = new Mock<IJsonDeserializer>();
            var journals = new Mock<IEnumerable<JournalJsonDto>>();
            mockJsonDeserializerWrapper.Setup(p => p.Deserialize(p.GetStreamReader()));
            var jsonWriter = new JsonWriter(mockTextWriterWrapper.Object, mockJsonSerializerWrapper.Object);

            // Act
            jsonWriter.ExportJournals(journals.Object);

            // Assert
            mockJsonSerializerWrapper.Verify(x => x.Serialize(journals.Object), Times.Once());
        }

        [Test]
        [Category("FileImporters.JsonReader.ImportJournals")]
        public void ThrowArgumentNullException_WhenJournalsArgumentIsNull()
        {
            // Arrange
            var mockTextWriterWrapper = new Mock<ITextWriter>();
            var mockJsonSerializerWrapper = new Mock<IJsonSerializer>();
            var jsonWriter = new JsonWriter(mockTextWriterWrapper.Object, mockJsonSerializerWrapper.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => jsonWriter.ExportJournals(null));
        }
    }
}
