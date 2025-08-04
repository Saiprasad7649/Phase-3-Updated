using System.ComponentModel.DataAnnotations;

namespace Equinox.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        public int EquinoxClassId { get; set; }

        public EquinoxClass? EquinoxClass { get; set; }
    }
}
