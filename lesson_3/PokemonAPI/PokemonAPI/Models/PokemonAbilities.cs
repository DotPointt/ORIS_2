namespace PokemonAPI.Models;

/// <summary>
/// Массив с абилками покемона
/// </summary>
public class PokemonAbilities
{
    /// <summary>
    /// Слот абилки покемона
    /// </summary>
    public int Slot { get; set; }
        
    /// <summary>
    /// Абилка покемона
    /// </summary>
    public Ability? Ability { get; set; }
}

/// <summary>
/// Абилка покемона
/// </summary>
public class Ability
{
    /// <summary>
    /// Название абилки
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Ссылка на абилку
    /// </summary>
    public string Url { get; set; }
}
