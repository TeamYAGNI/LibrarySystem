// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of JsonWriter object constructor.</summary>

using System;
using NUnit.Framework;
using LibrarySystem.FileExporters.Utils;

namespace LibrarySystem.FileExporters.UnitTests.Utils.TextWriterWrapperTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("FileExplorers.JsonWriter.Constructor")]
        public void ThrowArgumentException_WhenDirectoryArgumentIsNull()
        {
            // AAA
            Assert.Throws<ArgumentException>(() => new TextWriterWrapper(null, "file"));
        }

        [Test]
        [Category("FileExplorers.JsonWriter.Constructor")]
        public void ThrowArgumentException_WhenDirectoryArgumentIsEmpty()
        {
            // AAA
            Assert.Throws<ArgumentException>(() => new TextWriterWrapper("", "file"));
        }
    }
}
