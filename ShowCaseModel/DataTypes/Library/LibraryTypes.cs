using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseModel.DataTypes.Library
{
    public class LibraryAuthor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
    }

    public class LibraryPublisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class LibraryBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ISBN { get; set; }
    }

    public class LibraryBorrowedBook
    {
        public int Id { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime DueDate { get; set; }
        public LibraryBook BorrowedBook { get; set; }
    }

    public class LibraryPatron
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
