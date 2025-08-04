using System.ComponentModel.DataAnnotations;

namespace Equinox.Models
{
    public class Club
    {
        public int ClubId { get; set; }
        
        [Required(ErrorMessage="Required")]
        [StringLength(50, ErrorMessage="Max 50 chars")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage="Alphanumeric only")]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Phone number must be in format (555) 123-4567")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
