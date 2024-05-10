namespace PokemonAPI.Models;

/// <summary>
/// Массив с типами покемона
/// </summary>
public class PokemonTypes
{
    /// <summary>
    /// Слот типа покемона
    /// </summary>
    public required int? Slot { get; set; }
    
    /// <summary>
    /// Тип покемона
    /// </summary>
    public required Type? Type { get; set; }
}

/// <summary>
/// Тип покемона
/// </summary>
public class Type
{
    /// <summary>
    /// Название типа
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// Ссылка на тип
    /// </summary>
    public required string Url { get; set; }
}