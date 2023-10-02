using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_DBModels.Library
{
    public class Author : Types.Standard
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Biography { get; set; }
        
        public List<Book> Books { get; set; }
    }
}
