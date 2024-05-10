using MediatR;
using TeamHost.Application.Features.Games.DTOs;

namespace TeamHost.Application.Features.Games.Queries.AuthQuery;

public class AuthUserQuery : AuthDtoRequest, IRequest<AuthDtoResponse>
{
    public AuthUserQuery(AuthDtoRequest request) : base(request)
    {
    }
   
}