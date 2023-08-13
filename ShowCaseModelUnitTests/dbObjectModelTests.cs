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

        private void GetCurrentEntryValue(out string testName, out int testId)
        {
            testName = database.DbObjectModel.GetName();
            testId = database.DbObjectModel.GetiD();
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
            string testEntryName;
            int testID;
            database.DbObjectModel.AddEntry("Name1");
            GetCurrentEntryValue(out testEntryName, out testID);
            Assert.Equal(1, testID);
            Assert.Equal("Name1", testEntryName);
            database.DbObjectModel.DeleteEntry();
            GetCurrentEntryValue(out testEntryName, out testID);
            Assert.Equal(1, testID);
            Assert.Equal("NULL", testEntryName);
        }

        [Fact]
        public void GetNextEntry()
        {
            string testEntryName;
            int testID;
            AddIndividualEntries(3);
            database.DbObjectModel.GetFirstEntry();
            GetCurrentEntryValue(out testEntryName, out testID);
            Assert.Equal(1, testID);
            Assert.Equal("Name0", testEntryName);
            database.DbObjectModel.NextEntry();
            GetCurrentEntryValue(out testEntryName, out testID);
            Assert.Equal(2, testID);
            Assert.Equal("Name1", testEntryName);
        }

        [Fact]
        public void GetPreviousEntry()
        {
            string testEntryName;
            int testID;
            AddIndividualEntries(4);
            GetCurrentEntryValue(out testEntryName, out testID);
            Assert.Equal(4, testID);
            Assert.Equal("Name3", testEntryName);
            database.DbObjectModel.PrevEntry();
            GetCurrentEntryValue(out testEntryName, out testID);
            Assert.Equal(3, testID);
            Assert.Equal("Name2", testEntryName);
        }


    }
}