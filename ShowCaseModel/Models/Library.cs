using EFCore_DBLibrary;
using EFCore_DBModels.Library;
using EFCore_DBModels.Types;
using Microsoft.EntityFrameworkCore;
using ShowCaseModel.DataTypes.Library;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageExt.Common;
using LanguageExt.Pipes;

namespace ShowCaseModel.Models
{
    public class Library : ILibrary
    {
        private readonly DBFactory dBFactory;

        public Library()
        {
            dBFactory = new DBFactory();
        }

        public Library(DbContextOptions<ShowCaseDbContext> options)
        {
            dBFactory = new DBFactory(options);
        }

        private void SetCreationValues(Standard standard)
        {
            standard.IsDeleted = false;
            standard.IsActive = true;
        }

        public void AddAuthor(LibraryAuthor libraryAuthor)
        {
            var database = dBFactory.GetDbContext();
            Author author = AuthorDTOtoDatabase(libraryAuthor);
            SetCreationValues(author);
            database.Authors.Add(author);
            database.SaveChanges();
            libraryAuthor.Id = author.Id;
        }

        private static BorrowedBook CreateBorrowBook(Book book, Patron patron, DateTime duedate)
        {
            return new BorrowedBook() { Book = book, BookId = book.Id, BorrowedDate = DateTime.Now.ToUniversalTime(), DueDate = duedate.ToUniversalTime(), Patron = patron };
        }

        private static LibraryAuthor AuthorDatabaseToDTO(Author author)
        {
            return new LibraryAuthor { Biography = author.Biography, Id = author.Id, Name = author.Name };
        }

        private static LibraryBook BookDatabaseToDTO(Book book)
        {
            return new LibraryBook() { ISBN = book.ISBN, Description = book.Description, Title = book.Title, Id = book.Id };
        }

        private static LibraryBorrowedBook BorrowedBookDatabaseToDTO(BorrowedBook book)
        {
            return new LibraryBorrowedBook() { BorrowedDate = book.BorrowedDate, DueDate = book.DueDate, Id = book.Id };
        }

        private static LibraryPatron PatronDatabaseToDTO(Patron patron)
        {
            return new LibraryPatron() { PhoneNumber = patron.PhoneNumber, Id = patron.Id, City = patron.City, Name = patron.Name, PostalCode = patron.PostalCode, StreetAddress = patron.StreetAddress };
        }

        private static LibraryPublisher PublisherDatabaseToDTO(Publisher publisher)
        {
            return new LibraryPublisher { Description = publisher.Description, Id = publisher.Id, Name = publisher.Name };
        }

        private static Author AuthorDTOtoDatabase(LibraryAuthor libraryAuthor)
        {
            return new Author { Biography = libraryAuthor.Biography, Name = libraryAuthor.Name };
        }

        private static Book BookDTOtoDatabase(LibraryBook book, Author author, Publisher publisher)
        {
            return new Book() { Author = author, Publisher = publisher, Description = book.Description, ISBN = book.ISBN, Title = book.Title };
        }

        private static Patron PatronDTOtoDatabase(LibraryPatron libraryPatron)
        {
            return new Patron { Name = libraryPatron.Name, City = libraryPatron.City, PhoneNumber = libraryPatron.PhoneNumber, StreetAddress = libraryPatron.StreetAddress, PostalCode = libraryPatron.PostalCode };
        }

        private static Publisher PublisherDtoToDatabase(LibraryPublisher libraryPublisher)
        {
            return new Publisher { Description = libraryPublisher.Description, Name = libraryPublisher.Name };
        }

        public void AddBook(LibraryBook book, int AuthorID, int PublisherID)
        {
            var database = dBFactory.GetDbContext();
            var author = database.Authors.FirstOrDefault(x => x.Id == AuthorID);
            var publisher = database.Publishers.FirstOrDefault(x => x.Id == PublisherID);
            if (publisher is not null && author is not null)
            {
                Book newBook = BookDTOtoDatabase(book, author, publisher);
                SetCreationValues(newBook);
                database.Books.Add(newBook);
                database.SaveChanges();
                book.Id = newBook.Id;
            }
        }

