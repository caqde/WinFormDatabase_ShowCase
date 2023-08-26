using ShowCaseModelUnitTests.TestFixtures;
using ShowCaseModelUnitTests.TestTools;

namespace ShowCaseModelUnitTests
{
    public class dbObjectModelTests : IClassFixture<DatabaseFixture>
    {
        readonly DatabaseFixture database;

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
            testId = database.DbObjectModel.GetID();
        }


        [Fact]
        public void GetIDEmptyDatabase()
        {
            database.DbObjectModel.GetFirstEntry();
            int testInt = database.DbObjectModel.GetID();
            Assert.Equal(1, testInt);
        }

        [Fact]
        public void AddEntryDatabase()
        {
            AddIndividualEntries(2);
            string testString = database.DbObjectModel.GetName();
            int testInt = database.DbObjectModel.GetID();
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
            int testInt = database.DbObjectModel.GetID();
            Assert.Equal(1, testInt);
            Assert.Equal("NULL", testString);
        }

        [Fact]
        public void RemoveNullDatabaseEntry()
        {
            database.DbObjectModel.DeleteEntry();
            string testString = database.DbObjectModel.GetName();
            int testInt = database.DbObjectModel.GetID();
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
        public void GetNextNullEntry()
        {
            string testEntryName;
            int testID;
            AddIndividualEntries(3);
            GetCurrentEntryValue(out testEntryName,out testID);
            Assert.Equal(3, testID);
            Assert.Equal("Name2", testEntryName);
            database.DbObjectModel.NextEntry();
            GetCurrentEntryValue(out testEntryName, out testID);
            Assert.Equal(3, testID);
            Assert.Equal("Name2", testEntryName);
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

        [Fact]
        public void GetPreviousNullEntry()
        {
            string testEntryName;
            int testID;
            AddIndividualEntries(2);
            database.DbObjectModel.GetFirstEntry();
            GetCurrentEntryValue(out testEntryName, out testID);
            Assert.Equal(1, testID);
            Assert.Equal("Name0", testEntryName);
            database.DbObjectModel.PrevEntry();
            GetCurrentEntryValue(out testEntryName, out testID);
            Assert.Equal(1, testID);
            Assert.Equal("Name0", testEntryName);
        }

        [Fact]
        public void SetEntryName()
        {
            string testEntryName;
            int testID;
            AddIndividualEntries(2);
            GetCurrentEntryValue(out testEntryName, out testID);
            Assert.Equal(2, testID);
            Assert.Equal("Name1", testEntryName);
            database.DbObjectModel.SetName("NewName1");
            GetCurrentEntryValue(out testEntryName, out testID);
            Assert.Equal("NewName1", testEntryName);
            database.DbObjectModel.PrevEntry();
            GetCurrentEntryValue(out testEntryName, out testID);
            Assert.Equal("Name0", testEntryName);
            Assert.Equal(1, testID);
            database.DbObjectModel.SetName("NewName0");
            GetCurrentEntryValue(out testEntryName, out testID);
            Assert.Equal("NewName0", testEntryName);
            database.DbObjectModel.NextEntry();
            GetCurrentEntryValue(out testEntryName, out testID);
            Assert.Equal("NewName1", testEntryName);
        }

        [Fact]
        public void GetEntries()
        {
            AddIndividualEntries(5);
            Dictionary<int, string> entries = database.DbObjectModel.GetEntries(1, 5);
            int ID = 0;
            foreach (var entry in entries)
            {
                Assert.Equal(entry.Value, "Name"+ID.ToString());
                ID++;
                Assert.Equal(entry.Key, ID);
            }
        }

        [Fact]
        public void GetEntriesWithInvalidNumbers()
        {
            AddIndividualEntries(5);
            Dictionary<int, string> entries = database.DbObjectModel.GetEntries(3, 11);
            int ID = 2;
            foreach (var entry in entries)
            {
                Assert.Equal("Name" + ID.ToString(), entry.Value);
                ID++;
                Assert.Equal(ID, entry.Key);
            }
        }

        [Fact]
        public void GetAllEntries()
        {
            AddIndividualEntries(9);
            Dictionary<int, string> entries = database.DbObjectModel.GetAllEntries();
            int ID = 0;
            foreach (var entry in entries)
            {
                Assert.Equal("Name" + ID.ToString(), entry.Value);
                ID++;
                Assert.Equal(ID, entry.Key);
            }
        }

        [Fact]
        public void SetEntries()
        {
            AddIndividualEntries(9);
            Dictionary<int, string> entries = database.DbObjectModel.GetAllEntries();
            int ID = 0;
            foreach(var entry in entries)
            {
                entries[entry.Key] = "Changed" + ID.ToString();
                ID++;
            }
            database.DbObjectModel.SetEntries(entries);
            Dictionary<int, string> ChangedEntries = database.DbObjectModel.GetAllEntries();
            foreach(var entry in ChangedEntries)
            {
                Assert.Equal(entries[entry.Key], entry.Value);
            }

        }
    }
}