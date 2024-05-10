namespace TeamHost.Application.Features.Games.DTOs;

public class AuthDtoResponse
{
    public bool IsSuccessfully { get; set; }
    
    public List<string> Errors { get; set; }
}