using System.ComponentModel.DataAnnotations;

namespace Equinox.Models
{
    public class ClassCategory
    {
        public int ClassCategoryId { get; set; }
        
        [Required(ErrorMessage="Required")]
        [StringLength(50, ErrorMessage="Max 50 chars")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage="Alphanumeric only")]
        public string Name { get; set; } = string.Empty;
    }
}
