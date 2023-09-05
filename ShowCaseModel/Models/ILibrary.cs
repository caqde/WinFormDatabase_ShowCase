using LanguageExt;
using ShowCaseModel.DataTypes.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseModel.Models
{
    public interface ILibrary
    {
        public Try<bool> AddAuthor(AuthorDto authorDto);
        public Try<bool> AddBook(BookDto book, int AuthorID, int PublisherID);
        public Try<bool> AddPatron(PatronDto patronDto);
        public Try<bool> AddPublisher(PublisherDto publisherDto);

        public Try<bool> BorrowBook(int PatronID, int BookID, TimeSpan returnTimeSpan);

        public Try<AuthorDto> GetAuthor(int AuthorID);
        public Try<BookDto> GetBook(int BookID);
        public Try<PatronDto> GetPatron(int PatronID);
        public Try<PublisherDto> GetPublisher(int PublisherID);

        public Try<bool> RemoveAuthor(int AuthorID);
        public Try<bool> RemoveBook(int BookID);
        public Try<bool> RemoveBorrowedBook(int BorrowedBookID);
        public Try<bool> RemovePatron(int PatronID);
        public Try<bool> RemovePublisher(int PublisherID);

        public Try<List<BookDto>> GetAuthorBooks(int AuthorID);
        public Try<List<AuthorDto>> GetAuthorList();
        public Try<List<BookDto>> GetBookList();
        public Try<List<BorrowedBookDto>> GetBorrowedBooksByPatron(int PatronID);
        public Try<List<BorrowedBookDto>> GetBorrowedBooksList();
        public Try<List<PatronDto>> GetPatronList();
        public Try<List<BookDto>> GetPublisherBooks(int PublisherID);
        public Try<List<PublisherDto>> GetPublisherList();
    }
}
