using EFCore_DBModels.Library;
using EFCore_DBModels.SingleAttribute;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCore_DBLibrary
{
    public class ShowCaseDbContext : DbContext
    {
        private static IConfigurationRoot? _configuration;

        //SingleAttribute
        public DbSet<dbObject> dbObjects { get; set; }
        //Library
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowedBook>  BorrowedBooks { get; set; }
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<Publisher> Publishers { get; set; }


        public ShowCaseDbContext()
        {

        }

        public ShowCaseDbContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                _configuration = builder.Build();
                var connectionString = _configuration.GetConnectionString("ShowCaseDB");
                optionsBuilder.UseNpgsql(connectionString, options => 
                { 
                    options.EnableRetryOnFailure();
                });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dbObject>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<BorrowedBook>()
                .HasOne(a => a.Patron)
                .WithMany(a => a.BorrowedBooks)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}