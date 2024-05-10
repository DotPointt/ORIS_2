using MediatR;
using TeamHost.Application.Features.Games.DTOs;
using TeamHost.Application.Features.Games.Queries.GameQuery;
using TeamHost.Application.Interfaces.Repositories;

namespace TeamHost.Application.Features.Games.Handlers.GameHandler;

public class GetByIdGamesQueryHandler : IRequestHandler<GetByIdGamesQuery, GetByIdGameResponse>
{
    
    private readonly IGameRepository _repository;
    
    public GetByIdGamesQueryHandler(IGameRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<GetByIdGameResponse> Handle(GetByIdGamesQuery request, CancellationToken cancellationToken)
    {
        var t =  await _repository.GetById(request.Id);
        
        return new GetByIdGameResponse()
        {
            Name = t.Name,
            Description = t.Description,
            Rating = t.Rating,
            ReleaseDate = t.ReleaseDate,
            Price = t.Price,
            MediaFiles = t.Images.Select(x => x.Path).ToList(),
            Platforms = t.Platforms.Select(x => x.Name).ToList(),
            MainImage = t.Images[0].Path,
            Company = t.Company.Name,
            Categories = t.Category.Select(x => x.Name).ToList(),
        };
    }
}