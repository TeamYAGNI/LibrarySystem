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
using System.IO;

namespace LibrarySystem.FileImporters.UnitTests.JsonReaderTests
{
    [TestFixture]
    public class ImportJournals_Should
    {
        //[Test]
        //[Category("FileImporters.JsonReader.ImportJournals")]
        //public void CallGetStreamReaderMethodTwice_WhenAllArgumentsArePassed()
        //{
        //    // Arrange
        //    var mockStreamReaderWrapper = new Mock<IStreamReader>();
        //    mockStreamReaderWrapper.Setup(p => p.GetStreamReader());
        //    var mockJsonDeserializerWrapper = new Mock<IJsonDeserializer>();
        //    var journals = new Mock<IEnumerable<JournalJsonDto>>();
        //    var jsonReader = new JsonReader(mockStreamReaderWrapper.Object, mockJsonDeserializerWrapper.Object);

        //    // Act
        //    jsonReader.ImportJournals();

        //    // Assert
        //    mockStreamReaderWrapper.Verify(x => x.GetStreamReader(), Times.Once);
        //}

        //[Test]
        //[Category("FileImporters.JsonReader.ImportJournals")]
        //public void CallDeserializeMethodOnce_WhenAllArgumentsArePassed()
        //{
        //    // Arrange
        //    var mockStreamReaderWrapper = new Mock<IStreamReader>();
        //    mockStreamReaderWrapper.Setup(p => p.GetStreamReader()).Returns(new StreamReader());
        //    var mockJsonDeserializerWrapper = new Mock<IJsonDeserializer>();
        //    mockJsonDeserializerWrapper.Setup(p => p.Deserialize(It.IsAny<string>()));
        //    var jsonReader = new JsonReader(mockStreamReaderWrapper.Object, mockJsonDeserializerWrapper.Object);

        //    // Act
        //    jsonReader.ImportJournals();

        //    // Assert
        //    mockJsonDeserializerWrapper.Verify(x => x.Deserialize(It.IsAny<string>()), Times.Once());
        //}
    }
}
