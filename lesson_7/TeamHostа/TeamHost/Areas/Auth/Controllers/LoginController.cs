using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Auth.Controllers;


[Area("Auth")]
public class LoginController : Controller
{

   
    public IActionResult Index()
    {
        Console.WriteLine("Логинимся");
        return View();
    }
    

    [HttpPost]
    public async Task<IActionResult> Login()
    {
        return RedirectToAction("Index", "Home", new { area = "Home" });
    }
}

