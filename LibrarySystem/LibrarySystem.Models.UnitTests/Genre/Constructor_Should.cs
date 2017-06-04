// <copyright file="Constructor_Should.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds unit tests of Journal entity model constructor.</summary>
 
 using System.Collections.Generic;
 using NUnit.Framework;

namespace LibrarySystem.Models.UnitTests.GenreTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Models.Genre.Constructor")]
        public void InstantiateGenre_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var genre = new Genre();

            //Assert
            Assert.That(genre, Is.InstanceOf<Genre>());
        }

        [Test]
        [Category("Models.Genre.Constructor")]
        public void InstantiateGenreWithIdProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var genre = new Genre();

            //Assert
            Assert.That(genre, Has.Property("Id"));
        }

        [Test]
        [Category("Models.Genre.Constructor")]
        public void InstantiateGenreWithNameProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var genre = new Genre();

            //Assert
            Assert.That(genre, Has.Property("Name"));
        }

        [Test]
        [Category("Models.Genre.Constructor")]
        public void InstantiateGenreWithSuperGenreIdProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var genre = new Genre();

            //Assert
            Assert.That(genre, Has.Property("SuperGenreId"));
        }

        [Test]
        [Category("Models.Genre.Constructor")]
        public void InstantiateGenreWithSuperGenreProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var genre = new Genre();

            //Assert
            Assert.That(genre, Has.Property("SuperGenre"));
        }

        [Test]
        [Category("Models.Genre.Constructor")]
        public void InstantiateGenreWithSubGenresProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var genre = new Genre();

            //Assert
            Assert.That(genre, Has.Property("SubGenres"));
        }

        [Test]
        [Category("Models.Genre.Constructor")]
        public void InstantiateSubGenresCollection_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var genre = new Genre();

            //Assert
            Assert.That(genre.SubGenres.Count, Is.Zero);
            Assert.That(genre.SubGenres, Is.TypeOf<HashSet<Genre>>());
        }

        [Test]
        [Category("Models.Genre.Constructor")]
        public void InstantiateGenreWithBooksProperty_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var genre = new Genre();

            //Assert
            Assert.That(genre, Has.Property("Books"));
        }

        [Test]
        [Category("Models.Genre.Constructor")]
        public void InstantiateBooksCollection_WhenNoArgumentsArePassed()
        {
            //Arrange
            //Act
            var genre = new Genre();

            //Assert
            Assert.That(genre.Books.Count, Is.Zero);
            Assert.That(genre.Books, Is.TypeOf<HashSet<Book>>());
        }
    }
}
