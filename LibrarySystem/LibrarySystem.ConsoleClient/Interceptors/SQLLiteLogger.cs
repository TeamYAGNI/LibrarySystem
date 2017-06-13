// <copyright file = "SQLLiteLogger.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of SQLLiteLogger class.</summary>

using System;
using System.Collections.Generic;
using Bytes2you.Validation;
using LibrarySystem.Commands.Administrative.Logs;
using LibrarySystem.Commands.Contracts;
using Ninject.Extensions.Interception;

namespace LibrarySystem.ConsoleClient.Interceptors
{
    /// <summary>
    /// Represent a <see cref="SQLLiteLogger"/> class, implementator of <see cref="IInterceptor"/> interface.
    /// </summary>
    public class SQLLiteLogger : IInterceptor
    {
        private readonly ICommand addLogCommand;

        public SQLLiteLogger(ICommand addLogCommand)
        {
            Guard.WhenArgument(addLogCommand, "addLogCommand").IsNull().Throw();

            this.addLogCommand = addLogCommand;
        }
        /// <summary>
        /// Intercepts the specified invocation.
        /// </summary>
        /// <param name="invocation">The invocation to intercept.</param>
        public void Intercept(IInvocation invocation)
        {
            var parameterObjects = invocation.Request.Arguments;
            var message = parameterObjects.ToString();
            var logType = parameterObjects.ToString();
            var parameters = new List<string>() { message, logType };

            this.addLogCommand.Execute(parameters);

            invocation.Proceed();
        }
    }
}
