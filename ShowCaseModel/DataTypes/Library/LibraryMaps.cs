using EFCore_DBModels.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseModel.DataTypes.Library
{
    public static class LibraryMaps
    {
        public static AuthorDto MapToDto(this Author author)
        {
            return new AuthorDto() {
                Biography = author.Biography, 
                Id = author.Id, 
                Name = author.Name
            };
        }

        public static PublisherDto MapToDto(this Publisher publisher ) 
        {
            return new PublisherDto() { 
                Name = publisher.Name,
                Id = publisher.Id,
                Description = publisher.Description             
            };
        }

        public static BookDto MapToDto(this Book book ) 
        {
            return new BookDto()
            {
                Id = book.Id,
                ISBN = book.ISBN,
                Description = book.Description,
                Title = book.Title,
                authorID = book.Author.Id,
                publisherID = book.Publisher.Id
            };
        }

        public static BorrowedBookDto MapToDto(this BorrowedBook borrowedBook )
        {
            return new BorrowedBookDto()
            {
                Id = borrowedBook.Id,
                BorrowedDate = borrowedBook.BorrowedDate,
                DueDate = borrowedBook.DueDate,
                BorrowedBook = borrowedBook.Book.MapToDto()
            };
        }

        public static PatronDto MapToDto(this Patron patron )
        {
            return new PatronDto()
            {
                City = patron.City,
                Id = patron.Id,
                Name = patron.Name,
                PhoneNumber = patron.PhoneNumber,
                PostalCode = patron.PostalCode,
                StreetAddress = patron.StreetAddress
            };
        }

    }
}
