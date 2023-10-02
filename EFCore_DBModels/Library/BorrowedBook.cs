using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_DBModels.Library
{
    public class BorrowedBook : Types.Standard
    {
        [Required]
        public DateTime BorrowedDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public Book Book { get; set; }
        public int BookId { get; set; }

        [Required]
        public Patron Patron { get; set; }
    }
}
