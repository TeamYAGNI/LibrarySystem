// <copyright file = "LibrarySystemNinjectModule.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of LibrarySystemNinjectModule class.</summary>
using System;
using System.Linq;

using LibrarySystem.Commands.Contracts;
using LibrarySystem.ConsoleClient.ConsoleProviders;
using LibrarySystem.ConsoleClient.Interceptors;
using LibrarySystem.Framework;
using LibrarySystem.Framework.Contracts;
using LibrarySystem.Framework.Providers;
using LibrarySystem.Models.Factory;

using Ninject.Activation;
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
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            // Basic Baindings
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<ICommandReader>().To<ConsoleCommandReader>().WhenInjectedExactlyInto<Engine>().InSingletonScope();
            this.Bind<IResponseWriter>().To<ConsoleResponseWriter>().WhenInjectedExactlyInto<Engine>().InSingletonScope();
            this.Bind<ICommandProcessor>().To<CommandProcessor>().WhenInjectedExactlyInto<Engine>().InSingletonScope();

            // CommandFactory Bindings
            this.Bind<ICommandsFactory>().ToFactory().WhenInjectedInto<ICommandProcessor>().InSingletonScope();
            this.Bind<ICommand>().ToMethod(context => this.GetCommand(context))
                .NamedLikeFactoryMethod((ICommandsFactory factory) => factory.GetCommand(null));

            // Command Bindings

            // Command Dependancies Bindings
            this.Bind<IModelsFactory>().To<ModelsFactory>().WhenInjectedInto<ICommand>().InSingletonScope().Intercept().With<ModelValidation>();
            this.Bind<IValidator>().To<Validator>().WhenInjectedExactlyInto<ModelValidation>().InSingletonScope();
        }

        /// <summary>
        /// Represent the method witch provide a instance of <see cref="ICommand"/> implementator by a given command name in context argument.
        /// </summary>
        /// <param name="context">The context in witch the factory method have been invoked</param>
        /// <returns>Instance of <see cref="ICommand"/> implementator</returns>
        private ICommand GetCommand(IContext context)
        {
            string commandName = context.Parameters.Single().GetValue(context, null).ToString();

            switch (commandName.ToLower())
            {
                case "commandNameToLower": // TODO: Add case for each command!
                                           // return context.Kernel.Get<ICommand>("commandName");
                default:
                    throw new InvalidOperationException(string.Format("There is no such command as {0}!", commandName)); // TODO: Implement InvalidCommandException;
            }
        }
    }
}
