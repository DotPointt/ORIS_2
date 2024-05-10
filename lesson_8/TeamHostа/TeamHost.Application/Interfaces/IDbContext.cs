using Microsoft.EntityFrameworkCore;
using TeamHost.Domain.Entities;

namespace TeamHost.Application.Interfaces;

public interface IDbContext
{
    /// <summary>
    /// Категории
    /// </summary>
    public DbSet<Category> Categories { get; set; }
    
    /// <summary>
    /// Страны
    /// </summary>
    public DbSet<Country> Countries { get; set; }
    
    /// <summary>
    /// Компании
    /// </summary>
    public DbSet<Company> Companies { get; set; }
    
    /// <summary>
    /// Игры
    /// </summary>
    public DbSet<Game> Games { get; set; }
    
    /// <summary>
    /// Файлы
    /// </summary>
    public DbSet<StaticFile> StaticFiles { get; set; }
    
    /// <summary>
    /// Пользователи
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Информация о пользователе
    /// </summary>
    public DbSet<UserInfo> UserInfos { get; set; }
}