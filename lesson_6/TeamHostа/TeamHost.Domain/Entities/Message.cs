using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

public class Message : BaseAuditableEntity
{
    public string MessageContent { get; set; }
    
    public int SenderUserId { get; set; }
    
    public UserInfo SenderUserInfo { get; set; }
    
    public int ChatId { get; set; }
    
    public Chats Chat { get; set; }
}