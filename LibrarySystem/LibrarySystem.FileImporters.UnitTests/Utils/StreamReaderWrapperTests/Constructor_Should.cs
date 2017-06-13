// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of JsonWriter object constructor.</summary>

using System;
using LibrarySystem.FileImporters.Utils;
using NUnit.Framework;

namespace LibrarySystem.FileImporters.UnitTests.Utils.StreamReaderWrapperTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("FileImporters.StreamReaderWrapper.Constructor")]
        public void ThrowArgumentNullException_WhenDirectoryArgumentIsNull()
        {
            // AAA
            Assert.Throws<ArgumentNullException>(() => new StreamReaderWrapper(null));
        }

        [Test]
        [Category("FileImporters.StreamReaderWrapper.Constructor")]
        public void ThrowArgumentException_WhenDirectoryArgumentIsEmpty()
        {
            // AAA
            Assert.Throws<ArgumentException>(() => new StreamReaderWrapper(string.Empty));
        }
    }
}
