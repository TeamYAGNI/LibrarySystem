using System.Collections.Generic;

using LibrarySystem.Models.Factory;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Factory.ModelsFactoryTests
{
    [TestFixture]
    public class CreateBook_Should
    {
        [Test]
        [Category("Models.Factory.ModelFactory.CreateBook")]
        public void ReturnBookInstance_WhenValidArgumentsPassed()
        {
            // Arrange
            string title = "Dependency Injection in .NET";
            string isbn = "9781935182504";
            var authors = new HashSet<Author>
            {
                new Mock<Author>().Object
            };
            var genres = new HashSet<Genre>
            {
                new Mock<Genre>().Object
            };
            string description = "Some description";
            int pageCount = 584;
            int yearOfPublishing = 2011;
            Publisher publisher = new Mock<Publisher>().Object;
            int quantity = 12;
            int available = 9;
            var lendings = new HashSet<Lending>
            {
                new Mock<Lending>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var book = factoryUnderTest.CreateBook(title, isbn, authors, genres, description, pageCount, yearOfPublishing, publisher, quantity, available, lendings);

            // Assert
            Assert.That(book, Is.InstanceOf<Book>());
        }

        [Test]
        [Category("Models.Factory.ModelFactory.CreateBook")]
        public void SetBookProperties_WhenValidArgumentsPassed()
        {
            // Arrange
            string title = "Dependency Injection in .NET";
            string isbn = "9781935182504";
            var authors = new HashSet<Author>
            {
                new Mock<Author>().Object
            };
            var genres = new HashSet<Genre>
            {
                new Mock<Genre>().Object
            };
            string description = "Some description";
            int pageCount = 584;
            int yearOfPublishing = 2011;
            Publisher publisher = new Mock<Publisher>().Object;
            int quantity = 12;
            int available = 9;
            var lendings = new HashSet<Lending>
            {
                new Mock<Lending>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var book = factoryUnderTest.CreateBook(title, isbn, authors, genres, description, pageCount, yearOfPublishing, publisher, quantity, available, lendings);

            // Assert
            Assert.AreSame(title, book.Title);
            Assert.AreSame(isbn, book.ISBN);
            Assert.AreSame(authors, book.Authors);
            Assert.AreSame(genres, book.Genres);
            Assert.AreSame(description, book.Description);
            Assert.AreSame(lendings, book.Lendings);
            Assert.AreSame(publisher, book.Publisher);

            Assert.AreEqual(pageCount, book.PageCount);
            Assert.AreEqual(yearOfPublishing, book.YearOfPublishing);
            Assert.AreEqual(quantity, book.Quantity);
            Assert.AreEqual(available, book.Available);
        }
    }
}
