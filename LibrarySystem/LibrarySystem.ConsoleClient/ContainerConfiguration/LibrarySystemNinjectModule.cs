// <copyright file = "LibrarySystemNinjectModule.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of LibrarySystemNinjectModule class.</summary>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using LibrarySystem.Commands.Administrative.Creational;
using LibrarySystem.Commands.Administrative.File;
using LibrarySystem.Commands.Administrative.Listings.Client;
using LibrarySystem.Commands.Administrative.Listings.Employee;
using LibrarySystem.Commands.Administrative.Listings.User;
using LibrarySystem.Commands.Administrative.Logs;
using LibrarySystem.Commands.Contracts;
using LibrarySystem.Commands.Functional;
using LibrarySystem.Commands.Projection.Authors;
using LibrarySystem.Commands.Projection.Books;
using LibrarySystem.Commands.Projection.Genres;
using LibrarySystem.Commands.Projection.Journals;
using LibrarySystem.Commands.Projection.Publishers;
using LibrarySystem.Commands.Projection.Subjects;
using LibrarySystem.ConsoleClient.Interceptors;
using LibrarySystem.ConsoleClient.LocalProviders;
using LibrarySystem.Framework;
using LibrarySystem.Framework.Contracts;
using LibrarySystem.Framework.Exceptions;
using LibrarySystem.Framework.Providers;
using LibrarySystem.Models.Factory;

using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using LibrarySystem.Repositories.Contracts.Data;
using LibrarySystem.Repositories.Data;
using LibrarySystem.Repositories.Contracts.Data.UnitOfWork;
using LibrarySystem.Repositories.Data.UnitOfWork;
using LibrarySystem.Data;
using LibrarySystem.Data.Users;
using LibrarySystem.Data.Logs;
using LibrarySystem.FileExporters;
using LibrarySystem.FileExporters.Utils;
using LibrarySystem.FileExporters.Utils.Contracts;
using LibrarySystem.FileImporters;
using LibrarySystem.FileImporters.Utils;
using LibrarySystem.FileImporters.Utils.Contracts;
using LibrarySystem.Models.DTOs.XML;
using LibrarySystem.Repositories.Contracts.Data.Logs;
using LibrarySystem.Repositories.Contracts.Data.Users.UnitOfWork;
using LibrarySystem.Repositories.Data.Users.UnitOfWork;
using LibrarySystem.Repositories.Contracts.Data.Logs.UnitOfWork;
using LibrarySystem.Repositories.Data.Logs.UnitOfWork;
using LibrarySystem.Repositories.Contracts.Data.Users;
using LibrarySystem.Repositories.Data.Logs;
using LibrarySystem.Repositories.Data.Users;
using Ninject.Extensions.Conventions;

namespace LibrarySystem.ConsoleClient.ContainerConfiguration
{
    /// <summary>
    /// Represent a <see cref="LibrarySystemNinjectModule"/> class, heir of <see cref="NinjectModule"/> interface.
    /// </summary>
    public class LibrarySystemNinjectModule : NinjectModule
    {
        private const string GetAllClientsWithDelayedLendingsCommand = "getallclientswithdelayedlendings";
        private const string GetAllClientsWithJournalsCommand = "getallclientswithjournals";
        private const string GetClientAddressByPINCommand = "getclientaddressbypin";
        private const string GetClientByPINCommand = "getclientbypin";
        private const string GetLendingsByClientPINCommand = "getlendingsbyclientpin";
        private const string GetRemarksByClientPINCommand = "getremarksbyclientpin";
        private const string GetAllEmployeesByManagerNameCommand = "getallemployeesbymanagername";
        private const string GetAllEmployeesWithoutManagerCommand = "getallemployeeswithoutmanager";
        private const string GetEmployeesByFullNameCommand = "getemployeesbyfullname";
        private const string GetLoggedInUsersCommand = "getloggedinusers";
        private const string ClientExitLibraryCommand = "clientexitlibrary";
        private const string ClientGetBookCommand = "clientgetbook";
        private const string ClientGetJournalCommand = "clientgetjournal";
        private const string ClientReturnBookCommand = "clientreturnbook";
        private const string ClientReturnJournalsCommand = "clientreturnjournals";
        private const string UserLoginCommand = "userlogin";
        private const string UserLogoutCommand = "userlogout";
        private const string GetAuthorsByBookTitleCommand = "getauthorsbybooktitle";
        private const string GetBookByISBNCommand = "getbookbyisbn";
        private const string GetBooksByAuthorCommand = "getbooksbyauthor";
        private const string GetBooksByGenreNameCommand = "getbooksbygenrename";
        private const string GetBooksByPublisherCommand = "getbooksbypublisher";
        private const string GetGenresWithMostBooksCommand = "getgenreswithmostbooks";
        private const string GetJournalByISSNCommand = "getjournalbyissn";
        private const string GetJournalsByPublisherNameCommand = "getjournalsbypublishername";
        private const string GetJournalsBySubjectCommand = "getjournalsbysubject";
        private const string GetPublisherByBookTitleCommand = "getpublisherbybooktitle";
        private const string GetPublisherByJournalTitleCommand = "getpublisherbyjournaltitle";
        private const string GetSubjectsWithHighestImpactFactorCommand = "getsubjectswithhighestimpactfactor";
        private const string GetSubjectsWithMostJournalsCommand = "getsubjectswithmostjournals";
        private const string CreateBookCommand = "createbook";
        private const string CreateJournalCommand = "createjournal";
        private const string RegisterUserCommand = "registeruser";
        private const string GetLatestLogsCommand = "getlatestlogs";
        private const string ExportBooksToFileCommand = "exportbookstofile";
        private const string ImportBooksFromFileCommand = "importbooksfromfile";
        private const string ImportJournalsFromFileCommand = "importjournalsfromfile";
        private const string ExportJournalsToFileCommand = "exportjournalstofile";
        private const string GetPDFReportCommand = "getpdfreport";

