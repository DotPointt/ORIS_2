using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Main.Controllers;
[Area("Main")]
public class CommunityController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}