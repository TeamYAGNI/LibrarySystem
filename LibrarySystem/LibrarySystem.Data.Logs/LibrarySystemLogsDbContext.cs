// <copyright file = "LibrarySystemLogsDbContext.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of LibrarySystemLogsDbContext class.</summary>

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;

using LibrarySystem.Data.Logs.Migrations;
using LibrarySystem.Models.Logs;

namespace LibrarySystem.Data.Logs
{
    /// <summary>
    /// Represent a <see cref="LibrarySystemLogsDbContext"/> class, heir of <see cref="DbContext"/>.
    /// </summary>
    public class LibrarySystemLogsDbContext : DbContext
    {
        /// <summary>
        /// Name of the connection string that describe witch database server <see cref="LibrarySystemLogsDbContext"/> instance to use and how.
        /// </summary>
        private const string ConnectionString = "LibrarySystemSQLite";

        /// <summary>
        /// Initializes a new instance of the <see cref="LibrarySystemLogsDbContext"/> class.
        /// </summary>
        public LibrarySystemLogsDbContext()
            : base(ConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibrarySystemLogsDbContext, Configuration>(true));
        }

        /// <summary>
        /// Gets or sets access point to Addresses table in Database.
        /// </summary>
        public virtual IDbSet<Log> Logs { get; set; }

        /// <summary>
        /// Gets or sets access point to Authors table in Database.
        /// </summary>
        public virtual IDbSet<LogType> LogTypes { get; set; }

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
            // Fluent API
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder
                .Entity<LogType>()
                .Property(l => l.Name)
                .HasMaxLength(256)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new IndexAttribute("IX_NAME") { IsUnique = true }));

            base.OnModelCreating(modelBuilder);
        }
    }
}
