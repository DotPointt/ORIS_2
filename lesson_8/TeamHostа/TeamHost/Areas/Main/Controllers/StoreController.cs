using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamHost.Application.Features.Games.Queries.GameQuery;

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
        var result = await _mediator.Send(new GetAllGamesQuery());
        

        foreach (var res in result.Games)
        {
            Console.WriteLine(res.MainImagePath);
        }
        
        return View(result);
    }
    
    [HttpGet("card-store/{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var result = await _mediator.Send(new GetByIdGamesQuery(id));
        return View(result);
    }
    
}