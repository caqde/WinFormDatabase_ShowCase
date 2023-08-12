using AutoMapper;
using EFCore_DBLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using ShowCaseModel.Models;
using ShowCaseModelUnitTests.TestFixtures;
using ShowCaseModelUnitTests.TestTools;
using System.Runtime;
using Xunit.Abstractions;

namespace ShowCaseModelUnitTests
{
    public class dbObjectModelTests : IClassFixture<DatabaseFixture>
    {
        private static MapperConfiguration _config;
        private IMapper mapper;
        private static IServiceProvider serviceProvider;

        DatabaseFixture database;

        public dbObjectModelTests(DatabaseFixture fixture)
        {
            this.database = fixture;    
        }



        [Fact]
        public void GetIDEmptyDatabase()
        {
            DatabaseTracker.New(false);
            database.DbObjectModel.GetFirstEntry();
            int testInt = database.DbObjectModel.GetiD();
            Assert.Equal(1, testInt);
        }

        [Fact]
        public void AddEntryDatabase()
        {
            DatabaseTracker.New(false);
            database.DbObjectModel.AddEntry("Name1");
            database.DbObjectModel.AddEntry("Name2");
            string testString = database.DbObjectModel.GetName();
            int testInt = database.DbObjectModel.GetiD();
            Assert.Equal(2, testInt);
            Assert.Equal("Name2", testString);
        }

        [Fact]
        public void GetNullDatabaseEntry()
        {
            DatabaseTracker.New(false);
            string testString = database.DbObjectModel.GetName();
            Assert.Equal(@"NULL", testString);
        }
    }
}