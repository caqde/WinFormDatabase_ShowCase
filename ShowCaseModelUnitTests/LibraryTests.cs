using ShowCaseModel.DataTypes.Library;
using ShowCaseModelUnitTests.TestFixtures;
using ShowCaseModelUnitTests.TestTools;
using static LanguageExt.Prelude;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore_DBModels.Library;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Xml.Linq;
using LanguageExt.UnitsOfMeasure;

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

        private void AddBorrowedBook(int patronId, int bookId, TimeSpan time)
        {
            database.Library.BorrowBook(patronId, bookId, time).Match(pass => Assert.True(pass), Fail => Assert.Equal("", Fail.Message));
        }

        private AuthorDto AddAuthorToDatabase(string name, string Biography)
        {
            AuthorDto author = new AuthorDto() { Biography = Biography, Name = name };
            database.Library.AddAuthor(author).Match(pass => Assert.True(pass), fail => Assert.Equal("", fail.Message));
            return author;
        }

        private PublisherDto AddPublisherToDatabase(string name, string Description)
        {
            PublisherDto publisher = new PublisherDto() { Description = Description, Name = name };
            database.Library.AddPublisher(publisher).Match(pass => Assert.True(pass), fail => Assert.Equal("", fail.Message));
            return publisher;
        }

        private BookDto AddBookToDatabase(string title, string description, int ISBN, AuthorDto author, PublisherDto publisher)
        {
            BookDto book = new BookDto() { Title = title, Description = description, ISBN = ISBN };
            database.Library.AddBook(book, author.Id, publisher.Id).Match(pass => Assert.True(pass), fail => Assert.Equal("", fail.Message));
            return book;
        }

        private PatronDto AddPatronToDatabase(string name, string address, int postal, string city, string number)
        {
            PatronDto patron = new PatronDto() { Name = name, City = city, PhoneNumber = number, PostalCode = postal, StreetAddress = address };
            database.Library.AddPatron(patron).Match(pass => Assert.True(pass), fail => Assert.Equal("", fail.Message));
            return patron;
        }

        private AuthorDto? GetAuthorFromDatabase(int Id)
        {
            AuthorDto? Author = null;
            database.Library.GetAuthor(Id).Match(pass => Author = pass, fail => Author = null);
            return Author;
        }

        private BookDto? GetBookFromDatabase(int Id)
        {
            BookDto? Book = null;
            database.Library.GetBook(Id).Match(pass => Book = pass, fail => Book = null);
            return Book;
        }

        private PatronDto? GetPatronFromDatabase(int Id)
        {
            PatronDto? Patron = null;
            database.Library.GetPatron(Id).Match(pass =>  Patron = pass, fail => Patron = null);
            return Patron;
        }

        private PublisherDto? GetPublisherFromDatabase(int Id)
        {
            PublisherDto? Publisher = null;
            database.Library.GetPublisher(Id).Match(pass =>  Publisher = pass, fail => Publisher = null);
            return Publisher;
        }

        [Fact]
        public void AddAuthor()
        {
            AuthorDto libraryAuthor = new AuthorDto();
            libraryAuthor.Name = "Test";
            libraryAuthor.Biography = "TestBiography";
            database.Library.AddAuthor(libraryAuthor).Match(pass => Assert.True(pass), fail => Assert.Equal("", fail.Message));
            var check = GetAuthorFromDatabase(libraryAuthor.Id);
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
            var TestData = GetAuthorFromDatabase(3);
            Assert.NotNull(TestData);
            Assert.Equal("Test3", TestData.Name);
            Assert.Equal("TestBiography3", TestData.Biography);
            TestData = GetAuthorFromDatabase(1);
            Assert.NotNull(TestData);
            Assert.Equal("Test", TestData.Name);
            Assert.Equal("TestBiography", TestData.Biography);
            TestData = GetAuthorFromDatabase(5);
            Assert.Null(TestData);
        }

        [Fact]
        public void AddPublisher()
        {
            PublisherDto libraryPublisher = new PublisherDto();
            libraryPublisher.Name = "Test";
            libraryPublisher.Description = "TestDescription";
            database.Library.AddPublisher(libraryPublisher).Match(pass => Assert.True(pass), fail => Assert.Equal("", fail.Message));
            var check = GetPublisherFromDatabase(libraryPublisher.Id); 
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
            var TestData = GetPublisherFromDatabase(3);
            Assert.NotNull(TestData);
            Assert.Equal("Test3", TestData.Name);
            Assert.Equal("TestDescription3", TestData.Description);
            TestData = GetPublisherFromDatabase(1);
            Assert.NotNull(TestData);
            Assert.Equal("Test", TestData.Name);
            Assert.Equal("TestDescription", TestData.Description);
            TestData = GetPublisherFromDatabase(6);
            Assert.Null(TestData);
        }

        [Fact]
        public void AddBook()
        {
            AddAuthorToDatabase("Test", "TestBiography");
            AddPublisherToDatabase("Test", "TestDescription");
            var TestPublisher = GetPublisherFromDatabase(1);
            var TestAuthor = GetAuthorFromDatabase(1);
            Assert.NotNull(TestPublisher);
            Assert.NotNull(TestAuthor);
            var book = AddBookToDatabase("Test", "TestDescription", 1, TestAuthor, TestPublisher);
            var TestBook = GetBookFromDatabase(book.Id);
            Assert.NotNull(TestBook);
            Assert.Equal(book.Description, TestBook.Description);
            Assert.Equal(book.Title, TestBook.Title);
            Assert.Equal(book.ISBN, TestBook.ISBN);
        }

        [Fact]
        public void AddBookExceptions()
        {
            var author = AddAuthorToDatabase("Test", "TestBiography");
            var author2 = AddAuthorToDatabase("Test2", "TestBiography2");
            var publisher = AddPublisherToDatabase("Test", "TestDescription");
            var publisher2 = AddPublisherToDatabase("Test2", "TestDescription2");
            database.Library.RemoveAuthor(author.Id).Match(success => Assert.True(success)
                                                , failure => Assert.Equal("true", failure.Message));
            database.Library.RemovePublisher(publisher.Id).Match(success => Assert.True(success)
            , failure => Assert.Equal("true", failure.Message));
            BookDto book = new BookDto() { Title = "TestTitle", Description = "TestDescription", ISBN = 1 };
            database.Library.AddBook(book, author.Id, publisher.Id).Match(pass => Assert.False(pass), fail => Assert.IsType<Exception>(fail));
            database.Library.AddBook(book, author2.Id, publisher.Id).Match(pass => Assert.False(pass), fail => Assert.IsType<Exception>(fail));
            database.Library.AddBook(book, author.Id, publisher2.Id).Match(pass => Assert.False(pass), fail => Assert.IsType<Exception>(fail));
            database.Library.AddBook(book, 6, publisher.Id).Match(pass => Assert.False(pass), fail => Assert.IsType<Exception>(fail));
            database.Library.AddBook(book, author.Id, 6).Match(pass => Assert.False(pass), fail => Assert.IsType<Exception>(fail));
            database.Library.AddBook(book, 6, 6).Match(pass => Assert.False(pass), fail => Assert.IsType<Exception>(fail));
        }

        [Fact]
        public void BorrowBook()
        {
            var patron = AddPatronToDatabase("Test", "TestAddress", 12345, "TestCity", "12345");
            var patron2 = AddPatronToDatabase("Test2", "TestAddress2", 12356, "TestCity", "12356");
            var author = AddAuthorToDatabase("Test", "TestBiography");
            var publisher = AddPublisherToDatabase("Test", "TestDescription");
            var book = AddBookToDatabase("Test", "TestDescription", 1, author, publisher);
            AddBorrowedBook(patron.Id, book.Id, new TimeSpan(7, 0, 0, 0, 0));
            List<BorrowedBookDto> borrowedBooks = new List<BorrowedBookDto>();
            database.Library.GetBorrowedBooksByPatron(patron.Id).Match(pass => borrowedBooks = pass, fail => borrowedBooks = null);
            Assert.NotNull(borrowedBooks);
            Assert.NotEmpty(borrowedBooks);
            Assert.Single(borrowedBooks);
            database.Library.BorrowBook(patron2.Id, book.Id, new TimeSpan(7,0,0,0,0)).Match(pass => Assert.Fail("This book should already be borrowed"), Fail => Assert.IsType<System.Exception>(Fail));
            database.Library.BorrowBook(7, book.Id, new TimeSpan(7, 0, 0, 0, 0)).Match(pass => Assert.Fail("Patron should be invalid"), Fail => Assert.IsType<System.Exception>(Fail));
            database.Library.BorrowBook(7, 7, new TimeSpan(7, 0, 0, 0, 0)).Match(pass => Assert.Fail("Patron and Book should be invalid"), Fail => Assert.IsType<System.Exception>(Fail));
            database.Library.BorrowBook(patron2.Id, 7, new TimeSpan(7, 0, 0, 0, 0)).Match(pass => Assert.Fail("Book should be invalid"), Fail => Assert.IsType<System.Exception>(Fail));
        }
        [Fact]
        public void GetBorrowedBooksByPatron()
        {
            var patron = AddPatronToDatabase("Test", "TestAddress", 12345, "TestCity", "12345");
            var author = AddAuthorToDatabase("Test", "TestBiography");
            var publisher = AddPublisherToDatabase("Test", "TestDescription");
            var book = AddBookToDatabase("Test", "TestDescription",1, author,publisher);
            var book2 = AddBookToDatabase("Test2", "TestDescription", 2, author, publisher);
            var book3 = AddBookToDatabase("Test3", "TestDescription", 3, author, publisher);
            database.Library.GetBorrowedBooksByPatron(patron.Id).Match(pass => Assert.Empty(pass), fail => Assert.Equal("", fail.Message ));
            TimeSpan week = new TimeSpan(7,0,0,0, 0);
            AddBorrowedBook(patron.Id, book.Id, week);
            AddBorrowedBook(patron.Id, book2.Id, week);
            AddBorrowedBook(patron.Id, book3.Id, week);
            List<BorrowedBookDto> borrowedBooks = new List<BorrowedBookDto>();
            database.Library.GetBorrowedBooksByPatron(patron.Id).Match(pass => borrowedBooks = pass, fail => borrowedBooks = null);
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
            var testBook1 = GetBookFromDatabase(book1.Id);
            Assert.NotNull (testBook1);
            Assert.Equal (book1.Description, testBook1.Description);
            Assert.Equal (book1.Title, testBook1.Title);
            Assert.Equal (book1.ISBN, testBook1.ISBN);
            var testBook2 = GetBookFromDatabase(book3.Id);
            Assert.NotNull (testBook2);
            Assert.Equal (book3.Description, testBook2.Description);
            Assert.Equal (book3.Title, testBook2.Title);
            Assert.Equal (book3.ISBN, testBook2.ISBN);
            var testBook3 = GetBookFromDatabase(6);
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
            var testBook = GetBookFromDatabase(book1.Id);
            Assert.Null (testBook);
        }

        [Fact]
        public void DeleteBookExceptions()
        {
            var author = AddAuthorToDatabase("Test", "TestBiography");
            var publisher = AddPublisherToDatabase("Test", "TestDescription");
            var patron = AddPatronToDatabase("Test", "TestAddress", 12345, "TestCity", "12345");
            var book1 = AddBookToDatabase("Test", "TestDescription", 1, author, publisher);
            var book2 = AddBookToDatabase("Test2", "TestDescription2", 2, author, publisher);
            TimeSpan week = TimeSpan.FromDays(7);
            AddBorrowedBook(patron.Id, book2.Id, week);
            database.Library.RemoveBook(book1.Id).Match(pass => Assert.True(pass), fail => Assert.Equal("", fail.Message));
            database.Library.RemoveBook(book1.Id).Match(pass => Assert.False(pass), fail => Assert.IsType<System.Exception>(fail));
            database.Library.RemoveBook(book2.Id).Match(pass => Assert.False(pass), fail => Assert.IsType<System.Exception>(fail));
            database.Library.RemoveBook(7).Match(pass => Assert.False(pass), fail => Assert.IsType<System.Exception>(fail));
        }

        [Fact]
        public void AddPatron()
        {
            var patron = AddPatronToDatabase("Test", "TestAddress", 12345, "TestCity", "12345");
            var testData = GetPatronFromDatabase(patron.Id);
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
            var TestPatron1 = GetPatronFromDatabase (patron1.Id);
            Assert.NotNull(TestPatron1);
            Assert.Equal(patron1.Name, TestPatron1.Name);
            Assert.Equal(patron1.City, TestPatron1.City);
            Assert.Equal(patron1.PostalCode, TestPatron1.PostalCode);
            var TestPatron2 = GetPatronFromDatabase(patron3.Id);
            Assert.NotNull(TestPatron2);
            Assert.Equal(patron3.PhoneNumber, TestPatron2.PhoneNumber);
            Assert.Equal(patron3.Name, TestPatron2.Name);
            Assert.Equal(patron3.StreetAddress, TestPatron2.StreetAddress);
            var TestPatron3 = GetPatronFromDatabase(6);
            Assert.Null(TestPatron3);
        }

        [Fact]
        public void GetAuthorsBooks()
        {
            var publisher = AddPublisherToDatabase("Test", "TestDescription");
            var author1 = AddAuthorToDatabase("Test", "TestBiography");
            var author2 = AddAuthorToDatabase("Test", "TestBiography2");
            var author3 = AddAuthorToDatabase("Test3", "TestBiography3");
            var book1author1 = AddBookToDatabase("Test", "TestDescription", 1, author1, publisher);
            var book2author1 = AddBookToDatabase("Test2", "TestDescription2", 2, author1, publisher);
            var book1author2 = AddBookToDatabase("Test3", "TestDescription3", 3, author2, publisher);
            var book2author2 = AddBookToDatabase("Test4", "TestDescription4", 4, author2, publisher);
            var book3author2 = AddBookToDatabase("Test5", "TestDescription5", 5, author2, publisher);
            var author1BookList = match(from x in database.Library.GetAuthorBooks(author1.Id) select x, Succ: x => x, Fail: new List<BookDto>());
            var author2BookList = match(from x in database.Library.GetAuthorBooks(author2.Id) select x, Succ: x => x, Fail: new List<BookDto>());
            Assert.NotNull(author1BookList);
            Assert.NotNull(author2BookList);
            Assert.NotEmpty(author1BookList);
            Assert.NotEmpty(author2BookList);
            Assert.Collection(author1BookList, i => Assert.Equal(book1author1.Title, i.Title), i => Assert.Equal(book2author1.Title, i.Title));
            Assert.Collection(author2BookList, i => Assert.Equal(book1author2.Description, i.Description), i => Assert.Equal(book2author2.Description, i.Description), i => Assert.Equal(book3author2.Description, i.Description));
            database.Library.GetAuthorBooks(author3.Id).Match(pass => Assert.Empty(pass), Fail => Assert.Equal("", Fail.Message));
            database.Library.GetAuthorBooks(6).Match(pass => Assert.Fail("Should be an Invalid Author"), fail => Assert.IsType<System.Exception>(fail));
        }

        [Fact]
        public void GetPublishersBooks()
        {
            var author = AddAuthorToDatabase("Test", "TestBiography");
            var publisher1 = AddPublisherToDatabase("Test", "TestDescription");
            var publisher2 = AddPublisherToDatabase("Test2", "TestDescription2");
            database.Library.GetPublisherBooks(publisher1.Id).Match(pass => Assert.Empty(pass), fail => Assert.Equal("", fail.Message));
            var book1pub1 = AddBookToDatabase("Test", "TestDescription", 1, author, publisher1);
            var book2pub1 = AddBookToDatabase("Test2", "TestDescription2", 2, author, publisher1);
            var book1pub2 = AddBookToDatabase("Test3", "TestDescription3", 3, author, publisher2);
            var book2pub2 = AddBookToDatabase("Test4", "TestDescription4", 4, author, publisher2);
            var book3pub2 = AddBookToDatabase("Test5", "TestDescription5", 5, author, publisher2);
            var pub1BookList = match(from x in database.Library.GetPublisherBooks(publisher1.Id) select x, Succ: x => x, Fail: new List<BookDto>());
            var pub2BookList = match(from x in database.Library.GetPublisherBooks(publisher2.Id) select x, Succ: x => x, Fail: new List<BookDto>());
            Assert.NotNull(pub1BookList);
            Assert.NotNull(pub2BookList);
            Assert.NotEmpty(pub1BookList);
            Assert.NotEmpty(pub2BookList);
            Assert.Collection(pub1BookList, item =>  Assert.Equal(book1pub1.Title, item.Title), item =>  Assert.Equal(book2pub1.Title,item.Title));
            Assert.Collection(pub2BookList, item => Assert.Equal(book1pub2.Description, item.Description), item => Assert.Equal(book2pub2.Description, item.Description), item => Assert.Equal(book3pub2.Description, item.Description));
            database.Library.GetPublisherBooks(7).Match(pass => Assert.Fail("Should be an Invalid Publisher ID"), Fail => Assert.IsType<System.Exception>(Fail));
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
            database.Library.RemoveBook(book.Id).Match(success => Assert.True(success), fail =>  Assert.Equal("true", fail.Message));
            database.Library.RemoveAuthor(author2.Id).Match(success => Assert.True(success), fail => Assert.Equal("false", fail.Message));
            database.Library.RemoveAuthor(6).Match(success => Assert.False(success), fail => Assert.IsType<System.Exception>(fail));
            var TestAuthor2Get = GetAuthorFromDatabase(author1.Id);
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
            var TestPublisher1Get = GetPublisherFromDatabase(publisher1.Id);
            Assert.Null(TestPublisher1Get);
            database.Library.RemoveBook(book.Id).Match(success => Assert.True(success), failure =>  Assert.Equal("true", failure.Message));
            database.Library.RemovePublisher(publisher2.Id).Match(success => Assert.True(success), failure => Assert.Equal("true", failure.Message));
            database.Library.RemovePublisher(6).Match(success => Assert.False(success), failure => Assert.IsType<System.Exception>(failure) );
        }

        [Fact]
        public void DeletePatron()
        {
            var patron = AddPatronToDatabase("Test", "TestAddress", 12345, "TestCity", "12345");
            var testPatron = GetPatronFromDatabase(patron.Id);
            Assert.NotNull(testPatron);
            database.Library.RemovePatron(testPatron.Id).Match(Success => Assert.True(Success),
                                                                Failure => Assert.Equal("", Failure.Message));
            var NullPatron = GetPatronFromDatabase(patron.Id);
            Assert.Null(NullPatron);
        }

        [Fact]
        public void DeletePatronExceptions()
        {
            var patron = AddPatronToDatabase("Test", "TestAddress", 12345, "TestCity", "12345");
            var author = AddAuthorToDatabase("Test", "TestBiography");
            var publisher = AddPublisherToDatabase("Test", "TestDescription");
            var book = AddBookToDatabase("Test", "TestDescription", 1, author, publisher);
            TimeSpan week = TimeSpan.FromDays(7);
            AddBorrowedBook(patron.Id, book.Id, week);
            database.Library.RemovePatron(patron.Id).Match(Success => Assert.False(Success), Fail => Assert.IsType<System.Exception>(Fail));
            database.Library.RemovePatron(8).Match(Success => Assert.False(Success), Fail => Assert.IsType<System.Exception>(Fail));
        }

        [Fact]
        public void DeleteBorrowedBook()
        {
            var patron = AddPatronToDatabase("Test", "TestAddress", 12345, "TestCity", "12345");
            var author = AddAuthorToDatabase("Test", "TestBiography");
            var publisher = AddPublisherToDatabase("Test", "TestDescription");
            var book1 = AddBookToDatabase("Test", "TestDescription", 1, author, publisher);
            var book2 = AddBookToDatabase("Test2", "TestDescription2", 2, author, publisher);
            var book3 = AddBookToDatabase("Test3", "TestDescription3", 3, author, publisher);
            TimeSpan week = new TimeSpan(7, 0, 0, 0);
            AddBorrowedBook(patron.Id, book1.Id, week);
            AddBorrowedBook(patron.Id, book2.Id, week);
            AddBorrowedBook(patron.Id, book3.Id, week);
            var bookList = match(from x in database.Library.GetBorrowedBooksByPatron(patron.Id) select x, Succ: x => x, Fail: new List<BorrowedBookDto>());
            Assert.NotEmpty(bookList);
            Assert.Equal(3, bookList.Count);
            database.Library.RemoveBorrowedBook(bookList[1].Id).Match(pass => Assert.True(pass), fail => Assert.Equal("", fail.Message));
            var bookList2 = match(from x in database.Library.GetBorrowedBooksByPatron(patron.Id) select x, Succ: x => x, Fail: new List<BorrowedBookDto>());
            Assert.NotEmpty(bookList2);
            Assert.Equal(2, bookList2.Count);
            Assert.Collection(bookList2, book => Assert.Equal(book1.Id, book.Id), book => Assert.Equal(book3.Id,book.Id));
            database.Library.RemoveBorrowedBook(6).Match(pass => Assert.Fail("There should not be a book at this location"), fail => Assert.IsType<System.Exception>(fail));
        }

        [Fact]
        public void GetBorrowedBooksList()
        {
            database.Library.GetBorrowedBooksList().Match(pass => Assert.Null(pass), fail => Assert.IsType<System.Exception>(fail));
            var patron = AddPatronToDatabase("Test", "TestAddress", 12345, "TestCity", "12345");
            var patron2 = AddPatronToDatabase("Test2", "TestAddress2", 12345, "TestCity", "1345");
            var author = AddAuthorToDatabase("Test", "TestBiography");
            var publisher = AddPublisherToDatabase("Test", "TestDescription");
            var book1 = AddBookToDatabase("Test1", "TestDescription", 1, author, publisher);
            var book2 = AddBookToDatabase("Test2", "TestDescription2", 2, author, publisher);
            var book3 = AddBookToDatabase("Test3", "TestDescription3", 3, author, publisher);
            TimeSpan week = TimeSpan.FromDays(7);
            AddBorrowedBook(patron.Id, book1.Id, week);
            AddBorrowedBook(patron.Id, book2.Id, week);
            AddBorrowedBook(patron2.Id, book3.Id, week);
            var borrowedBooks = new List<BorrowedBookDto>();
            database.Library.GetBorrowedBooksList().Match(pass => borrowedBooks = pass, Fail => borrowedBooks = null);
            Assert.NotNull(borrowedBooks);
            Assert.NotEmpty(borrowedBooks);
            Assert.Equal(3, borrowedBooks.Count);
            
        }

        [Fact]
        public void GetPublisherList()
        {
            var publisher1 = AddPublisherToDatabase("Test", "TestDescription");
            database.Library.RemovePublisher(publisher1.Id).Match(pass => Assert.True(pass), fail => Assert.Equal("", fail.Message));
            database.Library.GetPublisherList().Match(pass => Assert.Fail("This should be empty as all publishers have been deleted"), fail => Assert.IsType<System.Exception>(fail));
            var publisher2 = AddPublisherToDatabase("Test2", "TestDescription2");
            var publisher3 = AddPublisherToDatabase("Test3", "TestDescription3");
            var publisher4 = AddPublisherToDatabase("Test4", "TestDescription4");
            var publisherList = new List<PublisherDto>();
            database.Library.GetPublisherList().Match(pass => publisherList = pass, fail => publisherList = null);
            Assert.NotNull(publisherList);
            Assert.NotEmpty(publisherList);
            Assert.Collection(publisherList, item => Assert.Equal(publisher1.Name, item.Name), item => Assert.Equal(publisher2.Name, item.Name)
                                             , item => Assert.Equal(publisher3.Name, item.Name), item => Assert.Equal(publisher4.Name, item.Name));
        }

        [Fact]
        public void GetEmptyPublisherList()
        {
            database.Library.GetPublisherList().Match(pass => Assert.Empty(pass), fail => Assert.IsType<System.Exception>(fail));
        }

        [Fact]
        public void GetAuthorList()
        {
            database.Library.GetAuthorList().Match(pass => Assert.Fail("This should be empty"), fail => Assert.IsType<System.Exception>(fail));
            var author1 = AddAuthorToDatabase("Test", "TestDescription");
            database.Library.RemoveAuthor(author1.Id).Match(pass => Assert.True(pass), fail => Assert.Equal("", fail.Message));
            database.Library.GetAuthorList().Match(pass => Assert.Fail("This should be empty as all authors are deleted"), fail => Assert.IsType<System.Exception>(fail));
            var author2 = AddAuthorToDatabase("Test2", "TestDescription");
            var author3 = AddAuthorToDatabase("Test3", "TestDescription");
            var author4 = AddAuthorToDatabase("Test4", "TestDescription");
            List<AuthorDto> authorList = new List<AuthorDto>();
            database.Library.GetAuthorList().Match(pass =>  authorList = pass, Fail =>  Assert.Equal("", Fail.Message));
            Assert.NotNull(authorList);
            Assert.NotEmpty(authorList);
            Assert.Equal(4, authorList.Count);
        }

        [Fact]
        public void GetBookList()
        {
            database.Library.GetBookList().Match(pass => Assert.Fail("This should be Empty"), fail => Assert.IsType<System.Exception>(fail));
            var author = AddAuthorToDatabase("Test", "TestBiography");
            var publisher = AddPublisherToDatabase("Test", "TestDescription");
            var book1 = AddBookToDatabase("Test", "TestDescription", 1, author, publisher);
            database.Library.RemoveBook(book1.Id).Match(pass => Assert.True(pass), fail => Assert.Equal("", fail.Message));
            database.Library.GetBookList().Match(pass => Assert.Fail("List should be Empty due to everything being deleted"), fail => Assert.IsType<System.Exception>(fail));
            var book2 = AddBookToDatabase("Test2","TestDescription", 2, author, publisher);
            var book3 = AddBookToDatabase("Test3", "TestDescription", 3, author, publisher);
            var book4 = AddBookToDatabase("Test4", "TestDescription", 4, author, publisher);
            var book5 = AddBookToDatabase("Test5", "TestDescription", 5, author, publisher);
            var bookList = new List<BookDto>();
            database.Library.GetBookList().Match(pass => bookList = pass, fail => Assert.Equal("", fail.Message));
            Assert.NotEmpty(bookList);
            Assert.Equal(4, bookList.Count);
        }

        [Fact]
        public void GetPatronList()
        {
            database.Library.GetPatronList().Match(pass => Assert.Fail("This should be empty"), fail => Assert.IsType<System.Exception>(fail));
            var patron1 = AddPatronToDatabase("Test", "TestAddress", 12345, "TestCity", "12345");
            database.Library.RemovePatron(patron1.Id).Match(pass => Assert.True(pass), fail => Assert.Equal("", fail.Message));
            database.Library.GetPatronList().Match(pass => Assert.Fail("This should be empty as all patrons have been deleted"), fail => Assert.IsType<System.Exception>(fail));
            var patron2 = AddPatronToDatabase("Test2", "TestAddress2", 12345, "TestCity", "12345");
            var patron3 = AddPatronToDatabase("Test3", "TestAddress3", 12345, "TestCity", "12345");
            var patron4 = AddPatronToDatabase("Test4", "TestAddress4", 12345, "TestCity", "12345");
            var patron5 = AddPatronToDatabase("Test5", "TestAddress5", 12345, "TestCity", "12345");
            var patronList = new List<PatronDto>();
            database.Library.GetPatronList().Match(pass => patronList = pass, fail => Assert.Equal("", fail.Message));
            Assert.NotEmpty(patronList);
            Assert.Equal(4, patronList.Count);
        }
    }
}
