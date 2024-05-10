using MediatR;
using TeamHost.Application.Features.Games.DTOs;

namespace TeamHost.Application.Features.Games.Queries.GameQuery;

public record GetAllGamesQuery : IRequest<GetAllGamesResponse>;

