using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_DBModels.Library
{
    public class Book : Types.Standard
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int ISBN { get; set; }
        [Required]
        public Author Author { get; set; }
        [Required]
        public Publisher Publisher { get; set; }
    }
}
