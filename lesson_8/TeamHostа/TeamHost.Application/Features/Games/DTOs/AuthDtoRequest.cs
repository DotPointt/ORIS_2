namespace TeamHost.Application.Features.Games.DTOs;

public class AuthDtoRequest
{
    public AuthDtoRequest()
    {
    }
    public AuthDtoRequest(AuthDtoRequest request)
    {
        Password = request.Password;
        Email = request.Email;
        Username = request.Username;
    }

    public string Password { get; set; }
    
    public string Email { get; set; }
    
    public string Username { get; set; }
}