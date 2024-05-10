namespace PokemonAPI.IntegrationTests.Tests;

[TestClass]
public class FilterTests
{
    [TestMethod, Priority(2)]
    [DataRow("bulbasaur")]
    public async Task TestBulbasaurFilter(string filter)
    {   
        // Arrange
        using HttpClient httpClient = new HttpClient();
        
        var expectedPokemon = new Poke
        {
            Name = "bulbasaur",
            Url = "https://pokeapi.co/api/v2/pokemon/1/"
        };

        // Act
        HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7046/pokemonApi/filter/{filter}");

        string pokemonResponse = await response.Content.ReadAsStringAsync();
        Poke[]? poke = _serializer.DeserializeObject<Poke[]>(pokemonResponse);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsTrue(!String.IsNullOrEmpty(pokemonResponse));
        Assert.AreEqual(expectedPokemon.Name, poke?[0].Name);
        Assert.AreEqual(expectedPokemon.Url, poke?[0].Url);
    }
    
    [TestMethod, Priority(2)]
    [DataRow("skjgkdfkh")]
    [DataRow("136743")]
    [DataRow("pokemon")]
    [DataRow("sgk1-4335")]
    [DataRow("0.0")]
    [DataRow("покемон")]
    [DataRow(".net")]
    public async Task TestWrongFilter(string filter)
    {   
        // Arrange
        using HttpClient httpClient = new HttpClient();
        
        // Act
        HttpResponseMessage response = await httpClient!.GetAsync($"https://localhost:7046/pokemonApi/filter/{filter}");
        string pokemonResponse = await response.Content.ReadAsStringAsync();
        Poke[]? poke = _serializer.DeserializeObject<Poke[]>(pokemonResponse);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.AreEqual(poke!.Length, 0);
    }
    
    [TestMethod, Priority(2)]
    [DataRow("")]
    [DataRow(null)]
    public async Task TestEmptyFilter(string filter)
    {   
        // Arrange 
        using HttpClient httpClient = new HttpClient();
        
        // Act
        HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7046/pokemonApi/filter/{filter}");
        
        // Assert
        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    [TestMethod, Priority(2)]
    [DataRow("saur")]
    public async Task TestSaurFilter(string filter)
    {   
        // Arrange
        using HttpClient httpClient = new HttpClient();
        
        var expectedPokemonList = new []
        {
            new Poke
            {
                Name = "bulbasaur",
                Url = "https://pokeapi.co/api/v2/pokemon/1/"
            },
            new Poke
            {
                Name = "ivysaur",
                Url = "https://pokeapi.co/api/v2/pokemon/2/"
            },
            new Poke
            {
                Name = "venusaur",
                Url = "https://pokeapi.co/api/v2/pokemon/3/"
            },
            new Poke
            {
                Name = "venusaur-mega",
                Url = "https://pokeapi.co/api/v2/pokemon/10033/"
            },
            new Poke
            {
                Name = "venusaur-gmax",
                Url = "https://pokeapi.co/api/v2/pokemon/10195/"
            }
        };

        // Act
        HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7046/pokemonApi/filter/{filter}");
        string pokemonResponse = await response.Content.ReadAsStringAsync();
        Poke[]? poke = _serializer.DeserializeObject<Poke[]>(pokemonResponse);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.IsTrue(!String.IsNullOrEmpty(pokemonResponse));
        
        Assert.AreEqual(expectedPokemonList[0].Name, poke?[0].Name);
        Assert.AreEqual(expectedPokemonList[0].Url, poke?[0].Url);
        
        Assert.AreEqual(expectedPokemonList[1].Name, poke?[1].Name);
        Assert.AreEqual(expectedPokemonList[1].Url, poke?[1].Url);
        
        Assert.AreEqual(expectedPokemonList[2].Name, poke?[2].Name);
        Assert.AreEqual(expectedPokemonList[2].Url, poke?[2].Url);
        
        Assert.AreEqual(expectedPokemonList[3].Name, poke?[3].Name);
        Assert.AreEqual(expectedPokemonList[3].Url, poke?[3].Url);
    }
}