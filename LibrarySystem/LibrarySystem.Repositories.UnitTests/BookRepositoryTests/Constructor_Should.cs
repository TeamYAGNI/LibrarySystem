﻿using Effort;

using LibrarySystem.Data;
using LibrarySystem.Repositories.Data;

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
            var bookRepository = new BookRepository(dbContext);

            //Act
            //Assert
            Assert.That(bookRepository, Is.InstanceOf<BookRepository>());
        }
    }
}
