﻿// <copyright file="StartUP.cs" company="YAGNI">
// All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LibrarySystem.Data;
using LibrarySystem.Models;
using LibrarySystem.Models.Enumerations;
using LibrarySystem.Repositories;using LibrarySystem.ConsoleClient.ContainerConfiguration;
using LibrarySystem.Framework.Contracts;
using Ninject;namespace LibrarySystem.ConsoleClient
{
    /// <summary>
    /// Represent the Console Client of the Library System application starting point.
    /// </summary>
    public class StartUp
    {
        /// <summary>
        /// Represent the main method called in the application live.
        /// </summary>
        public static void Main()
        {
            IEngine engine = new StandardKernel(new LibrarySystemNinjectModule()).Get<IEngine>();
            engine.Start();
        }
    }
}
