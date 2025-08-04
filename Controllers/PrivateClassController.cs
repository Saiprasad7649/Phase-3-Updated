using Microsoft.AspNetCore.Mvc;

namespace Equinox.Controllers
{
    public class PrivateClassController : Controller
    {
        // GET /PrivateClass/List or /PrivateClass/List?id=Pilates
        public IActionResult List(string id = "All")
        {
            return Content($"Area=Main, Controller=PrivateClass, Action=List, id={id}");
        }
    }
}
