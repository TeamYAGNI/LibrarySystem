# LibrarySystem

This is a course-project for the Databases Course in TelerikAcademy. It represents a Library management system with a console
client application. The data is hosted on SQL Server database, but PostgreSQL is used for hosting User information and
SQLite for hosting administrative logs.

## [*Assignment.*](https://github.com/TelerikAcademy/Databases/blob/master/Teamwork/2017/README.md)

## Commands

### Functional
| Command         | Parameters  | Description |
| -------------       | :--------:   | :----------------: |
| **ClientGetBook** | *clientPIN*, *bookISBN* | Lends a book for a period of One month. |
| **ClientReturnBook**  | *clientPIN*, *bookISBN*, *Remarks* | Returns a lended book keeping history of Client's remarks.|
| **ClientGetJournal**  | *clientPIN* | Gets a Journal only for In-Library usage.|
| **ClientReturnJournals**  | *clientPIN* | Returns all Journals kept by the Client. |
| **ClientExitLibrary**  | *clientPIN* | Client leaves the library if he has returned all Journals. |
| **UserLogin**  | *username*, *password* | User Log in the Library System so he has auth to administrative commands. |
| **ClientExitLibrary**  | *username*, *password* | User Logs out of the Library system. |

### Administrative - Files
| Command         | Parameters  | Description |
| -------------       | :--------:   | :----------------: |
| **ExportBooksToFile** | *takes no parameters* | Exports All Books to a xml file in the Solution's directory. |
| **ExportJournalsToFile** | *takes no parameters* | Exports All Journals to a json file in the Solution's directory. |
| **GetPDFReport** | *takes no parameters* | Creates a report of all Book Lendings in the Solution's directory.|
| **ImportBooksFromFile** | *takes no parameters* | Imports Books from a xml file to the LibrarySystem database. |
| **ImportJournalsFromFile** | *takes no parameters* | Imports Journals from a json file to the LibrarySystem database. |
### Administrative - Creational
| Command         | Parameters  | Description |
| -------------       | :--------:   | :----------------: |
| **CreateBook** | *bookTitle*, *bookISBN*, *pageCount*, *yearOfPublishing*, *publisherName*, *quantity*  | Creates a new book in the Library. |
| **CreateJournal** | *journalTitle*, *journalISSN*, *issueNumber*, *yearOfPublishing*, *publisherName*, *quantity*  | Creates a new journal in the database. |
| **RegisterUser** | *username*, *password*, *userType* | Creates a new user of the LibrarySystem. |
### Administrative - Logs
| Command         | Parameters  | Description |
| -------------       | :--------:   | :----------------: |
| **GetLatestLogs** | *takes no parameters* | Gets the latest Logs from the LibrarySystem database. |
### Administrative - Listings - Clients
| Command         | Parameters  | Description |
| -------------       | :--------:   | :----------------: |
| **GetAllClientsWithDelayedLendings** | *takes no parameters* | Gets the clients who have delayed returning their lending. |
| **GetAllClientsWithJournals** | *takes no parameters* | Gets all clients who are holding Journals in the Library. |
| **GetClientByPIN** | *PIN* | Gets client by given PIN. |
| **GetClientAddressByPIN** | *PIN* | Gets the client Address by given PIN. |
| **GetLendingsByClientPIN** | *PIN* | Gets all actual Lendings of client with given PIN. |
| **GetRemarksByClientPIN** | *PIN* | Gets Remarks of the client returned Lendings. |
### Administrative - Listings - Clients
| Command         | Parameters  | Description |
| -------------       | :--------:   | :----------------: |
| **GetAllEmployeesByManagerName** | *managerFirstName*, *managerLastName* | Gets the employees who are Managed by employee with given First name and Last name. |
| **GetEmployeesByFullName** | *employeeFirstName*, *employeeLastName* | Gets the employees with given First name and Last name. |
| **GetAllEmployeesWithoutManager** | *takes no parameters* | Gets all the employees without managers. |
### Administrative - Listings - Users
| Command         | Parameters  | Description |
| -------------       | :--------:   | :----------------: |
| **GetLoggedInUsers** | *takes no parameters* | Gets all the users who are currently logged in. |
### Administrative - Listings - Users
| Command         | Parameters  | Description |
| -------------       | :--------:   | :----------------: |
| **GetLoggedInUsers** | *takes no parameters* | Gets all the users who are currently logged in. |
### Projection - Authors
| Command         | Parameters  | Description |
| -------------       | :--------:   | :----------------: |
| **GetAuthorsByBookTitle** | *bookTitle* | Gets all the Authors of the Book with given title. |
### Projection - Books
| Command         | Parameters  | Description |
| -------------       | :--------:   | :----------------: |
| **GetBookByISBN** | *ISBN* | Gets Book by given ISBN. |
| **GetBooksByAuthor** | *authorFirstName*, *authorLastName* | Gets all books written by given Author. |
| **GetBooksByGenreName** | *genreName* | Gets all books from the given Genre. |
| **GetBooksByPublisher** | *publisherName* | Gets all books by the given Publisher. |
### Projection - Genres
| Command         | Parameters  | Description |
| -------------       | :--------:   | :----------------: |
| **GetGenresWithMostBooks** | *takes no parameters* | Gets most related Genres. |
### Projection - Journals
| Command         | Parameters  | Description |
| -------------       | :--------:   | :----------------: |
| **GetJournalByISSN** | *ISSN* | Gets Book by given ISSN. |
| **GetJournalsByPublisherName** | *publisherName* | Gets all journals by the given Publisher. |
| **GetJournalsBySubject** | *subjectName* | Gets all journals from the given Subject. |
### Projection - Publishers
| Command         | Parameters  | Description |
| -------------       | :--------:   | :----------------: |
| **GetPublisherByBookTitle** | *bookTitle* | Gets Publisher by given Book Title. |
| **GetPublisherByJournalTitle** | *journalTitle* | Gets Publisher by given Journal Title. |
### Projection - Subjects
| Command         | Parameters  | Description |
| -------------       | :--------:   | :----------------: |
| **GetSubjectsWithHighestImpactFactor** | *takes no parameters* | Gets Subjects Ordered by related Journals Impact Factor. |
| **GetSubjectsWithMostJournals** | *takes no parameters* | Gets most related Subjects. |


