using Newtonsoft.Json;

namespace PokemonAPI.Models;

/// <summary>
/// Массив со статами покемона
/// </summary>
public class PokemonStats
{
    /// <summary>
    /// Параметр статы покемона
    /// </summary>
    [JsonProperty("base_stat")]
    public required int BaseStat { get; set; }
    
    /// <summary>
    /// Стата покемона
    /// </summary>
    public required Stat Stat { get; set; }
}

/// <summary>
/// Стата покемона
/// </summary>
public class Stat
{
    /// <summary>
    /// Название статы покемона
    /// </summary>
    public required string Name { get; set; }
}