        private const string BooksForImportPath = "./../../../books.xml";
        private const string bookExporterDirectory = "./../../../";
        private const string bookExporterFileName = "books-inventory.xml";
        private const string JournalImporterFilePath = "./../../../journals.json";
        private const string JournalExporterDirectory = "./../../../";
        private const string JournalExporterFileName = "journals-inventory.json";
        private const string PdfFileDirectory = "./../../../";
        private const string PdfFileName = "lendings.pdf";

        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            //Kernel.Bind(x =>
            //{
            //    x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            //        .SelectAllClasses()
            //        .BindDefaultInterface();
            //});
            // Basic bindings
            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IUserPassport>().To<UserPassport>();

            this.Bind<ICommandReader>().To<ConsoleCommandReader>().WhenInjectedExactlyInto<Engine>().InSingletonScope();
            this.Bind<IResponseWriter>().To<ConsoleResponseWriter>().WhenInjectedExactlyInto<Engine>().InSingletonScope();
            this.Bind<ICommandProcessor>().To<CommandProcessor>().WhenInjectedExactlyInto<Engine>().InSingletonScope();
            // CommandFactory Bindings
            this.Bind<ICommandsFactory>().ToFactory().WhenInjectedInto<ICommandProcessor>().InSingletonScope();
            this.Bind<ICommand>().ToMethod(context => this.GetCommand(context))
                .NamedLikeFactoryMethod((ICommandsFactory factory) => factory.GetCommand(null));

