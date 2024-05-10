using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Home.Controllers;
[Area("Home")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        if (!Request.Cookies.ContainsKey("Language"))
        {
            // Если куки не существует, устанавливаем язык по умолчанию
            var defaultLanguage = "en";
            Response.Cookies.Append("Language", defaultLanguage, new CookieOptions
            {
                // Установка времени жизни куки, например, в один месяц
                Expires = DateTime.UtcNow.AddMonths(1),
                // Путь, для которого куки будут доступны, например, корень сайта
                Path = "/"
            });
        }
        return View();
    }
    
   
}