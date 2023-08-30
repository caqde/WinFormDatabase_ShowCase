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
    }
}
