﻿// <copyright file = "LibrarySystemUsersDbContext.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of LibrarySystemUsersDbContext class.</summary>

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;

using LibrarySystem.Models.Users;
using LibrarySystem.Data.Users.Migrations;

namespace LibrarySystem.Data.Users
{
    /// <summary>
    /// Represent a <see cref="LibrarySystemUsersDbContext"/> class, heir of <see cref="DbContext"/>.
    /// </summary>
    public class LibrarySystemUsersDbContext : DbContext
    {
        /// <summary>
        /// Name of the connection string that describe witch database server <see cref="LibrarySystemUsersDbContext"/> instance to use and how.
        /// </summary>
        private const string ConnectionString = "PostgresDotNet";

        /// <summary>
        /// Initializes a new instance of the <see 
        /// cref="LibrarySystemUsersDbContext"/> class.
        /// </summary>
        public LibrarySystemUsersDbContext()
            : base(ConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibrarySystemUsersDbContext, Configuration>(true));
        }

        /// <summary>
        /// Gets or sets access point to User table in Database.
        /// </summary>
        public virtual IDbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets access point to User table in Database.
        /// </summary>
        public virtual IDbSet<Group> Groups { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized,
        /// but before the model has been locked down and used to initialize the context.
        /// The default implementation of this method does nothing, but it can be overridden
        /// in a derived class such that the model can be further configured before it is
        /// locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.HasDefaultSchema("public");

            modelBuilder
               .Entity<User>()
               .Property(u => u.Username)
               .HasMaxLength(50)
               .HasColumnAnnotation(
                   "Index",
                   new IndexAnnotation(new IndexAttribute("IX_USERNAME") { IsUnique = true }));

            modelBuilder
               .Entity<Group>()
               .Property(u => u.Name)
               .HasMaxLength(50)
               .HasColumnAnnotation(
                   "Index",
                   new IndexAnnotation(new IndexAttribute("IX_NAME") { IsUnique = true }));

            base.OnModelCreating(modelBuilder);
        }
    }
}
