using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Equinox.Models;

namespace Equinox.Controllers
{
    public class HomeController : Controller
    {
        // GET: / (renders the client home page view)
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/Contact
        public IActionResult Contact()
        {
            return Content($"Area=Main;Controller=Home;Action=Contact");
        }

        // GET: /Home/Privacy
        public IActionResult Privacy()
        {
            return Content($"Area=Main;Controller=Home;Action=Privacy");
        }

        // GET: /Home/Terms
        public IActionResult Terms()
        {
            return Content($"Area=Main;Controller=Home;Action=Terms");
        }

        // GET: /Home/Cookie
        public IActionResult Cookie()
        {
            return Content($"Area=Main;Controller=Home;Action=Cookie");
        }

        // Standard error handler
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var vm = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(vm);
        }
    }
}
