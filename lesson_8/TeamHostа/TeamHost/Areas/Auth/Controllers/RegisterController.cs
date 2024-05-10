using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Features.Games.DTOs;
using TeamHost.Application.Features.Games.Queries.AuthQuery;
using TeamHost.Domain.Entities;

namespace TeamHost.Web.Areas.Auth.Controllers;
[Area("Auth")]
public class RegisterController : Controller
{

    private readonly IMediator _mediator;

    private readonly SignInManager<User> _signInManager;

    public RegisterController(IMediator mediator, SignInManager<User> signInManager)
    {
        _mediator = mediator;
        _signInManager = signInManager;
    }
    public IActionResult Index()
    {
        Console.WriteLine("Регистрируем");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromForm] AuthDtoRequest authDtoRequest)
    {
        var result = await _mediator.Send(new AuthUserQuery(authDtoRequest));

        if (!result.IsSuccessfully)
            return BadRequest(result.Errors);
        
        return RedirectToAction("Index", "Home", new { area = "Home" });
    }
    
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home", new { area = "Home" });
    }
}

