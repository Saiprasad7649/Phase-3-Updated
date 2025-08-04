using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Equinox.Models;
using Equinox.Utilities;
using System.Linq;

namespace Equinox.Controllers
{
    public class ClassController : Controller
    {
        private readonly EquinoxContext context;

        public ClassController(EquinoxContext ctx)
        {
            context = ctx;
        }

        public IActionResult List(string clubId, string categoryId)
        {
            // 1) Use the session‐wrapper to persist filter values
            var filterSession = new FilterSession(HttpContext.Session);

            if (!string.IsNullOrEmpty(clubId) || !string.IsNullOrEmpty(categoryId))
            {
                // store new values in session
                filterSession.ClubId     = clubId     ?? "all";
                filterSession.CategoryId = categoryId ?? "all";
            }
            else
            {
                // load last values from session
                clubId     = filterSession.ClubId;
                categoryId = filterSession.CategoryId;
            }

            // 2) Build the ViewModel
            var viewModel = new ClassViewModel
            {
                ActiveClubId     = clubId,
                ActiveCategoryId = categoryId,
                Clubs            = context.Clubs.ToList(),
                Categories       = context.ClassCategories.ToList()
            };

            // 3) Apply filters
            var classes = context.EquinoxClasses
                .Include(c => c.Club)
                .Include(c => c.ClassCategory)
                .Include(c => c.User)
                .AsQueryable();

            if (clubId != "all")
                classes = classes.Where(c => c.Club.ClubId.ToString() == clubId);

            if (categoryId != "all")
                classes = classes.Where(c => c.ClassCategory.ClassCategoryId.ToString() == categoryId);

            viewModel.Classes = classes.ToList();

            return View(viewModel);
        }

        public IActionResult Details(int id, string clubId, string categoryId)
        {
            // Pass the active filters along for the Details view
            ViewBag.ActiveClubId     = clubId     ?? "all";
            ViewBag.ActiveCategoryId = categoryId ?? "all";

            var equinoxClass = context.EquinoxClasses
                .Include(c => c.Club)
                .Include(c => c.ClassCategory)
                .Include(c => c.User)
                .FirstOrDefault(c => c.EquinoxClassId == id);

            if (equinoxClass == null)
                return NotFound();

            return View(equinoxClass);
        }
    }
}
