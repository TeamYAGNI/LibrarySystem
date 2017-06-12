// <copyright file="ExportJournals_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of JsonWriter object constructor.</summary>

using System;
using System.Collections.Generic;
using LibrarySystem.FileExporters.Utils.Contracts;
using LibrarySystem.Models.DTOs.JSON;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.FileExporters.UnitTests.JsonWriterTests
{
    [TestFixture]
    public class ExportBooks_Should
    {
        [Test]
        [Category("FileExplorers.JsonWriter.Constructor")]
        public void CallGetTextWriterMethodOnce_WhenAllArgumentsArePassed()
        {
            // Arrange
            var mockTextWriterWrapper = new Mock<ITextWriter>();
            mockTextWriterWrapper.Setup(p => p.GetTextWriter().Write(It.IsAny<string>()));
            var mockJsonSerializerWrapper = new Mock<IJsonSerializer>();
            var journals = new Mock<IEnumerable<JournalJsonDto>>();
            var jsonWriter = new JsonWriter(mockTextWriterWrapper.Object, mockJsonSerializerWrapper.Object);

            // Act
            jsonWriter.ExportJournals(journals.Object);

            // Assert
            mockTextWriterWrapper.Verify(x => x.GetTextWriter().Write(It.IsAny<string>()), Times.Once());
        }

        [Test]
        [Category("FileExplorers.JsonWriter.Constructor")]
        public void CallSerializeMethodOnce_WhenAllArgumentsArePassed()
        {
            // Arrange
            var mockTextWriterWrapper = new Mock<ITextWriter>();
            mockTextWriterWrapper.Setup(p => p.GetTextWriter().Write(It.IsAny<string>()));
            var mockJsonSerializerWrapper = new Mock<IJsonSerializer>();
            var journals = new Mock<IEnumerable<JournalJsonDto>>();
            mockJsonSerializerWrapper.Setup(p => p.Serialize(journals.Object));
            var jsonWriter = new JsonWriter(mockTextWriterWrapper.Object, mockJsonSerializerWrapper.Object);

            // Act
            jsonWriter.ExportJournals(journals.Object);

            // Assert
            mockJsonSerializerWrapper.Verify(x => x.Serialize(journals.Object), Times.Once());
        }

        [Test]
        [Category("FileExplorers.JsonWriter.Constructor")]
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
