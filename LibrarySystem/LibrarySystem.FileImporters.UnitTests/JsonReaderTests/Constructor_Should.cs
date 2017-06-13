// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of JsonReader object constructor.</summary>

using System;
using LibrarySystem.FileImporters;
using LibrarySystem.FileImporters.Utils.Contracts;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.FileImporters.UnitTests.JsonReaderTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("FileImporters.JsonReader.Constructor")]
        public void InstantiateJsonReader_WhenAllArgumentsArePassed()
        {
            // Arrange
            var mockStreamReaderWrapper = new Mock<IStreamReader>();
            var mockJsonDeserializerWrapper = new Mock<IJsonDeserializer>();

            // Act
            var jsonReader = new JsonReader(mockStreamReaderWrapper.Object, mockJsonDeserializerWrapper.Object);

            // Assert
            Assert.That(jsonReader, Is.InstanceOf<JsonReader>());
        }

        [Test]
        [Category("FileImporters.JsonReader.Constructor")]
        public void ThrowArgumenNullException_WhenStreamReaderArgumentIsNull()
        {
            // Arrange
            var mockJsonDeserializerWrapper = new Mock<IJsonDeserializer>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new JsonReader(null, mockJsonDeserializerWrapper.Object));
        }

        [Test]
        [Category("FileImporters.JsonReader.Constructor")]
        public void ThrowArgumentNullException_WhenJsonJournalsSerializerArgumentIsNull()
        {
            // Arrange
            var mockStreamReaderWrapper = new Mock<IStreamReader>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new JsonReader(mockStreamReaderWrapper.Object, null));
        }
    }
}
