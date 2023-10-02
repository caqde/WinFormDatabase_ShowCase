using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_DBModels.Library
{
    public class Patron : Types.Standard
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public List<BorrowedBook>? BorrowedBooks { get; set;}
    }
}
