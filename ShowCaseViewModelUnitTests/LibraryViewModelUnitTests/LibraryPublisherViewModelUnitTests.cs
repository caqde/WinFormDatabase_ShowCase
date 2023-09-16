using LanguageExt;
using LanguageExt.Common;
using Moq;
using ShowCaseModel;
using ShowCaseModel.DataTypes.Library;
using ShowCaseModel.Models;
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
        }

        private void SetupLibraryBoolReturn()
        {
            mockILibrary
                .Setup(x => x.AddAuthor(It.IsAny<AuthorDto>()))
                .Returns(() => true);
            mockILibrary
                .Setup(x => x.AddBook(It.IsAny<BookDto>(), It.IsAny<int>(), It.IsAny<int>()))
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
                .Returns(() => authorDto1);
            mockILibrary
                .SetupSequence(x => x.GetBook(It.IsAny<int>()))
                .Returns(() => bookDto1);
            mockILibrary
                .SetupSequence(x => x.GetPatron(It.IsAny<int>()))
                .Returns(() => patronDto1);
            mockILibrary
                .SetupSequence(x => x.GetPublisher(It.IsAny<int>()))
                .Returns(() => publisherDto1);
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
            
        }

        [Fact]
        public void AddBook()
        {

        }

        [Fact]
        public void RemoveBook()
        {

        }

        [Fact]
        public void UpdateBook()
        {

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
