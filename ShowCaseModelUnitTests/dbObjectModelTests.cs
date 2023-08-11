using AutoMapper;
using EFCore_DBLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using ShowCaseModel.Models;
using System.Runtime;

namespace ShowCaseModelUnitTests
{
    public class dbObjectModelTests
    {
        private static MapperConfiguration _config;
        private IMapper mapper;
        private static IServiceProvider serviceProvider;

        DbContextOptionsBuilder<ShowCaseDbContext> builder;
        dbObjectModel testUnit;

        public dbObjectModelTests()
        {
            SetupOptions();
            RunMigrations();
        }

        private void SetupOptions()
        {
            builder = new DbContextOptionsBuilder<ShowCaseDbContext>();
            var configbuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = configbuilder.Build();
            var connectionString = configuration.GetConnectionString("TestShowCaseDB");
            builder.UseNpgsql(connectionString, options => options.EnableRetryOnFailure()); 

            testUnit = new dbObjectModel(builder.Options);
        }

        private async void RunMigrations()
        {
            var context = new ShowCaseDbContext(builder.Options);
            var migrator = context.Database.GetService<IMigrator>();
            await migrator.MigrateAsync();
        }

        [Fact]
        public void GetIDEmptyDatabase()
        {
            int testInt = testUnit.GetiD();
            Assert.Equal(0, testInt);
        }
    }
}