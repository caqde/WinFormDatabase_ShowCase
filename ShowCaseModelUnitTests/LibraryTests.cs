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

        private LibraryAuthor AddAuthorToDatabase(string name, string Biography)
        {
            LibraryAuthor author = new LibraryAuthor() { Biography = Biography, Name = name };
            database.Library.AddAuthor(author);
            return author;
        }

        private LibraryPublisher AddPublisherToDatabase(string name, string Description)
        {
            LibraryPublisher publisher = new LibraryPublisher() { Description = Description, Name = name };
            database.Library.AddPublisher(publisher);
            return publisher;
        }

        private LibraryBook AddBookToDatabase(string name, string description, int ISBN, LibraryAuthor author, LibraryPublisher publisher)
        {
            LibraryBook book = new LibraryBook() { Title = name, Description = description, ISBN = ISBN };
            database.Library.AddBook(book, author.Id, publisher.Id);
            return book;
        }

        private LibraryPatron AddPatronToDatabase(string name, string address, int postal, string city, string number)
        {
            LibraryPatron patron = new LibraryPatron() { Name = name, City = city, PhoneNumber = number, PostalCode = postal, StreetAddress = address };
            database.Library.AddPatron(patron);
            return patron;
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

        [Fact]
        public void AddBook()
        {
            AddAuthorToDatabase("Test", "TestBiography");
            AddPublisherToDatabase("Test", "TestDescription");
            var TestPublisher = database.Library.GetPublisher(1);
            var TestAuthor = database.Library.GetAuthor(1);
            Assert.NotNull(TestPublisher);
            Assert.NotNull(TestAuthor);
            LibraryBook book = new LibraryBook() { Description = "TestDescription", ISBN = 1, Title = "Test" };
            database.Library.AddBook(book, TestAuthor.Id, TestPublisher.Id);
            var TestBook = database.Library.GetBook(book.Id);
            Assert.NotNull(TestBook);
            Assert.Equal(book.Description, TestBook.Description);
            Assert.Equal(book.Title, TestBook.Title);
            Assert.Equal(book.ISBN, TestBook.ISBN);
        }

        [Fact]
        public void GetBook()
        {
            var author = AddAuthorToDatabase("Test", "TestBiography");
            var publisher = AddPublisherToDatabase("Test", "TestDescription");
            var book1 = AddBookToDatabase("Test", "TestDescription", 1, author, publisher);
            var book2 = AddBookToDatabase("Test2", "TestDescription2", 12, author, publisher);
            var book3 = AddBookToDatabase("Test3", "TestDescription3", 1234, author, publisher);
            var testBook1 = database.Library.GetBook(book1.Id);
            Assert.NotNull (testBook1);
            Assert.Equal (book1.Description, testBook1.Description);
            Assert.Equal (book1.Title, testBook1.Title);
            Assert.Equal (book1.ISBN, testBook1.ISBN);
            var testBook2 = database.Library.GetBook (book3.Id);
            Assert.NotNull (testBook2);
            Assert.Equal (book3.Description, testBook2.Description);
            Assert.Equal (book3.Title, testBook2.Title);
            Assert.Equal (book3.ISBN, testBook2.ISBN);
            var testBook3 = database.Library.GetBook(6);
            Assert.Null (testBook3);
        }

        [Fact]
        public void AddPatron()
        {
            LibraryPatron patron = new LibraryPatron();
            patron.StreetAddress = "TestAddress";
            patron.PhoneNumber = "12345";
            patron.City = "TestCity";
            patron.Name = "Test";
            patron.PostalCode = 12345;
            database.Library.AddPatron(patron);
            var testData = database.Library.GetPatron(patron.Id);
            Assert.NotNull (testData);
            Assert.Equal(patron.Id, testData.Id);
            Assert.Equal(patron.Name, testData.Name);
            Assert.Equal(patron.City, testData.City);
            Assert.True (testData.PhoneNumber == testData.PhoneNumber);
            Assert.Equal(patron.PostalCode, testData.PostalCode);
            Assert.Equal(patron.StreetAddress, testData.StreetAddress);
        }

        [Fact]
        public void GetPatron()
        {
            var patron1 = AddPatronToDatabase("Test", "TestAddress", 12345, "TestCity", "12345");
            var patron2 = AddPatronToDatabase("Test2", "TestAddress2", 23456, "TestCity2", "23456");
            var patron3 = AddPatronToDatabase("Test3", "TestAddress3", 34567, "TestCity3", "34567");
            var TestPatron1 = database.Library.GetPatron(patron1.Id);
            Assert.NotNull(TestPatron1);
            Assert.Equal(patron1.Name, TestPatron1.Name);
            Assert.Equal(patron1.City, TestPatron1.City);
            Assert.Equal(patron1.PostalCode, TestPatron1.PostalCode);
            var TestPatron2 = database.Library.GetPatron(patron3.Id);
            Assert.NotNull(TestPatron2);
            Assert.Equal(patron3.PhoneNumber, TestPatron2.PhoneNumber);
            Assert.Equal(patron3.Name, TestPatron2.Name);
            Assert.Equal(patron3.StreetAddress, TestPatron2.StreetAddress);
            var TestPatron3 = database.Library.GetPatron(6);
            Assert.Null(TestPatron3);
        }
    }
}
