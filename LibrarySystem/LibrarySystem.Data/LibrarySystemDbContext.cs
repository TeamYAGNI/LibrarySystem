// <copyright file = "LibrarySystemDbContext.cs" company="YAGNI">
// All rights reserved.
// </copyright>
// <summary>Holds implementation of LibrarySystemDbContext class.</summary>

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using LibrarySystem.Models;

namespace LibrarySystem.Data
{
    /// <summary>
    /// Represent a <see cref="LibrarySystemDbContext"/> class, heir of <see cref="DbContext"/>.
    /// </summary>
    public class LibrarySystemDbContext : DbContext
    {
        /// <summary>
        /// Name of the connection string that describe witch database server <see cref="LibrarySystemDbContext"/> instance to use and how.
        /// </summary>
        private const string ConnectionString = "LibrarySystemSQLExpress";

        /// <summary>
        /// Name of the connection string that describe witch database server <see cref="LibrarySystemDbContext"/> instance to use and how.
        /// </summary>
        ////private const string ConnectionString = "LibrarySystemSQLServer";

        /// <summary>
        /// Initializes a new instance of the <see cref="LibrarySystemDbContext"/> class.
        /// </summary>
        public LibrarySystemDbContext()
            : base(ConnectionString)
        {
        }

        /// <summary>
        /// Gets or sets access point to Addresses table in Database.
        /// </summary>
        public virtual IDbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or sets access point to Authors table in Database.
        /// </summary>
        public virtual IDbSet<Author> Authors { get; set; }

        /// <summary>
        /// Gets or sets access point to Books table in Database.
        /// </summary>
        public virtual IDbSet<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets access point to Cities table in Database.
        /// </summary>
        public virtual IDbSet<City> Cities { get; set; }

        /// <summary>
        /// Gets or sets access point to Clients table in Database.
        /// </summary>
        public virtual IDbSet<Client> Clients { get; set; }

        /// <summary>
        /// Gets or sets access point to Employees table in Database.
        /// </summary>
        public virtual IDbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Gets or sets access point to Genres table in Database.
        /// </summary>
        public virtual IDbSet<Genre> Genres { get; set; }

        /// <summary>
        /// Gets or sets access point to Journals table in Database.
        /// </summary>
        public virtual IDbSet<Journal> Journals { get; set; }

        /// <summary>
        /// Gets or sets access point to Lendings table in Database.
        /// </summary>
        public virtual IDbSet<Lending> Lendings { get; set; }

        /// <summary>
        /// Gets or sets access point to Publishers table in Database.
        /// </summary>
        public virtual IDbSet<Publisher> Publishers { get; set; }

        /// <summary>
        /// Gets or sets access point to Subjects table in Database.
        /// </summary>
        public virtual IDbSet<Subject> Subjects { get; set; }

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

            // Unique keys
            modelBuilder
                .Entity<Book>()
                .Property(b => b.ISBN)
                .HasMaxLength(13)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new IndexAttribute("IX_ISBN") { IsUnique = true }));

            modelBuilder
                .Entity<Journal>()
                .Property(j => j.ISSN)
                .HasMaxLength(9)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new IndexAttribute("IX_ISSN") { IsUnique = true }));

            modelBuilder
                .Entity<Publisher>()
                .Property(p => p.Name)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new IndexAttribute("IX_Name") { IsUnique = true }));

            modelBuilder
                .Entity<Genre>()
                .Property(g => g.Name)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new IndexAttribute("IX_Name") { IsUnique = true }));

            modelBuilder
                .Entity<Subject>()
                .Property(s => s.Name)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new IndexAttribute("IX_Name") { IsUnique = true }));

            modelBuilder
                .Entity<Client>()
                .Property(c => c.PIN)
                .HasMaxLength(10)
                .HasColumnAnnotation(
                    "Index",
                    new IndexAnnotation(new IndexAttribute("IX_PIN") { IsUnique = true }));

            base.OnModelCreating(modelBuilder);
        }
    }
}