// <copyright file = "CommandProcessor.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of CommandProcessor class.</summary>

using System;
using System.Collections.Generic;
using System.Linq;

using Bytes2you.Validation;

using LibrarySystem.Commands.Contracts;
using LibrarySystem.Framework.Contracts;

namespace LibrarySystem.Framework.Providers
{
    /// <summary>
    /// Represent a <see cref="CommandProcessor"/> class, implementator of <see cref="ICommandProcessor"/> interface.
    /// </summary>
    public class CommandProcessor : ICommandProcessor
    {
        /// <summary>
        /// Commands factory to be used for providing commands instances.
        /// </summary>
        private ICommandsFactory commandsFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandProcessor"/> class.
        /// </summary>
        /// <param name="commandsFactory">Commands factory to be used for providing commands instances.</param>
        public CommandProcessor(ICommandsFactory commandsFactory)
        {
            Guard.WhenArgument(commandsFactory, "CommandProcessor commandsFactory").IsNull().Throw();

            this.commandsFactory = commandsFactory;
        }

        /// <summary>
        /// Represent the method which process a command.
        /// </summary>
        /// <param name="fullCommand">Full command to be processed.</param>
        /// <returns>Response as string.</returns>
        public string ProcessCommand(string fullCommand)
        {
            Guard.WhenArgument(fullCommand, "No command has been provided!").IsNullOrWhiteSpace().Throw();

            List<string> commandList = fullCommand.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string commandName = commandList.FirstOrDefault();
            List<string> commandParameters = commandList.Skip(1).ToList();

            ICommand command = this.commandsFactory.GetCommand(commandName);

            string executionResult = command.Execute(commandParameters);

            return executionResult;
        }
    }
}
