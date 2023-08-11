using AutoMapper;
using EFCore_DBLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using ShowCaseModel.Models;
using System.Runtime;
using Xunit.Abstractions;

namespace ShowCaseModelUnitTests
{
    public class dbObjectModelTests
    {
        private static MapperConfiguration _config;
        private IMapper mapper;
        private static IServiceProvider serviceProvider;
        private static ChangeTracking changeTracker;
        private readonly ITestOutputHelper output;

        private dbObjectModel testUnit;

        public dbObjectModelTests(ITestOutputHelper output)
        {
            this.output = output;
            SetupOptions();
            RunMigrations();
            ResetDatabase();
        }

        private void SetupOptions()
        {
            testUnit = new dbObjectModel(DatabaseTracker.GetOptionBuilder().Options);
        }

        private async void RunMigrations()
        {
            var context = new ShowCaseDbContext(DatabaseTracker.GetOptionBuilder().Options);
            
            var migrator = context.Database.GetService<IMigrator>();
            await migrator.MigrateAsync();
        }

        private void ResetDatabase()
        {
            var context = new ShowCaseDbContext(DatabaseTracker.GetOptionBuilder().Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Fact]
        public void GetIDEmptyDatabase()
        {
            DatabaseTracker.New(output, true);
            int testInt = testUnit.GetiD();
            Assert.Equal(0, testInt);
        }
    }
}