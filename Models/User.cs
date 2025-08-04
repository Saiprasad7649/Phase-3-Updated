using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Equinox.Models
{
    public class User
    {
        public string UserId { get; set; } = string.Empty;
        
        [Required, StringLength(50), RegularExpression("^[a-zA-Z0-9 ]+$")]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Phone number must be in format (555) 123-4567")]
        [Remote("VerifyPhone","User","Admin",
                AdditionalFields = nameof(UserId),
                ErrorMessage="Phone in use")]
        public string PhoneNumber { get; set; } = string.Empty;
        
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required, DataType(DataType.Date)]
        [AgeRange(8,80, ErrorMessage="Age must be 8–80")]
        public DateTime DOB { get; set; }
        
        public bool IsCoach { get; set; } = false;
    }
}