        public void AddPatron(LibraryPatron libraryPatron)
        {
            var database = dBFactory.GetDbContext();
            Patron patron = PatronDTOtoDatabase(libraryPatron);
            SetCreationValues(patron);
            database.Patrons.Add(patron);
            database.SaveChanges();
            libraryPatron.Id = patron.Id;
        }


        public void AddPublisher(LibraryPublisher libraryPublisher)
        {
            var database = dBFactory.GetDbContext();
            Publisher publisher = PublisherDtoToDatabase(libraryPublisher);
            SetCreationValues(publisher);
            database.Publishers.Add(publisher);
            database.SaveChanges();
            libraryPublisher.Id = publisher.Id;
        }

        public Try<LibraryAuthor> GetAuthor(int Id) => () => 
        {
            var database = dBFactory.GetDbContext();
            var author = database.Authors.FirstOrDefault(x => x.Id == Id);
            if (author == null)
            {
                return new Result<LibraryAuthor>(new Exception("Author not found"));
            }
            else
            {
                if (author.IsDeleted)
                {
                    return new Result<LibraryAuthor>(new Exception("This Author has been deleted"));
                }
                else
                {
                    return new Result<LibraryAuthor>(AuthorDatabaseToDTO(author));
                }
            }
        };

        public Try<LibraryPublisher> GetPublisher(int Id) => () => 
        {
            var database = dBFactory.GetDbContext();
            var publisher = database.Publishers.FirstOrDefault(x => x.Id == Id);
            if (publisher == null)
            {
                return new Result<LibraryPublisher>(new Exception("Publisher not found"));
            }
            else
            {
                if (publisher.IsDeleted)
                {
                    return new Result<LibraryPublisher>(new Exception("This Publisher has been deleted"));
                }
                else
                {
                    return new Result<LibraryPublisher>(PublisherDatabaseToDTO(publisher));
                }
            }
        };

        public Try<LibraryBook> GetBook(int Id) => () => {
            var db = dBFactory.GetDbContext();
            var book = db.Books.FirstOrDefault(x => x.Id == Id);
            if (book == null)
            {
                return new Result<LibraryBook>(new Exception("Book not found"));
            }
            else
            {
                if (book.IsDeleted)
                {
                    return new Result<LibraryBook>(new Exception("This Book has been deleted"));
                }
                return new Result<LibraryBook>(BookDatabaseToDTO(book));
            }
        };

        public LibraryPatron GetPatron(int Id)
        {
            var db = dBFactory.GetDbContext();
            var patron = db.Patrons.FirstOrDefault(x => x.Id == Id);
            if (patron == null)
            {
                return null;
            }
            else
            {
                LibraryPatron newPatron = PatronDatabaseToDTO(patron);
                return newPatron;
            }
        }

        public Try<bool> RemoveBook(int Id) => () => {
            var db = dBFactory.GetDbContext();
            var book = db.Books.FirstOrDefault(x => x.Id == Id);
            if (book is not null)
            {
                if (book.IsDeleted && !book.IsActive)
                {
                    return new Result<bool>(new Exception("Book already removed"));
                }
                book.IsDeleted = true;
                book.IsActive = false;
                db.SaveChanges();
                return new Result<bool>(true);
            }
            return new Result<bool>(new Exception("Book doesn't exist"));
        };

        public Try<bool> RemoveAuthor(int Id) => () => 
        {
            var db = dBFactory.GetDbContext();
            var author = db.Authors.Include(x => x.Books).FirstOrDefault(x => x.Id == Id);
            if (author is not null)
            {
                if (author.Books.Count == 0)
                {
                    author.IsDeleted = true;
                    author.IsActive = false;
                    db.SaveChanges();
                    return new Result<bool>(true);
                }
                else
                {
                    if (!author.Books.Any(x => x.IsDeleted == false))
                    {
                        author.IsDeleted = true;
                        author.IsActive = false;
                        db.SaveChanges();
                        return new Result<bool>(true);
                    }
                    else
                    {
                        return new Result<bool>(new Exception("This Author can not be deleted until all the Author's books are deleted"));
                    }
                }
            }
            else
            {
                return new Result<bool>(new Exception("There is no Author with this Id Available"));
            }
        };

