namespace PokemonAPI.IntegrationTests.Tests;

[TestClass]
public class PaginationTests
{
    [TestMethod, Priority(2)]
    [DataRow(0, 1302)]
    [DataRow(50, 120)]
    [DataRow(120, 121)]
    [DataRow(1302, 1302)]
    [DataRow(1302, 0)]
    [DataRow(500, 120)]
    [DataRow(0, 0)]
    [DataRow(130, -1)]
    public async Task TestCorrectPagination(int offset, int limit)
    {   
        // Arrange
        using HttpClient httpClient = new HttpClient();
        
        HttpResponseMessage expectedPokemonRequest = await httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon?offset={offset}&limit={limit}");
        string expectedPokemonResponse = expectedPokemonRequest.Content.ReadAsStringAsync().Result;
        PokemonResponse? expectedPokemonList = _serializer.DeserializeObject<PokemonResponse>(expectedPokemonResponse);
        
        // Act
        HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7046/pokemonApi/pokemon/offset={offset}&limit={limit}");

        string pokemonResponse = await response.Content.ReadAsStringAsync();
        PokemonResponse? pokemon = _serializer.DeserializeObject<PokemonResponse>(pokemonResponse);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsTrue(!String.IsNullOrEmpty(pokemonResponse));
        Assert.AreEqual(expectedPokemonList!.Count, pokemon?.Count);
    }
    
    [TestMethod, Priority(2)]
    [DataRow("", "")]
    [DataRow(" ", " ")]
    public async Task TestWrongPagination(string offset, string limit)
    {   
        // Arrange
        using HttpClient httpClient = new HttpClient();
        
        // Act
        HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7046/pokemonApi/pokemon/offset={offset}&limit={limit}");

        // Assert
        Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
    }
}