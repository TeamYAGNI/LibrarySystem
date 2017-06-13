// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of JsonWriter object constructor.</summary>

using System;
using LibrarySystem.FileExporters.Utils.Contracts;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.FileExporters.UnitTests.XmlWriterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("FileExplorers.XmlWriter.Constructor")]
        public void InstantiateXmlWriter_WhenAllArgumentsArePassed()
        {
            // Arrange
            var mockTextWriterWrapper = new Mock<ITextWriter>();
            var mockXmlSerializerWrapper = new Mock<IXmlSerializer>();

            // Act
            var xmlWriter = new XmlWriter(mockTextWriterWrapper.Object, mockXmlSerializerWrapper.Object);

            // Assert
            Assert.That(xmlWriter, Is.InstanceOf<XmlWriter>());
        }

        [Test]
        [Category("FileExplorers.XmlWriter.Constructor")]
        public void ThrowArgumentNullException_WhenTextStreamWriterArgumentIsNull()
        {
            // Arrange
            var mockXmlSerializerWrapper = new Mock<IXmlSerializer>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new XmlWriter(null, mockXmlSerializerWrapper.Object));
        }

        [Test]
        [Category("FileExplorers.XmlWriter.Constructor")]
        public void ThrowArgumentNullException_WhenJsonJournalsSerializerArgumentIsNull()
        {
            // Arrange
            var mockTextWriterWrapper = new Mock<ITextWriter>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new JsonWriter(mockTextWriterWrapper.Object, null));
        }
    }
}
