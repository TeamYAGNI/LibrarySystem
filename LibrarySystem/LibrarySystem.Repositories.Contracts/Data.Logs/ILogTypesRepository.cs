﻿// <copyright file = "ILogTypesRepository.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds constrains of ILogTypesRepository implementators.</summary>

using System.Collections.Generic;
using LibrarySystem.Models.Logs;

namespace LibrarySystem.Repositories.Contracts.Data.Logs
{
    /// <summary>
    /// Represent a <see cref="ILogTypesRepository"/> interface. Heir of <see cref="IRepository{LogType}"/>
    /// </summary>
    public interface ILogTypesRepository : IRepository<LogType>
    {
        /// <summary>
        /// Provide collection of logs by a given name.
        /// </summary>
        /// <param name="logTypeName">Name of the log type.</param>
        /// <returns>collection of the logs with the given name.</returns>
        IEnumerable<LogType> GetLogTypeByName(string logTypeName);
    }
}