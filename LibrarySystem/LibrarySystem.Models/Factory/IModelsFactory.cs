// <copyright file = "IModelsFactory.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of IModelsFactory implementators.</summary>

using System;
using System.Collections.Generic;

using LibrarySystem.Models.Enumerations;
using LibrarySystem.Models.Users;
using LibrarySystem.Models.Logs;

namespace LibrarySystem.Models.Factory
{
    /// <summary>
    /// Represent a <see cref="IModelsFactory"/> interface.
    /// </summary>
    public interface IModelsFactory
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
        Address CreateAddress(string street, int? streetNumber, City city, ICollection<Client> clients, ICollection<Employee> employees);

        /// <summary>
        /// Represent the method which provide a instance of <see cref="Author"/> class with properties given as arguments.
        /// </summary>
        /// <param name="firstName">First name of the <see cref="Author"/> instance.</param>
        /// <param name="lastName">Last name of the <see cref="Author"/> instance.</param>
        /// <param name="genderType">Gender type of the <see cref="Author"/> instance.</param>
        /// <param name="books">Initial collection of books of the <see cref="Author"/> instance.</param>
        /// <returns>Instance of <see cref="Author"/> class.</returns>
        Author CreateAuthor(string firstName, string lastName, GenderType genderType, ICollection<Book> books);

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
        Book CreateBook(
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
            ICollection<Lending> lendings);

        /// <summary>
        /// Represent the method which provide a instance of <see cref="City"/> class with properties given as arguments.
        /// </summary>
        /// <param name="name">Name of the <see cref="City"/> instance.</param>
        /// <param name="addresses">Initial collection of addresses related to the <see cref="City"/> instance.</param>
        /// <returns>Instance of <see cref="City"/> class.</returns>
        City CreateCity(string name, ICollection<Address> addresses);

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
        Client CreateClient(
            string firstName,
            string lastName,
            GenderType genderType,
            string pin,
            string phone,
            string email,
            Address address,
            ICollection<Lending> lendings);

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
        Employee CreateEmployee(string firstName, string lastName, GenderType genderType, JobTitle jobTitle, Address address, Employee manager);

        /// <summary>
        /// Represent the method which provide a instance of <see cref="Genre"/> class with properties given as arguments.
        /// </summary>
        /// <param name="name">Name of the <see cref="Genre"/> instance.</param>
        /// <param name="parrentGenre">Parrent genre of the <see cref="Book"/> instance.</param>
        /// <param name="childGenres">Collection of child genres of the <see cref="Genre"/> instance.</param>
        /// <param name="books">Collection of books from the <see cref="Genre"/> instance.</param>
        /// <returns>Instance of <see cref="Genre"/> class.</returns>
        Genre CreateGenre(string name, Genre parrentGenre, ICollection<Genre> childGenres, ICollection<Book> books);

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
        Journal CreateJournal(
            string title,
            float? impactFactor,
            string issn,
            int issueNumber,
            int yearOfPublishing,
            Publisher publisher,
            int quantity,
            int available,
            ICollection<Subject> subjects);

        /// <summary>
        /// Represent the method which provide a instance of <see cref="Lending"/> class with properties given as arguments.
        /// </summary>
        /// <param name="book">Lended <see cref="Book"/> instance.</param>
        /// <param name="client"><see cref="Client"/> instance borrowed the copy.</param>
        /// <param name="borrowDate">Date when the copy is borrowed.</param>
        /// <param name="returnDate">Date when the copy is returned.</param>
        /// <param name="remarks">Remarks of the current <see cref="Lending"/> instance.</param>
        /// <returns>Instance of <see cref="Lending"/> class.</returns>
        Lending CreateLending(Book book, Client client, DateTime borrowDate, DateTime? returnDate, string remarks);

        /// <summary>
        /// Represent the method which provide a instance of <see cref="Publisher"/> class with properties given as arguments.
        /// </summary>
        /// <param name="name">Name of the <see cref="Publisher"/> instance.</param>
        /// <param name="books">Collection of books of the <see cref="Publisher"/> instance.</param>
        /// <param name="journals">Collection of journals of the <see cref="Publisher"/> instance.</param>
        /// <returns>Instance of <see cref="Publisher"/> class.</returns>
        Publisher CreatePublisher(string name, ICollection<Book> books, ICollection<Journal> journals);

        /// <summary>
        /// Represent the method which provide a instance of <see cref="Subject"/> class with properties given as arguments.
        /// </summary>
        /// <param name="name">Name of the <see cref="Subject"/> instance.</param>
        /// <param name="parrentSubject">Parent node of the <see cref="Subject"/> instance.</param>
        /// <param name="childSubjects">Initial collection of child nodes of the <see cref="Subject"/> instance.</param>
        /// <param name="journals">Initial collection of journals related to the <see cref="Subject"/> instance.</param>
        /// <returns>Instance of <see cref="Subject"/> class.</returns>
        Subject CreateSubject(string name, Subject parrentSubject, ICollection<Subject> childSubjects, ICollection<Journal> journals);

        /// <summary>
        /// Represent the method witch provide a instance of <see cref="User"/> class with properties given as arguments.
        /// </summary>
        /// <param name="username">Username of the <see cref="User"/> instance.</param>
        /// <param name="passHash">PassHash of the <see cref="User"/> instance.</param>
        /// <param name="authKey">AuthKey of the <see cref="User"/> instance.</param>
        /// <param name="userType">Type of the <see cref="User"/> instance.</param>
        /// <param name="groups">Initial collection of groups related to the <see cref="User"/> instance.</param>
        /// <returns>Instance of <see cref="User"/> class.</returns>
        User CreateUser(string username, string passHash, string authKey, DateTime expirationDate, UserType userType, ICollection<Group> groups);

        /// <summary>
        /// Represent the method witch provide a instance of <see cref="Group"/> class with properties given as arguments.
        /// </summary>
        /// <param name="name">Name of the <see cref="Group"/> instance.</param>
        /// <param name="users">Collection of groups related to the <see cref="User"/> instance.</param>
        /// <returns>Instance of <see cref="Group"/> class.</returns>
        Group CreateGroup(string name, ICollection<User> users);

        /// <summary>
        /// Represent the method witch provide a instance of <see cref="Log"/> class with properties given as arguments.
        /// </summary>
        /// <param name="message">Message of the <see cref="Log"/> instance.</param>
        /// <param name="dateTime">DateTime when the log is logged.</param>
        /// <param name="logType">LogType of the <see cref="Log"/> instance.</param>
        /// <returns>Instance of <see cref="Log"/> class.</returns>
        Log CreateLog(string message, DateTime dateTime, LogType logType);

        /// <summary>
        /// Represent the method witch provide a instance of <see cref="LogType"/> class with properties given as arguments.
        /// </summary>
        /// <param name="name">Name of the <see cref="LogType"/> instance.</param>
        /// <param name="logs">Collection of logs related to the <see cref="LogType"/> instance.</param>
        /// <returns>Instance of <see cref="LogType"/> class.</returns>
        LogType CreateLogType(string name, ICollection<Log> logs);
    }
}
