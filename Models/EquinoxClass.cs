namespace Equinox.Models
{
    public class EquinoxClass
    {
        public int EquinoxClassId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ClassPicture { get; set; } = string.Empty;
        public string ClassDay { get; set; } = string.Empty; // "Monday", "Tuesday", etc.
        public string Time { get; set; } = string.Empty;     // e.g., "8 AM – 9 AM"

        public int ClassCategoryId { get; set; }
        public ClassCategory ClassCategory { get; set; } = null!;

        public int ClubId { get; set; }
        public Club Club { get; set; } = null!;

        public string? UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