            // Command Bindings
            this.Bind<ICommand>().To<GetAllClientsWithDelayedLendingsCommand>().Named(GetAllClientsWithDelayedLendingsCommand);
            this.Bind<ICommand>().To<GetAllClientsWithJournalsCommand>().Named(GetAllClientsWithJournalsCommand);
            this.Bind<ICommand>().To<GetClientAddressByPINCommand>().Named(GetClientAddressByPINCommand);
            this.Bind<ICommand>().To<GetClientByPINCommand>().Named(GetClientByPINCommand);
            this.Bind<ICommand>().To<GetLendingsByClientPINCommand>().Named(GetLendingsByClientPINCommand);
            this.Bind<ICommand>().To<GetRemarksByClientPINCommand>().Named(GetRemarksByClientPINCommand);
            this.Bind<ICommand>().To<GetAllEmployeesByManagerNameCommand>().Named(GetAllEmployeesByManagerNameCommand);
            this.Bind<ICommand>().To<GetAllEmployeesWithoutManagerCommand>().Named(GetAllEmployeesWithoutManagerCommand);
            this.Bind<ICommand>().To<GetEmployeesByFullNameCommand>().Named(GetEmployeesByFullNameCommand);
            this.Bind<ICommand>().To<GetLoggedInUsersCommand>().Named(GetLoggedInUsersCommand);
            this.Bind<ICommand>().To<ClientExitLibraryCommand>().Named(ClientExitLibraryCommand);
            this.Bind<ICommand>().To<ClientGetBookCommand>().Named(ClientGetBookCommand);
            this.Bind<ICommand>().To<ClientGetJournalCommand>().Named(ClientGetJournalCommand);
            this.Bind<ICommand>().To<ClientReturnBookCommand>().Named(ClientReturnBookCommand);
            this.Bind<ICommand>().To<ClientReturnJournalsCommand>().Named(ClientReturnJournalsCommand);
            this.Bind<ICommand>().To<UserLoginCommand>().Named(UserLoginCommand);
            this.Bind<ICommand>().To<UserLogoutCommand>().Named(UserLogoutCommand);
            this.Bind<ICommand>().To<GetAuthorsByBookTitleCommand>().Named(GetAuthorsByBookTitleCommand);
            this.Bind<ICommand>().To<GetBookByISBNCommand>().Named(GetBookByISBNCommand);
            this.Bind<ICommand>().To<GetBooksByAuthorCommand>().Named(GetBooksByAuthorCommand);
            this.Bind<ICommand>().To<GetBooksByGenreNameCommand>().Named(GetBooksByGenreNameCommand);
            this.Bind<ICommand>().To<GetBooksByPublisherCommand>().Named(GetBooksByPublisherCommand);
            this.Bind<ICommand>().To<GetGenresWithMostBooksCommand>().Named(GetGenresWithMostBooksCommand);
            this.Bind<ICommand>().To<GetJournalByISSNCommand>().Named(GetJournalByISSNCommand);
            this.Bind<ICommand>().To<GetJournalsByPublisherNameCommand>().Named(GetJournalsByPublisherNameCommand);
            this.Bind<ICommand>().To<GetJournalsBySubjectCommand>().Named(GetJournalsBySubjectCommand);
            this.Bind<ICommand>().To<GetPublisherByBookTitleCommand>().Named(GetPublisherByBookTitleCommand);
            this.Bind<ICommand>().To<GetPublisherByJournalTitleCommand>().Named(GetPublisherByJournalTitleCommand);
            this.Bind<ICommand>().To<GetSubjectsWithHighestImpactFactorCommand>().Named(GetSubjectsWithHighestImpactFactorCommand);
            this.Bind<ICommand>().To<GetSubjectsWithMostJournalsCommand>().Named(GetSubjectsWithMostJournalsCommand);
            this.Bind<ICommand>().To<CreateBookCommand>().Named(CreateBookCommand);
            this.Bind<ICommand>().To<CreateJournalCommand>().Named(CreateJournalCommand);
            this.Bind<ICommand>().To<RegisterUserCommand>().Named(RegisterUserCommand);
            this.Bind<ICommand>().To<GetLatestLogsCommand>().Named(GetLatestLogsCommand);
            this.Bind<ICommand>().To<ImportBooksFromFileCommand>().Named(ImportBooksFromFileCommand);
            this.Bind<ICommand>().To<ExportBooksToFileCommand>().Named(ExportBooksToFileCommand);
            this.Bind<ICommand>().To<ImportJournalsFromFileCommand>().Named(ImportJournalsFromFileCommand);
            this.Bind<ICommand>().To<ExportJournalsToFileCommand>().Named(ExportJournalsToFileCommand);
            this.Bind<ICommand>().To<GetPDFReportCommand>().Named(GetPDFReportCommand);

            // Command Dependancies Bindings
            this.Bind<IModelsFactory>().To<ModelsFactory>().WhenInjectedInto<ICommand>().InSingletonScope().Intercept().With<ModelValidation>();
            this.Bind<IValidator>().To<Validator>().WhenInjectedExactlyInto<ModelValidation>().InSingletonScope();

            // Repository Bindings
            this.Bind<IPublisherRepository>().To<PublisherRepository>();
            this.Bind<IBookRepository>().To<BookRepository>();
            this.Bind<IJournalRepository>().To<JournalRepository>();
            this.Bind<IUserRepository>().To<UserRepository>();
            this.Bind<ILendingRepository>().To<LendingRepository>();
            this.Bind<ILibraryUnitOfWork>().To<LibraryUnitOfWork>();
            this.Bind<IUsersUnitOfWork>().To<UsersUnitOfWork>();
            this.Bind<ILogsUnitOfWork>().To<LogsUnitOfWork>();
            this.Bind<ILogsRepository>().To<LogsRepository>();
            this.Bind<ILogTypesRepository>().To<LogTypesRepository>();
            this.Bind<IAddressRepository>().To<AddressRepository>();
            this.Bind<IAuthorRepository>().To<AuthorRepository>();
            this.Bind<IGenreRepository>().To<GenreRepository>();
            this.Bind<ISubjectRepository>().To<SubjectRepository>();
            this.Bind<IClientRepository>().To<ClientRepository>();
            this.Bind<IEmployeeRepository>().To<EmployeeRepository>();

