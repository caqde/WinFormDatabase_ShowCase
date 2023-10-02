﻿using EFCore_DBLibrary;
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

        private static BorrowedBook CreateBorrowBook(Book book, Patron patron, DateTime duedate)
        {
            return new BorrowedBook() { Book = book, BookId = book.Id, BorrowedDate = DateTime.Now.ToUniversalTime(), DueDate = duedate.ToUniversalTime(), Patron = patron };
        }

        private static Author AuthorDTOtoDatabase(AuthorDto libraryAuthor)
        {
            return new Author { Biography = libraryAuthor.Biography, Name = libraryAuthor.Name };
        }

        private static Book BookDTOtoDatabase(BookDto book, Author author, Publisher publisher)
        {
            return new Book() { Author = author, Publisher = publisher, Description = book.Description, ISBN = book.ISBN, Title = book.Title };
        }

        private static Patron PatronDTOtoDatabase(PatronDto libraryPatron)
        {
            return new Patron { Name = libraryPatron.Name, City = libraryPatron.City, PhoneNumber = libraryPatron.PhoneNumber, StreetAddress = libraryPatron.StreetAddress, PostalCode = libraryPatron.PostalCode };
        }

        private static Publisher PublisherDtoToDatabase(PublisherDto libraryPublisher)
        {
            return new Publisher { Description = libraryPublisher.Description, Name = libraryPublisher.Name };
        }

        private static Result<bool> DetermineNullException(Book? book, Patron? patron)
        {
            if (patron is null && book is null)
            {
                return new Result<bool>(new Exception("Invalid Patron and Book Id"));
            }
            else
            {
                if (patron is null)
                {
                    return new Result<bool>(new Exception("Invalid Patron Id"));
                }
                else
                {
                    return new Result<bool>(new Exception("Invalid Book Id"));
                }
            }
        }

        private static Result<bool> DetermineNullException(Author? author, Publisher? publisher)
        {
            if (author is null && publisher is null)
            {
                return new Result<bool>(new Exception("Invalid Author and Publisher"));
            }
            if (author is null)
            {
                return new Result<bool>(new Exception("Invalid Author"));
            }
            else
            {
                return new Result<bool>(new Exception("Invalid Publisher"));
            }
        }

        private static Result<bool> DetermineDeletionException(Author author, Publisher publisher)
        {
            if (author.IsDeleted && publisher.IsDeleted)
            {
                return new Result<bool>(new Exception($"Author with ID = {author.Id} and Publisher with ID = {publisher.Id} was deleted"));
            }
            else if (publisher.IsDeleted)
            {
                return new Result<bool>(new Exception($"Publisher with ID = {publisher.Id} was deleted"));
            }
            else if (author.IsDeleted)
            {
                return new Result<bool>(new Exception($"Author with ID = {author.Id} was deleted"));
            }

            return new Result<bool>(new Exception("Invalid call for DetermineDeletionException"));
        }

        public Try<bool> AddAuthor(AuthorDto authorDto) => () => 
        {
            var database = dBFactory.GetDbContext();
            Author author = AuthorDTOtoDatabase(authorDto);
            SetCreationValues(author);
            database.Authors.Add(author);
            database.SaveChanges();
            authorDto.Id = author.Id;
            return new Result<bool>(true);
        };

        public Try<bool> AddBook(BookDto book) => () => 
        {
            var database = dBFactory.GetDbContext();
            var author = database.Authors.FirstOrDefault(x => x.Id == book.authorID);
            var publisher = database.Publishers.FirstOrDefault(x => x.Id == book.publisherID);
            if (publisher is not null && author is not null)
            {
                if (author.IsDeleted || publisher.IsDeleted)
                {
                    return DetermineDeletionException(author, publisher);
                }

                Book newBook = BookDTOtoDatabase(book, author, publisher);
                SetCreationValues(newBook);
                database.Books.Add(newBook);
                database.SaveChanges();
                book.Id = newBook.Id;
                return new Result<bool>(true);
            }
            else
            {
                return DetermineNullException(author, publisher);
            }
        };

        public Try<bool> AddPatron(PatronDto patronDto) => () => 
        {
            var database = dBFactory.GetDbContext();
            Patron patron = PatronDTOtoDatabase(patronDto);
            SetCreationValues(patron);
            database.Patrons.Add(patron);
            database.SaveChanges();
            patronDto.Id = patron.Id;
            return new Result<bool>(true);
        };


        public Try<bool> AddPublisher(PublisherDto publisherDto) => () => 
        {
            var database = dBFactory.GetDbContext();
            Publisher publisher = PublisherDtoToDatabase(publisherDto);
            SetCreationValues(publisher);
            database.Publishers.Add(publisher);
            database.SaveChanges();
            publisherDto.Id = publisher.Id;
            return new Result<bool>(true);
        };

        public Try<AuthorDto> GetAuthor(int AuthorID) => () => 
        {
            var database = dBFactory.GetDbContext();
            var author = database.Authors.AsNoTracking().FirstOrDefault(x => x.Id == AuthorID);
            if (author == null)
            {
                return new Result<AuthorDto>(new Exception("Author not found"));
            }
            else
            {
                if (author.IsDeleted)
                {
                    return new Result<AuthorDto>(new Exception("This Author has been deleted"));
                }
                else
                {
                    return new Result<AuthorDto>(author.MapToDto());
                }
            }
        };

        public Try<PublisherDto> GetPublisher(int PublisherID) => () => 
        {
            var database = dBFactory.GetDbContext();
            var publisher = database.Publishers.AsNoTracking().FirstOrDefault(x => x.Id == PublisherID);
            if (publisher == null)
            {
                return new Result<PublisherDto>(new Exception("Publisher not found"));
            }
            else
            {
                if (publisher.IsDeleted)
                {
                    return new Result<PublisherDto>(new Exception("This Publisher has been deleted"));
                }
                else
                {
                    return new Result<PublisherDto>(publisher.MapToDto());
                }
            }
        };

        public Try<BookDto> GetBook(int BookID) => () => 
        {
            var db = dBFactory.GetDbContext();
            var book = db.Books.AsNoTracking().Include(x => x.Author).Include(x => x.Publisher).FirstOrDefault(x => x.Id == BookID);
            if (book == null)
            {
                return new Result<BookDto>(new Exception("Book not found"));
            }
            else
            {
                if (book.IsDeleted)
                {
                    return new Result<BookDto>(new Exception("This Book has been deleted"));
                }
                return new Result<BookDto>(book.MapToDto());
            }
        };

        public Try<PatronDto> GetPatron(int PatronID) => () => 
        {
            var db = dBFactory.GetDbContext();
            var patron = db.Patrons.AsNoTracking().FirstOrDefault(x => x.Id == PatronID);
            if (patron == null)
            {
                return new Result<PatronDto>(new Exception("Patron doesn't exist"));
            }
            else
            {
                if (patron.IsDeleted)
                {
                    return new Result<PatronDto>(new Exception("Patron has been deleted"));
                }
                else
                {
                    return new Result<PatronDto>(patron.MapToDto());
                }
            }
        };

        public Try<bool> RemoveBook(int BookID) => () => 
        {
            var db = dBFactory.GetDbContext();
            var book = db.Books.Include(x => x.BorrowedBook).FirstOrDefault(x => x.Id == BookID);
            if (book is not null)
            {
                if (book.IsDeleted && !book.IsActive)
                {
                    return new Result<bool>(new Exception("Book already removed"));
                }
                if (book.BorrowedBook is not null)
                {
                    return new Result<bool>(new Exception("Book is currently being borrowed"));
                }
                book.IsDeleted = true;
                book.IsActive = false;
                db.SaveChanges();
                return new Result<bool>(true);
            }
            return new Result<bool>(new Exception("Book doesn't exist"));
        };

        public Try<bool> RemoveAuthor(int AuthorID) => () => 
        {
            var db = dBFactory.GetDbContext();
            var author = db.Authors.Include(x => x.Books).FirstOrDefault(x => x.Id == AuthorID);
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

        public Try<bool> RemovePublisher(int PublisherID) => () => 
        {
            var db = dBFactory.GetDbContext();
            var publisher = db.Publishers.Include(x => x.Books).FirstOrDefault(x => x.Id == PublisherID);
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

        public Try<bool> RemovePatron(int PatronID) => () => 
        {
            var db = dBFactory.GetDbContext();
            var patron = db.Patrons.Include(x => x.BorrowedBooks).FirstOrDefault(x => x.Id == PatronID);
            if (patron is not null)
            {
                if (patron.BorrowedBooks.Count == 0)
                {
                    patron.IsDeleted = true;
                    patron.IsActive = false;
                    db.SaveChanges();
                    return new Result<bool>(true);
                }
                else
                {
                    return new Result<bool>(new Exception($"Patron has Books that are listed as borrowed please resolve the borrowed books before deleting the patron"));
                }
            }
            else
            {
                return new Result<bool>(new Exception($"Invalid Patron Id no Patron with ID = {PatronID} found"));
            }
        };

        public Try<bool> RemoveBorrowedBook(int BorrowedBookID) => () => 
        {
            var db = dBFactory.GetDbContext();
            var borrowedBook = db.BorrowedBooks.FirstOrDefault(x => x.Id == BorrowedBookID);
            if (borrowedBook is not null)
            {
                db.BorrowedBooks.Remove(borrowedBook);
                db.SaveChanges();
                return new Result<bool>(true);
            }
            else
            {
                return new Result<bool>(new Exception($"There is no Borrowed book with ID {BorrowedBookID}"));
            }
        };

        public Try<bool> BorrowBook(int PatronID, int BookID, TimeSpan returnTimeSpan) => () => 
        {
            var db = dBFactory.GetDbContext();
            var book = db.Books.Include(x => x.BorrowedBook).FirstOrDefault(x => x.Id == BookID);
            var patron = db.Patrons.Include(x => x.BorrowedBooks).FirstOrDefault(x => x.Id == PatronID);
            if (patron is null || book is null)
            {
                return DetermineNullException(book, patron);
            }
            else
            {
                if (book.BorrowedBook is not null)
                {
                    return new Result<bool>(new Exception("Book is currently being borrowed"));
                }
                else
                {
                    DateTime duedate = DateTime.Now;
                    duedate.Add(returnTimeSpan);
                    BorrowedBook borrowBook = CreateBorrowBook(book, patron, duedate);
                    SetCreationValues(borrowBook);
                    db.BorrowedBooks.Add(borrowBook);
                    db.SaveChanges();
                    return new Result<bool>(true);
                }
            }
        };

        public Try<List<BorrowedBookDto>> GetBorrowedBooksByPatron(int PatronID) => () => 
        {
            var db = dBFactory.GetDbContext();
            var borrowedBooks = db.BorrowedBooks.AsNoTracking().Include(x => x.Book).ThenInclude(x => x.Author).Include(x => x.Book).ThenInclude(x => x.Publisher).Where(x => x.Patron.Id == PatronID).ToList();
            if (borrowedBooks is not null)
            {
                if (borrowedBooks.Count > 0)
                {
                    return GetPatronsBorrowedBookList(borrowedBooks);
                }
                else
                {
                    return new Result<List<BorrowedBookDto>>(new List<BorrowedBookDto>());
                }
            }
            else
            {
                return new Result<List<BorrowedBookDto>>(new Exception("Invalid Patron"));
            }
        };

        private static Result<List<BorrowedBookDto>> GetPatronsBorrowedBookList(List<BorrowedBook> borrowedBooks)
        {
            List<BorrowedBookDto> borrowedLibraryBooks = new List<BorrowedBookDto>();
            foreach (BorrowedBook book in borrowedBooks)
            {
                if (book is not null)
                {
                    borrowedLibraryBooks.Add(book.MapToDto());
                }
                else
                {
                    return new Result<List<BorrowedBookDto>>(new Exception("Invalid Book in list, Contact Database Administrator"));
                }
            }
            return new Result<List<BorrowedBookDto>>(borrowedLibraryBooks);
        }

        public Try<List<BorrowedBookDto>> GetBorrowedBooksList() => () => 
        {
            var db = dBFactory.GetDbContext();
            var borrowedBooks = db.BorrowedBooks.AsNoTracking().Include(x => x.Book).ThenInclude(x => x.Author).Include(x => x.Book).ThenInclude(x => x.Publisher).ToList();
            if (borrowedBooks.Count > 0)
            {
                List<BorrowedBookDto> BookList = new List<BorrowedBookDto>();
                foreach (var book in borrowedBooks)
                {
                    BookList.Add(book.MapToDto());
                }
                return new Result<List<BorrowedBookDto>>(BookList);
            }
            else
            {
                return new Result<List<BorrowedBookDto>>(new Exception("No Borrowed books found"));
            }
        };

        public Try<List<BookDto>> GetAuthorBooks(int AuthorID) => () => 
        {
            var db = dBFactory.GetDbContext();
            var author = db.Authors.AsNoTracking().Include(x => x.Books).ThenInclude(x => x.Publisher).FirstOrDefault(x => x.Id == AuthorID);
            if (author is not null && author.Books.Count > 0)
            {
                var BookList = new List<BookDto>();
                foreach (var book in author.Books)
                {
                    BookList.Add(book.MapToDto());
                }
                return new Result<List<BookDto>>(BookList);
            }
            else
            {
                if (author is not null)
                {
                    return new Result<List<BookDto>>(new List<BookDto>());
                }
                else
                {
                    return new Result<List<BookDto>>(new Exception("Invalid Author"));
                }
            }
        };

        public Try<List<BookDto>> GetPublisherBooks(int PublisherID) => () => 
        {
            var db = dBFactory.GetDbContext();
            var publisher = db.Publishers.AsNoTracking().Include(x => x.Books).ThenInclude(x => x.Author).FirstOrDefault(x => x.Id == PublisherID);
            if (publisher is not null && publisher.Books.Count > 0)
            {
                var bookList = new List<BookDto>();
                foreach (Book book in publisher.Books)
                {
                    bookList.Add(book.MapToDto());
                }
                return new Result<List<BookDto>>(bookList);
            }
            else
            {
                if (publisher is not null)
                {
                    return new Result<List<BookDto>>(new List<BookDto>());
                }
                else
                {
                    return new Result<List<BookDto>>(new Exception("Invalid Publisher"));
                }
            }
        };

        public Try<List<PublisherDto>> GetPublisherList() => () => 
        {
            var db = dBFactory.GetDbContext();
            var publishers = db.Publishers.AsNoTracking().ToList();
            if (publishers.Count > 0 && publishers.Any(x => x.IsDeleted == false))
            {
                var list = new List<PublisherDto>();
                foreach (var publisher in publishers)
                {
                    list.Add(publisher.MapToDto());
                }
                return new Result<List<PublisherDto>>(list);
            }
            else
            {
                if (publishers.Count > 0)
                {
                    return new Result<List<PublisherDto>>(new Exception("All publisher have been deleted"));
                }
                else
                {
                    return new Result<List<PublisherDto>>(new Exception("No publishers available"));
                }
            }

        };

        public Try<List<AuthorDto>> GetAuthorList() => () => 
        {
            var db = dBFactory.GetDbContext();
            var authors = db.Authors.AsNoTracking().ToList();
            if (authors.Count > 0 && authors.Any(x => x.IsDeleted == false))
            {
                var list = new List<AuthorDto>();
                foreach (var author in authors)
                {
                    list.Add(author.MapToDto());
                }
                return new Result<List<AuthorDto>>(list);
            }
            else
            {
                if (authors.Count > 0)
                {
                    return new Result<List<AuthorDto>>(new Exception("All Authors have been deleted"));
                }
                else
                {
                    return new Result<List<AuthorDto>>(new Exception("No Authors available"));
                }
            }
        };

        public Try<List<BookDto>> GetBookList() => () => 
        {
            var db = dBFactory.GetDbContext();
            var books = db.Books.AsNoTracking().Include(x => x.Author).Include(x => x.Publisher).ToList();
            if (books.Count > 0 && books.Any(x => x.IsDeleted == false))
            {
                var list = new List<BookDto>();
                foreach (var book in books)
                {
                    if (book.IsDeleted == false)
                    {
                        list.Add(book.MapToDto());
                    }
                }
                return new Result<List<BookDto>>(list);
            }
            else
            {
                if (books.Count > 0)
                {
                    return new Result<List<BookDto>>(new Exception("All books in list are deleted"));
                }
                else
                {
                    return new Result<List<BookDto>>(new Exception("No Books available"));
                }
            }
        };

        public Try<List<PatronDto>> GetPatronList() => () => 
        {
            var db = dBFactory.GetDbContext();
            var patrons = db.Patrons.AsNoTracking().ToList();
            if (patrons.Count > 0 && patrons.Any(p => p.IsDeleted == false))
            {
                var list = new List<PatronDto>();
                foreach (var patron in patrons)
                {
                    if (patron.IsDeleted == false)
                    {
                        list.Add(patron.MapToDto());
                    }
                }
                return new Result<List<PatronDto>>(list);
            }
            else
            {
                if (patrons.Count > 0)
                {
                    return new Result<List<PatronDto>>(new Exception("All patrons in list are deleted"));
                }
                else
                {
                    return new Result<List<PatronDto>>(new Exception("No Patrons available"));
                }
            }
        };

        public Try<bool> UpdateAuthor(AuthorDto author) => () => 
        {
            var db = dBFactory.GetDbContext();
            var dbAuthor = db.Authors.FirstOrDefault(x => x.Id == author.Id);
            if (dbAuthor is null)
                return new Result<bool>(new Exception("Author not Found"));
            dbAuthor.Name = author.Name;
            dbAuthor.Biography = author.Biography;
            db.Update(dbAuthor);
            db.SaveChanges();
            return new Result<bool>(true);
        };

        public Try<bool> UpdateBook(BookDto book) => () => 
        {
            var db = dBFactory.GetDbContext();
            var dbBook = db.Books.Include(x => x.Author).Include(x => x.Publisher).FirstOrDefault(x => x.Id == book.Id);
            if (dbBook is null)
                return new Result<bool>(new Exception("Book not found"));
            if (dbBook.Author.Id != book.authorID)
            {
                var dbAuthor = db.Authors.FirstOrDefault(x => x.Id == book.authorID);
                if (dbAuthor is null)
                    return new Result<bool>(new Exception("Selected Author not found"));
                dbBook.Author = dbAuthor;
            }
            if (dbBook.Publisher.Id != book.publisherID)
            {
                var dbPublisher = db.Publishers.FirstOrDefault(x => x.Id == book.publisherID);
                if (dbPublisher is null)
                    return new Result<bool>(new Exception("Selected Publisher not found"));
                dbBook.Publisher = dbPublisher;
            }
            dbBook.Title = book.Title; 
            dbBook.Description = book.Description;
            dbBook.ISBN = book.ISBN;
            db.Update(dbBook);
            db.SaveChanges();
            return new Result<bool>(true);
        };

        public Try<bool> UpdateBorrowedBook(BorrowedBookDto book) => () => 
        {
            var db = dBFactory.GetDbContext();
            var dbBorrowedBook = db.BorrowedBooks.FirstOrDefault(x => x.Id == book.Id);
            if (dbBorrowedBook is null)
                return new Result<bool>(new Exception("BorrowedBook not found"));
            dbBorrowedBook.DueDate = book.DueDate;
            dbBorrowedBook.BorrowedDate = book.BorrowedDate;
            db.Update(dbBorrowedBook);
            db.SaveChanges();
            return new Result<bool>(true);
        };

        public Try<bool> UpdatePatron(PatronDto patron) => () => 
        {
            var db = dBFactory.GetDbContext();
            var dbPatron = db.Patrons.FirstOrDefault(x =>x.Id == patron.Id);
            if (dbPatron is null)
                return new Result<bool>(new Exception("Patron not found"));
            dbPatron.City = patron.City;
            dbPatron.StreetAddress = patron.StreetAddress;
            dbPatron.Name = patron.Name;
            dbPatron.PhoneNumber = patron.PhoneNumber;
            dbPatron.PostalCode = patron.PostalCode;
            db.Update(dbPatron);
            db.SaveChanges();
            return new Result<bool>(true);
        };

        public Try<bool> UpdatePublisher(PublisherDto publisher) => () => 
        {
            var db = dBFactory.GetDbContext();
            var dbPublisher = db.Publishers.FirstOrDefault(x =>  x.Id == publisher.Id);
            if (dbPublisher is null) 
                return new Result<bool>(new Exception("Publisher not found"));
            dbPublisher.Description = publisher.Description;
            dbPublisher.Name = publisher.Name;
            db.Update(dbPublisher);
            db.SaveChanges();
            return new Result<bool>(true);
        };
    }
}
