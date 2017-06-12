// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of Book entity model constructor.</summary>

using System.Collections.Generic;

using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.BookTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Models.Book.Constructor")]
        public void InstantiateBook_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var book = new Book();

            // Assert
            Assert.That(book, Is.InstanceOf<Book>());
        }

        [Test]
        [Category("Models.Book.Constructor")]
        public void InstantiateBookWithIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var book = new Book();

            // Assert
            Assert.That(book, Has.Property("Id"));
        }

        [Test]
        [Category("Models.Book.Constructor")]
        public void InstantiateBookWithTitleProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var book = new Book();

            // Assert
            Assert.That(book, Has.Property("Title"));
        }

        [Test]
        [Category("Models.Book.Constructor")]
        public void InstantiateBookWithISBNProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var book = new Book();

            // Assert
            Assert.That(book, Has.Property("ISBN"));
        }

        [Test]
        [Category("Models.Book.Constructor")]
        public void InstantiateBookWithAuthorsProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var book = new Book();

            // Assert
            Assert.That(book, Has.Property("Authors"));
        }

        [Test]
        [Category("Models.Book.Constructor")]
        public void InstantiateBookWithGenresProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var book = new Book();

            // Assert
            Assert.That(book, Has.Property("Genres"));
        }

        [Test]
        [Category("Models.Book.Constructor")]
        public void InstantiateBookWithDescriptionProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var book = new Book();

            // Assert
            Assert.That(book, Has.Property("Description"));
        }

        [Test]
        [Category("Models.Book.Constructor")]
        public void InstantiateBookWithPageCountProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var book = new Book();

            // Assert
            Assert.That(book, Has.Property("PageCount"));
        }

        [Test]
        [Category("Models.Book.Constructor")]
        public void InstantiateBookWithYearOfPublishingProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var book = new Book();

            // Assert
            Assert.That(book, Has.Property("YearOfPublishing"));
        }

        [Test]
        [Category("Models.Book.Constructor")]
        public void InstantiateBookWithPublisherIdProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var book = new Book();

            // Assert
            Assert.That(book, Has.Property("PublisherId"));
        }

        [Test]
        [Category("Models.Book.Constructor")]
        public void InstantiateBookWithPublisherProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var book = new Book();

            // Assert
            Assert.That(book, Has.Property("Publisher"));
        }

        [Test]
        [Category("Models.Book.Constructor")]
        public void InstantiateBookWithQuantityProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var book = new Book();

            // Assert
            Assert.That(book, Has.Property("Quantity"));
        }

        [Test]
        [Category("Models.Book.Constructor")]
        public void InstantiateBookWithAvailableProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var book = new Book();

            // Assert
            Assert.That(book, Has.Property("Available"));
        }

        [Test]
        [Category("Models.Book.Constructor")]
        public void InstantiateBookWithLendingsProperty_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var book = new Book();

            // Assert
            Assert.That(book, Has.Property("Lendings"));
        }

        [Test]
        [Category("Models.Book.Constructor")]
        public void InstantiateAuthorsCollection_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var book = new Book();

            // Assert
            Assert.That(book.Authors.Count, Is.Zero);
            Assert.That(book.Authors, Is.TypeOf<HashSet<Author>>());
        }

        [Test]
        [Category("Models.Book.Constructor")]
        public void InstantiateGenresCollection_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var book = new Book();

            // Assert
            Assert.That(book.Genres.Count, Is.Zero);
            Assert.That(book.Genres, Is.TypeOf<HashSet<Genre>>());
        }

        [Test]
        [Category("Models.Book.Constructor")]
        public void InstantiateLendingsCollection_WhenNoArgumentsArePassed()
        {
            // Arrange
            // Act
            var book = new Book();

            // Assert
            Assert.That(book.Lendings.Count, Is.Zero);
            Assert.That(book.Lendings, Is.TypeOf<HashSet<Lending>>());
        }
    }
}