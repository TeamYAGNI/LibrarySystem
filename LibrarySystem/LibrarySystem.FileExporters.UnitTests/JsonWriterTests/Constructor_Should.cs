// <copyright file="Constructor_Should.cs" company="YAGNI">
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
    public class Constructor_Should
    {
        [Test]
        [Category("FileExplorers.JsonWriter.Constructor")]
        public void InstantiateJsonWriter_WhenAllArgumentsArePassed()
        {
            // Arrange
            var mockTextWriterWrapper = new Mock<ITextWriterWrapper>();
            var mockJsonSerializerWrapper = new Mock<JsonSerializerWrapper>();

            // Act
            var jsonWriter = new JsonWriter(mockTextWriterWrapper.Object, mockJsonSerializerWrapper.Object);

            // Assert
            Assert.That(jsonWriter, Is.InstanceOf<JsonWriter>());
        }

        [Test]
        [Category("FileExplorers.JsonWriter.Constructor")]
        public void Throw_WhenNoTextStreamWriterArgumentIsPassed()
        {
            // Arrange
            var mockJsonSerializerWrapper = new Mock<JsonSerializerWrapper>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new JsonWriter(null, mockJsonSerializerWrapper.Object));
        }

        [Test]
        [Category("FileExplorers.JsonWriter.Constructor")]
        public void Throw_WhenNoJsonJournalsSerializerArgumentIsPassed()
        {
            // Arrange
            var mockTextWriterWrapper = new Mock<ITextWriterWrapper>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new JsonWriter(mockTextWriterWrapper.Object, null));
        }
    }
}
