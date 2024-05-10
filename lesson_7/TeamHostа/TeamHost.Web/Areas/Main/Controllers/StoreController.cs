using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Main.Controllers;
[Area("Main")]
public class StoreController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}