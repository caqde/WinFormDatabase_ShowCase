using EFCore_DBLibrary;
using EFCore_DBModels.Library;
using EFCore_DBModels.Types;
using Microsoft.EntityFrameworkCore;
using ShowCaseModel.DataTypes.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Author author = new Author { Biography = libraryAuthor.Biography, Name = libraryAuthor.Name };
            SetCreationValues(author);
            database.Authors.Add(author);
            database.SaveChanges();
            libraryAuthor.Id = author.Id;
        }

        public void AddBook(LibraryBook book, int AuthorID, int PublisherID)
        {
            var database = dBFactory.GetDbContext();
            var author = database.Authors.FirstOrDefault(x => x.Id == AuthorID);
            var publisher = database.Publishers.FirstOrDefault(x => x.Id == PublisherID);
            if (publisher == null || author == null)
            {
                //throw exception or error?
                return;
            }
            else
            {
                Book newBook = new Book() { Author = author, Publisher = publisher, Description = book.Description, ISBN = book.ISBN, Title = book.Title };
                SetCreationValues(newBook);
                database.Books.Add(newBook);
                database.SaveChanges();
                book.Id = newBook.Id;
            }
        }

        public void AddPatron(LibraryPatron libraryPatron)
        {
            var database = dBFactory.GetDbContext();
            Patron patron = new Patron { Name = libraryPatron.Name, City = libraryPatron.City, PhoneNumber = libraryPatron.PhoneNumber, StreetAddress = libraryPatron.StreetAddress, PostalCode = libraryPatron.PostalCode };
            SetCreationValues(patron);
            database.Patrons.Add(patron);
            database.SaveChanges();
            libraryPatron.Id = patron.Id;
        }

        public void AddPublisher(LibraryPublisher libraryPublisher)
        {
            var database = dBFactory.GetDbContext();
            Publisher publisher = new Publisher { Description = libraryPublisher.Description, Name = libraryPublisher.Name };
            SetCreationValues(publisher);
            database.Publishers.Add(publisher);
            database.SaveChanges();
            libraryPublisher.Id = publisher.Id;
        }

        public LibraryAuthor? GetAuthor(int Id)
        {
            var database = dBFactory.GetDbContext();
            var author = database.Authors.FirstOrDefault(x => x.Id == Id);
            if (author == null)
            {
                return null;
            }
            else
            {
                return new LibraryAuthor { Biography = author.Biography, Id = author.Id, Name = author.Name };
            }
        }

        public LibraryPublisher? GetPublisher(int Id)
        {
            var database = dBFactory.GetDbContext();
            var publisher = database.Publishers.FirstOrDefault(x => x.Id == Id);
            if (publisher == null)
            {
                return null;
            }
            else
            {
                return new LibraryPublisher { Description = publisher.Description, Id = publisher.Id, Name = publisher.Name };
            }
        }

        public LibraryBook GetBook(int Id)
        {
            var db = dBFactory.GetDbContext();  
            var book = db.Books.FirstOrDefault(x => x.Id == Id);
            if (book == null)
            {
                return null;
            }
            else
            {
                if (book.IsDeleted) 
                {
                    return null;
                }
                LibraryBook newBook = new LibraryBook() { ISBN = book.ISBN, Description = book.Description, Title = book.Title, Id = book.Id };
                return newBook;
            }
        }

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
                LibraryPatron newPatron = new LibraryPatron() { PhoneNumber = patron.PhoneNumber, Id = patron.Id, City = patron.City, Name = patron.Name, PostalCode = patron.PostalCode, StreetAddress = patron.StreetAddress };
                return newPatron;
            }
        }

        public void RemoveBook(int Id)
        {
            var db = dBFactory.GetDbContext();
            var book = db.Books.FirstOrDefault(x => x.Id == Id);
            if (book == null)
            {
                return;
            }
            else
            {
                book.IsDeleted = true;
                book.IsActive = false;
                db.SaveChanges();
                return;
            }
        }

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
                    BorrowedBook borrowBook = new BorrowedBook() { Book = book, BookId = book.Id, BorrowedDate = DateTime.Now.ToUniversalTime(), DueDate = duedate.ToUniversalTime(), Patron = patron };
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
                        LibraryBorrowedBook borrowedBook = new LibraryBorrowedBook() { BorrowedDate = book.BorrowedDate, DueDate = book.DueDate, Id = book.Id };
                        LibraryBook newBook = new LibraryBook() { Id = book.Book.Id, Description = book.Book.Description, ISBN = book.Book.ISBN, Title = book.Book.Title };
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
                    LibraryBook libraryBook = new LibraryBook() { Description = book.Description, Id = book.Id, ISBN = book.ISBN, Title = book.Title };
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
                    LibraryBook libraryBook = new LibraryBook() { Description = book.Description, Id = book.Id, ISBN = book.ISBN, Title = book.Title };
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
