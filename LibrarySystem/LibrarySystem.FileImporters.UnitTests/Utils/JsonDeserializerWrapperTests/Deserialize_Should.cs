// <copyright file="ExportJournals_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of JsonWriter object constructor.</summary>

using System;
using System.Collections.Generic;
using LibrarySystem.FileImporters.Utils;
using LibrarySystem.Models.DTOs.JSON;
using NUnit.Framework;
using Moq;

namespace LibrarySystem.FileImporters.UnitTests.Utils.JsonDeserializerWrapperTests
{
    [TestFixture]
    public class Deserialize_Should
    {
        //[Test]
        //[Category("FileImporters.JsonDeserializerWrapper.Deserialize")]
        //public void ReturnIEnumerableOfJournalJsonDto_WhenAllArgumentsArePassed()
        //{
        //    // Arrange
        //    var jsonDeserializerWrapper = new JsonDeserializerWrapper();

        //    // Act
        //    var result = jsonDeserializerWrapper.Deserialize("any string");

        //    // Assert
        //    Assert.IsInstanceOf<IEnumerable<JournalJsonDto>>(result);
        //}

        [Test]
        [Category("FileImporters.JsonDeserializerWrapper.Deserialize")]
        public void ThrowArgumentNullException_WhenJournalsArgumentsIsNull()
        {
            // Arrange
            var jsonSerializerWrapper = new JsonDeserializerWrapper();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => jsonSerializerWrapper.Deserialize(null));
        }

        [Test]
        [Category("FileImporters.JsonDeserializerWrapper.Deserialize")]
        public void ThrowArgumentException_WhenJournalsArgumentsIsEmpty()
        {
            // Arrange
            var jsonSerializerWrapper = new JsonDeserializerWrapper();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => jsonSerializerWrapper.Deserialize(string.Empty));
        }
    }
}
