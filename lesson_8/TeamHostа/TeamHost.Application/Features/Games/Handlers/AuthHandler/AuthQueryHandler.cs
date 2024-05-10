using MediatR;
using Microsoft.AspNetCore.Identity;

using TeamHost.Application.Features.Games.DTOs;
using TeamHost.Application.Features.Games.Queries.AuthQuery;
using TeamHost.Application.Interfaces.Repositories;
using TeamHost.Domain.Entities;

namespace TeamHost.Application.Features.Games.Handlers.AuthHandler;

public class AuthQueryHandler : IRequestHandler<AuthUserQuery, AuthDtoResponse>
{

    private readonly UserManager<User> _userManager;

    private readonly ILoginRepository _loginRepository;

    private readonly SignInManager<User> _signInManager;

    public AuthQueryHandler(UserManager<User> userManager, ILoginRepository loginRepository, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _loginRepository = loginRepository;
        _signInManager = signInManager;
    }
    public async Task<AuthDtoResponse> Handle(AuthUserQuery request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Медиатр");
        Console.WriteLine(request.Email);
        Console.WriteLine(request.Password);
        Console.WriteLine(request.Username);
        
        if (request is null)
            throw new ArgumentNullException(nameof(request));
        
        if (string.IsNullOrEmpty(request.Email))
            throw new ApplicationException("Email обязателен");

        if (string.IsNullOrEmpty(request.Password))
            throw new ApplicationException("Password обязателен");

        if (string.IsNullOrWhiteSpace(request.Username))
            throw new ApplicationException("Username обязателен");
        
        var email = await _loginRepository.GetUserByEmail(request.Email);
        
        if (email != null!)
        {
            return new AuthDtoResponse()
            {
                IsSuccessfully = false,
                Errors = new List<string>() { "Такой пользователь уже зарегестрирован" }
            };
        }
       

        UserInfo userInfo= new UserInfo
        {
            FirstName = "Тимерхан",
            LastName = "Мухутдинов",
            Patronimic = "Аглямович",
            NickName = request.Username,
            Country = new Country
            {
                Name = "Неизвестно",
                Fullname = "Не знаю"
            },
        };

        User user = new User
        {
            UserName = request.Username,
            Email = request.Email,
            PasswordHash = request.Password,
            UserInfo = userInfo
        };
        Console.WriteLine("IMediatr re " + " " + request.Password);
        Console.WriteLine("IMediatr re " + " " + request.Email);
        Console.WriteLine("IMediatr re " + " " + request.Username);
        IdentityResult result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            return new AuthDtoResponse()
            {
                IsSuccessfully = false,
                Errors = result.Errors
                    .Select(x => x.Description)
                    .ToList()
            };
        }
        await _signInManager.SignInAsync(user, false);


        return new AuthDtoResponse() { IsSuccessfully = true, Errors = null!};
    }
}