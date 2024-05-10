using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Market.Controllers
{
    [Area("Market")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
