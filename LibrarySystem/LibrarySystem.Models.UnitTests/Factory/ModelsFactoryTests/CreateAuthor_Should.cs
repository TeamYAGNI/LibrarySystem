using System.Collections.Generic;

using LibrarySystem.Models.Enumerations;
using LibrarySystem.Models.Factory;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Factory.ModelsFactoryTests
{
    [TestFixture]
    public class CreateAuthor_Should
    {
        [Test]
        [Category("Models.Factory.ModelFactory.CreateAuthor")]
        public void ReturnAuthorInstance_WhenValidArgumentsPassed()
        {
            // Arrange
            string firstName = "Alexander";
            string lastName = "Malinov";
            GenderType genderType = GenderType.Male;
            ICollection<Book> books = new HashSet<Book>
            {
                new Mock<Book>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var author = factoryUnderTest.CreateAuthor(firstName, lastName, genderType, books);

            // Assert
            Assert.That(author, Is.InstanceOf<Author>());
        }

        [Test]
        [Category("Models.Factory.ModelFactory.CreateAuthor")]
        public void SetAuthorsProperties_WhenValidArgumentsPassed()
        {
            // Arrange
            string firstName = "Alexander";
            string lastName = "Malinov";
            string fullName = "Alexander Malinov";
            GenderType genderType = GenderType.Male;
            ICollection<Book> books = new HashSet<Book>
            {
                new Mock<Book>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var author = factoryUnderTest.CreateAuthor(firstName, lastName, genderType, books);

            // Assert
            Assert.AreSame(firstName, author.FirstName);
            Assert.AreSame(lastName, author.LastName);
            Assert.AreSame(books, author.Books);

            Assert.AreEqual(genderType, author.GenderType);

            Assert.AreEqual(fullName, author.FullName);
        }
    }
}
