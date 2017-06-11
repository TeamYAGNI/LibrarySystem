// <copyright file="ExportJournals_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of JsonWriter object constructor.</summary>

using System;
using System.Collections.Generic;
using LibrarySystem.FileExporters.Utils;
using LibrarySystem.Models;
using NUnit.Framework;

namespace LibrarySystem.FileExporters.UnitTests.Utils.JsonSerializerWrapperTests
{
    [TestFixture]
    public class Serialize_Should
    {
        [Test]
        [Category("FileExplorers.XmlWriter.Constructor")]
        public void ReturnString_WhenAllArgumentsArePassed()
        {
            // Arrange
            var jsonSerializerWrapper = new JsonSerializerWrapper();
            var journals = new List<JournalDto>();

            // Act
            var result = jsonSerializerWrapper.Serialize(journals);

            // Assert
            Assert.IsInstanceOf<string>(result);
        }

        [Test]
        [Category("FileExplorers.XmlWriter.Constructor")]
        public void ThrowArgumentNullException_WhenJournalsArgumentsIsNull()
        {
            // Arrange
            var jsonSerializerWrapper = new JsonSerializerWrapper();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => jsonSerializerWrapper.Serialize(null));
        }
    }
}
