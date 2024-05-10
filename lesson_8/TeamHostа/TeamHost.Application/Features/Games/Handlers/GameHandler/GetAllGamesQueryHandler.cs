using MediatR;
using TeamHost.Application.Features.Games.DTOs;
using TeamHost.Application.Features.Games.Queries.GameQuery;
using TeamHost.Application.Interfaces.Repositories;

namespace TeamHost.Application.Features.Games.Handlers.GameHandler
{
    internal class GetAllPlayersQueryHandler : IRequestHandler<GetAllGamesQuery, GetAllGamesResponse>
    {
        
        private readonly IGameRepository _repository;

        public GetAllPlayersQueryHandler(IGameRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllGamesResponse> Handle(GetAllGamesQuery query, CancellationToken cancellationToken)
        {

            var result = await _repository.GetAllGame();

            var allGames = result.Select(x => new GetGamesItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Rating = x.Rating,
                MainImagePath = x.Images[0].Path,
              
            }).ToList();
            
            return new GetAllGamesResponse() { TotalCount = allGames.Count, Games = allGames };
        }
    }
}
