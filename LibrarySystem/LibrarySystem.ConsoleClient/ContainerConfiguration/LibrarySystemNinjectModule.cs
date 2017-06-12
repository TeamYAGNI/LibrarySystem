// <copyright file = "LibrarySystemNinjectModule.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of LibrarySystemNinjectModule class.</summary>

using System.IO;
using System.Linq;
using System.Reflection;

using LibrarySystem.Commands.Administrative.Listings.Client;
using LibrarySystem.Commands.Administrative.Listings.Employee;
using LibrarySystem.Commands.Administrative.Listings.User;
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
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;

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
        private const string GetSubjectsWithHighestImpactFactorcs = "getsubjectswithhighestimpactfactorcs";
        private const string GetSubjectsWithMostJournalsCommand = "getsubjectswithmostjournals";

        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            // Basic Baindings
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            this.Bind<IEngine>().To<Engine>().InSingletonScope();

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
            this.Bind<ICommand>().To<GetSubjectsWithHighestImpactFactorcs>().Named(GetSubjectsWithHighestImpactFactorcs);
            this.Bind<ICommand>().To<GetSubjectsWithMostJournalsCommand>().Named(GetSubjectsWithMostJournalsCommand);

            // Command Dependancies Bindings
            this.Bind<IModelsFactory>().To<ModelsFactory>().WhenInjectedInto<ICommand>().InSingletonScope().Intercept().With<ModelValidation>();
            this.Bind<IValidator>().To<Validator>().WhenInjectedExactlyInto<ModelValidation>().InSingletonScope();
        }

        /// <summary>
        /// Represent the method which provide a instance of <see cref="ICommand"/> implementator by a given command name in context argument.
        /// </summary>
        /// <param name="context">The context in which the factory method have been invoked</param>
        /// <returns>Instance of <see cref="ICommand"/> implementator</returns>
        private ICommand GetCommand(IContext context)
        {
            string commandName = context.Parameters.Single().GetValue(context, null).ToString();

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
                case GetSubjectsWithHighestImpactFactorcs: return context.Kernel.Get<ICommand>(GetSubjectsWithHighestImpactFactorcs);
                case GetSubjectsWithMostJournalsCommand: return context.Kernel.Get<ICommand>(GetSubjectsWithMostJournalsCommand);
                default: throw new InvalidCommandException(commandName);
            }
        }
    }
}
