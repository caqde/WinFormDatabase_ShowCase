using ShowCaseModel.DataTypes.Library;
using ShowCaseModelUnitTests.TestFixtures;
using ShowCaseModelUnitTests.TestTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseModelUnitTests
{
    public class LibraryTests : IClassFixture<DatabaseFixtureLibrary>
    {
        readonly DatabaseFixtureLibrary database;

        public LibraryTests(DatabaseFixtureLibrary database)
        {
            this.database = database;
            DatabaseTracker.New(false);
        }

        private int AddAuthorToDatabase(string name, string Biography)
        {
            LibraryAuthor author = new LibraryAuthor() { Biography = Biography, Name = name };
            database.Library.AddAuthor(author);
            return author.Id;
        }

        private int AddPublisherToDatabase(string name, string Description)
        {
            LibraryPublisher publisher = new LibraryPublisher() { Description = Description, Name = name };
            database.Library.AddPublisher(publisher);
            return publisher.Id;
        }

        [Fact]
        public void AddAuthor()
        {
            LibraryAuthor libraryAuthor = new LibraryAuthor();
            libraryAuthor.Name = "Test";
            libraryAuthor.Biography = "TestBiography";
            database.Library.AddAuthor(libraryAuthor);
            var check = database.Library.GetAuthor(libraryAuthor.Id);
            Assert.NotNull(check);
            Assert.Equal(libraryAuthor.Name, check.Name);
            Assert.Equal(libraryAuthor.Biography, check.Biography);
        }

        [Fact]
        public void GetAuthor()
        {
            AddAuthorToDatabase("Test", "TestBiography");
            AddAuthorToDatabase("Test2", "TestBiography2");
            AddAuthorToDatabase("Test3", "TestBiography3");
            var TestData = database.Library.GetAuthor(3);
            Assert.NotNull(TestData);
            Assert.Equal("Test3", TestData.Name);
            Assert.Equal("TestBiography3", TestData.Biography);
            TestData = database.Library.GetAuthor(1);
            Assert.NotNull(TestData);
            Assert.Equal("Test", TestData.Name);
            Assert.Equal("TestBiography", TestData.Biography);
            TestData = database.Library.GetAuthor(5);
            Assert.Null(TestData);
        }

        [Fact]
        public void AddPublisher()
        {
            LibraryPublisher libraryPublisher = new LibraryPublisher();
            libraryPublisher.Name = "Test";
            libraryPublisher.Description = "TestDescription";
            database.Library.AddPublisher(libraryPublisher);
            var check = database.Library.GetPublisher(libraryPublisher.Id);
            Assert.NotNull(check);
            Assert.Equal(libraryPublisher.Name, check.Name);
            Assert.Equal(libraryPublisher.Description, check.Description);
        }

        [Fact]
        public void GetPublisher()
        {
            AddPublisherToDatabase("Test", "TestDescription");
            AddPublisherToDatabase("Test2", "TestDescription2");
            AddPublisherToDatabase("Test3", "TestDescription3");
            var TestData = database.Library.GetPublisher(3);
            Assert.NotNull(TestData);
            Assert.Equal("Test3", TestData.Name);
            Assert.Equal("TestDescription3", TestData.Description);
            TestData = database.Library.GetPublisher(1);
            Assert.NotNull(TestData);
            Assert.Equal("Test", TestData.Name);
            Assert.Equal("TestDescription", TestData.Description);
            TestData = database.Library.GetPublisher(6);
            Assert.Null(TestData);
        }
    }
}
