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
    public class GetBooksByPublisher_Should
    {
        private Author markSeemann;
        private Publisher manning;
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
            manning = new Publisher { Name = "Manning2" };
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
                    markSeemann
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
        }

        [SetUp]
        public void InitContext()
        {
            connection = DbConnectionFactory.CreateTransient();
            dbContext = new LibrarySystemDbContext(connection);
            bookRepository = new BookRepository(dbContext);
        }

        [Test] [Category("Repositories.BookRepository.GetBooksByPublisher")] public void ReturnAllBooksByPublisher_WhenValidArgumentsArePassed()
        {
            //Arrange
            dbContext.Books.Add(theBook1);
            dbContext.Books.Add(theBook2);
            dbContext.Books.Add(theBook3);
            dbContext.SaveChanges();
            //Act
            var resultBooks = bookRepository.GetBooksByPublisher("Manning2");
            //Assert
            Assert.That(resultBooks.Count(), Is.EqualTo(3));
            CollectionAssert.AreEqual(resultBooks, new List<Book>()
            {
                theBook1,
                theBook2,
                theBook3
            });
        }

        [Test]
        [Category("Repositories.BookRepository.GetBooksByPublisher")]
        public void ReturnEmptyList_WhenPublisherHasNoBooks()
        {
            //Arrange
            //Act
            var resultBooks = bookRepository.GetBooksByPublisher("Manning2");
            //Assert
            Assert.That(resultBooks, Is.Empty);
            Assert.That(resultBooks.Count(), Is.Zero);
        }

        [Test]
        [Category("Repositories.BookRepository.GetBooksByPublisher")]
        public void ReturnEmptyList_WhenThePassedPublisherIsNonExistent()
        {
            //Arrange
            dbContext.Books.Add(theBook1);
            dbContext.Books.Add(theBook2);
            dbContext.Books.Add(theBook3);
            dbContext.SaveChanges();
            //Act
            var resultBooks = bookRepository.GetBooksByPublisher("Mannng2");
            //Assert
            Assert.That(resultBooks, Is.Empty);
            Assert.That(resultBooks.Count(), Is.Zero);
        }
    }
}
