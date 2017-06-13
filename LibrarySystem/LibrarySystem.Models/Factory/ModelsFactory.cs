// <copyright file = "ModelsFactory.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of ModelsFactory class.</summary>

using System;
using System.Collections.Generic;

using LibrarySystem.Models.Enumerations;
using LibrarySystem.Models.Logs;
using LibrarySystem.Models.Users;

namespace LibrarySystem.Models.Factory
{
    /// <summary>
    /// Represent a <see cref="ModelsFactory"/> class, implementator of <see cref="IModelsFactory"/> interface.
    /// </summary>
    public class ModelsFactory : IModelsFactory
    {
        /// <summary>
        /// Represent the method which provide a instance of <see cref="Address"/> class with properties given as arguments.
        /// </summary>
        /// <param name="street">Street of the <see cref="Address"/> instance.</param>
        /// <param name="streetNumber">Street number of the <see cref="Address"/> instance.</param>
        /// <param name="city">City of the <see cref="Address"/> instance.</param>
        /// <param name="clients">Initial collection of clients of the <see cref="Address"/> instance.</param>
        /// <param name="employees">Initial collection of employees of the <see cref="Address"/> instance.</param>
        /// <returns>Instance of <see cref="Address"/> class.</returns>
        public Address CreateAddress(string street, int? streetNumber, City city, ICollection<Client> clients, ICollection<Employee> employees)
        {
            Address address = new Address
            {
                Street = street,
                StreetNumber = streetNumber,
                City = city,
                Clients = clients,
                Employees = employees
            };

            return address;
        }

        /// <summary>
        /// Represent the method which provide a instance of <see cref="Author"/> class with properties given as arguments.
        /// </summary>
        /// <param name="firstName">First name of the <see cref="Author"/> instance.</param>
        /// <param name="lastName">Last name of the <see cref="Author"/> instance.</param>
        /// <param name="genderType">Gender type of the <see cref="Author"/> instance.</param>
        /// <param name="books">Initial collection of books of the <see cref="Author"/> instance.</param>
        /// <returns>Instance of <see cref="Author"/> class.</returns>
        public Author CreateAuthor(string firstName, string lastName, GenderType genderType, ICollection<Book> books)
        {
            Author author = new Author
            {
                FirstName = firstName,
                LastName = lastName,
                GenderType = genderType,
                Books = books
            };

            return author;
        }

        /// <summary>
        /// Represent the method which provide a instance of <see cref="Book"/> class with properties given as arguments.
        /// </summary>
        /// <param name="title">Title of the <see cref="Book"/> instance.</param>
        /// <param name="isbn">ISBN of the <see cref="Book"/> instance.</param>
        /// <param name="authors">Collection of authors of the <see cref="Book"/> instance.</param>
        /// <param name="genres">Collection of genres of the <see cref="Book"/> instance.</param>
        /// <param name="description">Description of the <see cref="Book"/> instance.</param>
        /// <param name="pageCount">Number of pages of the <see cref="Book"/> instance.</param>
        /// <param name="yearOfPublishing">Year of publishing of the <see cref="Book"/> instance.</param>
        /// <param name="publisher">Publisher of the <see cref="Book"/> instance.</param>
        /// <param name="quantity">Number of copies of the <see cref="Book"/> instance in the library.</param>
        /// <param name="available">Number of available copies of the <see cref="Book"/> instance in the library.</param>
        /// <param name="lendings">Initial collection of landings of the <see cref="Book"/> instance.</param>
        /// <returns>Instance of <see cref="Book"/> class.</returns>
        public Book CreateBook(
            string title,
            string isbn,
            ICollection<Author> authors,
            ICollection<Genre> genres,
            string description,
            int pageCount,
            int yearOfPublishing,
            Publisher publisher,
            int quantity,
            int available,
            ICollection<Lending> lendings)
        {
            Book book = new Book
            {
                Title = title,
                ISBN = isbn,
                Authors = authors,
                Genres = genres,
                Description = description,
                PageCount = pageCount,
                YearOfPublishing = yearOfPublishing,
                Publisher = publisher,
                Quantity = quantity,
                Available = available,
                Lendings = lendings
            };

            return book;
        }

        /// <summary>
        /// Represent the method which provide a instance of <see cref="City"/> class with properties given as arguments.
        /// </summary>
        /// <param name="name">Name of the <see cref="City"/> instance.</param>
        /// <param name="addresses">Initial collection of addresses related to the <see cref="City"/> instance.</param>
        /// <returns>Instance of <see cref="City"/> class.</returns>
        public City CreateCity(string name, ICollection<Address> addresses)
        {
            City city = new City
            {
                Name = name,
                Addresses = addresses
            };

            return city;
        }

