using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Domain.Entities;

namespace TeamHost.Web.Areas.Auth.Controllers;
[Area("Auth")]
public class RegisterController : Controller
{

    
    public IActionResult Index()
    {
        Console.WriteLine("Регистрируем");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register()
    {
        return RedirectToAction("Index", "Home", new { area = "Home" });
    }
    
    public async Task<IActionResult> Logout()
    {
        return RedirectToAction("Index", "Home", new { area = "Home" });
    }
}