## Installation

These instructions will let you install a copy of the project on your local machine for development and testing purposes.
Clone the repository on your local machine. [Read more...](https://help.github.com/articles/cloning-a-repository/)

### Prerequisites

 - Visual Studio Community  [Download the latest version from here.](https://www.visualstudio.com/thank-you-downloading-visual-studio/?sku=Community&rel=15)
 - SQL Server [Download the latest version from here.](https://www.microsoft.com/en-in/sql-server/sql-server-downloads)
 - PostgreSQL [Download the latest version from here.](https://www.postgresql.org/download/)

### Dependencies

1.Install the required dependencies by building the solution (<kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>B</kbd>);

Create or Update SQL Server database instance by typing following command in the Package Manager Console:	
(Ensure Default Project in Package Manager Console is set to LibrarySystem.Data)
```
Update-Database -Verbose -StartUpProjectName LibrarySystem.Data
```

Create or Update PostgreSQL server database instance by typing following command in the Package Manager Console:
(Ensure Default Project in Package Manager Console is set to LibrarySystem.Data.Users)
```
Update-Database -Verbose -StartUpProjectName LibrarySystem.Data.Users
```

Create or Update SQLite server database instance by typing following command in the Package Manager Console:
(Ensure Default Project in Package Manager Console is set to LibrarySystem.Data.Logs)
```
Update-Database -Verbose -StartUpProjectName LibrarySystem.Data.Logs
```
## Built With

* [EntityFramework](https://docs.microsoft.com/en-us/ef/) - object-relational mapper that enables .NET developers to work with a database using .NET objects.

* [Ninject](http://www.ninject.org/) - Open source dependency injector for .NET
* [Ninject.Extensions.Factory](https://github.com/ninject/Ninject.Extensions.Factory/wiki) - Extension allows you to create factory implementations automatically.
* [Ninject.Extensions.Interception](https://github.com/ninject/Ninject.Extensions.Interception/wiki) - Extension supporting interception.
* [Ninject.Extensions.Interception.DynamicProxy](https://www.nuget.org/packages/Ninject.Extensions.Interception.DynamicProxy/) - Castle DynamicProxy Interception extension for Ninject.

* [Bytes2you.Validation](https://github.com/veskokolev/Bytes2you.Validation) - Fast, extensible, intuitive and easy-to-use C# portable library providing fluent APIs for argument validation.

* [Json.NET](http://www.newtonsoft.com/json) - Popular high-performance JSON framework for .NET.

* [iTextSharp](http://itextpdf.com/) - iText is a PDF library that allows you to CREATE, ADAPT, INSPECT and MAINTAIN documents in the Portable Document Format (PDF).

## Tested With

* [NUnit](https://www.nunit.org/) - Unit-testing framework for all .Net languages with a strong TDD focus.
* [Moq](https://github.com/moq/moq4/wiki) - The most popular and friendly mocking framework for .NET.
* [Effort.EF6](https://github.com/tamasflamich/effort) - A powerful tool that enables a convenient way to create automated tests for Entity Framework based applications that can run without the presence of the external database.
* [NMemory](https://github.com/tamasflamich/nmemory) -A lightweight non-persistent in-memory relational database engine.

## Authors

### [***TeamYAGNI***](https://github.com/TeamYAGNI)
| Team member         | Username     |
| -------------       | :--------:   |
| **Stefan Arnaudov** | [*Arnaudov_St*](http://telerikacademy.com/Users/Arnaudov_St)  |
| **Gancho Chankov**  | [*gchankov*](http://telerikacademy.com/Users/gchankov)     |
| **Stefan Ludzhev**  | [*ludzhev*](https://github.com/ludzhev)      |

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
