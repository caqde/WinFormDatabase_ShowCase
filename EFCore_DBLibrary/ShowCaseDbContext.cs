using EFCore_DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCore_DBLibrary
{
    public class ShowCaseDbContext : DbContext
    {
        private static IConfigurationRoot? _configuration;

        public DbSet<dbObject> dbObjects { get; set; }

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
        }
    }
}