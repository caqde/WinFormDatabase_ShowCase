using System.ComponentModel.DataAnnotations;

namespace EFCore_DBModels
{
    public class dbObject: Types.Standard
    {
        [Required]
        public string Name { get; set; }
    }
}