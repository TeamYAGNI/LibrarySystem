// <copyright file = "Engine.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of Engine class.</summary>

using System;
using System.Text;

using Bytes2you.Validation;

using LibrarySystem.Framework.Contracts;
using LibrarySystem.Framework.Exceptions;

namespace LibrarySystem.Framework
{
    /// <summary>
    /// Represent a <see cref="Engine"/> class, implementator of <see cref="IEngine"/> interface.
    /// </summary>
    public class Engine : IEngine
    {
        /// <summary>
        /// Command indicates the end of command session.
        /// </summary>
        private const string TerminateCommand = "exit";

        /// <summary>
        /// Message shown when command session is closed.
        /// </summary>
        private const string TerminateMessage = "Program terminated.";

        /// <summary>
        /// Command reader to be used as command as string provider.
        /// </summary>
        private readonly ICommandReader commandReader;

        /// <summary>
        /// Response writer to be used for providing responses.
        /// </summary>
        private readonly IResponseWriter responseWriter;

        /// <summary>
        /// Command processor to be used for processing commands.
        /// </summary>
        private readonly ICommandProcessor commandProcessor;

        /// <summary>
        /// Response writer to be used for logging responses.
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Engine"/> class.
        /// </summary>
        /// <param name="commandReader">Command reader to be used as command as string provider.</param>
        /// <param name="responseWriter">Response writer to be used for providing responses.</param>
        /// <param name="commandProcessor">Command processor to be used for processing commands.</param>
        public Engine(ICommandReader commandReader, IResponseWriter responseWriter, ICommandProcessor commandProcessor, ILogger logger)
        {
            Guard.WhenArgument(commandReader, "Engine commandReader").IsNull().Throw();
            Guard.WhenArgument(responseWriter, "Engine responseWriter").IsNull().Throw();
            Guard.WhenArgument(commandProcessor, "Engine commandProcessor").IsNull().Throw();
            Guard.WhenArgument(logger, "Engine logger").IsNull().Throw();

            this.commandReader = commandReader;
            this.responseWriter = responseWriter;
            this.commandProcessor = commandProcessor;
            this.logger = logger;
        }

        /// <summary>
        /// Represent the method which holds the main logic of the <see cref="Engine"/> class.
        /// </summary>
        public void Start()
        {
            string commandLine = this.commandReader.ReadLine();

            while (commandLine.ToLower() != TerminateCommand)
            {
                try
                {
                    string executionResult = this.commandProcessor.ProcessCommand(commandLine);
                    this.responseWriter.WriteLine(executionResult);
                }
                catch (InvalidCommandException ex)
                {
                    this.logger.Log(ex.Message, "InvalidCommandException");
                    this.responseWriter.WriteLine("Invalid command! Please try again.");
                }
                catch (UserAuthException ex)
                {
                    this.logger.Log(ex.Message, "UserAuthException");
                    this.responseWriter.WriteLine("Unable to Authenticate user! Please Log in!");
                }
                catch (ModelValidationException ex)
                {
                    this.logger.Log(ex.Message, "ModelValidationException");
                    this.responseWriter.WriteLine("Unable to validate model. Please try again!");
                }
                catch (Exception ex)
                {
                    this.logger.Log(ex.Message, "GenericException");
                    this.responseWriter.WriteLine("Unexpected Error occured while handling your Command! Plese excuse us! You can try some other commands.");
                }

                commandLine = this.commandReader.ReadLine();
            }

            this.responseWriter.WriteLine(TerminateMessage);
        }
    }
}