        public Try<bool> RemovePublisher(int Id) => () => 
        {
            var db = dBFactory.GetDbContext();
            var publisher = db.Publishers.Include(x => x.Books).FirstOrDefault(x => x.Id == Id);
            if (publisher is not null)
            {
                if (publisher.Books.Count == 0)
                {
                    publisher.IsDeleted = true;
                    publisher.IsActive = false;
                    db.SaveChanges();
                    return new Result<bool>(true);
                }
                else
                {
                    if(!publisher.Books.Any(x => x.IsDeleted == false))
                    {
                        publisher.IsDeleted = true;
                        publisher.IsActive = false;
                        db.SaveChanges();
                        return new Result<bool>(true);
                    }
                    else
                    {
                        return new Result<bool>(new Exception("This Publisher can not be deleted until all the Publisher's books are deleted"));
                    }
                }
            }
            else
            {
                return new Result<bool>(new Exception("There is no Publisher with this Id Available"));
            }
        };

        public void BorrowBook(int PatronId, int BookId, TimeSpan returnTimeSpan)
        {
            var db = dBFactory.GetDbContext();
            var book = db.Books.Include(x => x.BorrowedBook).FirstOrDefault(x => x.Id==BookId);
            var patron = db.Patrons.Include(x => x.BorrowedBooks).FirstOrDefault(x => x.Id == PatronId);
            if (patron is null || book is null) 
            {
                return;
            }
            else
            {
                if (book.BorrowedBook is not null)
                {
                    return;
                }
                else
                {
                    DateTime duedate = DateTime.Now;
                    duedate.Add(returnTimeSpan);
                    BorrowedBook borrowBook = CreateBorrowBook(book, patron, duedate);
                    SetCreationValues(borrowBook);
                    db.BorrowedBooks.Add(borrowBook);
                    db.SaveChanges();
                }
            }
        }

        public List<LibraryBorrowedBook> GetBorrowedBooks(int patronId)
        {
            var db = dBFactory.GetDbContext();
            var borrowedBooks = db.BorrowedBooks.AsNoTracking().Include(x => x.Book).Where(x => x.Patron.Id == patronId).ToList();
            if (borrowedBooks is not null)
            {
                if (borrowedBooks is not null)
                {
                    
                    List<LibraryBorrowedBook> borrowedLibraryBooks = new List<LibraryBorrowedBook>();
                    foreach (BorrowedBook book in borrowedBooks)
                    {
                        LibraryBorrowedBook borrowedBook = BorrowedBookDatabaseToDTO(book);
                        LibraryBook newBook = BookDatabaseToDTO(book.Book);
                        borrowedBook.BorrowedBook = newBook;
                        borrowedLibraryBooks.Add(borrowedBook);
                    }
                    return borrowedLibraryBooks;
                }
                else
                {
                    return new List<LibraryBorrowedBook>();
                }
            }
            else
            {
                return new List<LibraryBorrowedBook>();
            }
        }

        public List<LibraryBook> GetAuthorBooks(int authorId)
        {
            var db = dBFactory.GetDbContext();
            var author = db.Authors.AsNoTracking().Include(x => x.Books).FirstOrDefault(x => x.Id == authorId);
            if (author is not null && author.Books.Count > 0)
            {
                var BookList = new List<LibraryBook>();
                foreach (var book in author.Books)
                {
                    LibraryBook libraryBook = BookDatabaseToDTO(book);
                    BookList.Add(libraryBook);
                }
                return BookList;
            }
            else
            {
                return new List<LibraryBook>();
            }
        }

        public List<LibraryBook> GetPublisherBooks(int publisherId)
        {
            var db = dBFactory.GetDbContext();
            var publisher = db.Publishers.AsNoTracking().Include(x => x.Books).FirstOrDefault(x => x.Id == publisherId);
            if (publisher is not null && publisher.Books.Count > 0)
            {
                var bookList = new List<LibraryBook>();
                foreach (Book book in publisher.Books)
                {
                    LibraryBook libraryBook = BookDatabaseToDTO(book);
                    bookList.Add(libraryBook);
                }
                return bookList;
            }
            else
            {
                return new List<LibraryBook>();
            }
        }
    }
}
