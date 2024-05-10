using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

public class UserInfo : BaseEntity
{
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string? Patronimic { get; set; }

    /// <summary>
    /// Информация о себе
    /// </summary>
    public string? About { get; set; }

    /// <summary>
    /// День рождения
    /// </summary>
    public DateTime? Birthday { get; set; }

    /// <summary>
    /// Страна
    /// </summary>
    public Country? Country { get; set; }

    /// <summary>
    /// ИД страны
    /// </summary>
    public int? CountryId { get; set; }
    
    /// <summary>
    /// Nav-prop
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// ИД пользователя
    /// </summary>
    public int? UserId { get; set; }
    /// <summary>
    /// Ник
    /// </summary>
    public string NickName { get; set; }
    
    public List<Chats> ChatsList { get; set; }
    
}