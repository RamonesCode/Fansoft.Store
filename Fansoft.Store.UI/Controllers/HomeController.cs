using Microsoft.AspNetCore.Mvc;

namespace Fansoft.Store.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult About() => View();
    }
}
