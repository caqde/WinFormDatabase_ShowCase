using CommunityToolkit.Mvvm.Messaging;
using LanguageExt;
using LanguageExt.Common;
using Moq;
using ShowCaseModel;
using ShowCaseModel.DataTypes.Library;
using ShowCaseModel.Models;
using ShowCaseViewModel.Library;
using ShowCaseViewModel.Messages.LibraryMessages;
using ShowCaseViewModel.Messages.Universal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseViewModelUnitTests.LibraryViewModelUnitTests
{
    public class LibraryPublisherViewModelUnitTests
    {
        public Mock<ILibrary> mockILibrary;

        public LibraryPublisherViewModelUnitTests() 
        {
            SetupDbObjectMoq();
        }

        private void SetupDbObjectMoq()
        {
            ShowCaseInstance showcase = ShowCaseInstance.Instance;
            if (mockILibrary is null)
            {
                mockILibrary = new Mock<ILibrary>();
            }
            else
            {
                mockILibrary.Reset();
            }
            SetupLibraryBoolReturn();
            SetupLibraryValueReturn();
            showcase.SetupLibrary(mockILibrary.Object);
        }

        private void SetupLibraryBoolReturn()
        {
            mockILibrary
                .Setup(x => x.AddAuthor(It.IsAny<AuthorDto>()))
                .Returns(() => true);
            mockILibrary
                .Setup(x => x.AddBook(It.IsAny<BookDto>()))
                .Returns(() => true);
            mockILibrary
                .Setup(x => x.AddPatron(It.IsAny<PatronDto>()))
                .Returns(() => true);
            mockILibrary
                .Setup(x => x.AddPublisher(It.IsAny<PublisherDto>()))
                .Returns(() => true);
            mockILibrary
                .Setup(x => x.BorrowBook(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<TimeSpan>()))
                .Returns(() => true);
            mockILibrary
                .Setup(x => x.RemoveAuthor(It.IsAny<int>()))
                .Returns(() => true);
            mockILibrary
                .Setup(x => x.RemoveBook(It.IsAny<int>()))
                .Returns(() => true);
            mockILibrary
                .Setup(x => x.RemoveBorrowedBook(It.IsAny<int>()))
                .Returns(() => true);
            mockILibrary
                .Setup(x => x.RemovePatron(It.IsAny<int>()))
                .Returns(() => true);
            mockILibrary
                .Setup(x => x.RemovePublisher(It.IsAny<int>()))
                .Returns(() => true);
        }

        private readonly AuthorDto authorDto1 = new AuthorDto() { Biography = "TestBiography", Id = 1, Name = "Test" };
        private readonly AuthorDto authorDto2 = new AuthorDto() { Biography = "TestBiography", Id = 2, Name = "Test2" };
        private readonly AuthorDto authorDto3 = new AuthorDto() { Biography = "TestBiography", Id = 3, Name = "Test3" };
        private readonly AuthorDto authorDto4 = new AuthorDto() { Biography = "TestBiography", Id = 4, Name = "Test4" };

        private readonly BookDto bookDto1 = new BookDto() { Description = "TestDescription", Id = 1, Title = "Test", ISBN = 12345 };
        private readonly BookDto bookDto2 = new BookDto() { Description = "TestDescription", Id = 2, Title = "Test2", ISBN = 12345 };
        private readonly BookDto bookDto3 = new BookDto() { Description = "TestDescription", Id = 3, Title = "Test3", ISBN = 12345 };
        private readonly BookDto bookDto4 = new BookDto() { Description = "TestDescription", Id = 4, Title = "Test4", ISBN = 12345 };

        private readonly PublisherDto publisherDto1 = new PublisherDto() { Description = "TestDescription", Id = 1, Name = "Test" };
        private readonly PublisherDto publisherDto2 = new PublisherDto() { Description = "TestDescription", Id = 2, Name = "Test2" };
        private readonly PublisherDto publisherDto3 = new PublisherDto() { Description = "TestDescription", Id = 3, Name = "Test3" };
        private readonly PublisherDto publisherDto4 = new PublisherDto() { Description = "TestDescription", Id = 4, Name = "Test4" };

        private readonly PatronDto patronDto1 = new PatronDto() { Name = "Test", Id = 1, City = "TestCity", PhoneNumber = "12345", PostalCode = 12345, StreetAddress = "TestAddress" };
        private readonly PatronDto patronDto2 = new PatronDto() { Name = "Test2", Id = 2, City = "TestCity", PhoneNumber = "12345", PostalCode = 12345, StreetAddress = "TestAddress" };
        private readonly PatronDto patronDto3 = new PatronDto() { Name = "Test3", Id = 3, City = "TestCity", PhoneNumber = "12345", PostalCode = 12345, StreetAddress = "TestAddress" };
        private readonly PatronDto patronDto4 = new PatronDto() { Name = "Test4", Id = 4, City = "TestCity", PhoneNumber = "12345", PostalCode = 12345, StreetAddress = "TestAddress" };

        private void SetupLibraryValueReturn()
        {
            BorrowedBookDto borrowedBookDto1 = new BorrowedBookDto { BorrowedBook = bookDto1, BorrowedDate = DateTime.Now, DueDate = DateTime.Now + TimeSpan.FromDays(7) };
            BorrowedBookDto borrowedBookDto2 = new BorrowedBookDto { BorrowedBook = bookDto2, BorrowedDate = DateTime.Now, DueDate = DateTime.Now + TimeSpan.FromDays(7) };
            BorrowedBookDto borrowedBookDto3 = new BorrowedBookDto { BorrowedBook = bookDto3, BorrowedDate = DateTime.Now, DueDate = DateTime.Now + TimeSpan.FromDays(7) };
            BorrowedBookDto borrowedBookDto4 = new BorrowedBookDto { BorrowedBook = bookDto4, BorrowedDate = DateTime.Now, DueDate = DateTime.Now + TimeSpan.FromDays(7) };


            mockILibrary
                .SetupSequence(x => x.GetAuthor(It.IsAny<int>()))
                .Returns(() => authorDto1)
                .Returns(() => new Result<AuthorDto>(new Exception()));
            mockILibrary
                .SetupSequence(x => x.GetBook(It.IsAny<int>()))
                .Returns(() => bookDto1)
                .Returns(() => new Result<BookDto>(new Exception()));
            mockILibrary
                .SetupSequence(x => x.GetPatron(It.IsAny<int>()))
                .Returns(() => patronDto1)
                .Returns(() => new Result<PatronDto>(new Exception()));
            mockILibrary
                .SetupSequence(x => x.GetPublisher(It.IsAny<int>()))
                .Returns(() => publisherDto1)
                .Returns(() => new Result<PublisherDto>(new Exception()));
            mockILibrary
                .SetupSequence(x => x.GetAuthorBooks(It.IsAny<int>()))
                .Returns(() => new List<BookDto>() { bookDto1, bookDto2, bookDto3, bookDto4 });
            mockILibrary
                .SetupSequence(x => x.GetAuthorList())
                .Returns(() => new List<AuthorDto>() { authorDto1, authorDto2, authorDto3, authorDto4 });
            mockILibrary
                .SetupSequence(x => x.GetBookList())
                .Returns(() => new List<BookDto>() { bookDto1, bookDto2, bookDto3, bookDto4 });
            mockILibrary
                .SetupSequence(x => x.GetBorrowedBooksByPatron(It.IsAny<int>()))
                .Returns(() => new List<BorrowedBookDto>() { borrowedBookDto1, borrowedBookDto2, borrowedBookDto3, borrowedBookDto4 });
            mockILibrary
                .SetupSequence(x => x.GetBorrowedBooksList())
                .Returns(() => new List<BorrowedBookDto>() { borrowedBookDto1, borrowedBookDto2, borrowedBookDto3, borrowedBookDto4 });
            mockILibrary
                .SetupSequence(x => x.GetPatronList())
                .Returns(() => new List<PatronDto>() { patronDto1, patronDto2, patronDto3, patronDto4 });
            mockILibrary
                .SetupSequence(x => x.GetPublisherBooks(It.IsAny<int>()))
                .Returns(() => new List<BookDto> { bookDto1, bookDto2, bookDto3, bookDto4});
            mockILibrary
                .SetupSequence(x => x.GetPublisherList())
                .Returns(() => new List<PublisherDto> { publisherDto1, publisherDto2, publisherDto3, publisherDto4 });       
        }

        [Fact]
        public void GetBook()
        {
            LibraryBookViewModel libraryBookViewModel = new LibraryBookViewModel();
            Assert.True(libraryBookViewModel.getBookCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryGetItem>(this, (t, actual) => {
                testValue = true;
            });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t, actual) => {
                exception = actual.Value;
            });
            libraryBookViewModel.getBookCommand.Execute(null);
            Assert.False(testValue);
            libraryBookViewModel.SelectedBookID = 5;
            libraryBookViewModel.getBookCommand.Execute(null);
            if (exception is not null)
            {
                Assert.Equal("", exception.Message);
            }
            Assert.True(testValue);
            Assert.Equal(bookDto1.Description, libraryBookViewModel.Description);
            Assert.Equal(bookDto1.Title, libraryBookViewModel.Title);
            Assert.Equal(bookDto1.ISBN, libraryBookViewModel.ISBN);
            mockILibrary.Verify(mock => mock.GetBook(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void AddBook()
        {
            LibraryBookViewModel libraryBookViewModel = new LibraryBookViewModel();
            Assert.True(libraryBookViewModel.addBookCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryAddItem>(this, (t, actual) => {
                testValue = actual.Value;
            });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t, actual) => {
                exception = actual.Value;
            });
            libraryBookViewModel.addBookCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryBookViewModel.SelectedBookID = -1;
            libraryBookViewModel.addBookCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryBookViewModel.SelectedPublisherID = 4;
            libraryBookViewModel.SelectedAuthorID = 3;
            libraryBookViewModel.addBookCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryBookViewModel.Title = "Test";
            libraryBookViewModel.Description = "Test";
            libraryBookViewModel.ISBN = 12345;
            libraryBookViewModel.addBookCommand.Execute(null);
            if (exception is not null)
            {
                Assert.Equal("", exception.Message);
            }
            Assert.True(testValue);
            mockILibrary.Verify(mock => mock.AddBook(It.IsAny<BookDto>()), Times.Once());

        }

        [Fact]
        public void RemoveBook()
        {
            LibraryBookViewModel libraryBookViewModel = new LibraryBookViewModel();
            Assert.True(libraryBookViewModel.removeBookCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryRemoveItem>(this, (t, actual) => {
                testValue = actual.Value;
            });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t, actual) => {
                exception = actual.Value;
            });
            libraryBookViewModel.removeBookCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception= null;
            libraryBookViewModel.SelectedBookID = 1;
            libraryBookViewModel.removeBookCommand.Execute(null);
            Assert.True(testValue);
            mockILibrary.Verify(mock => mock.RemoveBook(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void UpdateBook()
        {
            LibraryBookViewModel libraryBookViewModel= new LibraryBookViewModel();
            Assert.True(libraryBookViewModel.updateBookCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryUpdateItem>(this, (t, actual) => {
                testValue = actual.Value;
            });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t, actual) => {
                exception = actual.Value;
            });
            libraryBookViewModel.updateBookCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryBookViewModel.SelectedBookID= 1;
            libraryBookViewModel.getBookCommand.Execute(null);
            libraryBookViewModel.updateBookCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception= null;
            libraryBookViewModel.Title = "Title";
            libraryBookViewModel.updateBookCommand.Execute(null);
            Assert.True(testValue);
            Assert.Null(exception);
        }

        [Fact]
        public void BorrowedBook() 
        {
            
        }

        [Fact]
        public void ReturnBook()
        {

        }

        [Fact]
        public void AddAuthor()
        {

        }

        [Fact]
        public void RemoveAuthor()
        {

        }

        [Fact]
        public void GetAuthor()
        {

        }

        [Fact]
        public void UpdateAuthor() 
        { 
        }

        [Fact]
        public void AddPatron()
        {

        }

        [Fact]
        public void RemovePatron()
        {

        }

        [Fact]
        public void GetPatron()
        {

        }

        [Fact]
        public void UpdatePatron()
        {

        }

        [Fact]
        public void AddPublisher()
        {

        }

        [Fact]
        public void GetPublisher()
        {

        }

        [Fact]
        public void RemovePublisher()
        {

        }

        [Fact]
        public void UpdatePublisher()
        {

        }
    }
}
