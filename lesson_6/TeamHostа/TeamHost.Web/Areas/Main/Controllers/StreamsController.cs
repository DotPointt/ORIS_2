using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Main.Controllers;
[Area("Main")]
public class StreamsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}