using System.Collections.Generic;
using System.Data.Common;
using Effort;
using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Repositories.Contracts;
using NUnit.Framework;

namespace LibrarySystem.Repositories.UnitTests.BookRepositoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        [Category("Repositories.BookRepository.Constructor")]
        public void InstantiateInstanceOfBookRepository_WhenValidArgumentsArePassed()
        {
            //Arrange
            var connection = DbConnectionFactory.CreateTransient();
            var dbContext = new LibrarySystemDbContext(connection);
            var repository = new BookRepository(dbContext);

            //Act
            //Assert
            Assert.That(repository, Is.InstanceOf<BookRepository>());
        }
    }
}
