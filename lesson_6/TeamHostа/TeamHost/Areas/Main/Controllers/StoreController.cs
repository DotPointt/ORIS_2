using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TeamHost.Web.Areas.Main.Controllers;
[Area("Main")]
public class StoreController : Controller
{
    private readonly IMediator _mediator;

    public StoreController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        
        return View();
    }
    
    [HttpGet("card-store/{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        return View();
    }
    
}