            this.Bind<LibrarySystemDbContext>().ToSelf().InSingletonScope();
            this.Bind<LibrarySystemUsersDbContext>().ToSelf().InSingletonScope();
            this.Bind<LibrarySystemLogsDbContext>().ToSelf().InSingletonScope();

            this.Bind<IHashProvider>().To<HashProvider>();
            this.Bind<IAuthKeyProvider>().To<AuthKeyProvider>();

            // Log Interceptor Bindings
            this.Bind<SQLLiteLogger>().ToSelf().InSingletonScope();
            this.Bind<ICommand>().To<AddLogCommand>().WhenInjectedInto<SQLLiteLogger>();
            this.Bind<ILogger>().To<Logger>().Intercept().With<SQLLiteLogger>();

            //Book Importer Bindings
            this.Bind<XmlReader>().ToSelf().InSingletonScope();
            this.Bind<IStreamReader>().To<StreamReaderWrapper>().WhenInjectedInto<XmlReader>().WithConstructorArgument("filePath", BooksForImportPath);
            this.Bind<IXmlDeserializer>().To<XmlDeserializerWrapper>().WhenInjectedInto<XmlReader>().WithConstructorArgument("xmlSerializer", new XmlSerializer(typeof(List<BookXmlDto>)));
            this.Bind<ICommand>().To<CreateBookCommand>().WhenInjectedInto<ImportBooksFromFileCommand>();

            //Book Exporter Bindings
            this.Bind<XmlWriter>().ToSelf().InSingletonScope();
            this.Bind<ITextWriter>().To<TextWriterWrapper>().WhenInjectedInto<XmlWriter>()
                .WithConstructorArgument("directory", bookExporterDirectory)
                .WithConstructorArgument("fileName", bookExporterFileName);
            this.Bind<IXmlSerializer>().To<XmlSerializerWrapper>().WhenInjectedInto<XmlWriter>().WithConstructorArgument("xmlSerializer", new XmlSerializer(typeof(List<BookXmlDto>)));

            //Journal Importer Bindings
            this.Bind<JsonReader>().ToSelf().InSingletonScope();
            this.Bind<IStreamReader>().To<StreamReaderWrapper>().WhenInjectedInto<JsonReader>()
                .WithConstructorArgument("filePath", JournalImporterFilePath);
            this.Bind<IJsonDeserializer>().To<JsonDeserializerWrapper>().WhenInjectedInto<JsonReader>();
            this.Bind<ICommand>().To<CreateJournalCommand>().WhenInjectedInto<ImportJournalsFromFileCommand>();

            //Journal Exporter Bindings
            this.Bind<JsonWriter>().ToSelf().InSingletonScope();
            this.Bind<ITextWriter>().To<TextWriterWrapper>().WhenInjectedInto<JsonWriter>()
                .WithConstructorArgument("directory", JournalExporterDirectory)
                .WithConstructorArgument("fileName", JournalExporterFileName);
            this.Bind<IJsonSerializer>().To<JsonSerializerWrapper>().WhenInjectedInto<JsonWriter>();

            //PDF
            this.Bind<IPdfStream>().To<PdfStreamWrapper>().WhenInjectedInto<PdfWriterProvider>()
                .WithConstructorArgument("directory", PdfFileDirectory)
                .WithConstructorArgument("fileName", PdfFileName);

            this.Bind<IPdfTableGenerator>().To<PdfTableGenerator>().WhenInjectedInto<PdfWriterProvider>();
            this.Bind<PdfWriterProvider>().ToSelf().WhenInjectedInto<AddLogCommand>().InSingletonScope();

        }

