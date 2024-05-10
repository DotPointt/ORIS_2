using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using PokemonAPI.Models;
using PokemonAPI.Services;
using _serializer = Newtonsoft.Json.JsonConvert;
namespace PokemonAPI.Controllers
{
    [Route("pokemonApi/")]
    [ApiController]
    public class PokemonController(IDistributedCache distributedCache) : ControllerBase
    {
        private readonly PokeApiService? _pokeApiService = new (distributedCache);
        
        /// <summary>
        /// Получение списка покемонов по фильтру
        /// </summary>
        /// <param name="filter">Параметр для фильтрации</param>
        /// <returns>Возвращает массив покемонов по фильтру</returns>
        [HttpGet("filter/{filter}")]
        public Poke[]? GetPokemonByFilter(string filter)
        {
            try
            {
                string pokemonResponse = _pokeApiService!.GetPokemonList(0, 1302).Result;
                if (!String.IsNullOrEmpty(pokemonResponse))
                {
                    List<Poke> filteredPokemonList = new List<Poke>();
                    PokemonResponse? response = _serializer.DeserializeObject<PokemonResponse>(pokemonResponse);

                    foreach (var pokemon in response!.Results)
                    {
                        if (pokemon.Name.Contains(filter))
                            filteredPokemonList.Add(pokemon);
                    }
                    
                    return filteredPokemonList.ToArray();
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Status Code 500: Internal server error: " + ex.Message);
                Console.ResetColor();
                return null;
            }
        }

        /// <summary>
        /// Получение покемона по ID либо Name
        /// </summary>
        /// <param name="param">ID либо Name покемона</param>
        /// <returns>Возвращает одного покемона по ID/Name</returns>
        [HttpGet("pokemon/{param}")]
        public Pokemon? GetPokemonByNameOrId(string param)
        {
            try
            {
                string pokemonResponse = _pokeApiService!.GetByNameOrId(param).Result;
                if (!String.IsNullOrEmpty(pokemonResponse))
                {
                    Pokemon? response = _serializer.DeserializeObject<Pokemon>(pokemonResponse);
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Status Code 500: Internal server error: " + ex.Message);
                Console.ResetColor();
                return null;
            }
        }
        
        /// <summary>
        /// Получение списка всех покемонов
        /// </summary>
        /// <returns>Возвращает список всех покемонов</returns>
        [HttpGet("pokemon")]
        public PokemonResponse? GetAllPokemonList()
        {
            try
            {
                string pokemonResponse = _pokeApiService!.GetPokemonList(0, 1302).Result;
                if (!String.IsNullOrEmpty(pokemonResponse))
                {
                    PokemonResponse? response = _serializer.DeserializeObject<PokemonResponse>(pokemonResponse);
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Status Code 500: Internal server error: " + ex.Message);
                Console.ResetColor();
                return null;
            }
        }
        
        /// <summary>
        /// Получение мува покемона по ID либо Name
        /// </summary>
        /// <param name="param">ID либо Name мува</param>
        /// <returns>Возвращает мув покемона</returns>
        [HttpGet("move/{param}")]
        public Move? GetMove(string param)
        {
            try
            {
                string moveResponse = _pokeApiService!.GetMove(param).Result;
                if (!String.IsNullOrEmpty(moveResponse))
                {
                    Move? response = _serializer.DeserializeObject<Move>(moveResponse);
                    response!.Url = $"https://pokeapi.co/api/v2/move/{param}";
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Status Code 500: Internal server error: " + ex.Message);
                Console.ResetColor();
                return null;
            }
        }
        
        /// <summary>
        /// Пагинация
        /// </summary>
        /// <param name="offset">ID покемона, с которого нужно вернуть массив покемнов</param>
        /// <param name="limit">Количество покемонов, которое необходимо получить</param>
        /// <returns>Возвращает необходимый массив покемонов</returns>
        [HttpGet("pokemon/offset={offset}&limit={limit}")]
        public PokemonResponse? GetPokemonListByLimit(int offset, int limit)
        {
            try
            {
                string pokemonResponse = _pokeApiService!.GetPokemonList(offset, limit).Result;
                if (!String.IsNullOrEmpty(pokemonResponse))
                {
                    PokemonResponse? response = _serializer.DeserializeObject<PokemonResponse>(pokemonResponse);
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Status Code 500: Internal server error: " + ex.Message);
                Console.ResetColor();
                return null;
            }
        }
    }
}
