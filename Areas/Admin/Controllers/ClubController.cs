using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Equinox.Models;

namespace Equinox.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class ClubController : Controller
    {
        private readonly EquinoxContext _context;
        public ClubController(EquinoxContext ctx) => _context = ctx;

        // LIST
        public IActionResult Index()
        {
            var clubs = _context.Clubs.ToList();
            return View(clubs);
        }

        // CREATE: GET
        public IActionResult Create()
        {
            return View(new Club());
        }

        // CREATE: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Club club)
        {
            if (!ModelState.IsValid) return View(club);
            _context.Clubs.Add(club);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Club added successfully.";
            return RedirectToAction(nameof(Index));
        }

        // EDIT: GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var club = _context.Clubs.Find(id);
            if (club == null) return NotFound();
            return View(club);
        }

        // EDIT: POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Club model)
        {
            if (id != model.ClubId)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(model);

            _context.Update(model);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Club updated successfully.";

            return RedirectToAction(nameof(Index));
        }

        // DELETE: GET confirm
        public IActionResult Delete(int id)
        {
            var club = _context.Clubs.Find(id);
            if (club == null) return NotFound();
            return View(club);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            TempData["SuccessMessage"] = "Club deleted successfully.";
            return DeleteClub(id);
        }



        private IActionResult DeleteClub(int id)
        {
            var club = _context.Clubs.Find(id);
            if (club != null)
            {
                _context.Clubs.Remove(club);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
