using System.Collections.Generic;
using Equinox.Models;

namespace Equinox.Models
{
    public class ClassViewModel
    {
        public string ActiveClubId { get; set; } = "all";
        public string ActiveCategoryId { get; set; } = "all";
        public List<EquinoxClass> Classes { get; set; } = new();
        public List<Club> Clubs { get; set; } = new();
        public List<ClassCategory> Categories { get; set; } = new();

        public string CheckActiveClub(string clubId)
            => clubId.ToLower() == ActiveClubId.ToLower() ? "active" : "";

        public string CheckActiveCategory(string catId)
            => catId.ToLower() == ActiveCategoryId.ToLower() ? "active" : "";
    }
}
