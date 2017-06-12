using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Validation;
using System.Linq;

using Effort;

using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Repositories.Data;
using LibrarySystem.Repositories.Contracts.Data;

using NUnit.Framework;

namespace LibrarySystem.Repositories.UnitTests.Abstractions.RepositoryTests
{
    [TestFixture]
    public class Add_Should
    {
        private Author markSeemann;
        private Publisher manning;
        private Genre software;
        private Book theBook1;
        private Book theBook2;
        private Book theBook3;
        private DbConnection connection;
        private LibrarySystemDbContext dbContext;
        private IBookRepository repository;

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
                YearOfPublishing = 2011,
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
                YearOfPublishing = 2011,
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
                YearOfPublishing = 2011,
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
            repository = new BookRepository(dbContext);
        }

        [Test]
        [Category("Repositories.Abstractions.Add")]
        public void AddEntityToTheContext_WhenValidArgumentsArePassed()
        {

            //Arrange
            //Act
            repository.Add(theBook1);
            dbContext.SaveChanges();

            //Assert
            Assert.That(dbContext.Books.Count(), Is.EqualTo(1));
            Assert.That(dbContext.Books.Single(), Is.SameAs(theBook1));
        }

        [Test]
        [Category("Repositories.Abstractions.Add")]
        public void ThrowException_WhenInvalidArgumentIsPassed()
        {

            //Arrange
            //Act
            repository.Add(new Book());

            //Assert
            Assert.Throws<DbEntityValidationException>(() => dbContext.SaveChanges());
        }
    }
}
