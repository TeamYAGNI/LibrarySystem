// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of Author entity model constructor.</summary>

using System.Collections.Generic;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.AuthorTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Models.Author.Constructor")]
        public void InstantiateAuthor_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var author = new Author();

            // Assert
            Assert.That(author, Is.InstanceOf<Author>());
        }

        [Test]
        [Category("Models.Author.Constructor")]
        public void InstantiateAuthorWithIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var author = new Author();

            // Assert
            Assert.That(author, Has.Property("Id"));
        }

        [Test]
        [Category("Models.Author.Constructor")]
        public void InstantiateAuthorWithNameProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var author = new Author();

            // Assert
            Assert.That(author, Has.Property("Name"));
        }

        [Test]
        [Category("Models.Author.Constructor")]
        public void InstantiateAuthorWithBooksProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var author = new Author();

            // Assert
            Assert.That(author, Has.Property("Books"));
        }

        [Test]
        [Category("Models.Author.Constructor")]
        public void InstantiateAuthorBookCollection_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var author = new Author();

            // Assert
            Assert.That(author.Books.Count, Is.Zero);
            Assert.That(author.Books, Is.TypeOf<HashSet<Book>>());
        }
    }
}
