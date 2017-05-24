using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using LibrarySystem.Models;

namespace LibrarySystem.Data
{
    public class LibrarySystemDbContext : DbContext
    {
        // Your context has been configured to use a 'LibrarySystemDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LibrarySystem.Data.LibrarySystemDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LibrarySystemDbContext' 
        // connection string in the application configuration file.
        public LibrarySystemDbContext()
            : base("name=LibrarySystemDbContext")
        {
        }

        //// Add a DbSet for each entity type that you want to include in your model. For more information 
        //// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual IDbSet<Address> Addresses { get; set; }

        public virtual IDbSet<Author> Authors { get; set; }

        public virtual IDbSet<Book> Books { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Client> Clients { get; set; }

        public virtual IDbSet<Employee> Employees { get; set; }

        public virtual IDbSet<Genre> Genres { get; set; }

        public virtual IDbSet<Journal> Journals { get; set; }

        public virtual IDbSet<Lending> Lendings { get; set; }
        
        public virtual IDbSet<Publisher> Publishers { get; set; }

        public virtual IDbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Fluent API
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}