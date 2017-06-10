# LibrarySystem

This is a course-project for the Databases Course in TelerikAcademy. It represent a Library management system with a console client application.

// TODO: Describe all the functionalities...

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

## Built With

* [EntityFramework](https://docs.microsoft.com/en-us/ef/) - object-relational mapper that enables .NET developers to work with a database using .NET objects.

* [Ninject](http://www.ninject.org/) - Open source dependency injector for .NET
* [Ninject.Extensions.Factory](https://github.com/ninject/Ninject.Extensions.Factory/wiki) - Extension allows you to create factory implementations automatically.
* [Ninject.Extensions.Interception](https://github.com/ninject/Ninject.Extensions.Interception/wiki) - Extension supporting interception.
* [Ninject.Extensions.Interception.DynamicProxy](https://www.nuget.org/packages/Ninject.Extensions.Interception.DynamicProxy/) - Castle DynamicProxy Interception extension for Ninject.

* [Bytes2you.Validation](https://github.com/veskokolev/Bytes2you.Validation) - Fast, extensible, intuitive and easy-to-use C# portable library providing fluent APIs for argument validation.

## Tested With

* [NUnit](https://www.nunit.org/) - Unit-testing framework for all .Net languages with a strong TDD focus.
* [Moq](https://github.com/moq/moq4/wiki) - The most popular and friendly mocking framework for .NET.
* [Effort.EF6](https://github.com/tamasflamich/effort) - Effort is a powerful tool that enables a convenient way to create automated tests for Entity Framework based applications that can run without the presence of the external database.
* [NMemory](https://github.com/tamasflamich/nmemory) -A lightweight non-persistent in-memory relational database engine.

## Authors

### [***TeamYAGNI***](https://github.com/TeamYAGNI)
| Team member         | Username     |
| -------------       | :--------:   |
| **Stefan Arnaudov** | [*Arnaudov_St*](http://telerikacademy.com/Users/Arnaudov_St)  |
| **Gancho Chankov**  | [*gchankov*](http://telerikacademy.com/Users/gchankov)     |
| **Stefan Ludzhev**  | [*ludzhev*](https://github.com/ludzhev)      |

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
