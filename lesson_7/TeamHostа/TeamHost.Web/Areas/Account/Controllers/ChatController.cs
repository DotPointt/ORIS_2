using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Account.Controllers;
[Area("Account")]
public class ChatController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}