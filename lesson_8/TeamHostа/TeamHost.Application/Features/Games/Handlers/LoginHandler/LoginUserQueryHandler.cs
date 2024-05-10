using MediatR;
using Microsoft.AspNetCore.Identity;
using TeamHost.Application.Features.Games.DTOs;
using TeamHost.Application.Features.Games.Queries.LoginQuery;
using TeamHost.Application.Interfaces.Repositories;
using TeamHost.Domain.Entities;

namespace TeamHost.Application.Features.Games.Handlers.LoginHandler;

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, AuthDtoResponse>
{
    private readonly ILoginRepository _loginRepository;
    
    private readonly SignInManager<User> _signInManager;


    public LoginUserQueryHandler(ILoginRepository loginRepository, SignInManager<User> signInManager)
    {
        _loginRepository = loginRepository;
        _signInManager = signInManager;
    }
    public async Task<AuthDtoResponse> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (string.IsNullOrEmpty(request.Password))
            throw new ApplicationException("Password обязателен");

        if (string.IsNullOrWhiteSpace(request.Username))
            throw new ApplicationException("Username обязателен");
        
        var user = await _loginRepository.GetUserByName(request.Username);

        if (user == null!)
        {
            return new AuthDtoResponse()
            {
                IsSuccessfully = false,
                Errors = new List<string>() { "Такого пользователя нет!" }
            };
        }
        
        await _signInManager.SignInAsync(user, false);

        return new AuthDtoResponse()
        {
            IsSuccessfully = true,
            Errors = null!
        };
    }
}