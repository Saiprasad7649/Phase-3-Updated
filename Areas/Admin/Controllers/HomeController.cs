using Microsoft.AspNetCore.Mvc;

namespace Equinox.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class HomeController : Controller
    {
        // GET: /Admin/Home/Index
        public IActionResult Index()
        {
            return View();
        }
    }
}
