// <copyright file="StartUP.cs" company="YAGNI">
// All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Repositories;

namespace LibrarySystem.ConsoleClient
{
    /// <summary>
    /// Represent the Console Client of the Library System application starting point.
    /// </summary>
    public class StartUp
    {
        /// <summary>
        /// Represent the main method called in the application live.
        /// </summary>
        public static void Main()
        {
            var dbContext = new LibrarySystemDbContext();

            var bookRepository = new BookRepository(dbContext);

            var uow = new LibraryUnitOfWork(dbContext, bookRepository);

            var book = uow.Books.Get(1);
            Console.WriteLine("Book id SHOULD be 1 => " + book.Id);

            var allBooks = uow.Books.GetAll();
            Console.WriteLine("All books count SHOULD be 3 => " + allBooks.Count());
            Console.WriteLine("Printing All Book Details");
            foreach (var b in allBooks)
            {
                Console.WriteLine("Book Title => " + b.Title);
                Console.WriteLine("Book Publisher =>" + b.Publisher.Name);
                foreach (var a in b.Authors)
                {
                    Console.WriteLine("Book Authors => " + a.FullName);
                }
            }
            Console.WriteLine("Printed All Book Details");

            var numberOfAvailableCopies = uow.Books.GetAvailableBookCopiesByBookTitle("Dependency Injection in .NET");
            Console.WriteLine("numberOfAvailableCopies SHOULD Equal 42 => " + numberOfAvailableCopies);

            var bookByMarkSeeman = uow.Books.GetBooksByAuthor("Mark", "Seemann");
            foreach (var b in bookByMarkSeeman)
            {
                Console.WriteLine("Book Title => " + b.Title);
                Console.WriteLine("Book Publisher =>" + b.Publisher.Name);
                foreach (var a in b.Authors)
                {
                    Console.WriteLine("Book Author SHOULD be Mark Seeman => " + a.FullName);
                }
            }

            var booksPublishedByManning = uow.Books.GetBooksByPublisher("Manning");
            foreach (var b in booksPublishedByManning)
            {
                Console.WriteLine("Book Title => " + b.Title);
                Console.WriteLine("Book Publisher SHOULD be Manning =>" + b.Publisher.Name);
                foreach (var a in b.Authors)
                {
                    Console.WriteLine("Book Authors => " + a.FullName);
                }
            }

            var bookByIsbn = uow.Books.Find(b => b.ISBN == "9781935182504");
            Console.WriteLine("Book ISBN Should be 9781935182504 => " + bookByIsbn.First().ISBN);

            Author markSeemann = new Author { FirstName = "Mark", LastName = "Seemann", GenderType = GenderType.Male };
            Publisher manning = new Publisher { Name = "Manning1" };
            Genre software = new Genre { Name = "Software1" };
            Book theBook1 = new Book
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

            Book theBook2 = new Book
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

            Book theBook3 = new Book
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

            uow.Books.Add(theBook1);

            uow.Books.AddRange(new List<Book>()
            {
                theBook2,
                theBook3
            });

            uow.Commit();
            uow.Dispose();

            try
            {
                uow.Books.Get(1);
            }
            catch (Exception e)
            {
                Console.WriteLine("It was disposed");
                Console.WriteLine(e.Message);
                Console.WriteLine("It was disposed");
            }

            ////Will not be able to do it due to CascadeDeleting -> LibrarySystemDbContext.cs line 103,104
            //var uow2 = new LibraryUnitOfWork(dbContext, bookRepository);

            //uow2.Books.Remove(uow2.Books.Get(4));
            //uow2.Books.RemoveRange(uow2.Books.GetBooksByPublisher("Manning1"));

            //uow2.Commit();
            //uow2.Dispose();
        }
    }
}
