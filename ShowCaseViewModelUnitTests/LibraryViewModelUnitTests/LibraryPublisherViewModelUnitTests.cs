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
            mockILibrary
                .Setup(x => x.UpdateAuthor(It.IsAny<AuthorDto>()))
                .Returns(() => true);
            mockILibrary
                .Setup(x => x.UpdateBook(It.IsAny<BookDto>()))
                .Returns(() => true);
            mockILibrary
                .Setup(x => x.UpdateBorrowedBook(It.IsAny<BorrowedBookDto>()))
                .Returns(() => true);
            mockILibrary
                .Setup(x => x.UpdatePatron(It.IsAny<PatronDto>()))
                .Returns(() => true);
            mockILibrary
                .Setup(x => x.UpdatePublisher(It.IsAny<PublisherDto>()))
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
            libraryBookViewModel.getBookCommand.Execute(null);
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
            libraryBookViewModel.SelectedBookID= 2;
            libraryBookViewModel.getBookCommand.Execute(null);
            libraryBookViewModel.updateBookCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception= null;
            libraryBookViewModel.Title = "Title";
            libraryBookViewModel.updateBookCommand.Execute(null);
            Assert.True(testValue);
            Assert.Null(exception);
            mockILibrary.Verify(mock => mock.UpdateBook(It.IsAny<BookDto>()), Times.Once());
        }

        [Fact]
        public void AddAuthor()
        {
            LibraryAuthorViewModel libraryAuthorViewModel= new LibraryAuthorViewModel();
            Assert.True(libraryAuthorViewModel.addAuthorCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryAddItem>(this, (t, actual) => {
                testValue = actual.Value;
            });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t, actual) => {
                exception = actual.Value;
            });
            libraryAuthorViewModel.addAuthorCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryAuthorViewModel.SelectedAuthorID = -1;
            libraryAuthorViewModel.addAuthorCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryAuthorViewModel.AuthorName = "Test";
            libraryAuthorViewModel.AuthorBiography = "TestBiography";
            libraryAuthorViewModel.addAuthorCommand.Execute(null);
            Assert.True(testValue);
            Assert.Null(exception);
            mockILibrary.Verify(mock => mock.AddAuthor(It.IsAny<AuthorDto>()), Times.Once());
        }

        [Fact]
        public void RemoveAuthor()
        {
            LibraryAuthorViewModel libraryAuthorViewModel = new LibraryAuthorViewModel();
            Assert.True(libraryAuthorViewModel.removeAuthorCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryRemoveItem>(this, (t, actual) => {
                testValue = actual.Value; 
            });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t, actual) => {
                exception = actual.Value;
            });
            libraryAuthorViewModel.removeAuthorCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception= null;
            libraryAuthorViewModel.SelectedAuthorID = 1;
            libraryAuthorViewModel.removeAuthorCommand.Execute(null);
            Assert.True(testValue);
            Assert.Null(exception);
            mockILibrary.Verify(mock => mock.RemoveAuthor(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void GetAuthor()
        {
            LibraryAuthorViewModel libraryAuthorViewModel= new LibraryAuthorViewModel();
            Assert.True(libraryAuthorViewModel.getAuthorCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryGetItem>(this, (t, actual) => {
                testValue = actual.Value;
            });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t, actual) => {
                exception = actual.Value;
            });
            libraryAuthorViewModel.getAuthorCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryAuthorViewModel.SelectedAuthorID= 1;
            libraryAuthorViewModel.getAuthorCommand.Execute(null);
            Assert.True(testValue);
            Assert.Null(exception);
            Assert.Equal(authorDto1.Name, libraryAuthorViewModel.AuthorName);
            Assert.Equal(authorDto1.Biography, libraryAuthorViewModel.AuthorBiography);
            mockILibrary.Verify(mock => mock.GetAuthor(It.IsAny<int>()), Times.Once());
            mockILibrary.Verify(mock => mock.GetAuthorBooks(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void UpdateAuthor() 
        { 
            LibraryAuthorViewModel libraryAuthorViewModel = new LibraryAuthorViewModel();
            Assert.True(libraryAuthorViewModel.updateAuthorCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryUpdateItem>(this, (t, actual) => {
                testValue = actual.Value;
            });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t, actual) => {
                exception = actual.Value;
            });
            libraryAuthorViewModel.updateAuthorCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryAuthorViewModel.SelectedAuthorID = 1;
            libraryAuthorViewModel.getAuthorCommand.Execute(null);
            libraryAuthorViewModel.updateAuthorCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryAuthorViewModel.AuthorBiography = "NewBiography";
            libraryAuthorViewModel.AuthorName = "NewName";
            libraryAuthorViewModel.updateAuthorCommand.Execute(null);
            Assert.True(testValue); 
            Assert.Null(exception);
            mockILibrary.Verify(mock => mock.UpdateAuthor(It.IsAny<AuthorDto>()), Times.Once());
        }

        [Fact]
        public void AddPatron()
        {
            LibraryPatronViewModel libraryPatronViewModel = new LibraryPatronViewModel();
            Assert.True(libraryPatronViewModel.addPatronCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryAddItem>(this, (t, actual) => {
                testValue = actual.Value;
            });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t, actual) => {
                exception = actual.Value;
            });
            libraryPatronViewModel.addPatronCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryPatronViewModel.SelectedPatronID = -1;
            libraryPatronViewModel.addPatronCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryPatronViewModel.PatronName = "Test";
            libraryPatronViewModel.PatronPhoneNumber = "123-456-7891";
            libraryPatronViewModel.PatronAddress = "TestAddress";
            libraryPatronViewModel.PatronCity = "TestCity";
            libraryPatronViewModel.PatronPostalCode = 12345;
            libraryPatronViewModel.addPatronCommand.Execute(null);
            Assert.True(testValue);
            Assert.Null(exception);
            mockILibrary.Verify(mock => mock.AddPatron(It.IsAny<PatronDto>()), Times.Once);
        }

        [Fact]
        public void RemovePatron()
        {
            LibraryPatronViewModel libraryPatronViewModel = new LibraryPatronViewModel();
            Assert.True(libraryPatronViewModel.removePatronCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryRemoveItem>(this, (t, actual) => { testValue = actual.Value; });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t, actual) => { exception = actual.Value; });
            libraryPatronViewModel.removePatronCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryPatronViewModel.SelectedPatronID = 4;
            libraryPatronViewModel.removePatronCommand.Execute(null);
            Assert.True(testValue);
            Assert.Null(exception);
            mockILibrary.Verify(mock => mock.RemovePatron(It.IsAny<int>()), Times.Once);

        }

        [Fact]
        public void GetPatron()
        {
            LibraryPatronViewModel libraryPatronViewModel = new LibraryPatronViewModel();
            Assert.True(libraryPatronViewModel.getPatronCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryGetItem>(this, (t,actual) => { testValue = actual.Value; });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t, actual) => { exception = actual.Value; });
            libraryPatronViewModel.getPatronCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception= null;
            libraryPatronViewModel.SelectedPatronID = 4;
            libraryPatronViewModel.getPatronCommand.Execute(null);
            Assert.True(testValue);
            Assert.Null(exception);
            mockILibrary.Verify(mock => mock.GetPatron(It.IsAny<int>()), Times.Once);
            mockILibrary.Verify(mock => mock.GetBorrowedBooksByPatron(It.IsAny<int>()), Times.Once());
            Assert.Equal(patronDto1.Name, libraryPatronViewModel.PatronName);
            Assert.Equal(patronDto1.City, libraryPatronViewModel.PatronCity);
            Assert.Equal(patronDto1.StreetAddress, libraryPatronViewModel.PatronAddress);
        }

        [Fact]
        public void UpdatePatron()
        {
            LibraryPatronViewModel libraryPatronViewModel = new LibraryPatronViewModel();
            Assert.True(libraryPatronViewModel.updatePatronCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryUpdateItem>(this, (t, actual) => { testValue = actual.Value; });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t, actual) => { exception = actual.Value; });
            libraryPatronViewModel.updatePatronCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryPatronViewModel.SelectedPatronID = 1;
            libraryPatronViewModel.updatePatronCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryPatronViewModel.getPatronCommand.Execute(null);
            libraryPatronViewModel.updatePatronCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryPatronViewModel.PatronAddress = "NewAddress";
            libraryPatronViewModel.updatePatronCommand.Execute(null);
            Assert.True(testValue);
            Assert.Null(exception);
            mockILibrary.Verify(mock => mock.UpdatePatron(It.IsAny<PatronDto>()), Times.Once);
        }

        [Fact]
        public void AddPublisher()
        {
            LibraryPublisherViewModel libraryPublisherViewModel = new LibraryPublisherViewModel();
            Assert.True(libraryPublisherViewModel.addPublisherCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryAddItem>(this, (t,actual) => { testValue = actual.Value; });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t, actual) => { exception = actual.Value; });
            libraryPublisherViewModel.addPublisherCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception= null;
            libraryPublisherViewModel.SelectedPublisherID = -1;
            libraryPublisherViewModel.addPublisherCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryPublisherViewModel.PublisherName = "Test";
            libraryPublisherViewModel.PublisherDescription = "TestDescription";
            libraryPublisherViewModel.addPublisherCommand.Execute(null);
            Assert.True(testValue);
            Assert.Null(exception);
            mockILibrary.Verify(mock => mock.AddPublisher(It.IsAny<PublisherDto>()), Times.Once());
        }

        [Fact]
        public void GetPublisher()
        {
            LibraryPublisherViewModel libraryPublisherViewModel = new LibraryPublisherViewModel();
            Assert.True(libraryPublisherViewModel.getPublisherCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryGetItem>(this, (t,actual) => { testValue = actual.Value; });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t, actual) => { exception = actual.Value; });
            libraryPublisherViewModel.getPublisherCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryPublisherViewModel.SelectedPublisherID = 4;
            libraryPublisherViewModel.getPublisherCommand.Execute(null);
            Assert.True(testValue);
            Assert.Null(exception);
            mockILibrary.Verify(mock => mock.GetPublisher(It.IsAny<int>()), Times.Once());
            mockILibrary.Verify(mock => mock.GetPublisherBooks(It.IsAny<int>()), Times.Once());
            Assert.Equal(publisherDto1.Name, libraryPublisherViewModel.PublisherName);
            Assert.Equal(publisherDto1.Description, libraryPublisherViewModel.PublisherDescription);
        }

        [Fact]
        public void RemovePublisher()
        {
            LibraryPublisherViewModel libraryPublisherViewModel = new LibraryPublisherViewModel();
            Assert.True(libraryPublisherViewModel.removePublisherCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryRemoveItem>(this, (t,actual) => { testValue = actual.Value; });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t, actual) => { exception = actual.Value; });
            libraryPublisherViewModel.removePublisherCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception= null;
            libraryPublisherViewModel.SelectedPublisherID= 4;
            libraryPublisherViewModel.removePublisherCommand.Execute(null);
            Assert.True(testValue);
            Assert.Null(exception);
            mockILibrary.Verify(mock => mock.RemovePublisher(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void UpdatePublisher()
        {
            LibraryPublisherViewModel libraryPublisherViewModel= new LibraryPublisherViewModel();
            Assert.True(libraryPublisherViewModel.updatePublisherCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryUpdateItem>(this, (t,actual) => { testValue = actual.Value; });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t,actual) => { exception = actual.Value; });
            libraryPublisherViewModel.updatePublisherCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception= null;
            libraryPublisherViewModel.SelectedPublisherID = 5;
            libraryPublisherViewModel.updatePublisherCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryPublisherViewModel.getPublisherCommand.Execute(null);
            libraryPublisherViewModel.updatePublisherCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryPublisherViewModel.PublisherDescription = "NewDescription";
            libraryPublisherViewModel.updatePublisherCommand.Execute(null);
            Assert.True(testValue); 
            Assert.Null(exception);
            mockILibrary.Verify(mock => mock.UpdatePublisher(It.IsAny<PublisherDto>()), Times.Once());
        }

        [Fact]
        public void BorrowBook()
        {
            LibraryMainCheckoutViewModel libraryMainCheckoutViewModel = new LibraryMainCheckoutViewModel();
            Assert.True(libraryMainCheckoutViewModel.borrowBookCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryBorrowBook>(this, (t,actual) => { testValue = actual.Value; });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t, actual) => { exception = actual.Value; });
            libraryMainCheckoutViewModel.borrowBookCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryMainCheckoutViewModel.SelectedBook = 4;
            libraryMainCheckoutViewModel.borrowBookCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception= null;
            libraryMainCheckoutViewModel.SelectedPatron = 4;
            libraryMainCheckoutViewModel.SelectedBook = -1;
            libraryMainCheckoutViewModel.borrowBookCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception = null;
            libraryMainCheckoutViewModel.SelectedBook = 3;
            libraryMainCheckoutViewModel.borrowBookCommand.Execute (null);
            Assert.True(testValue);
            Assert.Null(exception);
            mockILibrary.Verify(mock => mock.BorrowBook(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<TimeSpan>()), Times.Once());
        }

        [Fact]
        public void ReturnBook()
        {
            LibraryMainCheckoutViewModel libraryMainCheckoutViewModel = new LibraryMainCheckoutViewModel();
            Assert.True(libraryMainCheckoutViewModel.returnBookCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryReturnBook>(this, (t, actual) => { testValue = actual.Value; });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t, actual) => { exception = actual.Value; });
            libraryMainCheckoutViewModel.returnBookCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception= null;
            libraryMainCheckoutViewModel.SelectedBorrowedBook = 3;
            libraryMainCheckoutViewModel.returnBookCommand.Execute(null);
            Assert.True(testValue);
            Assert.Null(exception);
            mockILibrary.Verify(mock => mock.RemoveBorrowedBook(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void ReBorrowBook()
        {
            LibraryMainCheckoutViewModel libraryMainCheckoutViewModel = new LibraryMainCheckoutViewModel();
            Assert.True(libraryMainCheckoutViewModel.reBorrowBookCommand.CanExecute(null));
            bool testValue = false;
            Exception exception = null;
            WeakReferenceMessenger.Default.Register<LibraryReBorrowBook>(this, (t, actual) => { testValue = actual.Value; });
            WeakReferenceMessenger.Default.Register<ExceptionMessage>(this, (t,actual) => { exception = actual.Value; });
            libraryMainCheckoutViewModel.reBorrowBookCommand.Execute(null);
            Assert.False(testValue);
            Assert.NotNull(exception);
            exception= null;
            libraryMainCheckoutViewModel.SelectedBorrowedBook=3;
            libraryMainCheckoutViewModel.reBorrowBookCommand.Execute(null);
            Assert.True(testValue);
            Assert.Null(exception);
            mockILibrary.Verify(mock => mock.UpdateBorrowedBook(It.IsAny<BorrowedBookDto>()), Times.Once());
        }
    }
}
