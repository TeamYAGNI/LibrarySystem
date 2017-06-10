﻿using System;
using System.Collections.Generic;
using System.Linq;
using LibrarySystem.Data;
using LibrarySystem.Repositories.Contracts;
using LibrarySystem.Models;
using LibrarySystem.Repositories.Abstractions;

namespace LibrarySystem.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LibrarySystemDbContext context) : base(context)
        {
        }

        private LibrarySystemDbContext LibraryDbContext
        {
            get
            {
                return this.Context as LibrarySystemDbContext;
            }
        }

        public Book GetMostRecentBookByAuthor(string authorFirstName, string authorLastName)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.Authors
                    .Any(a => a.FirstName == authorFirstName && a.LastName == authorLastName))
                .OrderByDescending(b => b.YearOfPublishing)
                .FirstOrDefault();
        }

        public Book GetMostRecentBookByPublisher(string publisherName)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.Publisher.Name == publisherName)
                .OrderByDescending(b => b.YearOfPublishing)
                .FirstOrDefault();
        }

        public IEnumerable<Book> GetBooksByPublisher(string publisherName)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.Publisher.Name == publisherName)
                .ToList();
        }

        public IEnumerable<Book> GetBooksByAuthor(string authorFirstName, string authorLastName)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.Authors
                    .Any(a => a.FirstName == authorFirstName && a.LastName == authorLastName))
                .ToList();
        }

        public IEnumerable<Book> GetBooksByPublisherAndAuthor(string publisherName, string authorFirstName, string authorLastName)
        {
            return this.LibraryDbContext.Books.Where(
                    b => b.Publisher.Name == publisherName &&
                         b.Authors.Any(a => a.FirstName == authorFirstName && a.LastName == authorLastName))
                .ToList();
        }   

        public Book GetBookByISBN(string ISBN)
        {
            return this.LibraryDbContext.Books.FirstOrDefault(b => b.ISBN == ISBN);
        }

        public string GetBookDescriptionByISBN(string ISBN)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.ISBN == ISBN)
                .Select(b => b.Description)
                .FirstOrDefault();
        }

        public IEnumerable<Book> GetBooksByTitle(string title)
        {
            return this.Find(b => b.Title == title);
        }

        public IEnumerable<Book> GetAllBooksInUse()
        {
            return this.Find(b => b.Quantity != b.Available);
        }

        public int GetInitialQuantityByISBN(string ISBN)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.ISBN == ISBN)
                .Select(b => b.Quantity)
                .FirstOrDefault();
        }

        public int GetAvailableQuantityByISBN(string ISBN)
        {
            return this.LibraryDbContext.Books
                .Where(b => b.ISBN == ISBN)
                .Select(b => b.Available)
                .FirstOrDefault();
        }

        public IEnumerable<Book> GetAllLendedBooks()
        {
            return this.LibraryDbContext.Books.Where(b => b.Lendings.Any(l => l.BookId == b.Id)).ToList();
        }

        public IEnumerable<Book> GetAllBooksLendedBeforeMoreThanAMonth()
        {
            return this.LibraryDbContext.Books.Where(
                b => b.Lendings.Any(l => l.BorrоwDate.AddMonths(1) < DateTime.Today)).ToList();
        }
    }
}