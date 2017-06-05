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

namespace LibrarySystem.FileExporters.UnitTests.JsonWriterTests
{
    [TestFixture]
    public class ExportJournals_Should
    {
        [Test]
        [Category("FileExplorers.JsonWriter.Constructor")]
        public void CallWriteMethodOnce_WhenAllArgumentsArePassed()
        {
            // Arrange
            var mockTextWriterWrapper = new Mock<ITextWriterWrapper>();
            mockTextWriterWrapper.Setup(p => p.TextWriter.Write(It.IsAny<string>()));
            var mockJsonSerializerWrapper = new Mock<IJsonSerializerWrapper>();
            var journals = new Mock<IEnumerable<DTOJournal>>();
            var jsonWriter = new JsonWriter(mockTextWriterWrapper.Object, mockJsonSerializerWrapper.Object);

            // Act
            jsonWriter.ExportJournals(journals.Object);

            // Assert
            mockTextWriterWrapper.Verify(x => x.TextWriter.Write(It.IsAny<string>()), Times.Once());
        }

        [Test]
        [Category("FileExplorers.JsonWriter.Constructor")]
        public void CallSerializeMethodOnce_WhenAllArgumentsArePassed()
        {
            // Arrange
            var mockTextWriterWrapper = new Mock<ITextWriterWrapper>();
            mockTextWriterWrapper.Setup(p => p.TextWriter.Write(It.IsAny<string>()));
            var mockJsonSerializerWrapper = new Mock<IJsonSerializerWrapper>();
            var journals = new Mock<IEnumerable<DTOJournal>>();
            mockJsonSerializerWrapper.Setup(p => p.Serialize(journals.Object));
            var jsonWriter = new JsonWriter(mockTextWriterWrapper.Object, mockJsonSerializerWrapper.Object);

            // Act
            jsonWriter.ExportJournals(journals.Object);

            // Assert
            mockJsonSerializerWrapper.Verify(x => x.Serialize(journals.Object), Times.Once());
        }

        [Test]
        [Category("FileExplorers.JsonWriter.Constructor")]
        public void Throw_WhenNoJournalsArgumentIsPassed()
        {
            // Arrange
            var mockTextWriterWrapper = new Mock<ITextWriterWrapper>();
            var mockJsonSerializerWrapper = new Mock<IJsonSerializerWrapper>();
            var jsonWriter = new JsonWriter(mockTextWriterWrapper.Object, mockJsonSerializerWrapper.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => jsonWriter.ExportJournals(null));
        }
    }
}
