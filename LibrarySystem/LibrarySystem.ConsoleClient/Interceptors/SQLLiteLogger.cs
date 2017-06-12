// <copyright file = "SQLLiteLogger.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of SQLLiteLogger class.</summary>

using System;
using Bytes2you.Validation;
using LibrarySystem.Framework.Contracts;
using Ninject.Extensions.Interception;

namespace LibrarySystem.ConsoleClient.Interceptors
{
    /// <summary>
    /// Represent a <see cref="SQLLiteLogger"/> class, implementator of <see cref="IInterceptor"/> interface.
    /// </summary>
    public class SQLLiteLogger : IInterceptor
    {
        /// <summary>
        /// Intercepts the specified invocation.
        /// </summary>
        /// <param name="invocation">The invocation to intercept.</param>
        public void Intercept(IInvocation invocation)
        {
            // TODO: Implement SQLLite Logging
        }
    }
}
