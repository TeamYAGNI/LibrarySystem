// <copyright file="Configuration.cs" company="YAGNI">
// All rights reserved.
// </copyright>

using System;
using System.Data.Entity.Migrations;
using System.Data.SQLite.EF6.Migrations;
using System.Linq;

using LibrarySystem.Models.Logs;

namespace LibrarySystem.Data.Logs.Migrations
{
    /// <summary>
    /// Represent a <see cref="Configuration"/> class, heir of <see cref="DbMigrationsConfiguration"/>.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<LibrarySystemLogsDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }

        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        protected override void Seed(LibrarySystemLogsDbContext context)
        {
            LogType logtype = context.LogTypes
                .Where(l => l.Name == "Updating Database")
                .FirstOrDefault() ?? new LogType { Name = "Updating Database" };

            Log updatingLog = new Log
            {
                Message = "Running Seed method After a migration!",
                DateTime = DateTime.Now, // TODO: Implement DateTime provider.
                LogType = logtype
            };

            context.Logs.Add(updatingLog);

            context.SaveChanges();
        }
    }
}
