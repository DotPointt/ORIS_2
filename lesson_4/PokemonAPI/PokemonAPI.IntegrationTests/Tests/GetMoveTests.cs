namespace PokemonAPI.IntegrationTests.Tests;

[TestClass]
public class GetMoveTests
{
    [TestMethod, Priority(2)]
    [DataRow("1")]
    [DataRow("40")]
    [DataRow("cut")]
    [DataRow("vice-grip")]
    [DataRow("guillotine")]
    [DataRow("bite")]
    public async Task TestGetMove(string param)
    {   
        // Arrange
        using HttpClient httpClient = new HttpClient();
        HttpResponseMessage expectedPokemonRequest = await httpClient.GetAsync($"https://pokeapi.co/api/v2/move/{param}");
        string expectedPokemonResponse = expectedPokemonRequest.Content.ReadAsStringAsync().Result;
        Move? expectedPokemon = _serializer.DeserializeObject<Move>(expectedPokemonResponse);
        
        // Act
        HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7046/pokemonApi/move/{param}");

        string pokemonResponse = await response.Content.ReadAsStringAsync();
        Move? pokemon = _serializer.DeserializeObject<Move>(pokemonResponse);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsTrue(!String.IsNullOrEmpty(pokemonResponse));
        Assert.AreEqual(expectedPokemon?.Name, pokemon?.Name);
        Assert.AreEqual(expectedPokemon?.Type?.Name, pokemon?.Type?.Name);
        Assert.AreEqual(expectedPokemon?.Type?.Url, pokemon?.Type?.Url);
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
    public async Task TestGetMoveByWrongNameOrId(string param)
    {   
        // Arrange
        using HttpClient httpClient = new HttpClient();
        
        // Act
        HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7046/pokemonApi/move/{param}");

        // Assert
        Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
    }
}