        /// <summary>
        /// Represent the method which provide a instance of <see cref="ICommand"/> implementator by a given command name in context argument.
        /// </summary>
        /// <param name="context">The context in which the factory method have been invoked</param>
        /// <returns>Instance of <see cref="ICommand"/> implementator</returns>
        private ICommand GetCommand(IContext context)
        {
            string commandName = context.Parameters.Single().GetValue(context, null).ToString();
            string defaultMessage = "There is no such command as {0}!";

            switch (commandName.ToLower())
            {
                case GetAllClientsWithDelayedLendingsCommand: return context.Kernel.Get<ICommand>(GetAllClientsWithDelayedLendingsCommand);
                case GetAllClientsWithJournalsCommand: return context.Kernel.Get<ICommand>(GetAllClientsWithJournalsCommand);
                case GetClientAddressByPINCommand: return context.Kernel.Get<ICommand>(GetClientAddressByPINCommand);
                case GetClientByPINCommand: return context.Kernel.Get<ICommand>(GetClientByPINCommand);
                case GetLendingsByClientPINCommand: return context.Kernel.Get<ICommand>(GetLendingsByClientPINCommand);
                case GetRemarksByClientPINCommand: return context.Kernel.Get<ICommand>(GetRemarksByClientPINCommand);
                case GetAllEmployeesByManagerNameCommand: return context.Kernel.Get<ICommand>(GetAllEmployeesByManagerNameCommand);
                case GetAllEmployeesWithoutManagerCommand: return context.Kernel.Get<ICommand>(GetAllEmployeesWithoutManagerCommand);
                case GetEmployeesByFullNameCommand: return context.Kernel.Get<ICommand>(GetEmployeesByFullNameCommand);
                case GetLoggedInUsersCommand: return context.Kernel.Get<ICommand>(GetLoggedInUsersCommand);
                case ClientExitLibraryCommand: return context.Kernel.Get<ICommand>(ClientExitLibraryCommand);
                case ClientGetBookCommand: return context.Kernel.Get<ICommand>(ClientGetBookCommand);
                case ClientGetJournalCommand: return context.Kernel.Get<ICommand>(ClientGetJournalCommand);
                case ClientReturnBookCommand: return context.Kernel.Get<ICommand>(ClientReturnBookCommand);
                case ClientReturnJournalsCommand: return context.Kernel.Get<ICommand>(ClientReturnJournalsCommand);
                case UserLoginCommand: return context.Kernel.Get<ICommand>(UserLoginCommand);
                case UserLogoutCommand: return context.Kernel.Get<ICommand>(UserLogoutCommand);
                case GetAuthorsByBookTitleCommand: return context.Kernel.Get<ICommand>(GetAuthorsByBookTitleCommand);
                case GetBookByISBNCommand: return context.Kernel.Get<ICommand>(GetBookByISBNCommand);
                case GetBooksByAuthorCommand: return context.Kernel.Get<ICommand>(GetBooksByAuthorCommand);
                case GetBooksByGenreNameCommand: return context.Kernel.Get<ICommand>(GetBooksByGenreNameCommand);
                case GetBooksByPublisherCommand: return context.Kernel.Get<ICommand>(GetBooksByPublisherCommand);
                case GetGenresWithMostBooksCommand: return context.Kernel.Get<ICommand>(GetGenresWithMostBooksCommand);
                case GetJournalByISSNCommand: return context.Kernel.Get<ICommand>(GetJournalByISSNCommand);
                case GetJournalsByPublisherNameCommand: return context.Kernel.Get<ICommand>(GetJournalsByPublisherNameCommand);
                case GetJournalsBySubjectCommand: return context.Kernel.Get<ICommand>(GetJournalsBySubjectCommand);
                case GetPublisherByBookTitleCommand: return context.Kernel.Get<ICommand>(GetPublisherByBookTitleCommand);
                case GetPublisherByJournalTitleCommand: return context.Kernel.Get<ICommand>(GetPublisherByJournalTitleCommand);
                case GetSubjectsWithHighestImpactFactorCommand: return context.Kernel.Get<ICommand>(GetSubjectsWithHighestImpactFactorCommand);
                case GetSubjectsWithMostJournalsCommand: return context.Kernel.Get<ICommand>(GetSubjectsWithMostJournalsCommand);
                case CreateBookCommand: return context.Kernel.Get<ICommand>(CreateBookCommand);
                case CreateJournalCommand: return context.Kernel.Get<ICommand>(CreateJournalCommand);
                case RegisterUserCommand: return context.Kernel.Get<ICommand>(RegisterUserCommand);
                case GetLatestLogsCommand: return context.Kernel.Get<ICommand>(GetLatestLogsCommand);
                case ImportBooksFromFileCommand: return context.Kernel.Get<ICommand>(ImportBooksFromFileCommand);
                case ExportBooksToFileCommand: return context.Kernel.Get<ICommand>(ExportBooksToFileCommand);
                case ImportJournalsFromFileCommand: return context.Kernel.Get<ICommand>(ImportJournalsFromFileCommand);
                case ExportJournalsToFileCommand: return context.Kernel.Get<ICommand>(ExportJournalsToFileCommand);
                case GetPDFReportCommand: return context.Kernel.Get<ICommand>(GetPDFReportCommand);
                default: throw new InvalidCommandException(string.Format(defaultMessage, commandName));
            }
        }
    }
}
