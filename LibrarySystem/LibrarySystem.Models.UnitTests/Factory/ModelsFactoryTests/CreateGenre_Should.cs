using System.Collections.Generic;

using LibrarySystem.Models.Factory;

using Moq;
using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.Factory.ModelsFactoryTests
{
    [TestFixture]
    public class CreateGenre_Should
    {
        [Test]
        [Category("Models.Factory.ModelFactory.CreateGenre")]
        public void ReturnGenreInstance_WhenValidArgumentsPassed()
        {
            // Arrange
            string name = "Fantasy";
            var parrentGenre = new Mock<Genre>().Object;
            var childGenres = new HashSet<Genre>
            {
                new Mock<Genre>().Object
            };
            var books = new HashSet<Book>
            {
                new Mock<Book>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var genre = factoryUnderTest.CreateGenre(name, parrentGenre, childGenres, books);

            // Assert
            Assert.That(genre, Is.InstanceOf<Genre>());
        }

        [Test]
        [Category("Models.Factory.ModelFactory.CreateGenre")]
        public void SetGenreProperties_WhenValidArgumentsPassed()
        {
            // Arrange
            string name = "Fantasy";
            var parrentGenre = new Mock<Genre>().Object;
            var childGenres = new HashSet<Genre>
            {
                new Mock<Genre>().Object
            };
            var books = new HashSet<Book>
            {
                new Mock<Book>().Object
            };

            ModelsFactory factoryUnderTest = new ModelsFactory();

            // Act
            var genre = factoryUnderTest.CreateGenre(name, parrentGenre, childGenres, books);

            // Assert
            Assert.AreSame(name, genre.Name);
            Assert.AreSame(parrentGenre, genre.SuperGenre);
            Assert.AreSame(childGenres, genre.SubGenres);
            Assert.AreSame(books, genre.Books);
        }
    }
}
