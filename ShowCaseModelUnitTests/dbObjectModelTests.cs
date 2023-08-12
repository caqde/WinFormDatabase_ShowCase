using AutoMapper;
using EFCore_DBLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using ShowCaseModel.Models;
using ShowCaseModelUnitTests.TestTools;
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
            context.Database.CloseConnection();
        }

        [Fact]
        public void GetIDEmptyDatabase()
        {
            DatabaseTracker.New(output, false);
            int testInt = testUnit.GetiD();
            Assert.Equal(1, testInt);
        }

        [Fact]
        public void AddEntryDatabase()
        {
            DatabaseTracker.New(output, false);
            testUnit.AddEntry("Name1");
            testUnit.AddEntry("Name2");
            string testString = testUnit.GetName();
            int testInt = testUnit.GetiD();
            Assert.Equal(2, testInt);
            Assert.Equal("Name2", testString);
        }

        [Fact]
        public void GetNullDatabaseEntry()
        {
            DatabaseTracker.New(output, false);
            string testString = testUnit.GetName();
            Assert.Equal(@"NULL", testString);
        }
    }
}