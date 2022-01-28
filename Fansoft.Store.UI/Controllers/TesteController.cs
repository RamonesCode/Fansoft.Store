using Microsoft.AspNetCore.Mvc;

namespace Fansoft.Store.UI.Controllers
{
    public class TesteController : Controller
    {
        public ContentResult Index() => Content("App ok");
        
    }
}
