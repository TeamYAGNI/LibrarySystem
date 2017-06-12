using System.Collections.Generic;

using LibrarySystem.Models.Factory;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Factory.ModelsFactoryTests
{
    [TestFixture]
    public class CreatePublisher_Should
    {
        [Test]
        [Category("Models.Factory.ModelFactory.CreatePublisher")]
        public void ReturnPublisherInstance_WhenValidArgumentsPassed()
        {
            // Arrange
            string name = "Manning";
            var books = new HashSet<Book>
            {
                new Mock<Book>().Object
            };
            var journals = new HashSet<Journal>
            {
                new Mock<Journal>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var publisher = factoryUnderTest.CreatePublisher(name, books, journals);

            // Assert
            Assert.That(publisher, Is.InstanceOf<Publisher>());
        }

        [Test]
        [Category("Models.Factory.ModelFactory.CreatePublisher")]
        public void SetPublisherProperties_WhenValidArgumentsPassed()
        {
            // Arrange
            string name = "Manning";
            var books = new HashSet<Book>
            {
                new Mock<Book>().Object
            };
            var journals = new HashSet<Journal>
            {
                new Mock<Journal>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var publisher = factoryUnderTest.CreatePublisher(name, books, journals);

            // Assert
            Assert.AreSame(name, publisher.Name);
            Assert.AreSame(books, publisher.Books);
            Assert.AreSame(journals, publisher.Journals);
        }
    }
}
