using Microsoft.AspNetCore.Identity;

namespace TeamHost.Domain.Entities;

public class User : IdentityUser<int>
{
    public UserInfo UserInfo { get; set; }
}