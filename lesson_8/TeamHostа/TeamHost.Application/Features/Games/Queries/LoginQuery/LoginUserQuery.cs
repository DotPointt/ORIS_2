using MediatR;
using TeamHost.Application.Features.Games.DTOs;

namespace TeamHost.Application.Features.Games.Queries.LoginQuery;

public class LoginUserQuery : LoginDtoRequest, IRequest<AuthDtoResponse>
{
    public LoginUserQuery(LoginDtoRequest loginDtoRequest) : base(loginDtoRequest)
    {
        
    }
}