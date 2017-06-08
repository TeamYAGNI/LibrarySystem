using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Effort;
using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Repositories.Contracts;
using NUnit.Framework;

namespace LibrarySystem.Repositories.UnitTests.BookRepositoryTests
{
    [TestFixture]
    public class GetBooksByPublisherAndAuthor_Should
    {
        private Author markSeemann;
        private Author notMarkSeemann;
        private Publisher manning;
        private Publisher notManning;
        private Genre software;
        private Book theBook1;
        private Book theBook2;
        private Book theBook3;
        private DbConnection connection;
        private LibrarySystemDbContext dbContext;
        private IBookRepository bookRepository;

        [OneTimeSetUp]
        public void InitVariables()
        {
            markSeemann = new Author { FirstName = "Mark", LastName = "Seemann", GenderType = GenderType.Male };
            notMarkSeemann = new Author { FirstName = "notMark", LastName = "notSeemann", GenderType = GenderType.Male };
            manning = new Publisher { Name = "Manning" };
            notManning = new Publisher { Name = "NotManning" };
            software = new Genre { Name = "Software2" };
            theBook1 = new Book
            {
                Title = "test1Dependency Injection in .NET",
                ISBN = "9781935182501",
                Description = @"Dependency Injection in .NET introduces DI and provides a practical guide for applying it in .NET applications.
                                The book presents the core patterns in plain C#, so you'll fully understand how DI works. Then you'll learn to integrate DI
                                with standard Microsoft technologies like ASP.NET MVC, and to use DI frameworks like StructureMap, Castle Windsor, and Unity.
                                By the end of the book, you'll be comfortable applying this powerful technique in your everyday .NET development.",
                PageCount = 584,
                YearOfPublishing = 2010,
                Quantity = 41,
                Available = 41,
                Publisher = manning,
                Authors = new HashSet<Author>()
                {
                    markSeemann
                },
                Genres = new HashSet<Genre>()
                {
                    software
                }
            };

            theBook2 = new Book
            {
                Title = "test2Dependency Injection in .NET",
                ISBN = "9781935182502",
                Description = @"Dependency Injection in .NET introduces DI and provides a practical guide for applying it in .NET applications.
                                The book presents the core patterns in plain C#, so you'll fully understand how DI works. Then you'll learn to integrate DI
                                with standard Microsoft technologies like ASP.NET MVC, and to use DI frameworks like StructureMap, Castle Windsor, and Unity.
                                By the end of the book, you'll be comfortable applying this powerful technique in your everyday .NET development.",
                PageCount = 584,
                YearOfPublishing = 2009,
                Quantity = 422,
                Available = 422,
                Publisher = manning,
                Authors = new HashSet<Author>()
                {
                    notMarkSeemann
                },
                Genres = new HashSet<Genre>()
                {
                    software
                }
            };

            theBook3 = new Book
            {
                Title = "test3Dependency Injection in .NET",
                ISBN = "9781935182503",
                Description = @"Dependency Injection in .NET introduces DI and provides a practical guide for applying it in .NET applications.
                                The book presents the core patterns in plain C#, so you'll fully understand how DI works. Then you'll learn to integrate DI
                                with standard Microsoft technologies like ASP.NET MVC, and to use DI frameworks like StructureMap, Castle Windsor, and Unity.
                                By the end of the book, you'll be comfortable applying this powerful technique in your everyday .NET development.",
                PageCount = 584,
                YearOfPublishing = 2008,
                Quantity = 433,
                Available = 433,
                Publisher = notManning,
                Authors = new HashSet<Author>()
                {
                    markSeemann
                },
                Genres = new HashSet<Genre>()
                {
                    software
                }
            };
        }

        [SetUp]
        public void InitContext()
        {
            connection = DbConnectionFactory.CreateTransient();
            dbContext = new LibrarySystemDbContext(connection);
            dbContext.Books.Add(theBook1);
            dbContext.Books.Add(theBook2);
            dbContext.Books.Add(theBook3);
            dbContext.SaveChanges();
            bookRepository = new BookRepository(dbContext);
        }

        [Test]
        [Category("Repositories.BookRepository.GetBooksByPublisherAndAuthor")]
        public void ReturnAllBooksByAuthorAndPublisher_WhenValidArgumentsArePassed()
        {
            //Arrange
            //Act
            var resultBooks = bookRepository.GetBooksByPublisherAndAuthor("Manning", "Mark", "Seemann");
            //Assert
            Assert.That(resultBooks.Count(), Is.EqualTo(1));
            CollectionAssert.AreEqual(resultBooks, new List<Book>()
            {
                theBook1,
            });
        }

        [Test]
        [Category("Repositories.BookRepository.GetBooksByPublisherAndAuthor")]
        public void ReturnEmptyList_WhenValidPublisherButInvalidAuthorIsPassed()
        {
            //Arrange
            //Act
            var resultBooks = bookRepository.GetBooksByPublisherAndAuthor("Manning", "Mak", "Smnn");
            //Assert
            Assert.That(resultBooks, Is.Empty);
            Assert.That(resultBooks.Count(), Is.Zero);
        }

        [Test]
        [Category("Repositories.BookRepository.GetBooksByPublisherAndAuthor")]
        public void ReturnEmptyList_WhenValidAuthorButInvalidPublisherIsPassed()
        {
            //Arrange
            //Act
            var resultBooks = bookRepository.GetBooksByPublisherAndAuthor("Mnning", "Mark", "Seemann");
            //Assert
            Assert.That(resultBooks, Is.Empty);
            Assert.That(resultBooks.Count(), Is.Zero);
        }

        [Test]
        [Category("Repositories.BookRepository.GetBooksByPublisherAndAuthor")]
        public void ReturnEmptyList_WhenThePassedArgumentsAreInvalid()
        {
            //Arrange
            //Act
            var resultBooks = bookRepository.GetBooksByPublisherAndAuthor("Mannng", "Mrk", "Sann");
            //Assert
            Assert.That(resultBooks, Is.Empty);
            Assert.That(resultBooks.Count(), Is.Zero);
        }
    }
}
