// <copyright file="Configuration.cs" company="YAGNI">
// All rights reserved.
// </copyright>

using System.Data.Entity.Migrations;

namespace LibrarySystem.Data.Migrations
{
    /// <summary>
    /// Represent a <see cref="Configuration"/> class, heir of <see cref="DbMigrationsConfiguration"/>.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<LibrarySystem.Data.LibrarySystemDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // this.AutomaticMigrationDataLossAllowed = false;
        }

        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        protected override void Seed(LibrarySystem.Data.LibrarySystemDbContext context)
        {
        }
    }
}