        /// <summary>
        /// Represent the method which provide a instance of <see cref="Client"/> class with properties given as arguments.
        /// </summary>
        /// <param name="firstName">First name of the <see cref="Client"/> instance.</param>
        /// <param name="lastName">Last name of the <see cref="Client"/> instance.</param>
        /// <param name="genderType">Gender type of the <see cref="Client"/> instance.</param>
        /// <param name="pin">Personal Identification Number of the <see cref="Client"/> instance.</param>
        /// <param name="phone">Phone number of the <see cref="Client"/> instance.</param>
        /// <param name="email">Email address of the <see cref="Client"/> instance.</param>
        /// <param name="address">Address of the <see cref="Client"/> instance.</param>
        /// <param name="lendings">Initial collection of landings of the <see cref="Client"/> instance.</param>
        /// <returns>Instance of <see cref="Client"/> class.</returns>
        public Client CreateClient(
            string firstName,
            string lastName,
            GenderType genderType,
            string pin,
            string phone,
            string email,
            Address address,
            ICollection<Lending> lendings)
        {
            Client client = new Client
            {
                FirstName = firstName,
                LastName = lastName,
                GenderType = genderType,
                PIN = pin,
                Phone = phone,
                Email = email,
                Address = address,
                Lendings = lendings
            };

            return client;
        }

        /// <summary>
        /// Represent the method which provide a instance of <see cref="Employee"/> class with properties given as arguments.
        /// </summary>
        /// <param name="firstName">First name of the <see cref="Employee"/> instance.</param>
        /// <param name="lastName">Last name of the <see cref="Employee"/> instance.</param>
        /// <param name="genderType">Gender type of the <see cref="Employee"/> instance.</param>
        /// <param name="jobTitle">Job title of the <see cref="Employee"/> instance.</param>
        /// <param name="address">Address of the <see cref="Employee"/> instance.</param>
        /// <param name="manager">Manager of the <see cref="Employee"/> instance.</param>
        /// <returns>Instance of <see cref="Employee"/> class.</returns>
        public Employee CreateEmployee(string firstName, string lastName, GenderType genderType, JobTitle jobTitle, Address address, Employee manager = null)
        {
            Employee employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                GenderType = genderType,
                JobTitle = jobTitle,
                Address = address,
                ReportsTo = manager
            };

            return employee;
        }

        /// <summary>
        /// Represent the method which provide a instance of <see cref="Genre"/> class with properties given as arguments.
        /// </summary>
        /// <param name="name">Name of the <see cref="Genre"/> instance.</param>
        /// <param name="parrentGenre">Parrent genre of the <see cref="Book"/> instance.</param>
        /// <param name="childGenres">Collection of child genres of the <see cref="Genre"/> instance.</param>
        /// <param name="books">Collection of books from the <see cref="Genre"/> instance.</param>
        /// <returns>Instance of <see cref="Genre"/> class.</returns>
        public Genre CreateGenre(string name, Genre parrentGenre, ICollection<Genre> childGenres, ICollection<Book> books)
        {
            Genre genre = new Genre
            {
                Name = name,
                SuperGenre = parrentGenre,
                SubGenres = childGenres,
                Books = books
            };

            return genre;
        }

        /// <summary>
        /// Represent the method which provide a instance of <see cref="Journal"/> class with properties given as arguments.
        /// </summary>
        /// <param name="title">Title of the <see cref="Journal"/> instance.</param>
        /// <param name="impactFactor">Impact factor of the <see cref="Journal"/> instance.</param>
        /// <param name="issn">ISSN of the <see cref="Journal"/> instance.</param>
        /// <param name="issueNumber">Issue number of the <see cref="Journal"/> instance.</param>
        /// <param name="yearOfPublishing">Year of publishing of the <see cref="Journal"/> instance.</param>
        /// <param name="publisher">Publisher of the <see cref="Journal"/> instance.</param>
        /// <param name="quantity">Number of copies of the <see cref="Journal"/> instance in the library.</param>
        /// <param name="available">Number of available copies of the <see cref="Journal"/> instance in the library.</param>
        /// <param name="subjects">Collection of subjects of the <see cref="Journal"/> instance.</param>
        /// <returns>Instance of <see cref="Journal"/> class.</returns>
        public Journal CreateJournal(
            string title,
            float? impactFactor,
            string issn,
            int issueNumber,
            int yearOfPublishing,
            Publisher publisher,
            int quantity,
            int available,
            ICollection<Subject> subjects)
        {
            Journal journal = new Journal
            {
                Title = title,
                ImpactFactor = impactFactor,
                ISSN = issn,
                IssueNumber = issueNumber,
                YearOfPublishing = yearOfPublishing,
                Publisher = publisher,
                Quantity = quantity,
                Available = available,
                Subjects = subjects
            };

            return journal;
        }

