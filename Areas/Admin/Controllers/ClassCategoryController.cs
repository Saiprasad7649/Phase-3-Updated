using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Equinox.Models;

namespace Equinox.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class ClassCategoryController : Controller
    {
        private readonly EquinoxContext _context;
        public ClassCategoryController(EquinoxContext context) => _context = context;

        // LIST
        public IActionResult Index()
        {
            var categories = _context.ClassCategories.ToList();
            return View(categories);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return View(new ClassCategory());
        }

        // CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClassCategory category)
        {
            if (!ModelState.IsValid) return View(category);

            _context.ClassCategories.Add(category);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Class category added successfully.";
            return RedirectToAction(nameof(Index));
        }

        // EDIT (GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.ClassCategories.Find(id);
            if (category == null) return NotFound();

            return View(category);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ClassCategory model)
        {
            if (id != model.ClassCategoryId)
                return BadRequest();

            if (!ModelState.IsValid) return View(model);

            _context.Update(model);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Class category updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        // DELETE (GET)
        public IActionResult Delete(int id)
        {
            var category = _context.ClassCategories.Find(id);
            if (category == null) return NotFound();

            return View(category);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            TempData["SuccessMessage"] = "Class category deleted successfully.";
            return DeleteCategory(id);
        }



        private IActionResult DeleteCategory(int id)
        {
            var category = _context.ClassCategories.Find(id);
            if (category != null)
            {
                _context.ClassCategories.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
