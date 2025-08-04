using Microsoft.AspNetCore.Mvc;

namespace Equinox.Controllers
{
    public class MembershipController : Controller
    {
        // GET /Membership/List or /Membership/List?id=Gold
        public IActionResult List(string id = "All")
        {
            return Content($"Area=Main, Controller=Membership, Action=List, id={id}");
        }
    }
}
