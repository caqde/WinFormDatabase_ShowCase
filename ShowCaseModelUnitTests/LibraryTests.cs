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
            
        }
    }
}
