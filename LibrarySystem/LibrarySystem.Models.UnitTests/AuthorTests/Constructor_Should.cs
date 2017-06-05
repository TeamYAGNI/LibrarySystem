// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of Author entity model constructor.</summary>

using System.Collections.Generic;
using LibrarySystem.Models.Enumerations;
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
        public void InstantiateAuthorWithFirstNameProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var author = new Author();

            // Assert
            Assert.That(author, Has.Property("FirstName"));
        }

        [Test]
        [Category("Models.Author.Constructor")]
        public void InstantiateAuthorWithLastNameProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var author = new Author();

            // Assert
            Assert.That(author, Has.Property("LastName"));
        }

        [Test]
        [Category("Models.Author.Constructor")]
        public void InstantiateAuthorWithFullNameProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var author = new Author();

            // Assert
            Assert.That(author, Has.Property("FullName"));
        }

        [Test]
        [Category("Models.Author.Constructor")]
        public void ReturnStringJoiningFirstAndLastName_WhenInvoked()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Doe";

            string expectedFullName = "John Doe";

            var author = new Author();
            author.FirstName = firstName;
            author.LastName = lastName;

            // Act
            // Assert
            Assert.AreEqual(expectedFullName, author.FullName);
        }

        [Test]
        [Category("Models.Author.Constructor")]
        public void InstantiateAuthorWithGenderTypeProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var author = new Author();

            // Assert
            Assert.That(author, Has.Property("GenderType"));
            Assert.That(author.GenderType, Is.EqualTo(GenderType.NotSpecified));
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
