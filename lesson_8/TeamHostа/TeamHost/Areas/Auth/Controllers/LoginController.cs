using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Features.Games.DTOs;
using TeamHost.Application.Features.Games.Queries.LoginQuery;

namespace TeamHost.Web.Areas.Auth.Controllers;


[Area("Auth")]
public class LoginController : Controller
{

    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }
    public IActionResult Index()
    {
        Console.WriteLine("Логинимся");
        return View();
    }
    

    [HttpPost]
    public async Task<IActionResult> Login([FromForm] LoginDtoRequest loginDtoRequest)
    {
        var result = await _mediator.Send(new LoginUserQuery(loginDtoRequest));
        
        if (!result.IsSuccessfully)
            return BadRequest(result.Errors);
        
        return RedirectToAction("Index", "Home", new { area = "Home" });
    }
}

