namespace PokemonAPI.Models;

/// <summary>
/// Покемон
/// </summary>
public class Poke
{
    /// <summary>
    /// Имя покемона
    /// </summary>
    public required string Name { get; set; }
        
    /// <summary>
    /// Ссылка на покемона
    /// </summary>
    public required string Url { get; set; }
}

/// <summary>
/// Массив покемонов
/// </summary>
public class PokemonResponse
{
    /// <summary>
    /// Количество всех покемонов
    /// </summary>
    public required int Count { get; set; }
    
    /// <summary>
    /// Массив покемонов
    /// </summary>
    public required Poke[] Results { get; set; }
}
