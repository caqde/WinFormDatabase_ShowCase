using System.ComponentModel.DataAnnotations;

namespace EFCore_DBModels.SingleAttribute
{
    public class dbObject : Types.Standard
    {
        [Required]
        public string Name { get; set; }
    }
}