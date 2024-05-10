namespace PokemonAPI.IntegrationTests.Tests;

[TestClass]
public class GetByIdOrNameTests
{
    [TestMethod, Priority(2)]
    [DataRow("1")]
    [DataRow("400")]
    [DataRow("bulbasaur")]
    [DataRow("pikachu")]
    [DataRow("tornadus-incarnate")]
    public async Task TestGetPokemon(string param)
    {   
        // Arrange
        using HttpClient httpClient = new HttpClient();
        HttpResponseMessage expectedPokemonRequest = await httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{param}");
        string expectedPokemonResponse = expectedPokemonRequest.Content.ReadAsStringAsync().Result;
        Pokemon? expectedPokemon = _serializer.DeserializeObject<Pokemon>(expectedPokemonResponse);
        
        // Act
        HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7046/pokemonApi/pokemon/{param}");

        string pokemonResponse = await response.Content.ReadAsStringAsync();
        Pokemon? pokemon = _serializer.DeserializeObject<Pokemon>(pokemonResponse);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsTrue(!String.IsNullOrEmpty(pokemonResponse));
        Assert.AreEqual(expectedPokemon?.Name, pokemon?.Name);
        Assert.AreEqual(expectedPokemon?.Id, pokemon?.Id);
    }
    
    [TestMethod, Priority(2)]
    [DataRow("0")]
    [DataRow("1400")]
    [DataRow("pokemon")]
    [DataRow(".net")]
    [DataRow("-100")]
    [DataRow("Bulbasaur")]
    [DataRow("sgk1-4335")]
    [DataRow("0.0")]
    [DataRow("покемон")]
    public async Task TestGetPokemonByWrongNameOrId(string param)
    {   
        // Arrange
        using HttpClient httpClient = new HttpClient();
        
        // Act
        HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7046/pokemonApi/pokemon/{param}");

        // Assert
        Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
    }
}