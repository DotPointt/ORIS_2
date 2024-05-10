using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Account.Controllers;
[Area("Account")]
public class WalletController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
}