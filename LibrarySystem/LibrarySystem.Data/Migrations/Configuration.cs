// <copyright file="Configuration.cs" company="YAGNI">
// All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;

namespace LibrarySystem.Data.Migrations
{
    /// <summary>
    /// Represent a <see cref="Configuration"/> class, heir of <see cref="DbMigrationsConfiguration"/>.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<LibrarySystem.Data.LibrarySystemDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        protected override void Seed(LibrarySystemDbContext context)
        {
            Author markSeemann = context.Authors
                .Where(a => a.LastName == "Seemann")
                .FirstOrDefault() ?? new Author { FirstName = "Mark", LastName = "Seemann", GenderType = GenderType.Male };

            Author royOsherove = context.Authors
                .Where(a => a.LastName == "Osherove")
                .FirstOrDefault() ?? new Author { FirstName = "Roy", LastName = "Osherove", GenderType = GenderType.Male };

            Author martinFowler = context.Authors
                .Where(a => a.LastName == "Fowler")
                .FirstOrDefault() ?? new Author { FirstName = "Martin", LastName = "Fowler", GenderType = GenderType.Male };

            Publisher manning = context.Publishers
                .Where(p => p.Name == "Manning")
                .SingleOrDefault() ?? new Publisher { Name = "Manning" };

            Publisher addisonWesley = context.Publishers
                .Where(p => p.Name == "Addison-Wesley")
                .SingleOrDefault() ?? new Publisher { Name = "Addison-Wesley" };

            Genre software = context.Genres
                .Where(g => g.Name == "Software")
                .SingleOrDefault() ?? new Genre { Name = "Software" };

            Book theBook = context.Books
                .Where(b => b.ISBN == "9781935182504")
                .SingleOrDefault() ?? new Book
                {
                    Title = "Dependency Injection in .NET",
                    ISBN = "9781935182504",
                    Description = @"Dependency Injection in .NET introduces DI and provides a practical guide for applying it in .NET applications.
                                    The book presents the core patterns in plain C#, so you'll fully understand how DI works. Then you'll learn to integrate DI
                                    with standard Microsoft technologies like ASP.NET MVC, and to use DI frameworks like StructureMap, Castle Windsor, and Unity.
                                    By the end of the book, you'll be comfortable applying this powerful technique in your everyday .NET development.",
                    PageCount = 584,
                    YearOfPublishing = 2011,
                    Quantity = 42,
                    Available = 42,
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

            Book theArtOfUnitTesting = context.Books
                .Where(b => b.ISBN == "9781933988276")
                .SingleOrDefault() ?? new Book
                {
                    Title = "The Art of Unit Testing",
                    ISBN = "9781933988276",
                    Description = @"The Art of Unit Testing builds on top of what's already been written about this important topic. It guides you step by step
                                    from simple tests to tests that are maintainable, readable, and trustworthy. It covers advanced subjects like mocks, stubs,
                                    and frameworks such as Typemock Isolator and Rhino Mocks. And you'll learn about advanced test patterns and organization,
                                    working with legacy code and even untestable code. The book discusses tools you need when testing databases and other technologies.",
                    PageCount = 320,
                    YearOfPublishing = 2009,
                    Quantity = 37,
                    Available = 37,
                    Publisher = manning,
                    Authors = new HashSet<Author>()
                    {
                        royOsherove
                    },
                    Genres = new HashSet<Genre>()
                    {
                        software
                    }
                };

            Book patternsOfEnterpriseAppArchitecture = context.Books
                .Where(b => b.ISBN == "9780321127426")
                .SingleOrDefault() ?? new Book
                {
                    Title = "Patterns of Enterprise Application Architecture",
                    ISBN = "9780321127426",
                    Description = @"These pages are a brief overview of each of the patterns in P of EAA. They aren't intended to stand alone, but merely as a quick
                                    aide-memoire for those familiar with them, and a handy link if you want to refer to one online. In the future I may add some
                                    post-publication comments into the material here, but we'll see how that works out.",
                    PageCount = 533,
                    YearOfPublishing = 2003,
                    Quantity = 31,
                    Available = 31,
                    Publisher = addisonWesley,
                    Authors = new HashSet<Author>()
                    {
                        martinFowler
                    },
                    Genres = new HashSet<Genre>()
                    {
                        software
                    }
                };

            context.Books.AddOrUpdate(b => b.ISBN, theBook, theArtOfUnitTesting, patternsOfEnterpriseAppArchitecture);
        }
    }
}
