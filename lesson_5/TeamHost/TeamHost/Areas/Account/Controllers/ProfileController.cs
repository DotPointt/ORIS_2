using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Areas.Account.Controllers;

[Area("Account")]
public class ProfileController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}