using Microsoft.AspNetCore.Mvc;

namespace TMDT.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
