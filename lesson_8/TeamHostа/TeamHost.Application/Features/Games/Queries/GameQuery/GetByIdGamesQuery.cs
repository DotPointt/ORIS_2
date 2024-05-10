using MediatR;
using TeamHost.Application.Features.Games.DTOs;

namespace TeamHost.Application.Features.Games.Queries.GameQuery;

public class GetByIdGamesQuery : IRequest<GetByIdGameResponse>
{
    public GetByIdGamesQuery(int id) => Id = id;
    
    public int Id { get; set; }
}
