// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of JsonWriter object constructor.</summary>

using System;
using LibrarySystem.FileImporters.Utils.Contracts;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.FileImporters.UnitTests.XmlReaderTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("FileImporters.XmlReader.Constructor")]
        public void InstantiateXmlReader_WhenAllArgumentsArePassed()
        {
            // Arrange
            var mockStreamReaderWrapper = new Mock<IStreamReader>();
            var mockXmlDeserializerWrapper = new Mock<IXmlDeserializer>();

            // Act
            var xmlReader = new XmlReader(mockStreamReaderWrapper.Object, mockXmlDeserializerWrapper.Object);

            // Assert
            Assert.That(xmlReader, Is.InstanceOf<XmlReader>());
        }

        [Test]
        [Category("FileImporters.XmlReader.Constructor")]
        public void ThrowArgumentNullException_WhenStreamReaderArgumentIsNull()
        {
            // Arrange
            var mockXmlDeserializerWrapper = new Mock<IXmlDeserializer>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new XmlReader(null, mockXmlDeserializerWrapper.Object));
        }

        [Test]
        [Category("FileImporters.XmlReader.Constructor")]
        public void ThrowArgumentNullException_WhenXmlDeserializerWrapperArgumentIsNull()
        {
            // Arrange
            var mockStreamReaderWrapper = new Mock<IStreamReader>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new XmlReader(mockStreamReaderWrapper.Object, null));
        }
    }
}
