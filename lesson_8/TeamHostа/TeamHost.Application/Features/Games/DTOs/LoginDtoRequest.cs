namespace TeamHost.Application.Features.Games.DTOs;

public class LoginDtoRequest 
{
    public LoginDtoRequest()
    {
    }
    public LoginDtoRequest(LoginDtoRequest request)
    {
        Password = request.Password;
        Username = request.Username;
    }
    public string Password { get; set; }

    public string Username { get; set; }
}