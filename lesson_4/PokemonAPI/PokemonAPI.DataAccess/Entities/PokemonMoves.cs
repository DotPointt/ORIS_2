namespace PokemonAPI.DataAccess.Entities;

/// <summary>
/// Массив с мувами покемона
/// </summary>
public class PokemonMoves
{
    /// <summary>
    /// Мув покемона
    /// </summary>
    public required Move Move { get; set; }
}

/// <summary>
/// Мув покемона
/// </summary>
public class Move
{
    /// <summary>
    /// Название мува
    /// </summary>
    public required string Name { get; set; }
    
    /// <summary>
    /// Ссылка на мув
    /// </summary>
    public string? Url { get; set; }
    
    /// <summary>
    /// Тип мува покемона
    /// </summary>
    public Type? Type { get; set; }
}