        /// <summary>
        /// Represent the method which provide a instance of <see cref="Lending"/> class with properties given as arguments.
        /// </summary>
        /// <param name="book">Lended <see cref="Book"/> instance.</param>
        /// <param name="client"><see cref="Client"/> instance borrowed the copy.</param>
        /// <param name="borrowDate">Date when the copy is borrowed.</param>
        /// <param name="returnDate">Date when the copy is returned.</param>
        /// <param name="remarks">Remarks of the current <see cref="Lending"/> instance.</param>
        /// <returns>Instance of <see cref="Lending"/> class.</returns>
        public Lending CreateLending(Book book, Client client, DateTime borrowDate, DateTime? returnDate, string remarks)
        {
            Lending lending = new Lending
            {
                Book = book,
                Client = client,
                BorrоwDate = borrowDate,
                ReturnDate = returnDate,
                Remarks = remarks
            };

            return lending;
        }

        /// <summary>
        /// Represent the method which provide a instance of <see cref="Publisher"/> class with properties given as arguments.
        /// </summary>
        /// <param name="name">Name of the <see cref="Publisher"/> instance.</param>
        /// <param name="books">Collection of books of the <see cref="Publisher"/> instance.</param>
        /// <param name="journals">Collection of journals of the <see cref="Publisher"/> instance.</param>
        /// <returns>Instance of <see cref="Publisher"/> class.</returns>
        public Publisher CreatePublisher(string name, ICollection<Book> books, ICollection<Journal> journals)
        {
            Publisher publisher = new Publisher
            {
                Name = name,
                Books = books,
                Journals = journals
            };

            return publisher;
        }

        /// <summary>
        /// Represent the method which provide a instance of <see cref="Subject"/> class with properties given as arguments.
        /// </summary>
        /// <param name="name">Name of the <see cref="Subject"/> instance.</param>
        /// <param name="parrentSubject">Parent node of the <see cref="Subject"/> instance.</param>
        /// <param name="childSubjects">Initial collection of child nodes of the <see cref="Subject"/> instance.</param>
        /// <param name="journals">Initial collection of journals related to the <see cref="Subject"/> instance.</param>
        /// <returns>Instance of <see cref="Subject"/> class.</returns>
        public Subject CreateSubject(string name, Subject parrentSubject, ICollection<Subject> childSubjects, ICollection<Journal> journals)
        {
            Subject subject = new Subject
            {
                Name = name,
                SuperSubject = parrentSubject,
                SubSubjects = childSubjects,
                Journals = journals
            };

            return subject;
        }

        /// <summary>
        /// Represent the method witch provide a instance of <see cref="User"/> class with properties given as arguments.
        /// </summary>
        /// <param name="username">Username of the <see cref="User"/> instance.</param>
        /// <param name="passHash">PassHash of the <see cref="User"/> instance.</param>
        /// <param name="authKey">AuthKey of the <see cref="User"/> instance.</param>
        /// <param name="userType">Type of the <see cref="User"/> instance.</param>
        /// <param name="groups">Initial collection of groups related to the <see cref="User"/> instance.</param>
        /// <returns>Instance of <see cref="User"/> class.</returns>
        public User CreateUser(string username, string passHash, string authKey,DateTime expirationDate, UserType userType, ICollection<Group> groups)
        {
            User user = new User
            {
                Username = username,
                PassHash = passHash,
                AuthKey = authKey,
                AuthKeyExpirationDate = expirationDate,
                Type = userType,
                Groups = groups
            };

            return user;
        }

        /// <summary>
        /// Represent the method witch provide a instance of <see cref="Group"/> class with properties given as arguments.
        /// </summary>
        /// <param name="name">Name of the <see cref="Group"/> instance.</param>
        /// <param name="users">Collection of groups related to the <see cref="User"/> instance.</param>
        /// <returns>Instance of <see cref="Group"/> class.</returns>
        public Group CreateGroup(string name, ICollection<User> users)
        {
            Group group = new Group
            {
                Name = name,
                Users = users
            };

            return group;
        }

        /// <summary>
        /// Represent the method witch provide a instance of <see cref="Log"/> class with properties given as arguments.
        /// </summary>
        /// <param name="message">Message of the <see cref="Log"/> instance.</param>
        /// <param name="dateTime">DateTime when the log is logged.</param>
        /// <param name="logType">LogType of the <see cref="Log"/> instance.</param>
        /// <returns>Instance of <see cref="Log"/> class.</returns>
        public Log CreateLog(string message, DateTime dateTime, LogType logType)
        {
            Log log = new Log
            {
                Message = message,
                DateTime = dateTime,
                LogType = logType
            };

            return log;
        }

        /// <summary>
        /// Represent the method witch provide a instance of <see cref="LogType"/> class with properties given as arguments.
        /// </summary>
        /// <param name="name">Name of the <see cref="LogType"/> instance.</param>
        /// <param name="logs">Collection of logs related to the <see cref="LogType"/> instance.</param>
        /// <returns>Instance of <see cref="LogType"/> class.</returns>
        public LogType CreateLogType(string name, ICollection<Log> logs)
        {
            LogType logType = new LogType
            {
                Name = name,
                Logs = logs
            };

            return logType;
        }
    }
}
