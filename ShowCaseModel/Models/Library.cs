using EFCore_DBLibrary;
using EFCore_DBModels.Library;
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

        public void AddAuthor(LibraryAuthor libraryAuthor)
        {
            var database = dBFactory.GetDbContext();
            Author author = new Author { Biography = libraryAuthor.Biography, Name = libraryAuthor.Name };
            database.Authors.Add(author);
            database.SaveChanges();
            libraryAuthor.Id = author.Id;
        }

        public void AddPatron(LibraryPatron libraryPatron)
        {
            var database = dBFactory.GetDbContext();
            Patron patron = new Patron { Name = libraryPatron.Name, City = libraryPatron.City, PhoneNumber = libraryPatron.PhoneNumber, StreetAddress = libraryPatron.StreetAddress, PostalCode = libraryPatron.PostalCode };
            database.Patrons.Add(patron);
            database.SaveChanges();
            libraryPatron.Id = patron.Id;
        }

        public void AddPublisher(LibraryPublisher libraryPublisher)
        {
            var database = dBFactory.GetDbContext();
            Publisher publisher = new Publisher { Description = libraryPublisher.Description, Name = libraryPublisher.Name };
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

        public void AddBook(LibraryBook book, int AuthorID, int PublisherID)
        {
            var database = dBFactory.GetDbContext();
            var author = database.Authors.FirstOrDefault(x => x.Id ==  AuthorID);
            var publisher = database.Publishers.FirstOrDefault(x => x.Id == PublisherID);
            if (publisher == null || author == null)
            {
                //throw exception or error?
                return;
            }
            else
            {
                Book newBook = new Book() { Author = author, Publisher = publisher, Description = book.Description, ISBN = book.ISBN, Title = book.Title };
                database.Books.Add(newBook);
                database.SaveChanges();
                book.Id = newBook.Id;
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
    }
}
