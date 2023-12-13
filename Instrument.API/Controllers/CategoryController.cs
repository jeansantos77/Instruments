using Microsoft.AspNetCore.Mvc;

namespace Instrument.API.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
