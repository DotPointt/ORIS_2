using System.Diagnostics;

namespace PokemonAPI.IntegrationTests.Tests;

[TestClass]
public class PerformanceTests
{
    [TestMethod, Priority(1)]
    [DataRow("saur")]
    [DataRow("bulbasaur")]
    [DataRow("pikachu")]
    [DataRow("crow")]
    [DataRow("squirtle")]
    public async Task FilterPerformanceTests(string filter)
    {
        // Arrange
        using HttpClient httpClient = new HttpClient();
        Stopwatch stopwatch = new Stopwatch();
        
        // Act
        stopwatch.Start();
        await httpClient.GetAsync($"https://localhost:7046/pokemonApi/filter/{filter}");
        stopwatch.Stop();
        
        long firstMilliseconds = stopwatch.ElapsedMilliseconds;
        long firstTicks = stopwatch.ElapsedTicks;
        stopwatch.Reset();
        
        stopwatch.Start();
        await httpClient.GetAsync($"https://localhost:7046/pokemonApi/filter/{filter}");
        stopwatch.Stop();
        
        long secondMilliseconds = stopwatch.ElapsedMilliseconds;
        long secondTicks = stopwatch.ElapsedTicks;
        
        // Assert
        Console.WriteLine("Milliseconds: \n" + "Without caching: " + firstMilliseconds + ", With caching: " + secondMilliseconds);
        Console.WriteLine("CPU Ticks: \n" + "Without caching: " + firstTicks + ", With caching: " + secondTicks);
        Assert.IsTrue(firstMilliseconds > secondMilliseconds && firstTicks > secondTicks);
    }
    
    [TestMethod, Priority(1)]
    [DataRow("1")]
    [DataRow("400")]
    [DataRow("bulbasaur")]
    [DataRow("pikachu")]
    [DataRow("tornadus-incarnate")]
    public async Task GetPokemonPerformanceTests(string param)
    {   
        // Arrange
        using HttpClient httpClient = new HttpClient();
        Stopwatch stopwatch = new Stopwatch();
        
        // Act
        stopwatch.Start();
        await httpClient.GetAsync($"https://localhost:7046/pokemonApi/pokemon/{param}");
        stopwatch.Stop();
        
        long firstMilliseconds = stopwatch.ElapsedMilliseconds;
        long firstTicks = stopwatch.ElapsedTicks;
        stopwatch.Reset();
        
        stopwatch.Start();
        await httpClient.GetAsync($"https://localhost:7046/pokemonApi/pokemon/{param}");
        stopwatch.Stop();
        
        long secondMilliseconds = stopwatch.ElapsedMilliseconds;
        long secondTicks = stopwatch.ElapsedTicks;
        
        // Assert
        Console.WriteLine("Milliseconds: \n" + "Without caching: " + firstMilliseconds + ", With caching: " + secondMilliseconds);
        Console.WriteLine("CPU Ticks: \n" + "Without caching: " + firstTicks + ", With caching: " + secondTicks);
        Assert.IsTrue(firstMilliseconds > secondMilliseconds && firstTicks > secondTicks);
    }
    
    [TestMethod, Priority(2)]
    [DataRow("1")]
    [DataRow("40")]
    [DataRow("100")]
    [DataRow("vice-grip")]
    [DataRow("guillotine")]
    public async Task GetMovePerformanceTests(string param)
    {   
        // Arrange
        using HttpClient httpClient = new HttpClient();
        Stopwatch stopwatch = new Stopwatch();
        
        // Act
        stopwatch.Start();
        await httpClient.GetAsync($"https://localhost:7046/pokemonApi/move/{param}");
        stopwatch.Stop();
        
        long firstMilliseconds = stopwatch.ElapsedMilliseconds;
        long firstTicks = stopwatch.ElapsedTicks;
        stopwatch.Reset();
        
        stopwatch.Start();
        await httpClient.GetAsync($"https://localhost:7046/pokemonApi/move/{param}");
        stopwatch.Stop();
        
        long secondMilliseconds = stopwatch.ElapsedMilliseconds;
        long secondTicks = stopwatch.ElapsedTicks;
        
        // Assert
        Console.WriteLine("Milliseconds: \n" + "Without caching: " + firstMilliseconds + ", With caching: " + secondMilliseconds);
        Console.WriteLine("CPU Ticks: \n" + "Without caching: " + firstTicks + ", With caching: " + secondTicks);
        Assert.IsTrue(firstMilliseconds > secondMilliseconds && firstTicks > secondTicks);
    }
    
    [TestMethod, Priority(1)]
    [DataRow(0, 1302)]
    [DataRow(50, 120)]
    [DataRow(120, 121)]
    [DataRow(1302, 1302)]
    [DataRow(500, 120)]
    public async Task PaginationPerformanceTests(int offset, int limit)
    {   
        // Arrange
        using HttpClient httpClient = new HttpClient();
        Stopwatch stopwatch = new Stopwatch();
        
        // Act
        stopwatch.Start();
        await httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon?offset={offset}&limit={limit}");
        stopwatch.Stop();
        
        long firstMilliseconds = stopwatch.ElapsedMilliseconds;
        long firstTicks = stopwatch.ElapsedTicks;
        stopwatch.Reset();
        
        stopwatch.Start();
        await httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon?offset={offset}&limit={limit}");
        stopwatch.Stop();
        
        long secondMilliseconds = stopwatch.ElapsedMilliseconds;
        long secondTicks = stopwatch.ElapsedTicks;
        
        // Assert
        Console.WriteLine("Milliseconds: \n" + "Without caching: " + firstMilliseconds + ", With caching: " + secondMilliseconds);
        Console.WriteLine("CPU Ticks: \n" + "Without caching: " + firstTicks + ", With caching: " + secondTicks);
        Assert.IsTrue(firstMilliseconds > secondMilliseconds && firstTicks > secondTicks);
    }
}