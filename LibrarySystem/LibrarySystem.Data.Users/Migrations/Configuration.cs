// <copyright file="Configuration.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds configuration of migrations to the Users database.</summary>

namespace LibrarySystem.Data.Users.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using LibrarySystem.Models.Enumerations;
    using LibrarySystem.Models.Users;

    /// <summary>
    /// Represent a <see cref="Configuration"/> class, heir of <see cref="DbMigrationsConfiguration"/>.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<LibrarySystemUsersDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        protected override void Seed(LibrarySystemUsersDbContext context)
        {
            Group administrators = context.Groups
                .Where(g => g.Name == "Administrators")
                .FirstOrDefault() ?? new Group { Name = "Administrators" };

            User masterAdmin = context.Users
                .Where(u => u.Username == "Obama")
                .FirstOrDefault() ?? new User
                {
                    Username = "Obama",
                    PassHash = "I am watching you through the microwave. Even you dont have one.",
                    AuthKey = "We hold these truths to be self-evident, that all men are created equal, that they are endowed by their Creator. Thanks Obama:).",
                    Type = UserType.Master,
                    Groups = new HashSet<Group>()
                    {
                        administrators
                    }
                };

            context.Users.AddOrUpdate(u => u.Username, masterAdmin);
        }
    }
}
