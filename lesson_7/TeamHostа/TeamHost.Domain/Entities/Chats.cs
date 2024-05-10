using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

public class Chats : BaseAuditableEntity
{
    public string? ChatTitle { get; set; }
    public StaticFile? ChatImage { get; set; }
    
    public List<UserInfo> Users { get; set; }
    
    public List<Message> Messages { get; set; }
}