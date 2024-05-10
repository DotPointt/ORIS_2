using Microsoft.EntityFrameworkCore;
using PokemonAPI.DataAccess.Entities;

namespace PokemonAPI.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }
        
        public DbSet<PokemonAbilities> PokemonAbilities { get; set; }
        
        public DbSet<PokemonMoves> PokemonMoves { get; set; }
        
        public DbSet<PokemonResponse> PokemonResponses { get; set; }
        
        public DbSet<PokemonStats> PokemonStats { get; set; }
        
        public DbSet<PokemonTypes> PokemonTypes { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}