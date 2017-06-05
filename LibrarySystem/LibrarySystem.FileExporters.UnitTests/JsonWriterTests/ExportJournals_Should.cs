// <copyright file="ExportJournals_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of JsonWriter object constructor.</summary>

using System;
using LibrarySystem.FileExporters.Utils;
using LibrarySystem.FileExporters.Utils.Contracts;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.FileExporters.UnitTests.JsonWriterTests
{
    [TestFixture]
    public class ExportJournals_Should
    {
        [Test]
        [Category("FileExplorers.JsonWriter.Constructor")]
        public void Throw_WhenNoJournalsArgumentIsPassed()
        {
            // Arrange
            var mockTextWriterWrapper = new Mock<ITextWriterWrapper>();
            var mockJsonSerializerWrapper = new Mock<JsonSerializerWrapper>();
            var jsonWriter = new JsonWriter(mockTextWriterWrapper.Object, mockJsonSerializerWrapper.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => jsonWriter.ExportJournals(null));
        }
    }
}
