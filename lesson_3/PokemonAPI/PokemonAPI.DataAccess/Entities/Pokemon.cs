namespace PokemonAPI.DataAccess.Entities;

/// <summary>
/// Покемон
/// </summary>
public class Pokemon
{
    /// <summary>
    /// ID покемона
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Имя покемона
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Рост покемона
    /// </summary>
    public int? Height { get; set; }
    
    /// <summary>
    /// Вес покемона
    /// </summary>
    public int? Weight { get; set; }

    /// <summary>
    /// Ссылка на картинку покемона
    /// </summary>
    public string? ImageUrl
    {
        get
        {
            int id = Id;
            return $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/home/{id}.png";
        }
    }
    
    /// <summary>
    /// Массив абилок покемона
    /// </summary>
    public PokemonAbilities[]? Abilities { get; set; }
    
    /// <summary>
    /// Массив типов покемона
    /// </summary>
    public PokemonTypes[]? Types { get; set; }
    
    /// <summary>
    /// Массив мувов покемона
    /// </summary>
    public PokemonMoves[]? Moves { get; set; }
    
    /// <summary>
    /// Массив со статами покемона
    /// </summary>
    public PokemonStats[]? Stats { get; set; }
}