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
            DatabaseTracker.New(false);
            database.DbObjectModel.GetFirstEntry();
        }

        private void AddIndividualEntries(int num)
        {
            for (int i = 0; i < num; i++)
            {
                database.DbObjectModel.AddEntry("Name" + i.ToString());
            }
        }


        [Fact]
        public void GetIDEmptyDatabase()
        {
            database.DbObjectModel.GetFirstEntry();
            int testInt = database.DbObjectModel.GetiD();
            Assert.Equal(1, testInt);
        }

        [Fact]
        public void AddEntryDatabase()
        {
            AddIndividualEntries(2);
            string testString = database.DbObjectModel.GetName();
            int testInt = database.DbObjectModel.GetiD();
            Assert.Equal(2, testInt);
            Assert.Equal("Name1", testString);
        }

        [Fact]
        public void GetNullDatabaseEntry()
        {
            string testString = database.DbObjectModel.GetName();
            Assert.Equal(@"NULL", testString);
        }

        [Fact]
        public void AddNullDatabaseEntry()
        {
            database.DbObjectModel.AddEntry(null);
            string testString = database.DbObjectModel.GetName();
            int testInt = database.DbObjectModel.GetiD();
            Assert.Equal(1, testInt);
            Assert.Equal("NULL", testString);
        }

        [Fact]
        public void RemoveNullDatabaseEntry()
        {
            database.DbObjectModel.DeleteEntry();
            string testString = database.DbObjectModel.GetName();
            int testInt = database.DbObjectModel.GetiD();
            Assert.Equal(1, testInt);
            Assert.Equal("NULL", testString);
        }

        [Fact]
        public void RemoveDatabaseEntry()
        {
            database.DbObjectModel.AddEntry("Name1");
            string testString = database.DbObjectModel.GetName();
            int testInt = database.DbObjectModel.GetiD();
            Assert.Equal(1, testInt);
            Assert.Equal("Name1", testString);
            database.DbObjectModel.DeleteEntry();
            testString = database.DbObjectModel.GetName();
            testInt = database.DbObjectModel.GetiD();
            Assert.Equal(1, testInt);
            Assert.Equal("NULL", testString);
        }

        [Fact]
        public void GetNextEntry()
        {
            AddIndividualEntries(3);
            database.DbObjectModel.GetFirstEntry();
            string testString = database.DbObjectModel.GetName();
            int testInt = database.DbObjectModel.GetiD();
            Assert.Equal(1, testInt);
            Assert.Equal("Name0", testString);
            database.DbObjectModel.NextEntry();
            testString = database.DbObjectModel.GetName();
            testInt = database.DbObjectModel.GetiD();
            Assert.Equal(2, testInt);
            Assert.Equal("Name1", testString);
        }



    }
}