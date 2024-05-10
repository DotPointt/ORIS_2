namespace TeamHost.Application.Features.Games.DTOs;

public class GetGamesItemDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Цена (в вонах)
    /// </summary>
    public decimal Price { get; set; }
            
    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Главное изображение
    /// </summary>
    public string? MainImagePath { get; set; }

    /// <summary>
    /// Рейтинг
    /// </summary>
    public float Rating { get; set; }

    /// <summary>
    /// Категория
    /// </summary>
    public List<string> Categories { get; set; }

    /// <summary>
    /// Платформа
    /// </summary>
    public List<string> Platforms { get; set; }
}