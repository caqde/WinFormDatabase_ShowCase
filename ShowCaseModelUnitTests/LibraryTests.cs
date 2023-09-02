﻿using ShowCaseModel.DataTypes.Library;
using ShowCaseModelUnitTests.TestFixtures;
using ShowCaseModelUnitTests.TestTools;
using static LanguageExt.Prelude;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
            var check = match(from x in database.Library.GetAuthor(libraryAuthor.Id) select x, Succ: v => v, Fail: new LibraryAuthor());
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
            var TestData = match(from x in database.Library.GetAuthor(3) select x, Succ: v => v, Fail: new LibraryAuthor() );
            Assert.NotNull(TestData);
            Assert.Equal("Test3", TestData.Name);
            Assert.Equal("TestBiography3", TestData.Biography);
            TestData = match(from x in database.Library.GetAuthor(1) select x, Succ: v => v, Fail: new LibraryAuthor());
            Assert.NotNull(TestData);
            Assert.Equal("Test", TestData.Name);
            Assert.Equal("TestBiography", TestData.Biography);
            database.Library.GetAuthor(5).Match(success => TestData = success, failure => TestData = null);
            Assert.Null(TestData);
        }

        [Fact]
        public void AddPublisher()
        {
            LibraryPublisher libraryPublisher = new LibraryPublisher();
            libraryPublisher.Name = "Test";
            libraryPublisher.Description = "TestDescription";
            database.Library.AddPublisher(libraryPublisher);
            var check = match(from x in database.Library.GetPublisher(libraryPublisher.Id) select x, Succ: v => v, Fail: new LibraryPublisher() );
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
            var TestData = match (from x in database.Library.GetPublisher(3) select x, Succ: v => v, Fail: new LibraryPublisher());
            Assert.NotNull(TestData);
            Assert.Equal("Test3", TestData.Name);
            Assert.Equal("TestDescription3", TestData.Description);
            TestData = match (from x in database.Library.GetPublisher(1) select x, Succ: v => v, Fail: new LibraryPublisher());
            Assert.NotNull(TestData);
            Assert.Equal("Test", TestData.Name);
            Assert.Equal("TestDescription", TestData.Description);
            database.Library.GetPublisher(6).Match(success => TestData = success, failure => TestData = null);
            Assert.Null(TestData);
        }

        [Fact]
        public void AddBook()
        {
            AddAuthorToDatabase("Test", "TestBiography");
            AddPublisherToDatabase("Test", "TestDescription");
            var TestPublisher = match(from x in database.Library.GetPublisher(1) select x, Succ: v => v, Fail: new LibraryPublisher());
            var TestAuthor = match(from x in database.Library.GetAuthor(1) select x, Succ: v => v, Fail: new LibraryAuthor());
            Assert.NotNull(TestPublisher);
            Assert.NotNull(TestAuthor);
            LibraryBook book = new LibraryBook() { Description = "TestDescription", ISBN = 1, Title = "Test" };
            database.Library.AddBook(book, TestAuthor.Id, TestPublisher.Id);
            var TestBook = match(from x in database.Library.GetBook(book.Id) select x, Succ: v => v, Fail: new LibraryBook());
            Assert.NotNull(TestBook);
            Assert.Equal(book.Description, TestBook.Description);
            Assert.Equal(book.Title, TestBook.Title);
            Assert.Equal(book.ISBN, TestBook.ISBN);
        }

        [Fact]
        public void BorrowBook()
        {
            var patron = AddPatronToDatabase("Test", "TestAddress", 12345, "TestCity", "12345");
            var author = AddAuthorToDatabase("Test", "TestBiography");
            var publisher = AddPublisherToDatabase("Test", "TestDescription");
            var book = AddBookToDatabase("Test", "TestDescription", 1, author, publisher);
            database.Library.BorrowBook(patron.Id, book.Id, new TimeSpan(7,0,0,0,0));
            List<LibraryBorrowedBook> borrowedBooks = database.Library.GetBorrowedBooks(patron.Id);
            Assert.NotNull(borrowedBooks);
            Assert.NotEmpty(borrowedBooks);
            Assert.Single(borrowedBooks);
        }
        [Fact]
        public void GetBorrowedBooks()
        {
            var patron = AddPatronToDatabase("Test", "TestAddress", 12345, "TestCity", "12345");
            var author = AddAuthorToDatabase("Test", "TestBiography");
            var publisher = AddPublisherToDatabase("Test", "TestDescription");
            var book = AddBookToDatabase("Test", "TestDescription",1, author,publisher);
            var book2 = AddBookToDatabase("Test2", "TestDescription", 2, author, publisher);
            var book3 = AddBookToDatabase("Test3", "TestDescription", 3, author, publisher);
            TimeSpan week = new TimeSpan(7,0,0,0, 0);
            database.Library.BorrowBook(patron.Id, book.Id, week);
            database.Library.BorrowBook(patron.Id, book2.Id, week);
            database.Library.BorrowBook(patron.Id, book3.Id, week);
            List<LibraryBorrowedBook> borrowedBooks = database.Library.GetBorrowedBooks(patron.Id);
            Assert.NotNull(borrowedBooks);
            Assert.NotEmpty(borrowedBooks);
            Assert.Equal(3, borrowedBooks.Count);
            Assert.Collection(borrowedBooks, item => Assert.Equal(book.Id, item.BorrowedBook.Id), item => Assert.Equal(book2.Id, item.BorrowedBook.Id), item => Assert.Equal(book3.Id, item.BorrowedBook.Id));
        }

        [Fact]
        public void GetBook()
        {
            var author = AddAuthorToDatabase("Test", "TestBiography");
            var publisher = AddPublisherToDatabase("Test", "TestDescription");
            var book1 = AddBookToDatabase("Test", "TestDescription", 1, author, publisher);
            var book2 = AddBookToDatabase("Test2", "TestDescription2", 12, author, publisher);
            var book3 = AddBookToDatabase("Test3", "TestDescription3", 1234, author, publisher);
            var testBook1 = match(from x in database.Library.GetBook(book1.Id) select x, Succ: v => v, Fail: new LibraryBook());
            Assert.NotNull (testBook1);
            Assert.Equal (book1.Description, testBook1.Description);
            Assert.Equal (book1.Title, testBook1.Title);
            Assert.Equal (book1.ISBN, testBook1.ISBN);
            var testBook2 = match(from x in database.Library.GetBook (book3.Id) select x, Succ: v => v, Fail: new LibraryBook());
            Assert.NotNull (testBook2);
            Assert.Equal (book3.Description, testBook2.Description);
            Assert.Equal (book3.Title, testBook2.Title);
            Assert.Equal (book3.ISBN, testBook2.ISBN);
            LibraryBook testBook3 = new LibraryBook();
            database.Library.GetBook(6).Match(Success => testBook3 = Success, Fail => testBook3 = null);
            Assert.Null (testBook3);
        }

        [Fact]
        public void DeleteBook()
        {
            var author = AddAuthorToDatabase("Test", "TestBiography");
            var publisher = AddPublisherToDatabase("Test", "TestDescription");
            var book1 = AddBookToDatabase("Test", "TestDescription", 1, author, publisher);
            var book2 = AddBookToDatabase("Test2", "TestDescription2", 12, author, publisher);
            var result = match(from x in database.Library.RemoveBook(book1.Id) select x, Succ: v => v, Fail: false);
            LibraryBook testBook = new LibraryBook();
            database.Library.GetBook(book1.Id).Match(Success => testBook = Success, Fail => testBook = null);
            Assert.Null (testBook);
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

        [Fact]
        public void GetAuthorsBooks()
        {
            var publisher = AddPublisherToDatabase("Test", "TestDescription");
            var author1 = AddAuthorToDatabase("Test", "TestBiography");
            var author2 = AddAuthorToDatabase("Test", "TestBiography2");
            var book1author1 = AddBookToDatabase("Test", "TestDescription", 1, author1, publisher);
            var book2author1 = AddBookToDatabase("Test2", "TestDescription2", 2, author1, publisher);
            var book1author2 = AddBookToDatabase("Test3", "TestDescription3", 3, author2, publisher);
            var book2author2 = AddBookToDatabase("Test4", "TestDescription4", 4, author2, publisher);
            var book3author2 = AddBookToDatabase("Test5", "TestDescription5", 5, author2, publisher);
            var author1BookList = database.Library.GetAuthorBooks(author1.Id);
            var author2BookList = database.Library.GetAuthorBooks(author2.Id);
            Assert.NotNull(author1BookList);
            Assert.NotNull(author2BookList);
            Assert.NotEmpty(author1BookList);
            Assert.NotEmpty(author2BookList);
            Assert.Collection(author1BookList, i => Assert.Equal(book1author1.Title, i.Title), i => Assert.Equal(book2author1.Title, i.Title));
            Assert.Collection(author2BookList, i => Assert.Equal(book1author2.Description, i.Description), i => Assert.Equal(book2author2.Description, i.Description), i => Assert.Equal(book3author2.Description, i.Description));
        }

        [Fact]
        public void GetPublishersBooks()
        {
            var author = AddAuthorToDatabase("Test", "TestBiography");
            var publisher1 = AddPublisherToDatabase("Test", "TestDescription");
            var publisher2 = AddPublisherToDatabase("Test2", "TestDescription2");
            var book1pub1 = AddBookToDatabase("Test", "TestDescription", 1, author, publisher1);
            var book2pub1 = AddBookToDatabase("Test2", "TestDescription2", 2, author, publisher1);
            var book1pub2 = AddBookToDatabase("Test3", "TestDescription3", 3, author, publisher2);
            var book2pub2 = AddBookToDatabase("Test4", "TestDescription4", 4, author, publisher2);
            var book3pub2 = AddBookToDatabase("Test5", "TestDescription5", 5, author, publisher2);
            var pub1BookList = database.Library.GetPublisherBooks(publisher1.Id);
            var pub2BookList = database.Library.GetPublisherBooks(publisher2.Id);
            Assert.NotNull(pub1BookList);
            Assert.NotNull(pub2BookList);
            Assert.NotEmpty(pub1BookList);
            Assert.NotEmpty(pub2BookList);
            Assert.Collection(pub1BookList, item =>  Assert.Equal(book1pub1.Title, item.Title), item =>  Assert.Equal(book2pub1.Title,item.Title));
            Assert.Collection(pub2BookList, item => Assert.Equal(book1pub2.Description, item.Description), item => Assert.Equal(book2pub2.Description, item.Description), item => Assert.Equal(book3pub2.Description, item.Description));
        }

        [Fact]
        public void DeleteAuthor()
        {
            var author1 = AddAuthorToDatabase("Test", "TestBiography");
            var author2 = AddAuthorToDatabase("Test2", "TestBiography2");
            var author3 = AddAuthorToDatabase("Test3", "TestBiography3");
            var publisher = AddPublisherToDatabase("Test", "TestDescription");
            var book = AddBookToDatabase("Test", "Test Description", 1, author2, publisher);
            database.Library.RemoveAuthor(author1.Id).Match(success => Assert.True(success)
                                                            ,failure => Assert.Equal("true", failure.Message));
            database.Library.RemoveAuthor(author2.Id).Match(success => Assert.False(success),
                                                            failure => Assert.IsType<System.Exception>(failure));
            var TestAuthor2Get = new LibraryAuthor();
            database.Library.GetAuthor(author1.Id).Match(success => TestAuthor2Get = success, failure => TestAuthor2Get = null );
            Assert.Null(TestAuthor2Get);
        }

        [Fact]
        public void DeletePublisher()
        {
            var publisher1 = AddPublisherToDatabase("Test", "TestDescription");
            var publisher2 = AddPublisherToDatabase("Test2", "TestDescription2");
            var publisher3 = AddPublisherToDatabase("Test3", "TestDescription3");
            var author = AddAuthorToDatabase("Test", "TestBiography");
            var book = AddBookToDatabase("Test", "TestDescription", 1, author, publisher2);
            database.Library.RemovePublisher(publisher1.Id).Match(success => Assert.True(success),
                                                                failure => Assert.Equal("true", failure.Message));
            database.Library.RemovePublisher(publisher2.Id).Match(success => Assert.False(success),
                                                                   failure => Assert.IsType<System.Exception>(failure) );
            var TestPublisher2Get = new LibraryPublisher();
            database.Library.GetPublisher(publisher1.Id).Match(success => TestPublisher2Get = success, failure => TestPublisher2Get = null);
            Assert.Null(TestPublisher2Get);
        }
    }
}
